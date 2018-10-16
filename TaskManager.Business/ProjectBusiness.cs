using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using ProjectManager.Data.Models.Custom;
using ProjectManager.Data.Repository;

namespace ProjectManager.Business
{
    public class ProjectBusiness
    {
        ProjectRepository projectRepository;

        #region GetAll
        /// <summary>
        /// Method to fetch the all the project details
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> GetAll()
        {
            projectRepository = new ProjectRepository();
            var result = projectRepository.GetAll();
            return result;
        }
        #endregion

        #region ManageProject
        /// <summary>
        /// Method to add or update a project
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        public string ManageProject(object projectModel)
        {
            string result = string.Empty;
            projectRepository = new ProjectRepository();
            result = projectRepository.ManageProject(ProjectConverter(projectModel));
            return result;
        }
        #endregion

        #region SuspendProject
        /// <summary>
        /// Method to end Task 
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public bool Suspend(object projectModel)
        {
            projectRepository = new ProjectRepository();
            return projectRepository.Suspend(ProjectConverter(projectModel));
        }
        #endregion

        #region ProjectConverter
        /// <summary>
        /// Method to convert the incoming objects to models
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public ProjectModel ProjectConverter(object project)
        {
            ProjectModel projectModel = new ProjectModel();
            string details = project.ToString();
            JavaScriptSerializer objJavascript = new JavaScriptSerializer();
            var testModels = objJavascript.DeserializeObject(details);

            if (testModels != null)
            {
                Dictionary<string, object> dic1 = (Dictionary<string, object>)testModels;
                object value;

                if (dic1.TryGetValue("Project", out value))
                    projectModel.Project = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("ProjectId", out value))
                    projectModel.ProjectId = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);
                if (dic1.TryGetValue("StartDate", out value))
                    projectModel.StartDateString = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("EndDate", out value))
                    projectModel.EndDateString = value.ToString();
                if (dic1.TryGetValue("ManagerId", out value))
                    projectModel.ManagerId = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("Priority", out value))
                    projectModel.Priority = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);
                return projectModel;
            }

            return projectModel;
        }
        #endregion
    }
}

