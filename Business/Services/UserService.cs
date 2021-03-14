using AutoMapper;
using AutoMapper.Configuration;
using Burak.Application.Inveon.Data;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Utilities.Constants;
using Burak.Application.Inveon.Utilities.ValidationHelper.ValidationResolver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Business.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IValidatorResolver _validatorResolver;
        private readonly ILogger<UserService> _logger;

        public UserService(DataContext dataContext, IMapper mapper,
             IValidatorResolver validatorResolver, ILogger<UserService> logger)
        {
            _dataContext = dataContext;
            _validatorResolver = validatorResolver;
            _logger = logger;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = _dataContext.Users.Where(x => x.Username == username && x.Password == password).First();

            //// Kullanici bulunamadıysa null döner.
            //if (user == null)
            //    return null;

            //// Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(AppConstants.JWTSecretKey);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);
            //// Sifre null olarak gonderilir.
            //user.Password = null;

            return user;
        }

        #region User CRUD
        public async Task<User> CreateUser(User userRequest)
        {
            var updateDate = DateTime.Now;

            userRequest.CreatedOnUtc = updateDate;
            userRequest.UpdatedOnUtc = updateDate;
            userRequest.IsDeleted = false;

            var user = _dataContext.Users.Add(userRequest);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }

        public async Task<User> DeleteUser(User userRequest)
        {
            var updateDate = DateTime.Now;

            userRequest.UpdatedOnUtc = updateDate;
            userRequest.IsDeleted = true;

            var user = _dataContext.Users.Update(userRequest);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = _dataContext.Users.Where(x => x.Id == userId && !x.IsDeleted && x.IsActive).First();
            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = _dataContext.Users.Where(x => x.Username == username && !x.IsDeleted && x.IsActive).First();
            return user;
        }

        public async Task<User> UpdateUser(User userRequest)
        {
            var updateDate = DateTime.Now;

            userRequest.UpdatedOnUtc = updateDate;

            var user = _dataContext.Users.Update(userRequest);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }

        #endregion
    }
}
