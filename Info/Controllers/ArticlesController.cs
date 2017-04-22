using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Info.Data;
using Info.Models;

namespace Info.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly InfoContext _context;

        public ArticlesController(InfoContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            //include any property
            var articles = await _context.Articles
                .Include(a => a.AppID)
                .Include(u => u.UserID)
                .ToListAsync();
            return View(articles);
        }

        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            var appsDb = _context.Apps
                .Where(it => it.Name.StartsWith(Prefix))
                .AsNoTracking()
                .ToList();
            return Json(appsDb);
        }


        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.AppID)
                .Include(u => u.UserID)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = AppPlatform.Android.ToString(), Value = AppPlatform.Android.ToString() });
            items.Add(new SelectListItem { Text = AppPlatform.Ios.ToString(), Value = AppPlatform.Ios.ToString() });
            items.Add(new SelectListItem { Text = AppPlatform.Windows.ToString(), Value = AppPlatform.Windows.ToString() });
            ViewBag.Category = items;

            var appsDb = _context.Apps
                .AsNoTracking()
                .ToList();

            List<SelectListItem> apps = new List<SelectListItem>();
            foreach (var it in appsDb)
            {
                apps.Add(new SelectListItem { Text = it.Name, Value = it.ID.ToString() });
            }
            ViewBag.AppName = apps;
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModelArticle vArticle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var article = vArticle.GetArticle();
                    var appID = _context.Apps
                        .Where(it =>
                        it.Name == vArticle.AppName &&
                        it.Platform == vArticle.Platform)
                        .SingleOrDefault();
                    if (appID != null) {
                        article.AppID = appID;
                    }
                    else
                    {
                        //todo CreateAppID
                    }
                    _context.Add(article);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(vArticle);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Description,Content,Like")] Article article)
        {
            if (id != article.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ID == id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ID == id);
        }
    }
}
