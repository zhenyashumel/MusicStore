using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.Web.Models.Album;
using MusicStore.Web.Models.Song;

namespace MusicStore.Web.Controllers
{
    public class SongsController : Controller
    {
        IMusicService _service;
        IMapper _dtoToIndexVm;
        IMapper _indexVmToDTO;

        public SongsController(IMusicService service)
        {
            _service = service;
            _dtoToIndexVm = new MapperConfiguration(cfg => cfg.CreateMap<SongDTO, SongIndexViewModel>()).CreateMapper();
            _indexVmToDTO = new MapperConfiguration(cfg => cfg.CreateMap<SongIndexViewModel, SongDTO>()).CreateMapper();
        }


        // GET: Songs
        public ActionResult Index()
        {
            var songs =
                _dtoToIndexVm.Map<IEnumerable<SongDTO>, IEnumerable<SongIndexViewModel>>(_service.SongService.GetAll());
            return View(songs);
        }

        // GET: Songs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
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

        // GET: Songs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Songs/Edit/5
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

        // GET: Songs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Songs/Delete/5
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
