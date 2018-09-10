using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;

namespace MusicStore.BLL.Services
{
    class SongService: ICRUDService<SongDTO>
    {
        private IUnitOfWork db;
        private IMapper _songToDtoMapper;
        private IMapper _dtoToSongMapper;
        public SongService(IUnitOfWork uof)
        {
            
            db = uof;
           
            _dtoToSongMapper = new MapperConfiguration(cfg => cfg.CreateMap<SongDTO, Song>()).CreateMapper();
          
            _songToDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Song, SongDTO>()).CreateMapper();
        }
        public void Create(SongDTO item)
        {
            db.Songs.Create(_dtoToSongMapper.Map<SongDTO, Song>(item));
        }

        public void Delete(int id)
        {
            db.Songs.Delete(id);
        }

        public SongDTO Get(int id)
        {
            return _songToDtoMapper.Map<Song, SongDTO>(db.Songs.Get(id));
        }

        public IEnumerable<SongDTO> GetAll()
        {
           return _songToDtoMapper.Map<IEnumerable<Song>, IEnumerable<SongDTO>>(db.Songs.GetAll());
        }

        public void Update(SongDTO item)
        {
            db.Songs.Update(_dtoToSongMapper.Map<SongDTO, Song>(item));
        }
    }
}
