using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Subjects.Checklist;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class EventOpportunities : Base<EventOpportunitiesModel>
  {
    protected internal EventOpportunities(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<EventOpportunitiesModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public EventOpportunitiesModel Get(string orgCode, int meetingSequence, Ungerboeck.Api.Models.Options.Subjects.EventOpportunities options = null)
    {
      return base.Get(new { orgCode, meetingSequence }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public EventOpportunitiesModel Update(EventOpportunitiesModel model, Ungerboeck.Api.Models.Options.Subjects.EventOpportunities options = null)
    {
      return base.Update(new { model.Organization, model.MeetingSequence }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public EventOpportunitiesModel Add(EventOpportunitiesModel model, Ungerboeck.Api.Models.Options.Subjects.EventOpportunities options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Custom endpoint.  Create a new Event from an existing event opportunity.
    /// </summary>
    /// <param name="orgCode">The organization code of the event opportunity.</param>
    /// <param name="meetingSequence">The sequence of the event opportunity.</param>
    /// <returns>Newly added EventOpportunitiesModel</returns>
    public EventsModel CreateEvent(string orgCode, int meetingSequence, Ungerboeck.Api.Models.Options.Subjects.EventOpportunities options = null)
    {
      var task = CreateEventAsync(orgCode, meetingSequence, options);
      return CustomSync(task);
    }

    /// <summary>
    /// Custom endpoint.  Create a new Event from an existing event opportunity.
    /// </summary>
    /// <param name="orgCode">The organization code of the event opportunity.</param>
    /// <param name="meetingSequence">The sequence of the event opportunity.</param>
    /// <returns>Newly added EventOpportunitiesModel</returns>
    public Task<EventsModel> CreateEventAsync(string orgCode, int meetingSequence, Ungerboeck.Api.Models.Options.Subjects.EventOpportunities options = null)
    {
      object item = null; //This endpoint does not have a posted item
      Task<EventsModel> response = PostAsync<object, EventsModel>(Client, $"EventOpportunities/{orgCode}/{meetingSequence}/CreateEvent", item, options);
      return response;
    }

    /// <summary>
    /// Add Checklist
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpResponseMessage indicating success</returns>
    public HttpResponseMessage AddChecklist(string orgCode, int meetingSequenceId, AddChecklistModel model, Ungerboeck.Api.Models.Options.Subjects.EventOpportunities options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<AddChecklistModel, HttpResponseMessage>(Client, $"EventOpportunities/{orgCode}/{meetingSequenceId}/AddChecklist", model, options);

      return CustomSync(response);
    }

  }
}
