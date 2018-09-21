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
        IMapper _dtoToDetailsVm;
        public SongsController(IMusicService service)
        {
            _service = service;
            _dtoToIndexVm = new MapperConfiguration(cfg => cfg.CreateMap<SongDTO, SongIndexViewModel>()).CreateMapper();
            _indexVmToDTO = new MapperConfiguration(cfg => cfg.CreateMap<SongIndexViewModel, SongDTO>()).CreateMapper();
            _dtoToDetailsVm = new MapperConfiguration(cfg => cfg.CreateMap<SongDTO, SongDetailsViewModel>()).CreateMapper();
        }


        // GET: Songs
        public ActionResult Index()
        {
            var songs =
                _dtoToIndexVm.Map<IEnumerable<SongDTO>, IEnumerable<SongIndexViewModel>>(_service.SongService.GetAll());
            return View(songs);
        }
        public ActionResult Buy(int id, double price)
        {
            var order = new OrderDTO()
            {
                Date = DateTime.Now,
                UserId = 0,
                Description = "Some Text",
                Songs = new List<SongDTO>() { _service.SongService.Get(id)},
                
            };
            _service.OrderService.Create(order);
            var songs =
                _dtoToIndexVm.Map<IEnumerable<SongDTO>, IEnumerable<SongIndexViewModel>>(_service.SongService.GetAll());
            return View("Index", songs);

        }
        public ActionResult SongList(int id)
        {
            var songs = _dtoToDetailsVm.Map<IEnumerable<SongDTO>, IEnumerable<SongDetailsViewModel>>(_service.AlbumService.Get(id).Songs);
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
