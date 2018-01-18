using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppDomain;
using TestWebAppDomain.DAL;
using Fragment = TestWebApp.Models.Fragment;
using AutoMapper;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FragmentService _fragmentService;
        private const string WebDavBaseUrl = @"http://lpa-h-nb-228:63165/webdav/";            // Other project IIS Server


        public HomeController()
        {
            var db = new DocDesignerEntities();
            this._fragmentService = new FragmentService(db);
        }

        public ActionResult Index()
        {
            var fragments = this._fragmentService.GetSomeFragments();
            var responseFragments = fragments.Select(this.CreateResponseFragment).ToList();
            return View(responseFragments);
        }

        private Fragment CreateResponseFragment(TestWebAppDomain.DAL.Fragment fragment)
        {
            if (string.IsNullOrWhiteSpace(fragment?.FragName))
            {
                return null;
            }

            var outputFragment = Mapper.Map<Fragment>(fragment);
            outputFragment.DefaultUrl = HttpUtility.UrlDecode($"{WebDavBaseUrl}{outputFragment.Name}");
            outputFragment.OpenUrl = HttpUtility.UrlDecode($"ms-word:ofv|u|{WebDavBaseUrl}{outputFragment.Name}");
            outputFragment.EditUrl = HttpUtility.UrlDecode($"ms-word:ofe|u|{WebDavBaseUrl}{outputFragment.Name}");

            return outputFragment;
        }

    }
}