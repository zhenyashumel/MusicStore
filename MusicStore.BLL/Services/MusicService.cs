using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.Services
{
    public class MusicService : IMusicService
    {
        

        private IUnitOfWork db;
       

        private ICRUDService<SongDTO> _songService;
        private ICRUDService<AuthorDTO> _authorService;
        private ICRUDService<AlbumDTO> _albumService;
        private ICRUDService<OrderDTO> _orderService;

       
        public MusicService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public ICRUDService<SongDTO> SongService
        {
            get
            {
                if (_songService == null)
                    _songService = new SongService(db);
                return _songService;
            }
        }
        
        public ICRUDService<AuthorDTO> AuthorService
        {
            get
            {
                if (_authorService == null)
                    _authorService = new AuthorService(db);
                return _authorService;
            }
        }

        public ICRUDService<OrderDTO> OrderService
        {
            get
            {
                if (_orderService == null)
                    _orderService = new OrderService(db);
                return _orderService;
            }
        }

        public ICRUDService<AlbumDTO> AlbumService
        {
            get
            {
                if (_albumService == null)
                    _albumService = new AlbumService(db);
                return _albumService;
            }
        }
    }
}
