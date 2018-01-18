using System.Collections.Generic;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Services
{
    public interface IFragmentService
    {
        Fragment GetFragment(int id);
        bool SaveFragment(int id, byte[] content);
        IList<Fragment> GetSomeFragments();
    }
}