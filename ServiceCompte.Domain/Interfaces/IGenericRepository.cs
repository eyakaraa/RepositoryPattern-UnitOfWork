using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServiceCompte.Domain.Interfaces
{


    /*
     pourquoi nous avons utilisé generic repository ??

Lorsqu'il y a un grand nombre d'entités dans notre application, nous aurions besoin de
référentiels séparés pour chaque entité. Mais nous ne voulons pas implémenter toutes les 8
fonctions ci-dessus dans chaque classe de référentiel. Nous avons donc créé un référentiel
générique contenant les implémentations les plus couramment utilisées.
     
     */


    /*
    

Tout d'abord, ajoutons un nouveau dossier Interfaces dans notre projet de domaine. pour nous
allons inverser les dépendances, de sorte que vous puissiez définir l'interface dans le projet de
domaine, mais l'implémentation dans le projet DataAccess.EFCore . 
    
    Ainsi, votre couche de domaine ne dépendra de rien, mais les autres couches ont tendance à dépendre de l'interface de la
couche de domaine. Ceci est une explication simple du principe d'inversion de dépendance.
Ce sera une interface générique,
L'ensemble des fonctions dépend de vos préférences. Idéalement, nous avons 8 fonctions qui
couvrent la majeure partie de la partie traitement des données.


     */
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
