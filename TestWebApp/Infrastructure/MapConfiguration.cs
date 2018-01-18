using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TestWebAppDomain.DAL;

namespace TestWebApp.Infrastructure
{
    internal static class MapConfiguration
    {
        public static void AddMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Fragment, Models.Fragment>()
                    .ForMember(f => f.Name, x => x.MapFrom(y => y.FragAlias))
                    .ForMember(f => f.DefaultUrl, x => x.Ignore())
                    .ForMember(f => f.OpenUrl, x => x.Ignore())
                    .ForMember(f => f.EditUrl, x => x.Ignore())
                    .ForMember(f => f.DeleteUrl, x => x.Ignore());
            });
        }
    }
}