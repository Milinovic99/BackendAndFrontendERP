using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IUserServiceRepository
    {
        List<User_service> GetUserServices(string email=null);
        User_service GetUserServiceById(int korisnicki_id);
        User_service CreateUserService(User_service korisnicki);
        User_service UpdateUserService(User_service korisnicki);
        void DeleteUserService(int korisnicki_id);
        bool SaveChanges();
    }
}
