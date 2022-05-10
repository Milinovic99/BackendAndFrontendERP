using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role GetRoleById(int uloga_id);
        Role CreateRole(Role uloga);
        Role UpdateRole(Role uloga);
        void DeleteRole(int uloga_id);
        bool SaveChanges();
    }
}
