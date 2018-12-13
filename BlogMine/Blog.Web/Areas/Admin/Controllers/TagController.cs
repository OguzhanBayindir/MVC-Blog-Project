using Blog.Areas.Admin.Models.ResultModel;
using Blog.Entity.Model;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        TagRepository tagRepository = new TagRepository();

        InstanceResults<Tag> result = new InstanceResults<Tag>();
        public ActionResult List(string mesaj)
        {
            result.resultList = tagRepository.List();
            ViewBag.Mesaj = mesaj;
            return View(result.resultList.ProcessResult);
        }

        [HttpGet] //Get ile yapilan istekler tarayicinin adres satirinda gorunur. Sadece belirli boyutlarda veri gonderilecegi zaman kullanilir.
        public ActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTag(Tag model)
        {
            result.resultInt = tagRepository.Insert(model);
            ViewBag.Message = result.resultInt.UserMessage;

            if (result.resultInt.IsSucceeded)
            {
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            result.resultType = tagRepository.GetObjectByID(id);
            return View(result.resultType.ProcessResult);
        }
        [HttpPost]
        public ActionResult Edit(Tag model)
        {
            result.resultInt = tagRepository.Update(model);
            ViewBag.Message = result.resultInt.UserMessage;
            return View();
        }

        public ActionResult Delete(int id)
        {
            result.resultInt = tagRepository.Delete(id);
            return RedirectToAction("List", new { @mesaj = result.resultInt.UserMessage });
        }
    }
}