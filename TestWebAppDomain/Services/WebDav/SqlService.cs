using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamMil.WebDAV.Server;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Services.WebDav
{
    public class SqlService : WebDAVService
    {
        private readonly FragmentService _fragmentService;

        public SqlService()
        {
            var db = new DocDesignerEntities();
            this._fragmentService = new FragmentService(db);
        }

        public override IWebDAVResource ResolveResource(WebDAVContext context, string resourcePath)
        {
            if (string.IsNullOrWhiteSpace(resourcePath))
            {
                return null;
            }

            var fileId = Path.GetFileNameWithoutExtension(resourcePath);
            if (!int.TryParse(fileId, out int id))
            {
                return null;
            }

            var fragment = this._fragmentService.GetFragment(id);
            if (fragment == null)
            {
                return null;
            }

            var resource = new SqlEntryResource(fragment);
            return resource;
        }



    }
}
