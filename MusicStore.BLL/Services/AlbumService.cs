using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicStore.BLL.Services
{
    public class AlbumService : ICRUDService<AlbumDTO>
    {
        private IUnitOfWork db;
        private IMapper _albumToDtoMapper;
        private IMapper _dtoToAlbumMapper;

        public AlbumService(IUnitOfWork uow)
        {
            db = uow;
            _albumToDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Album, AlbumDTO>()).CreateMapper();
            _dtoToAlbumMapper = new MapperConfiguration(cfg => cfg.CreateMap<AlbumDTO, Album>()).CreateMapper();
           
        }
        public void Create(AlbumDTO item)
        {
            db.Albums.Create(_dtoToAlbumMapper.Map<AlbumDTO, Album>(item));
        }

        public void Delete(int id)
        {
            db.Albums.Delete(id);
        }

        public AlbumDTO Get(int id)
        {
            return _albumToDtoMapper.Map<Album, AlbumDTO>(db.Albums.Get(id));
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            var albums = db.Albums.GetAll();
            return _albumToDtoMapper.Map<IEnumerable<Album>, IEnumerable<AlbumDTO>>(albums);
        }

        public void Update(AlbumDTO item)
        {
            db.Albums.Update(_dtoToAlbumMapper.Map<AlbumDTO, Album>(item));
        }
    }
}
