using System.Collections.Generic;
using UserMicroService.EntitiesProvider.DomainEntities;
using UserMicroService.EntitiesProvider.Enums;
using UserMicroService.EntitiesProvider.Interfaces.Bussiness;
using UserMicroService.EntitiesProvider.Interfaces.DataAccess;
using UserMicroService.EntitiesProvider.ModelEntities.Request;
using UserMicroService.EntitiesProvider.ModelEntities.Response;
using System.Linq;

namespace UserMicroService.Bussiness.Bussiness.Users
{
    public class UserBussiness : IUserBussiness
    {
        private readonly IBaseRepository<User> _repository;

        public UserBussiness(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public ResponseBase CreatNewUser(UserAddRequest request)
        {
            var entity = new User()
            {
                Name = request.Name,
                Birthdate = request.Birthday,
                Active = true
            };

            _repository.Add(entity);

            return ResponseBase.FromSuccess(Messages.OK);
        }

        public ResponseBase DeleteUser(UserDeleteRequest request)
        {
            var entity = new User
            {
                Id = request.Id
            };

            var user = _repository.GetById(entity.Id);

            if (user == null)
            {
                return ResponseBase.FromFailure(Messages.NO_OK);

            }

            _repository.Delete(entity);

            return ResponseBase.FromSuccess(Messages.OK);
        }

        public ResponseBase GetAllUsers()
        {
            var users = _repository.Get();

            var activeUsers = users.Where(x => x.Active);

            var usersResponse = activeUsers.Select(x => new UserResponse 
                                                            { 
                                                                Id = x.Id,
                                                                Name = x.Name,
                                                                Birthdate = x.Birthdate.ToString("dd/MM/yyyy")
                                                            })
                                            .ToList();

            return ResponseBase<IEnumerable<UserResponse>>.FromSuccess(Messages.OK, usersResponse);
        }

        public ResponseBase UpdateUser(UserUpdateRequest request)
        {
            var entity = _repository.GetById(request.Id);

            if (entity == null)
            {
                return ResponseBase.FromFailure(Messages.NO_OK);
            }

            entity.Active = request.Active;

            _repository.Update(entity);

            return ResponseBase.FromSuccess(Messages.OK);
        }
    }
}
