using System;
using System.Collections.Generic;
using AutoMapper;
using MusicStore.BLL.DTO;
using MusicStore.BLL.Interfaces;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;

namespace MusicStore.BLL.Services
{
    class AuthorService : ICRUDService<AuthorDTO>
    {
        //Делаем по аналогии с SongService
        private IUnitOfWork db;
        private IMapper _authorToDtoMapper;
        private IMapper _dtoToAuthorMapper;

        public AuthorService(IUnitOfWork uof)
        {
            db = uof;

            _authorToDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            _dtoToAuthorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, Author>()).CreateMapper();
        }

        //Реализуем методы интерфейса по аналогии с SongService
        public void Create(AuthorDTO item)
        {
            db.Authors.Create(_dtoToAuthorMapper.Map<AuthorDTO, Author>(item));
        }

        public void Delete(int id)
        {
            db.Authors.Delete(id);
        }

        public AuthorDTO Get(int id)
        {
            return _authorToDtoMapper.Map<Author, AuthorDTO>(db.Authors.Get(id));
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            return _authorToDtoMapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(db.Authors.GetAll());
        }

        public void Update(AuthorDTO item)
        {
            db.Authors.Update(_dtoToAuthorMapper.Map<AuthorDTO, Author>(item));
        }
    }
}
