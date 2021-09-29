using System;
using System.Collections.Generic;
using System.Text;
using ServiceCompte.Domain.Entities;

namespace ServiceCompte.Domain.Interfaces
{
    public interface ISocieteRepository : IGenericRepository<Societe>
    {
        IEnumerable<Societe> GetAllSocieteInRegion(string Region);

    }
}
