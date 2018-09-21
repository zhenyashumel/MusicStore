using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.Web.Models.Album;
using MusicStore.Web.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.Models.Song;

namespace MusicStore.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private IMusicService _service;
        private IMapper _dtoToIndexVm;
        private IMapper _indexVmToDTO;
        private IMapper _dtoToDetailsVm;
        private IMapper _authorDtoToAuthorVm;
        private IMapper _songDtoToSongVm;

        public AlbumsController(IMusicService service)
        {
            _service = service;
            _authorDtoToAuthorVm = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorAlbumViewModel>()).CreateMapper();
            _dtoToIndexVm = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDTO, AlbumIndexViewModel>()).CreateMapper();
            _indexVmToDTO = new MapperConfiguration(cfg => cfg.CreateMap<AlbumIndexViewModel, AlbumDTO>().
                ForMember(el => el.Author, opt => opt.MapFrom(c => _service.AuthorService.Get(c.Author.Id)))).CreateMapper();
            _dtoToDetailsVm = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDTO, AlbumDetailsViewModel>()).CreateMapper();
            _songDtoToSongVm = new MapperConfiguration(cfg => cfg.CreateMap<SongDTO, SongDetailsViewModel>()).CreateMapper();


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
            var album = _dtoToDetailsVm.Map<AlbumDTO, AlbumDetailsViewModel>(_service.AlbumService.Get(id));

            return View(album);
        }

        public ActionResult AlbumsList(int id)
        {
            var albums = _dtoToDetailsVm.Map<IEnumerable<AlbumDTO>, IEnumerable<AlbumDetailsViewModel>>(_service.AuthorService.Get(id).Albums);
            return View(albums);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.Authors = _authorDtoToAuthorVm.Map<IEnumerable<AuthorDTO>, IEnumerable<AuthorIndexViewModel>>(_service.AuthorService.GetAll());

            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(AlbumIndexViewModel album)
        {
            album.Author =
                _authorDtoToAuthorVm.Map<AuthorDTO, AuthorAlbumViewModel>(_service.AuthorService.Get(album.AuthorId));


            _service.AlbumService.Create(_indexVmToDTO.Map<AlbumIndexViewModel, AlbumDTO>(album));
            var albums = _dtoToIndexVm.Map<IEnumerable<AlbumDTO>, IEnumerable<AlbumIndexViewModel>>(_service.AlbumService.GetAll());
            return View("Index", albums);

        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {

            var album = _dtoToIndexVm.Map<AlbumDTO, AlbumIndexViewModel>(_service.AlbumService.Get(id));
            ViewBag.Authors = _authorDtoToAuthorVm.Map<IEnumerable<AuthorDTO>, IEnumerable<AuthorIndexViewModel>>(_service.AuthorService.GetAll());
            if (album != null)
                return View(album);
            var albums = _dtoToIndexVm.Map<IEnumerable<AlbumDTO>, IEnumerable<AlbumIndexViewModel>>(_service.AlbumService.GetAll());
            return View("Index", albums);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(AlbumIndexViewModel album)
        {
            album.Author =
                _authorDtoToAuthorVm.Map<AuthorDTO, AuthorAlbumViewModel>(_service.AuthorService.Get(album.AuthorId));
            album.Songs = _songDtoToSongVm.Map<ICollection<SongDTO>, ICollection<SongDetailsViewModel>>(_service.AlbumService.Get(album.Id).Songs);


            _service.AlbumService.Update(_indexVmToDTO.Map<AlbumIndexViewModel, AlbumDTO>(album));

            var albums = _dtoToIndexVm.Map<IEnumerable<AlbumDTO>, IEnumerable<AlbumIndexViewModel>>(_service.AlbumService.GetAll());
            return View("Index", albums);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            _service.AlbumService.Delete(id);

            var albums = _dtoToIndexVm.Map<IEnumerable<AlbumDTO>, IEnumerable<AlbumIndexViewModel>>(_service.AlbumService.GetAll());
            return View("Index", albums);
        }


    }
}
