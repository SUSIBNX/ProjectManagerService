﻿using ProjectManager.Data.Models.Custom;
using System.Collections.Generic;
using System.Web.Http;
using ProjectManager.Business;

namespace ProjectManager.ServiceApi.Controllers
{
    public class UserController : ApiController
    {
        UserBusiness userBusiness;

        //[Route("api/ProjectManager/User/All")]
        [HttpGet]
        public List<UserModel> GetAll()
        {
            userBusiness = new UserBusiness();
            var result = userBusiness.GetActiveUserList();
            return result;
        }


        //[Route("api/ProjectManager/User/AddUpdate")]
        [HttpPost]
        public string Manage(object user)
        {
            string result = string.Empty;
            userBusiness = new UserBusiness();
            result = userBusiness.AddOrUpdateUser(user);
            return result;
        }

        //[Route("api/ProjectManager/User/Delete")]
        [HttpPost]
        public bool Delete(object user)
        {
            userBusiness = new UserBusiness();
            return userBusiness.DeleteUser(user);
        }
    }
}
