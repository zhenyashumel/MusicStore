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
        public AlbumService(IUnitOfWork uof)
        {
            db = uof;
        }

        public void Create(AlbumDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AlbumDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            var alb = db.Albums.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Album, AlbumDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDTO>>(alb);
        }

        public void Update(AlbumDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
