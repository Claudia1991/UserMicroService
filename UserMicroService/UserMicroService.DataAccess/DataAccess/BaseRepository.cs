using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserMicroService.DataAccess.Context;
using UserMicroService.EntitiesProvider.DomainEntities;
using UserMicroService.EntitiesProvider.Interfaces.DataAccess;

namespace UserMicroService.DataAccess.DataAccess
{
    public class BaseRepository : IBaseRepository<User>
    {
        private readonly UserMicroServiceContext context;

        public BaseRepository(UserMicroServiceContext context)
        {
            this.context = context;
        }

        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<User> Get()
        {
            return context.Users.AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
