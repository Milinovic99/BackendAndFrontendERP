using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IUserRepository
    {
        List<User> GetUsers(string name,string lastName,string UserName);
        User GetUserById(int korisnik_id);
        User CreateUser(User korisnik);
        User UpdateUser(User korisnik);
        void DeleteUser(int korisnik_id);
        bool SaveChanges();
        public bool UserWithCredentialsExists(AuthModel model);
    }
}
