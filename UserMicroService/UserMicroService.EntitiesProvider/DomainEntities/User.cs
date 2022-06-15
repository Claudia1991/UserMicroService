using System;

namespace UserMicroService.EntitiesProvider.DomainEntities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
    }
}
