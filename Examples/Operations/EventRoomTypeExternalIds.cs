using System;
using System.Net.Http;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class EventRoomTypeExternalIds : Base
  {
    public EventRoomTypeExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventRoomTypeExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.EventRoomTypeExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventRoomTypeExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventRoomTypeExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public EventRoomTypeExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string roomType, long numericId)
    {
      var myExternalSystem = new EventRoomTypeExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        RoomType = roomType,
        NumericID = numericId
      };

      return apiClient.Endpoints.EventRoomTypeExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public EventRoomTypeExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string roomType, string textId)
    {
      var myExternalSystem = new EventRoomTypeExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        RoomType = roomType,
        TextID = textId
      };

      return apiClient.Endpoints.EventRoomTypeExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public EventRoomTypeExternalIdsModel Edit(int id, long newNumericId)
    {
      var myExternalSystem = apiClient.Endpoints.EventRoomTypeExternalIds.Get(id);
      myExternalSystem.NumericID = newNumericId;

      return apiClient.Endpoints.EventRoomTypeExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public EventRoomTypeExternalIdsModel Edit(int id, string newTextId)
    {
      var myExternalSystem = apiClient.Endpoints.EventRoomTypeExternalIds.Get(id);
      myExternalSystem.TextID = newTextId;

      return apiClient.Endpoints.EventRoomTypeExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.EventRoomTypeExternalIds.Delete(id);
    }
  }
}
