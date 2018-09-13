using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.Web.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private IMusicService _service;
        private IMapper _dtoToDetailsVm;
        private IMapper _detailsVmToDTO;

        public AuthorsController(IMusicService service)
        {
            _service = service;
            _dtoToDetailsVm = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO,AuthorDetailsViewModel>()).CreateMapper();
            _detailsVmToDTO = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDetailsViewModel, AuthorDTO>()).CreateMapper();
        }
        // GET: Authors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            var author = _dtoToDetailsVm.Map<AuthorDTO, AuthorDetailsViewModel>(_service.AuthorService.Get(id));
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
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

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authors/Edit/5
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

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authors/Delete/5
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
