using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventOpportunityFlowPattern : Base
  {
    public EventOpportunityFlowPattern(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunityFlowPatternModel Get(string orgCode, int meetingTourSequenceNbr, int flowSequenceNumber)
    {
      return apiClient.Endpoints.EventOpportunityFlowPattern.Get(orgCode, meetingTourSequenceNbr, flowSequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>  
    public SearchResponse<EventOpportunityFlowPatternModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.EventOpportunityFlowPattern.Search(orgCode, $"{nameof(EventOpportunityFlowPatternModel.FlowSequenceNumber)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for orgCode, meetingTourSequenceNbr, roomsBlocked
    /// </summary>  
    public EventOpportunityFlowPatternModel Add(string orgCode, int meetingTourSequenceNbr, int roomsBlocked)
    {
      EventOpportunityFlowPatternModel myEventOpportunityFlowPattern = new EventOpportunityFlowPatternModel
      {
        OrganizationCode = orgCode,
        FlowApplicationCode = "EVSALE",
        MeetingTourSequenceNbr = meetingTourSequenceNbr,
        FlowSequenceNumber = -1,
        FlowRecordType = "MH",
        FlowRecordLevel = "P",
        Date = System.DateTime.Now,
        RoomsBlocked = roomsBlocked
      };

      return apiClient.Endpoints.EventOpportunityFlowPattern.Add(myEventOpportunityFlowPattern);
    }

    /// <summary>
    /// A basic edit example for orgCode, meetingTourSequenceNbr, flowSequenceNumber, roomsBlocked
    /// </summary> 
    public EventOpportunityFlowPatternModel Edit(string orgCode, int meetingTourSequenceNbr, int flowSequenceNumber, int roomsBlocked)
    {
      EventOpportunityFlowPatternModel myEventOpportunityFlowPattern = apiClient.Endpoints.EventOpportunityFlowPattern.Get(orgCode, meetingTourSequenceNbr, flowSequenceNumber);
      myEventOpportunityFlowPattern.RoomsBlocked = roomsBlocked;

      return apiClient.Endpoints.EventOpportunityFlowPattern.Update(myEventOpportunityFlowPattern);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(string orgCode, int meetingTourSequenceNbr, int flowSequenceNumber)
    {
      return apiClient.Endpoints.EventOpportunityFlowPattern.Delete(orgCode, meetingTourSequenceNbr, flowSequenceNumber);
    }

  }
}
