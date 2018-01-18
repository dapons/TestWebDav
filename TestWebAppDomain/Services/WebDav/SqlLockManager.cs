using System;
using System.Collections.Generic;
using System.Xml;
using AdamMil.WebDAV.Server;
using AdamMil.WebDAV.Server.Configuration;
using AutoMapper;
using TestWebAppDomain.Crosscutting;
using TestWebAppDomain.DAL;
using TestWebAppDomain.Extensions;
using TestWebAppDomain.Repositories;

namespace TestWebAppDomain.Services.WebDav
{
    public class SqlLockManager : IDisposable, ILockManager
    {
        private readonly IFragLockRepository _lockRepository;

        public SqlLockManager(string locationId, ParameterCollection parameters)
        {
            var db = new DocDesignerEntities();
            _lockRepository = new FragLockRepository(db);
        }


        public void Dispose()
        {
            this._lockRepository?.Dispose();
        }

        public ActiveLock AddLock(string canonicalPath, LockType type, LockSelection selection, 
                                  uint? timeoutSeconds, string ownerId, XmlElement ownerData, XmlElement serverData)
        {

            var id = canonicalPath.ConvertToInt();
            if (id == null)
            {
                return null;
            }

            var fragment = this._lockRepository.CreateLockForFragment(id.Value, MyContext.BranchId, MyContext.UserId);
            if (fragment == null)
            {
                return null;
            }

            var activeLock = Mapper.Map<ActiveLock>(fragment);
            return activeLock;
        }

        public IList<ActiveLock> GetConflictingLocks(string canonicalPath, LockType type, LockSelection selection, string ownerId)
        {
            return this.GetLocks(canonicalPath, selection, null);
        }

        public ActiveLock GetLock(string lockToken, string canonicalPath)
        {
            var id = canonicalPath.ConvertToInt();
            if (id == null)
            {
                return null;
            }

            var fragment = this._lockRepository.GetLock(id.Value);
            if (fragment == null)
            {
                return null;
            }

            var activeLock = Mapper.Map<ActiveLock>(fragment);
            return activeLock;
        }

        public IList<ActiveLock> GetLocks(string canonicalPath, LockSelection selection, Predicate<ActiveLock> filter)
        {
            var activeLock = this.GetLock(string.Empty, canonicalPath);
            if (activeLock == null)
            {
                return null;
            }

            return new List<ActiveLock> { activeLock };
        }

        public bool RefreshLock(ActiveLock activeLock, uint? timeoutSeconds)
        {
            var id = activeLock?.Path.ConvertToInt();
            if (id == null)
            {
                return false;
            }

            var fragment = this._lockRepository.CreateLockForFragment(id.Value, MyContext.BranchId, MyContext.UserId);
            return fragment != null;
        }

        public bool RemoveLock(ActiveLock activeLock)
        {
            if (activeLock == null)
            {
                return false;
            }
            return this.RemoveLocks(activeLock.Path, LockRemoval.Nonrecursive);
        }

        public bool RemoveLocks(string canonicalPath, LockRemoval removal)
        {
            var id = canonicalPath.ConvertToInt();
            if (id == null)
            {
                return false;
            }

            return this._lockRepository.DeleteLockForFragment(id.Value, MyContext.BranchId, MyContext.UserId);
        }
    }

}
