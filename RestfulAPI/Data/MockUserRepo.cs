using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Data
{
    public class MockUserRepo : IUserRepo
    {
        int IUserRepo.AddOrUpdateUserInfo(UserInfo userInfo)
        {
            Console.WriteLine(userInfo.ToString());
            return 0;
        }

        int IUserRepo.DeleteUserInfoByIds(int[] ids)
        {
            return 0;
        }

        IEnumerable<UserInfo> IUserRepo.GetAllUsers()
        {
            return new List<UserInfo>() { 
                new UserInfo{UserId=0,Name="test0",Password="password",IsAdmin=false } 
            ,   new UserInfo{UserId=1,Name="test1",Password="password",IsAdmin=false }
            ,   new UserInfo{UserId=2,Name="test2",Password="password",IsAdmin=true }
            };
        }

        UserInfo IUserRepo.GetUserById(int userId)
        {
            return new UserInfo { UserId = userId, Name = "test" + userId, Password = "password", IsAdmin = false };
        }

        UserInfo IUserRepo.GetUserByNamePwd(string name, string password)
        {
            return new UserInfo { UserId = -1, Name = name, Password = password, IsAdmin = false };
        }
    }
}
