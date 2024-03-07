using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class EventOpportunityGuestRoomFlow: Base
  {
    public EventOpportunityGuestRoomFlow(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunityGuestRoomFlowModel Get(int id)
    {
      return apiClient.Endpoints.EventOpportunityGuestRoomFlow.Get(id);
    }

    /// <summary>
    /// A basic search to find all Guest Room Flow records on a specific Event Opportunity.
    /// </summary> 
    public SearchResponse<EventOpportunityGuestRoomFlowModel> SearchByEventOpportunity(string orgCode, int eventOpportunity)
    {
      return apiClient.Endpoints.EventOpportunityGuestRoomFlow.Search(
        String.Empty, 
        $"{nameof(EventOpportunityGuestRoomFlowModel.OrganizationCode)} eq '{orgCode}' and {nameof(EventOpportunityGuestRoomFlowModel.EventOpportunity)} eq {eventOpportunity}");
    }

    /// <summary>
    /// A basic edit example, modifying the editable field 'Requested'
    /// </summary> 
    public EventOpportunityGuestRoomFlowModel UpdateRoomsRequested(int id, int newRoomRequested)
    {
      var guestRoomFlow = apiClient.Endpoints.EventOpportunityGuestRoomFlow.Get(id);

      guestRoomFlow.Requested = newRoomRequested;

      return apiClient.Endpoints.EventOpportunityGuestRoomFlow.Update(guestRoomFlow);
    }
  }
}
