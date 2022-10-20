using DataBase.Models;
using Logic.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WriteServices.Interfaces
{
    public interface IUserWriteService
    {
        public Guid Add(RegistrationRequest registrationRequest);
        public void UpdatePassword(Guid id, ChangePasswordRequest changePasswordRequest);
        public void Delete(Guid id);
    }
}
