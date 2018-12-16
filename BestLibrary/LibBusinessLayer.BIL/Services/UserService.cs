using AutoMapper;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using LibBusinessLayer.BIL.Interfaces;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibDataLayer.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace LibBusinessLayer.BIL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWorkUser Database { get; set; }
        private ClientProfileDto CurrentUser { get; set; }

        public UserService(IUnitOfWorkUser uow)
        {
            Database = uow;
        }

        public ClientProfileDto GetCurrentUser()
        {
            return CurrentUser;
        }

        public async Task<OperationDetails> Create(ClientProfileDto clientProfileDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(clientProfileDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = clientProfileDto.Email, UserName = clientProfileDto.Email };
                var result = await Database.UserManager.CreateAsync(user, clientProfileDto.Password);
                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, clientProfileDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile
                {
                    Id = user.Id,
                    Name = clientProfileDto.Name,
                    Address = clientProfileDto.Address
                };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                CurrentUser = new ClientProfileDto
                {
                    Id = user.Id,
                };
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }



        public async Task<ClaimsIdentity> Authenticate(ClientProfileDto clientProfileDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(clientProfileDto.Email, clientProfileDto.Password);

            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
            {
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                CurrentUser = new ClientProfileDto
                {
                    Id = user.Id,
                };
            }
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(ClientProfileDto adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
