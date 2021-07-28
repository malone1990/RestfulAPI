using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Data
{
    public interface IUserRepo
    {
        IEnumerable<UserInfo> GetAllUsers();

        UserInfo GetUserById(int userId);

        UserInfo GetUserByNamePwd(string name, string password);

        int AddOrUpdateUserInfo(UserInfo userInfo);

        int DeleteUserInfoByIds(int[] ids);
    }  
}
