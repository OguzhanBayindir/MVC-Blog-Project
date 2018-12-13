using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Repository;
using Blog.Entity;
using Blog.Common;
using Blog.Entity.Model;
using X.PagedList;
using X.PagedList.Mvc;


namespace Vidzy.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        PostRepository PostRepository = new PostRepository();


        public ActionResult Index(string username,int? Page, string result, string status)
        {
            ViewBag.CurrentUser =username;


            var pageNumber = Page ?? 1;

            var posts = PostRepository.List().ProcessResult.OrderByDescending(x => x.PostDate).ToList();

            var singlePageProducts = posts.ToPagedList(pageNumber, 6);


            ViewBag.result = result;
            ViewBag.status = status;



            return View(singlePageProducts);


        }

        public ActionResult RecentPosts()
            
        {

            IEnumerable<Post> recentPosts = PostRepository.List().ProcessResult.OrderByDescending(x => x.PostDate).Take(4);

            return View(recentPosts);

        }

        public ActionResult PopularPosts()

        {

            IEnumerable<Post> popularPosts = PostRepository.List().ProcessResult.OrderByDescending(x => x.IsRead).Take(5);

            return View(popularPosts);

        }

        public ActionResult SearchPosts(string search)

        {

            var SearchResults =PostRepository.List().ProcessResult.Where(x=> x.Title.Contains(search)).ToList();
            return View(SearchResults.OrderByDescending(x => x.PostDate));

        }

        public ActionResult Contact()

        {


            return View();

        }


    }
}