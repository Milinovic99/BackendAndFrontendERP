using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class RoleRepository:IRoleRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public RoleRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Role CreateRole(Role uloga)
        {
            var createdEntity = context.Add(uloga);
            return mapper.Map<Role>(createdEntity.Entity);
        }

        public void DeleteRole(int uloga_id)
        {
            var radnja = GetRoleById(uloga_id);
            context.Remove(radnja);
        }

        public Role GetRoleById(int uloga_id)
        {
            return context.Roles.FirstOrDefault(e => e.Role_id == uloga_id);

        }

        public List<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Role UpdateRole(Role uloga)
        {
            throw new NotImplementedException();
        }
    }
}
