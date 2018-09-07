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
        private ICRUDService<AuthorDTO> _authorervice;
        private ICRUDService<AlbumDTO> _albumService;
        private ICRUDService<OrderDTO> _orderService;
        public MusicService(IUnitOfWork uof)
        {
            db = uof;
        }

        public ICRUDService<SongDTO> SongService => throw new NotImplementedException();

        public ICRUDService<AuthorDTO> AuthorService => throw new NotImplementedException();

        public ICRUDService<AlbumDTO> AlbumService => throw new NotImplementedException();

        public ICRUDService<OrderDTO> OrderService => throw new NotImplementedException();
    }
}
