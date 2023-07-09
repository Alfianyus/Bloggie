using Microsoft.AspNetCore.Mvc;
using Bloggie.web.Models.ViewModels;
using Bloggie.web.Data;
using Bloggie.web.Models.Domain;

namespace Bloggie.web.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly BloggieDbContext bloggieDBContext;

        public AdminTagController(BloggieDbContext bloggieDBContext) 
        {
            this.bloggieDBContext = bloggieDBContext;
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
                {
            //Mapping Add tagrequest
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };



            bloggieDBContext.Tags.Add(tag);
            bloggieDBContext.SaveChanges();
           


            return View("Add");

        }
    }
}
