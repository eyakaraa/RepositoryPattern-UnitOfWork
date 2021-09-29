using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ServiceCompte.Domain.Entities;
namespace ServiceCompte.DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        /*
         
         Ajoutez une référence au projet de domaine (où nous avons défini nos entités) 
        créez une nouvelle classe dans le projet DataAccess.EFCore et nommez-la ApplicationContext.cs .

         */
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Societe> Societes { get; set; }

   
    }
}
