using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class EventOpportunityExternalIds : Base
  {
    public EventOpportunityExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunityExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.EventOpportunityExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunityExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventOpportunityExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public EventOpportunityExternalIdsModel Add(int externalSystem, string organization, int eventOpportunity, long numericId)
    {
      var myEventOpportunityExternalId = new EventOpportunityExternalIdsModel
      {
        ExternalSystem = externalSystem,
        Organization = organization,
        EventOpportunity = eventOpportunity,
        NumericID = numericId
      };

      return apiClient.Endpoints.EventOpportunityExternalIds.Add(myEventOpportunityExternalId);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public EventOpportunityExternalIdsModel Add(int externalSystem, string organization, int eventOpportunity, string textId)
    {
      var myEventOpportunityExternalId = new EventOpportunityExternalIdsModel
      {
        ExternalSystem = externalSystem,
        Organization = organization,
        EventOpportunity = eventOpportunity,
        TextID = textId
      };

      return apiClient.Endpoints.EventOpportunityExternalIds.Add(myEventOpportunityExternalId);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public EventOpportunityExternalIdsModel Edit(int id, long newNumericId)
    {
      var myEventOpportunityExternalId = apiClient.Endpoints.EventOpportunityExternalIds.Get(id);
      myEventOpportunityExternalId.NumericID = newNumericId;

      return apiClient.Endpoints.EventOpportunityExternalIds.Update(myEventOpportunityExternalId);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public EventOpportunityExternalIdsModel Edit(int id, string newTextId)
    {
      var myEventOpportunityExternalId = apiClient.Endpoints.EventOpportunityExternalIds.Get(id);
      myEventOpportunityExternalId.TextID = newTextId;

      return apiClient.Endpoints.EventOpportunityExternalIds.Update(myEventOpportunityExternalId);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.EventOpportunityExternalIds.Delete(id);
    }
  }
}
