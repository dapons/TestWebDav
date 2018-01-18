using System;
using System.Collections.Generic;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Repositories
{
    public interface IFragLockRepository : IDisposable
    {
        FragLock CreateLockForFragment(int fragmentId, int branchId, int userId);
        bool DeleteLockForFragment(int fragmentId, int branchId, int userId);
        FragLock GetLock(int id);
        IList<FragLock> GetLocksForFragment(int fragmentId, int branchId);
        IList<FragLock> GetLocksForFragment(int fragmentId, int branchId, int userId);
    }
}