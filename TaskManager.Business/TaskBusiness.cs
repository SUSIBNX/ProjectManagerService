using ProjectManager.Data.Models.Custom;
using ProjectManager.Data.Repository;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ProjectManager.Business
{
    public class TaskBusiness
    {
        TaskRepository taskRepository;

        #region GetParentTask
        /// <summary>
        /// Method to fetch the parent task details to load the parent task dropdown
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> GetAllParentTask()
        {
            taskRepository = new TaskRepository();
            var result = taskRepository.GetAllParentTask();
            return result;
        }
        #endregion

        #region GetAllTask
        /// <summary>
        /// Method to fetch all the task details
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> GetAll()
        {
            taskRepository = new TaskRepository();
            var result = taskRepository.GetAll();
            return result;
        }
        #endregion

        #region AddorUpdateTask
        /// <summary>
        /// Method to insert the task details
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public string ManageTask(object inputModel)
        {
            string result = string.Empty;
            taskRepository = new TaskRepository();
            TaskModel taskModel = TaskConverter(inputModel);
            if (taskModel != null && taskModel.IsParent)
                result = taskRepository.AddParent(taskModel);
            else
                result = taskRepository.ManageTask(taskModel);
            return result;
        }
        #endregion

        #region EndTask
        /// <summary>
        /// Method to end Task 
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public bool EndTask(object taskModel)
        {
            taskRepository = new TaskRepository();
            return taskRepository.End(TaskConverter(taskModel));
        }
        #endregion

        #region TaskConverter
        /// <summary>
        /// Method to convert the incoming objects to models
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public TaskModel TaskConverter(object task)
        {
            TaskModel taskModel = new TaskModel();
            string details = task.ToString();
            JavaScriptSerializer objJavascript = new JavaScriptSerializer();
            var testModels = objJavascript.DeserializeObject(details);

            if (testModels != null)
            {
                Dictionary<string, object> dic1 = (Dictionary<string, object>)testModels;
                object value;

                if (dic1.TryGetValue("Task", out value))
                    taskModel.Task = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("ParentId", out value))
                    taskModel.ParentId = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);
                if (dic1.TryGetValue("ProjectId", out value))
                    taskModel.ProjectId = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);
                if (dic1.TryGetValue("Priority", out value))
                    taskModel.Priority = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);
                if (dic1.TryGetValue("StartDate", out value))
                    taskModel.StartDateString = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("EndDate", out value))
                    taskModel.EndDateString = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("TaskId", out value))
                    taskModel.TaskId = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);
                if (dic1.TryGetValue("IsParent", out value))
                    taskModel.IsParent = Convert.ToBoolean(value);
                if (dic1.TryGetValue("ParentTask", out value))
                    taskModel.ParentTask = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("ManagerId", out value))
                    taskModel.ManagerId = value != null ? value.ToString() : null;
                if (dic1.TryGetValue("UserId", out value))
                    taskModel.UserId = (value == null || string.IsNullOrWhiteSpace(value.ToString())) ? 0 : Convert.ToInt16(value);

                return taskModel;
            }

            return taskModel;
        }
        #endregion
    }
}
