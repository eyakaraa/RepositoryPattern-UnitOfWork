using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ServiceCompte.Domain.Interfaces;

namespace ServiceCompte.DataAccess.EFCore.Repositories
/*
 repository :

  C’est un modèle de conception qui assure la médiation des données depuis et vers les couches de
  domaine et d'accès aux données (comme Entity Framework Core ). Les référentiels sont des
  classes qui masquent les logiques requises pour stocker ou récupérer des données. Ainsi, notre
  application ne se souciera pas du type d'ORM(objet relation mapping) puisque il est géré dans
  une couche de référentiel. Cela vous permet d'avoir une séparation plus claire des
  préoccupations. Le modèle de reposetory est l'un des modèles de conception les plus utilisés pour
  créer des solutions plus propres.

    Avantages De ce modele:

      * Réduit les requêtes en double
Imaginez avoir à écrire des lignes de code pour simplement récupérer des données de votre
banque de données. Que se passe-t-il maintenant si cet ensemble de requêtes va être utilisé à
plusieurs endroits dans l'application. Pas très idéal pour écrire ce code encore et encore. Ce
design pattern permet de avoir une solution pour ce probléme.

      * Dissocie l'application de la couche d'accès aux données

Il existe de nombreux ORM disponibles pour ASP.NET Core. Pour suivre le rythme de
l'évolution des technologies et maintenir nos solutions à jour, il est très important de créer une
abstraction sur la couche des données.Il peut également y avoir des cas où vous devez utiliser
plusieurs ORM dans une seule solution non seulement efcore .L'architecture doit être
indépendante des cadres.


 */
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);

        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
