using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Repositories
{
    public class FragLockRepository : BaseRepository, IFragLockRepository
    {
        public FragLockRepository(DocDesignerEntities dbContext) : base(dbContext)
        {
        }

        public FragLock GetLock(int id)
        {
            return this.DbContext.FragLocks.FirstOrDefault(x => x.Id == id);
        }


        public IList<FragLock> GetLocksForFragment(int fragmentId, int branchId)
        {
            return this.DbContext.FragLocks.Where(x => x.FragId == fragmentId && 
                                                       x.BranchId == branchId)?.ToList();
        }

        public IList<FragLock> GetLocksForFragment(int fragmentId, int branchId, int userId)
        {
            return this.DbContext.FragLocks.Where(x => x.FragId == fragmentId && 
                                                       x.BranchId == branchId &&
                                                       x.LockUserId == userId)?.ToList();
        }

        public FragLock CreateLockForFragment(int fragmentId, int branchId, int userId)
        {
            var locks = GetLocksForFragment(fragmentId, branchId);
            var othersLocks = locks.Any(x => x.LockUserId != userId);
            if (othersLocks)
            {
                return null;    // Other person has a lock on the fragment
            }

            var myLock = locks.FirstOrDefault(x => x.LockUserId == userId);
            if (myLock != null)
            {
                // I already have a lock
                myLock.LockDate = DateTime.UtcNow;
            }
            else
            {
                // New lock
                myLock = new FragLock
                {
                    BranchId = branchId,
                    EditFragId = 1000,
                    FragId = fragmentId,
                    ReadOnly = false,
                    LockDate = DateTime.UtcNow,
                    Version = null
                };
            }

            this.DbContext.FragLocks.AddOrUpdate(myLock);
            this.DbContext.SaveChanges();
            return myLock;
        }

        public bool DeleteLockForFragment(int fragmentId, int branchId, int userId)
        {
            var myLocks = this.GetLocksForFragment(fragmentId, branchId, userId);
            if (myLocks == null || myLocks.Count == 0)
            {
                return true;
            }

            this.DbContext.FragLocks.RemoveRange(myLocks);
            return this.DbContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            this.DbContext?.Dispose();
        }
    }
}
