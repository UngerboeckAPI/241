using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;
using Ungerboeck.Api.Models.Bulk;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class MeetingAttendees : Base
  {
    public MeetingAttendees(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MeetingAttendeesModel Get(int id)
    {
      return apiClient.Endpoints.MeetingAttendees.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MeetingAttendeesModel> Search(string propertyToSearchBy, string searchValue)
    {
      return apiClient.Endpoints.MeetingAttendees.Search(String.Empty, $"{propertyToSearchBy} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example for OrgCode, EventId, FirstName, LastName
    /// </summary>  
    public MeetingAttendeesModel Add(string orgCode, int eventId, string firstName, string lastName)
    {
      var myMeetingAttendee = new MeetingAttendeesModel
      {
        Organization = orgCode,
        Event = eventId,
        FirstName = firstName,
        LastName = lastName
      };

      return apiClient.Endpoints.MeetingAttendees.Add(myMeetingAttendee);
    }

    /// <summary>
    /// A basic edit example for ID, FirstName
    /// </summary> 
    public MeetingAttendeesModel Edit(int id, string newFirstName)
    {
      var myMeetingAttendee = apiClient.Endpoints.MeetingAttendees.Get(id);
      myMeetingAttendee.FirstName = newFirstName;

      return apiClient.Endpoints.MeetingAttendees.Update(myMeetingAttendee);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.MeetingAttendees.Delete(id);
    }


    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="meetingAttendeesModel1">This contains a standard MeetingAttendeesModel object.  
    ///                                         A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="meetingAttendeesModel2">This contains a standard MeetingAttendeesModel object.  
    ///                                        A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  
    ///                               If you are submitting a list of unrelated items to save, set this as false and the bulk save process 
    ///                               will attempt to continue saving if an item fails to save.  Note that certain errors will always result 
    ///                               in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(MeetingAttendeesModel meetingAttendeesModel1,
                                  string bulkOperation1,
                                  MeetingAttendeesModel meetingAttendeesModel2,
                                  string bulkOperation2,
                                  bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  
       * Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = meetingAttendeesModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = meetingAttendeesModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      return apiClient.Endpoints.MeetingAttendees.Bulk(myBulkRequest);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Task<BulkResponseModel> BulkAsync(MeetingAttendeesModel meetingAttendeesModel1,
                                             string bulkOperation1,
                                             MeetingAttendeesModel meetingAttendeesModel2,
                                             string bulkOperation2,
                                             bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  
       * Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = meetingAttendeesModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = meetingAttendeesModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      return apiClient.Endpoints.MeetingAttendees.BulkAsync(myBulkRequest);

    }

  }
}
