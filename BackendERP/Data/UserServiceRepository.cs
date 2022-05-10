using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class UserServiceRepository:IUserServiceRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UserServiceRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public User_service CreateUserService(User_service korisnicki)
        {
            var createdEntity = context.Add(korisnicki);
            return mapper.Map<User_service>(createdEntity.Entity);
        }

        public void DeleteUserService(int korisnicki_id)
        {
            var radnja = GetUserServiceById(korisnicki_id);
            context.Remove(radnja);
        }

        public List<User_service> GetUserServices(string email)
        {
            return (from e in context.User_services
                    where string.IsNullOrEmpty(email) ||
                    e.Email == email
                    select e).ToList();
        }

        public User_service GetUserServiceById(int korisnicki_id)
        {
            return context.User_services.FirstOrDefault(e => e.Service_id == korisnicki_id);

        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public User_service UpdateUserService(User_service korisnicki)
        {
            throw new NotImplementedException();
        }
    }
}
