using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.User
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Midname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
