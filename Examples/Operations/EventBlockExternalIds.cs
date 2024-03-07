using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class EventBlockExternalIds : Base
  {
    public EventBlockExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventBlockExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.EventBlockExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventBlockExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventBlockExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public EventBlockExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, int eventId, long numericId, string blockId)
    {
      var myEventExternalId = new EventBlockExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        EventIdRef = eventId,
        NumericID = numericId,
        BlockId = blockId
      };

      return apiClient.Endpoints.EventBlockExternalIds.Add(myEventExternalId);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public EventBlockExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, int eventId, string blockId, string textId)
    {
      var myEventExternalId = new EventBlockExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        EventIdRef = eventId,
        BlockId = blockId,
        TextID = textId
      };

      return apiClient.Endpoints.EventBlockExternalIds.Add(myEventExternalId);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public EventBlockExternalIdsModel Edit(int id, long newNumericId)
    {
      var myEventExternalId = apiClient.Endpoints.EventBlockExternalIds.Get(id);
      myEventExternalId.NumericID = newNumericId;

      return apiClient.Endpoints.EventBlockExternalIds.Update(myEventExternalId);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public EventBlockExternalIdsModel Edit(int id, string newTextId)
    {
      var myEventExternalId = apiClient.Endpoints.EventBlockExternalIds.Get(id);
      myEventExternalId.TextID = newTextId;

      return apiClient.Endpoints.EventBlockExternalIds.Update(myEventExternalId);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.EventBlockExternalIds.Delete(id);
    }

  }
}
