using AutoMapper;
using Burak.Application.Inveon.Business.Services;
using Burak.Application.Inveon.Business.Validator;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Models.Response;
using Burak.Application.Inveon.Utilities.ValidationHelper.ValidationResolver;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserApiController : ControllerBase
    {
        
        private readonly ILogger<UserApiController> _logger;
        private readonly IUserService _userService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public UserApiController(ILogger<UserApiController> logger,
            IUserService userService,
            IValidatorResolver validatorResolver,
            IMapper mapper
            )
        {
            _logger = logger;
            _userService = userService;
            _validatorResolver = validatorResolver;
            _mapper = mapper;
        }

        #region Authorization

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<UserResponse> Authenticate([FromBody] LoginRequest userRequest)
        {
            var user = await _userService.Authenticate(userRequest.Username, userRequest.Password);

            return _mapper.Map<UserResponse>(user);
        }

        #endregion

        #region User

        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<UserResponse> CreateUser([FromBody] UserRequest userRequest)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserValidator>();
            ValidationResult validationResult = validator.Validate(userRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = _mapper.Map<User>(userRequest);

            var userResponse = _userService.CreateUser(user);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }

        /// <summary>
        /// Updates  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<UserResponse> UpdateUser([FromBody] UserRequest userRequest)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserValidator>();
            ValidationResult validationResult = validator.Validate(userRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = _mapper.Map<User>(userRequest);

            var userResponse = _userService.UpdateUser(user);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }


        /// <summary>
        /// Deletes  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<UserResponse> DeleteUser([FromRoute] int userId)
        {
            if (userId == 0)
                return null;

            var user = _userService.GetUserById(userId);

            var userResponse = _userService.DeleteUser(user.Result);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }

        /// <summary>
        /// Gets  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<UserResponse> GetUser([FromRoute] int userId)
        {
            if (userId == 0)
                return null;

            var user = _userService.GetUserById(userId);

            var userResponseModel = _mapper.Map<UserResponse>(user.Result);

            return userResponseModel;
        }

        #endregion
    }
}
