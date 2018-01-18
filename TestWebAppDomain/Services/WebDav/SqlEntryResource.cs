using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AdamMil.Web;
using AdamMil.WebDAV.Server;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Services.WebDav
{
    public class SqlEntryResource : WebDAVResource, IStandardResource<SqlEntryResource>
    {

        public override string CanonicalPath => this.Fragment.Id.ToString();
        public bool IsCollection => false;
        public Fragment Fragment { get; private set; }


        public SqlEntryResource(Fragment fragment)
        {
            this.Fragment = fragment;
        }

        public IEnumerable<SqlEntryResource> GetChildren(WebDAVContext context)
        {
            return null;
        }


        public override void CopyOrMove(CopyOrMoveRequest request)
        {
            request.Status = new ConditionCode(HttpStatusCode.MethodNotAllowed);
            request.ProcessStandardRequest(this);
        }

     
        public override void GetOrHead(GetOrHeadRequest request)
        {
            if (request == null) throw new ArgumentNullException();
            request.WriteStandardResponse(this);
        }

        public override void PropFind(PropFindRequest request)
        {
            if (request == null) throw new ArgumentNullException();
            request.ProcessStandardRequest(this);
        }

        //public override void Delete(DeleteRequest request)
        //{
        //    request.Status = this.Delete();
        //    request.ProcessStandardRequest(this);
        //}


        public ConditionCode Delete()
        {
            return ConditionCodes.Forbidden;
        }

        public IDictionary<XmlQualifiedName, object> GetLiveProperties(WebDAVContext context)
        {
            var properties = new Dictionary<XmlQualifiedName, object>();
            var metadata = GetEntityMetadata(true);

            properties[DAVNames.resourcetype] = null;
            properties[DAVNames.getcontentlength] = metadata.Length;
            properties[DAVNames.getetag] = metadata.EntityTag;
            properties[DAVNames.getlastmodified] = metadata.LastModifiedTime;
            properties[DAVNames.displayname] = this.Fragment.FragName;
            properties[DAVNames.supportedlock] = null; // Lock is not supported, it's DB based

            if (!string.IsNullOrWhiteSpace(metadata.MediaType))
            {
                properties[DAVNames.getcontenttype] = metadata.MediaType;
            }
            
            return properties;

            // XML
            //var properties = new Dictionary<XmlQualifiedName, object>();
            //properties[DAVNames.resourcetype] = IsCollection ? ResourceType.Collection : null;
            //if (!IsCollection)
            //{
            //    EntityMetadata metadata = GetEntityMetadata(true);
            //    properties[DAVNames.getcontentlength] = metadata.Length;
            //    properties[DAVNames.getetag] = metadata.EntityTag;
            //    if (metadata.MediaType != null) properties[DAVNames.getcontenttype] = metadata.MediaType;
            //}
            //if (xmlProps != null)
            //{
            //    foreach (XmlElement xmlProp in xmlProps.ChildNodes) properties[xmlProp.GetQualifiedName()] = xmlProp;
            //}
            //return properties;

            //********************************************************************************************//
            //********************************************************************************************//


            // ZipFile
            //Dictionary<XmlQualifiedName, object> properties = new Dictionary<XmlQualifiedName, object>();
            //properties[DAVNames.resourcetype] = IsCollection ? ResourceType.Collection : null; // null indicates a non-collection resource

            //// add file-related properties if this is a file
            //if (!IsCollection)
            //{
            //    properties[DAVNames.getcontentlength] = archive.GetEntryLength(entry);
            //    properties[DAVNames.getlastmodified] = entry.LastWriteTime;

            //    string mediaType = MediaTypes.GuessMediaType(entry.Name);
            //    if (mediaType != null) properties[DAVNames.getcontenttype] = mediaType;

            //    // we don't want to return the DAV:getetag property unless it's necessary, since it's expensive to compute
            //    if (request != null && request.MustIncludeProperty(DAVNames.getetag)) // if we must include it (but not necessarily its value)...
            //    {
            //        // we have to report the property, but depending on the NamesOnly property we may be able avoid computing its value
            //        properties[DAVNames.getetag] = request.NamesOnly ? null : GetEntityMetadata(true).EntityTag;
            //    }
            //}

            //// if we support locking and we're servicing a PROPFIND request (as opposed to COPY/MOVE, etc.), add lock-related properties
            //if (!archive.IsReadOnly && request != null && request.Context.LockManager != null)
            //{
            //    // here we want to include the lockdiscovery value unless it must not be returned. we'll use the MustExcludePropertyValue function
            //    // to replace the value with null whenever it's not needed
            //    properties[DAVNames.lockdiscovery] = request.MustExcludePropertyValue(DAVNames.lockdiscovery) ?
            //        null : request.Context.LockManager.GetLocks(CanonicalPath, LockSelection.SelfAndRecursiveAncestors, null);
            //    properties[DAVNames.supportedlock] = LockType.WriteLocks;
            //}

            //return properties;

            //********************************************************************************************//
            //********************************************************************************************//

        }


        public override EntityMetadata GetEntityMetadata(bool includeEntityTag)
        {
            var metadata = new EntityMetadata();
            var stream = this.OpenStream(null);

            metadata.Length = stream.Length;
            metadata.MediaType = MediaTypes.GuessMediaType(this.Fragment.FragName);
            metadata.EntityTag = DAVUtility.ComputeEntityTag(stream);
            metadata.LastModifiedTime = DateTime.Now.Subtract(new TimeSpan(0,0,5,0));
            metadata.Exists = !this.Fragment.IsDeleted;
            return metadata;
        }

        public string GetMemberName(WebDAVContext context)
        {
            return this.Fragment.FragName;
        }

        public Stream OpenStream(WebDAVContext context)
        {
            Stream stream = new MemoryStream(this.Fragment.FragContent);
            return stream;
        }
        
    }
}
