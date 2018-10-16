using ProjectManager.Business;
using ProjectManager.Data.Models.Custom;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectManager.ServiceApi.Controllers
{
    public class TaskController : ApiController
    {
        TaskBusiness taskBusiness;

        //[Route("api/ProjectManager/Task/Parent")]
        [HttpGet]
        public List<TaskModel> GetAllParentTask()
        {
            taskBusiness = new TaskBusiness();
            var result = taskBusiness.GetAllParentTask();
            return result;
        }

        //[Route("api/ProjectManager/Task/All")]
        [HttpGet]
        public List<TaskModel> GetAll()
        {
            taskBusiness = new TaskBusiness();
            var result = taskBusiness.GetAll();
            return result;
        }

        //[Route("api/ProjectManager/Task/AddUpdate")]
        [HttpPost]
        public string Manage(object task)
        {
            string result = string.Empty;
            taskBusiness = new TaskBusiness();
            result = taskBusiness.ManageTask(task);
            return result;
        }

        //[Route("api/ProjectManager/Task/End")]
        [HttpPost]
        public bool End(object task)
        {
            taskBusiness = new TaskBusiness();
            return taskBusiness.EndTask(task);
        }
    }
}
