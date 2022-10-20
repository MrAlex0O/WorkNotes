using Logic.DTOs.User;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices
{
    public class UserReadService : IUserReadService
    {
        IUserQuery _userQuery;
        public UserReadService(IUserQuery query)
        {
            _userQuery = query;
        }
        public List<GetUserResponse> GetAll()
        {
            return _userQuery.GetAll();
        }
    }
}
