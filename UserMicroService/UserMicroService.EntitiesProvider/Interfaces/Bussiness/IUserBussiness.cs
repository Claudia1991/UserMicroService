using System.Collections.Generic;
using UserMicroService.EntitiesProvider.ModelEntities.Request;
using UserMicroService.EntitiesProvider.ModelEntities.Response;

namespace UserMicroService.EntitiesProvider.Interfaces.Bussiness
{
    public interface IUserBussiness
    {
        /// <summary>
        /// Creat a new user
        /// </summary>
        /// <param name="request">Parameters to create a user</param>
        /// <returns><see cref="ResponseBase"/></returns>
        ResponseBase CreatNewUser(UserAddRequest request);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="request">Parameters to update a user</param>
        /// <returns><see cref="ResponseBase"/></returns>
        ResponseBase UpdateUser(UserUpdateRequest request);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="request">Parameters to Delete a user</param>
        /// <returns><see cref="ResponseBase"/></returns>
        ResponseBase DeleteUser(UserDeleteRequest request);

        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns><see cref="ResponseBase"/></returns>
        ResponseBase GetAllUsers();
    }
}
