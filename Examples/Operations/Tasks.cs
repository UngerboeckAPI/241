using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace Examples.Operations
{
  public class Tasks : Base
  {
    public Tasks(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public TasksModel Get(int taskID)
    {
      return apiClient.Endpoints.Tasks.Get(taskID);
    }

    /// <summary>
    /// An example of retrieving a specific task's data
    /// </summary>
    /// <param name="taskID"></param>
    public SearchResponse<TasksModel> Search(int taskID)
    {
      return apiClient.Endpoints.Tasks.Search($"{nameof(TasksModel.ID)} eq {taskID}");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<TasksModel> SearchByOrgCodeAndDescription(string orgCode, string description)
    {
      return apiClient.Endpoints.Tasks.Search($"{nameof(TasksModel.OrganizationCode)} eq '{orgCode}' AND {nameof(TasksModel.Description)} eq '{description}'");
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    public TasksModel Edit(int taskId, int status)
    {
      var myTask = apiClient.Endpoints.Tasks.Get(taskId);

      myTask.Status = status; // Use USISDKConstants.TaskStatus to get the list of task statuses

      return apiClient.Endpoints.Tasks.Update(myTask);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    public TasksModel Edit(TasksModel myTask)
    {
      return apiClient.Endpoints.Tasks.Update(myTask);
    }
    public TasksModel EditAdvanced(string orgCode, int taskId)
    {
      var myTask = apiClient.Endpoints.Tasks.Get(taskId);

      myTask.Description = "A modified task description";
      myTask.AlternateDescription1 = "A modified task description 1";
      myTask.AlternateDescription2 = "A modified task description 2";
      myTask.AlternateDescription3 = "A modified task description 3";
      myTask.AlternateDescription4 = "A modified task description 4";
      myTask.AlternateDescription5 = "A modified task description 5";

      myTask.Title = "Changed Title on a Task";
      myTask.AlternateTitle1 = "Changed Title on a Task 1";
      myTask.AlternateTitle2 = "Changed Title on a Task 2";
      myTask.AlternateTitle3 = "Changed Title on a Task 3";
      myTask.AlternateTitle4 = "Changed Title on a Task 4";
      myTask.AlternateTitle5 = "Changed Title on a Task 5";

      myTask.Status = USISDKConstants.TaskStatus.InProgress;// Use USISDKConstants.TaskStatus to get the list of task statuses
      myTask.AllowApproval = "Y"; // Y or N
      myTask.EPCategory = 21; // Event Portal Category Id

      return apiClient.Endpoints.Tasks.Update(myTask);
    }

    /// <summary>
    /// A basic add example with minimum required fields.
    /// </summary>
    public TasksModel Add(string orgCode, int eventId, string title, int type, int status)
    {
      var myTask = new TasksModel
      {
        OrganizationCode = orgCode,
        Event = eventId,
        Title = title,
        Type = type, // Use USISDKConstants.TaskType to get the list of task types
        Status = status // Use USISDKConstants.TaskStatus to get the list of task statuses
      };

      return apiClient.Endpoints.Tasks.Add(myTask);

    }

    /// <summary>
    /// A basic add example with a contstructed tasks model.
    /// </summary>
    public TasksModel Add(TasksModel myTask)
    {
      return apiClient.Endpoints.Tasks.Add(myTask);
    }


    /// <summary>
    /// A basic delete task example.
    /// </summary>
    public void Delete(int taskId)
    {
      apiClient.Endpoints.Tasks.Delete(taskId);
    }
  }
}
