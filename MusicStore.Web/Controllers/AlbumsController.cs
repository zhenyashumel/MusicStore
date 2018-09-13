using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.Web.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private IMusicService _service;
        private IMapper _dtoToIndexVm;
        private IMapper _indexVmToDTO;

        public AlbumsController(IMusicService service)
        {
            _service = service;
            _dtoToIndexVm = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDTO, AlbumIndexViewModel>()).CreateMapper();
            _indexVmToDTO = new MapperConfiguration(cfg => cfg.CreateMap<AlbumIndexViewModel, AlbumDTO>()).CreateMapper();
        }
        // GET: Albums
        public ActionResult Index()
        {
            var albums = _dtoToIndexVm.Map<IEnumerable<AlbumDTO>, IEnumerable<AlbumIndexViewModel>>(_service.AlbumService.GetAll());
            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
