using System;

namespace UserMicroService.EntitiesProvider.ModelEntities.Request
{
    public class UserAddRequest
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
