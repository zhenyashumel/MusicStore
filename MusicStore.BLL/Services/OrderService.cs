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
    class OrderService: ICRUDService<OrderDTO>
    {
        private IUnitOfWork db;
        private IMapper _orderToDtoMapper;
        private IMapper _dtoToOrderMapper;

        public OrderService(IUnitOfWork uof)
        {
            db = uof;

            _orderToDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            _dtoToOrderMapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
        }
        
        public void Create(OrderDTO item)
        {
            db.Orders.Create(_dtoToOrderMapper.Map<OrderDTO, Order>(item));
        }

        public void Delete(int id)
        {
            db.Orders.Delete(id);
        }

        public OrderDTO Get(int id)
        {
            return _dtoToOrderMapper.Map<Order, OrderDTO>(db.Orders.Get(id));
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _orderToDtoMapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(db.Orders.GetAll());
        }

        public void Update(OrderDTO item)
        {
            db.Orders.Update(_dtoToOrderMapper.Map<OrderDTO, Order>(item));
        }
    }
}
