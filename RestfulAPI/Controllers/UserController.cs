using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Data;
using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("users/")]
        public ActionResult<IEnumerable<UserInfo>> GetAllUsers()
        {
            var userlist = _repository.GetAllUsers();
            return Ok(userlist);
        }

        [HttpGet("users/{id}")]
        public ActionResult<UserInfo> GetUserById(int id) 
        {
            var user = _repository.GetUserById(id);
            if (user == null)
                return new EmptyResult();
            return Ok(user);
        }

        [HttpGet("login/")]
        public ActionResult<ResultInfo> LoginByNameAndPwd(string name,string password ) 
        {

            var user = _repository.GetUserByNamePwd(name,password);
            if (user == null)
                return Ok(new ResultInfo{ ResultCode = "300", ResultMessage = "fail to login " }) ;
            return Ok(new ResultInfo {ResultCode="200",ResultMessage="login successfully",ResultData=user });

        }

        [HttpPost("user/")]
        public ActionResult<bool> AddNewUserInfo([FromBody] UserInfo user)
        {
            if (User != null)
            {
                int count = _repository.AddOrUpdateUserInfo(user);
                return Ok(count > 0);
            }
            else
                return Ok(false);
        }

        [HttpDelete("user/{ids}")]
        public ActionResult<bool> AddNewUserInfo(string ids)
        {
            var userIds = ids.Trim(',').Split(',');
            if (userIds != null && userIds.Length > 0)
            {
                int temp = -1;
                int[] uIds = Array.ConvertAll<string, int>(userIds, id => {
                    temp = -1;
                    if (int.TryParse(id, out temp))
                        return temp;
                    else
                        return -1;
                });
                int count = _repository.DeleteUserInfoByIds(uIds);
                return Ok(count > 0);
            }
            else
                return Ok(false);
        }


        /*
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
