using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnigdhaBeautyStudio.Models;
using SnigdhaBeautyStudio.Services;
using System.Collections.Concurrent;

namespace SnigdhaBeautyStudio.Controllers
{
    public class DocStoreController : Controller
    {

        private IDocTableService _doctableStoreSvc;
        private IBlobStorageService _blobStorageService;

        public DocStoreController(IDocTableService doctableStoreSvc, IBlobStorageService blobStorageService)
        {
            _doctableStoreSvc = doctableStoreSvc;
            _blobStorageService = blobStorageService;
        }
        // GET: DocStoreController
        public async Task<ActionResult> Index()
        {
            BlobContent blob = new BlobContent();
            blob.Content = await this._blobStorageService.ReadBlobContent();
            ViewBag.Blob = blob.Content;
            var data = await _doctableStoreSvc.GetDocs();
            return View(data);
        }

        // GET: DocStoreController/Details/5
        public async Task<ActionResult> Details(string partitionKey, string id)
        {
            var data = await _doctableStoreSvc.GetDoc(partitionKey, id);

            return View(data);
        }

        // GET: DocStoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocStoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(DocumentStoreEntity entity)
        {
            try
            {
                 await _doctableStoreSvc.UpsetData(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocStoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocStoreController/Edit/5
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

        // GET: DocStoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocStoreController/Delete/5
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
