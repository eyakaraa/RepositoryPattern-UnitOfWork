using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceCompte.Domain.Entities;
using ServiceCompte.Domain.Interfaces;

namespace ServiceCompte.DataAccess.EFCore.Repositories
{
    public class SocieteRepository : GenericRepository<Societe>, ISocieteRepository
    {
        public SocieteRepository(ApplicationContext context) : base(context)
        {
        }

        //Ajouter des fonctionnalités particulière
        public IEnumerable<Societe> GetAllSocieteInRegion(string Region)
        {
            return _context.Societes.Where(data => data.Adresse.Contains(Region)).ToList();

        }
    }
}
