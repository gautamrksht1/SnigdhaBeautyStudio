using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnigdhaBeautyStudio.Models;
using SnigdhaBeautyStudio.Services;

namespace SnigdhaBeautyStudio.Controllers
{
    public class DisplayBlobContentController : Controller
    {
        private IBlobStorageService _storageService;

        public DisplayBlobContentController(IBlobStorageService storageService)
        {
            _storageService = storageService;
        }

        // GET: DisplayBlobContent
        public async Task<ActionResult> Index()
        {
            BlobContent blob = new BlobContent();
            blob.Content = await this._storageService.ReadBlobContent();
            return View();
        }

        // GET: DisplayBlobContent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisplayBlobContent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayBlobContent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayBlobContent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayBlobContent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayBlobContent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayBlobContent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
