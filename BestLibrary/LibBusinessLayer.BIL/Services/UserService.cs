using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using LibBusinessLayer.BIL.Interfaces;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;

namespace LibBusinessLayer.BIL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        //UserService в конструкторе принимает объект IUnitOfWork, через который идет взаимодействие с уровнем DAL.
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id користувача", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Користувач не знайдений", "");

            return new UserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public void MakeUser(UserDTO userDto)
        {
            //TODO: Дополнительная логика

            User user = new User
            {
                UserId = userDto.UserId,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };
            Database.Users.Create(user);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
