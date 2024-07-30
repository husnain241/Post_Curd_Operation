using Microsoft.AspNetCore.Mvc;
using Post_Crud.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Post_Crud.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        private readonly PostDBContext postDB;
        public HomeController(PostDBContext postDB)
        {
            this.postDB = postDB;
        }


        public async Task<IActionResult> Index()
        {

            var postData = await postDB.posts.ToListAsync();

            return View(postData);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await postDB.posts.AddAsync(post    );
                await postDB.SaveChangesAsync();
                TempData["create_success"] = "create successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(post);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || postDB.posts == null)
            {
                return NotFound();
            }

            var postData = await postDB.posts.FirstOrDefaultAsync(x => x.Post_Id == id);
            if (postData == null)
            {

                return NotFound();

            }
            return View(postData);
        }



        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || postDB.posts == null)
            {
                return NotFound();
            }

            var stdData = await postDB.posts.FindAsync(id);

            if (stdData == null)
            {

                return NotFound();

            }

            return View(stdData);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Post post)
        {

            if (id != post.Post_Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                postDB.Update(post);
                await postDB.SaveChangesAsync();
                TempData["update_success"] = "update successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(post);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || postDB.posts == null)
            {
                return NotFound();
            }

            var stdData = await postDB.posts.FirstOrDefaultAsync(x => x.Post_Id == id);
            if (stdData == null)
            {

                return NotFound();

            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await postDB.posts.FindAsync(id);
            if (stdData != null)
            {
                postDB.posts.Remove(stdData);

            }
            await postDB.SaveChangesAsync();
            TempData["delete_success"] = "delete successfully";
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
