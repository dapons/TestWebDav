using AdamMil.WebDAV.Server;
using AutoMapper;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Infrastructure
{
    internal static class MapConfiguration
    {
        public static void AddMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<FragLock, ActiveLock>()
                    .ForMember(al => al.Path, x => x.MapFrom(fl => fl.Id.ToString()))
                    .ForMember(al => al.CreationTime, x => x.MapFrom(fl => fl.LockDate))
                    .ForMember(al => al.ExpirationTime, x => x.Ignore())
                    .ForMember(al => al.OwnerId, x => x.MapFrom(fl => fl.LockUserId))
                    .ForMember(al => al.Recursive, x => x.UseValue(true))
                    .ForMember(al => al.Timeout, x => x.UseValue(0))
                    .ForMember(al => al.Token, x => x.MapFrom(fl => fl.Id.ToString()))
                    .ForMember(al => al.Type, x => x.UseValue(LockType.ExclusiveWrite));
            });
        }
    }
}