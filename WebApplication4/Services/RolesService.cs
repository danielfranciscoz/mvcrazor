using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Database;
using WebApplication4.Interfaces;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class RolesService : IRolesService
    {
        private readonly mydatabaseDB _db;
        
        public RolesService(mydatabaseDB db)
        {
            _db = db;
        }

        public List<Role> ObtenerRoles()
        {
            return _db.Roles.Where(w => w.Activo).ToList();
        }
    }
}
