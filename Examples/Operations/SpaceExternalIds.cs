using System;
using System.Net.Http;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class SpaceExternalIds : Base
  {
    public SpaceExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.SpaceExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.SpaceExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public SpaceExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string spaceCode, long numericId)
    {
      var myExternalSystem = new SpaceExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        SpaceCode = spaceCode,
        NumericID = numericId
      };

      return apiClient.Endpoints.SpaceExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public SpaceExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string spaceCode, string textId)
    {
      var myExternalSystem = new SpaceExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        SpaceCode = spaceCode,
        TextID = textId
      };

      return apiClient.Endpoints.SpaceExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public SpaceExternalIdsModel Edit(int id, long newNumericId)
    {
      var myExternalSystem = apiClient.Endpoints.SpaceExternalIds.Get(id);
      myExternalSystem.NumericID = newNumericId;

      return apiClient.Endpoints.SpaceExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public SpaceExternalIdsModel Edit(int id, string newTextId)
    {
      var myExternalSystem = apiClient.Endpoints.SpaceExternalIds.Get(id);
      myExternalSystem.TextID = newTextId;

      return apiClient.Endpoints.SpaceExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.SpaceExternalIds.Delete(id);
    }
  }
}
