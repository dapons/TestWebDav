using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamMil.WebDAV.Server;

namespace TestWebAppDomain.Services.WebDav
{
    public class SqlService : WebDAVService
    {
        public override IWebDAVResource ResolveResource(WebDAVContext context, string resourcePath)
        {
            throw new NotImplementedException();
        }
    }
}
