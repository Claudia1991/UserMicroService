using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using UserMicroService.EntitiesProvider.Interfaces.Bussiness;
using UserMicroService.EntitiesProvider.ModelEntities.Request;
using UserMicroService.EntitiesProvider.ModelEntities.Response;

namespace UserMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBussiness _userBussiness;

        public UserController(IUserBussiness userBussiness)
        {
            _userBussiness = userBussiness;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns><see cref="ResponseBase"/></returns>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseBase),StatusCodes.Status200OK)]
        public ResponseBase Get()
        {
            var response = _userBussiness.GetAllUsers();
            return response;
        }

        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="request"><see cref="UserAddRequest"/></param>
        /// <returns><see cref="ResponseBase"/></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
        public ResponseBase Post([FromBody] UserAddRequest request)
        {
            var response = _userBussiness.CreatNewUser(request);
            return response;
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="request"><see cref="UserUpdateRequest"/></param>
        /// <returns><see cref="ResponseBase"/></returns>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
        public ResponseBase Put([FromBody] UserUpdateRequest request)
        {
            var response = _userBussiness.UpdateUser(request);
            return response;
        }

        /// <summary>
        /// Delete user by request
        /// </summary>
        /// <param name="request"><see cref="UserDeleteRequest"/></param>
        /// <returns><see cref="ResponseBase"/></returns>
        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
        public ResponseBase Delete([FromBody]UserDeleteRequest request)
        {
            var response = _userBussiness.DeleteUser(request);
            return response;
        }
    }
}
