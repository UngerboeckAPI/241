using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models.Search;
using System;

/// <summary>
/// Find endpoint calls for this subject here.
/// </summary>
namespace Examples.Operations
{
  public class EventPerformingArts : Base
  {
    public EventPerformingArts(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="eventPerformingArtsId">The id of the Performing Art to get.</param>
    /// <returns>A single model for this subject.</returns>
    public EventPerformingArtsModel Get(int eventPerformingArtsId)
    {
      return apiClient.Endpoints.EventPerformingArts.Get(eventPerformingArtsId);
    }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="orgCode">Organization code of Event Performing Art</param>
    /// <param name="eventId">Event Id of Event Performing Art</param>
    /// <returns>A list of this subject's model.</returns>
    public SearchResponse<EventPerformingArtsModel> Search(string orgCode, int eventId)
    {
      return apiClient.Endpoints.EventPerformingArts.Search($"{nameof(EventPerformingArtsModel.OrganizationCode)} eq '{orgCode}' AND {nameof(EventPerformingArtsModel.EventId)} eq {eventId}");
    }

    /// <summary>
    /// Add new Event Performing Art.
    /// </summary>
    /// <param name="orgCode">Organization code of Event Performing Art</param>
    /// <param name="eventId">Event Id of Event Performing Art</param>
    /// <returns></returns>
    public EventPerformingArtsModel Add(string orgCode, int eventId)
    {
      var performingArtsModel = new EventPerformingArtsModel()
      {
        OrganizationCode = orgCode,
        EventId = eventId
      };

      return apiClient.Endpoints.EventPerformingArts.Add(performingArtsModel);
    }

    /// <summary>
    /// Basic edit example
    /// </summary>
    /// <param name="performingArtsId">Performing Art to update</param>
    /// <param name="eventId">the Event Id of Performing Art to update</param>
    /// <param name="orgCode">the Organization Code of Performing Art to update</param>
    /// <param name="totalTicketsSold">updated Total Tickets Sold of Event Performing Art</param>
    /// <returns></returns>
    public EventPerformingArtsModel Edit(int performingArtsId, int totalTicketsSold, int eventId, string orgCode)
    {
      EventPerformingArtsModel performingArtsModel = apiClient.Endpoints.EventPerformingArts.Get(performingArtsId);
      if (performingArtsModel != null)
      {
        performingArtsModel.EventId = eventId;
        performingArtsModel.OrganizationCode = orgCode;
        performingArtsModel.TotalTicketsSold = totalTicketsSold;
      }

      return apiClient.Endpoints.EventPerformingArts.Update(performingArtsModel);
    }

  }
}

