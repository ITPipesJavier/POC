using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Logic.Admin.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User user);
        User Update(User user);
        void DeleteUser(string Id);
    }
}
