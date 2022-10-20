using AutoMapper;
using DataBase.Models;
using DataBase.Repositories.Interfaces;
using Logic.DTOs.User;
using Logic.WriteServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WriteServices
{
    public class UserWriteService : IUserWriteService
    {
        IUnitOfWork _repositories;
        readonly IMapper _mapper;
        public UserWriteService(IUnitOfWork repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        public Guid Add(RegistrationRequest registrationRequest)
        {
            User user = _mapper.Map<User>(registrationRequest);

            //TODO хеширование пароля
            user.PasswordHash = registrationRequest.Password;


            user = _repositories.Users.Add(user);
            _repositories.SaveChanges();
            return user.Id;
        }

        public void Delete(Guid id)
        {

            User user = _repositories.Users.Get(id);
            _repositories.Users.Delete(user);
            _repositories.SaveChanges();
        }

        public void UpdatePassword(Guid id, ChangePasswordRequest changePasswordRequest)
        {
            User user = _repositories.Users.Get(id);

            //TODO хеширование пароля
            user.PasswordHash = "string1";


            _repositories.Users.Update(user);
            _repositories.SaveChanges();
        }
    }
}
