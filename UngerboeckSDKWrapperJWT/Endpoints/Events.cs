using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using Ungerboeck.Api.Models.Search;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Subjects.Checklist;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class Events : Base<EventsModel>
  {
    protected internal Events(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new SearchResponse<EventsModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.SearchSync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Task<SearchResponse<EventsModel>> SearchAsync(string orgCode, string searchOData, Search options = null)
    {
      return base.SearchAsync(orgCode, searchOData, options);
    }


    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public EventsModel Get(string orgCode, int eventID, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      return base.GetSync(new { orgCode, eventID }, options);
    }

    /// <summary>
    /// Use this async endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public Task<EventsModel> GetAsync(string orgCode, int eventID, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      return base.GetAsync(new { orgCode, eventID }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public EventsModel Update(EventsModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      return base.UpdateSync(new { model.Organization, model.EventID }, model, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public Task<EventsModel> UpdateAsync(EventsModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      return base.UpdateAsync(new { model.Organization, model.EventID }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public EventsModel Add(EventsModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      return base.AddSync(model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public Task<EventsModel> AddAsync(EventsModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      return base.AddAsync(model, options);
    }

    /// <summary>
    /// Custom endpoint.  Add a new event from an event profile.
    /// </summary>
    /// <param name="data">(Include in the HTTP Body) A model of type AddFromEventProfileModel for configuration.</param>    
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Newly added EventsModel</returns>
    public EventsModel AddFromProfile(AddFromEventProfileModel eventProfile, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      var task = AddFromProfileAsync(eventProfile, options);
      return CustomSync(task);
    }

    /// <summary>
    /// Custom endpoint.  Add a new event from an event profile.
    /// </summary>
    /// <param name="data">(Include in the HTTP Body) A model of type AddFromEventProfileModel for configuration.</param>    
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Newly added EventsModel</returns>
    public Task<EventsModel> AddFromProfileAsync(AddFromEventProfileModel eventProfile, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {      
      Task<EventsModel> response = PostAsync<AddFromEventProfileModel, EventsModel>(Client, $"Events/AddFromProfile/", eventProfile, options);
      return response;
    }

    protected override void CollectValidationOverridesFromOptions(ref List<int> validationOverrides, Dictionary<string, string> headers, Ungerboeck.Api.Models.Options.Base baseOptions)
    {
      var options = GetOptions<Models.Options.Subjects.Events>(baseOptions);      
      SetValidation(validationOverrides, options?.BypassBookingConflictCheck, ValidationCodes.BypassBookingConflictCheck);         
      SetValidation(validationOverrides, options?.BypassBookingSameEventConflictCheck, ValidationCodes.BypassBookingSameEventConflictCheck);         
    }

    /// <summary>
    /// Custom endpoint. Use this endpoint to restore a cancelled event.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that all model properties required.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public EventsModel Restore(EventRestoreModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      var task = RestoreAsync(model, options);

      return CustomSync(task);
    }

    /// <summary>
    /// Custom endpoint. Use this endpoint to restore a cancelled event.
    /// </summary>
    /// <param name="model">This should contain a filled model of type EventRestoreModel.  Note that all model properties required.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public Task<EventsModel> RestoreAsync(EventRestoreModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      Task<EventsModel> response = PutAsync<EventRestoreModel, EventsModel>(Client, $"Events/Restore/", model, options);

      return response;
    }

    public string GetLogo(string orgCode, int eventID, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      Task<HttpResponseMessage> logoBytesTask = 
        base.GetAsync<HttpResponseMessage>(Client, $"Events/GetLogo/{orgCode}/{eventID}", options);
      var task = GetResponseContentAsString(logoBytesTask);
      return task.Result;
    }

    /// <summary>
    /// Add Checklist
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpResponseMessage indicating success</returns>
    public HttpResponseMessage AddChecklist(string orgCode, int eventId, AddChecklistModel model, Ungerboeck.Api.Models.Options.Subjects.Events options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<AddChecklistModel, HttpResponseMessage>(Client, $"Events/{orgCode}/{eventId}/AddChecklist", model, options);

      return CustomSync(response);
    }

  }
}
