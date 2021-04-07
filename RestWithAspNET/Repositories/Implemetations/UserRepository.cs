using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;
using RestWithAspNET.Models.Context;

namespace RestWithAspNET.Repositories.Implemetations
{
    public class UserRepository : IUserRepository
    {

        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(p => p.Id.Equals(user.Id))) return null;

            try
            {
                var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
                
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}