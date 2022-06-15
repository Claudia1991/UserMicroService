using System.Collections.Generic;
using UserMicroService.EntitiesProvider.DomainEntities;

namespace UserMicroService.EntitiesProvider.Interfaces.DataAccess
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get the collection of entities from database
        /// </summary>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Get the entity from data base by id
        /// </summary>
        /// <param name="id">The id of entity</param>
        /// <returns>The entity searched.</returns>
        T GetById(int id);

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(T entity);

        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(T entity);
    }
}
