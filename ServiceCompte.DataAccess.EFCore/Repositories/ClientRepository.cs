using ServiceCompte.Domain.Entities;
using ServiceCompte.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceCompte.DataAccess.EFCore.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
