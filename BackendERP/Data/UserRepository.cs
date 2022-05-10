using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UserRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public User CreateUser(User korisnik)
        {
            var createdEntity = context.Add(korisnik);
            return mapper.Map<User>(createdEntity.Entity);
        }

        public void DeleteUser(int korisnik_id)
        {
            var radnja = GetUserById(korisnik_id);
            context.Remove(radnja);
        }

        public List<User> GetUsers(string name = null,string lastName=null,string userName = null)
        {
            return (from e in context.Users
                    where (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(lastName) &&
                    string.IsNullOrEmpty(userName))
                 || (e.Name == name || e.LastName == lastName || e.User_name == userName)
                    select e).ToList();
        }

        public User GetUserById(int korisnik_id)
        {
            return context.Users.FirstOrDefault(e => e.User_id == korisnik_id);

        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public User UpdateUser(User korisnik)
        {
            throw new NotImplementedException();
        }

        public bool UserWithCredentialsExists(AuthModel model)
        {
            User korisnik = context.Users.FirstOrDefault(u => u.Email == model.Email);

            if (korisnik == null)
            {
                return false;
            }

            //Ako smo našli korisnika sa tim korisničkim imenom proveravamo lozinku
            if (ValidatePassword(model.Password))
            {
                return true;
            }
            return false;
        }

        public bool ValidatePassword(string password)
        {
            User korisnik = context.Users.FirstOrDefault(u => u.Password == password);

            if (password == null)
            {
                return false;
            }
            return true;
        }
    }
}
