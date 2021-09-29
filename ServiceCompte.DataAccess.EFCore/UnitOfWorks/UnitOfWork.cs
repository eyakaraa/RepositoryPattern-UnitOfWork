using System;
using System.Collections.Generic;
using System.Text;
using ServiceCompte.DataAccess.EFCore.Repositories;
using ServiceCompte.Domain.Interfaces;

namespace ServiceCompte.DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        /*
          l'Unité de travail a deux tâches importantes:

     conserver une liste de demandes en un seul endroit (la liste peut contenir plusieurs
     demandes d'insertion, de mise à jour et de suppression), et
      
     envoyer ces demandes en une seule transaction à la base de données
         
         */
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Societes = new SocieteRepository(_context);
            Clients = new ClientRepository(_context);
        }
        public ISocieteRepository Societes { get; private set; }
        public IClientRepository Clients { get; private set; }

        /*
        Nous avons décider grace a ce design pattern de ne pas inclure SaveChanges dans aucun des
        répertoires pour ne pas nuire a la base.
         */
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
