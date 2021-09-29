using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCompte.Domain.Entities
{
    public class Societe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string motDePasse { get; set; }
    }
}
