using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCompte.Domain.Interfaces
{
    /*
     Unité De Modèle De Travail

Unit of Work Pattern est un modèle de conception avec lequel vous pouvez exposer diverses
respostiories dans notre application. Il a des propriétés très similaires à dbContext, mais l'Unité
de travail n'est couplée à aucun framework tel que dbContext à Entity Framework Core.
Jusqu'à présent, nous avons construit quelques référentiels. Nous pouvons facilement injecter ces
référentiels dans le constructeur des classes Services et accéder aux données. C'est assez facile
lorsque vous n'avez que 2 ou 3 objets de référentiel impliqués. Que se passe-t-il quand il y a plus
de 3 référentiels. Il ne serait pas pratique de continuer à ajouter de nouvelles injections de temps
en temps. Afin de regrouper tous les référentiels en un seul objet, nous utilisons unit of work.
Unit of work est chargée d'exposer les référentiels disponibles et de valider les modifications de
la source de données en garantissant une transaction complète, sans perte de données.
L'autre avantage majeur est que plusieurs objets du référentiel contiennent différentes instances
de dbcontext. Cela peut entraîner des fuites de données dans des cas complexes.

     */
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        ISocieteRepository Societes { get; }
        int Complete();
    }
}
