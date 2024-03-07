using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class EventExternalIds : Base
  {
    public EventExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.EventExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public EventExternalIdsModel Add(int externalSystem, string organization, int eventId, long numericId)
    {
      var myEventExternalId = new EventExternalIdsModel
      {
        ExternalSystem = externalSystem,
        Organization = organization,
        Event = eventId,
        NumericID = numericId
      };

      return apiClient.Endpoints.EventExternalIds.Add(myEventExternalId);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public EventExternalIdsModel Add(int externalSystem, string organization, int eventId, string textId)
    {
      var myEventExternalId = new EventExternalIdsModel
      {
        ExternalSystem = externalSystem,
        Organization = organization,
        Event = eventId,
        TextID = textId
      };

      return apiClient.Endpoints.EventExternalIds.Add(myEventExternalId);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public EventExternalIdsModel Edit(int id, long newNumericId)
    {
      var myEventExternalId = apiClient.Endpoints.EventExternalIds.Get(id);
      myEventExternalId.NumericID = newNumericId;

      return apiClient.Endpoints.EventExternalIds.Update(myEventExternalId);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public EventExternalIdsModel Edit(int id, string newTextId)
    {
      var myEventExternalId = apiClient.Endpoints.EventExternalIds.Get(id);
      myEventExternalId.TextID = newTextId;

      return apiClient.Endpoints.EventExternalIds.Update(myEventExternalId);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.EventExternalIds.Delete(id);
    }

  }
}

