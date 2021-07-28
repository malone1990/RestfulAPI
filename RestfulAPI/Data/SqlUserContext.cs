using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Data
{
    public class SqlUserContext : IUserRepo
    {
        private readonly TimeCardContext _context;

        public SqlUserContext(TimeCardContext context)
        {
            _context = context;
        }

        public int DeleteUserInfoByIds(int[] ids)
        {
            var arr = _context.Users.Where(user=>ids.Contains(user.UserId)).ToArray();
            if (arr.Length == 0)
                return 0;

            _context.Users.RemoveRange(arr);

            return _context.SaveChanges();
        }

        int IUserRepo.AddOrUpdateUserInfo(UserInfo userInfo)
        {
            if(_context.Users.FirstOrDefault(user=>user.UserId == userInfo.UserId) == null)
                _context.Users.Add(userInfo);
            else 
            {
                var user = _context.Users.First(user => user.UserId == userInfo.UserId);
                user = userInfo;
            }
            return _context.SaveChanges();
        }

        IEnumerable<UserInfo> IUserRepo.GetAllUsers()
        {
            return _context.Users.ToList();
        }

        UserInfo IUserRepo.GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(user=>user.UserId == userId);
        }

        UserInfo IUserRepo.GetUserByNamePwd(string name, string password)
        {
            return _context.Users.FirstOrDefault(user => user.Name == name && user.Password == password);
        }
    }
}
