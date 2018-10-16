using System.Collections.Generic;
using System.Web.Http;
using ProjectManager.Business;
using ProjectManager.Data.Models.Custom;

namespace ProjectManager.Controllers
{
    public class ProjectController : ApiController
    {
        ProjectBusiness projectBusiness;

        //[Route("api/ProjectManager/Project/All")]
        [HttpGet]
        public List<ProjectModel> GetAll()
        {
            projectBusiness = new ProjectBusiness();
            var result = projectBusiness.GetAll();
            return result;
        }

        //[Route("api/ProjectManager/Project/AddUpdate")]
        [HttpPost]
        public string ManageProject(object project)
        {
            string result = string.Empty;
            projectBusiness = new ProjectBusiness();
            result = projectBusiness.ManageProject(project);
            return result;
        }
        

        //[Route("api/ProjectManager/Project/Suspend")]
        [HttpPost]
        public bool Suspend(object task)
        {
            projectBusiness = new ProjectBusiness();
            return projectBusiness.Suspend(task);
        }

    }
}
