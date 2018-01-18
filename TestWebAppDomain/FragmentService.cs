using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain
{
    public class FragmentService : IFragmentService
    {
        private readonly DocDesignerEntities _db;

        public FragmentService(DocDesignerEntities db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Fragment GetFragment(int id)
        {
            var fragment = this._db.Fragments.FirstOrDefault(x => x.Id == id);
            return fragment;
        }

        public IList<Fragment> GetSomeFragments()
        {
            return  this._db.Fragments
                .Where(x => !x.IsDeleted && x.FragName.EndsWith(".docx"))?
                    .OrderByDescending(x => x.Id)
                        .Take(20)?.ToList();
        }

        public bool SaveFragment(int id, byte[] content)
        {
            var fragment = this.GetFragment(id);
            if (fragment == null) return false;

            fragment.FragContent = content;
            return this._db.SaveChanges() > 0;
        }
    }
}