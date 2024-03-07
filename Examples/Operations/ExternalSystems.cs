using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class ExternalSystems : Base
  {
    public ExternalSystems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExternalSystemsModel Get(int id)
    {
      return apiClient.Endpoints.ExternalSystems.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExternalSystemsModel> Search(string propertyToSearchBy, string searchValue)
    {
      return apiClient.Endpoints.ExternalSystems.Search(String.Empty, $"{propertyToSearchBy} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example for OrgCode, Description
    /// </summary>  
    public ExternalSystemsModel Add(string orgCode, string description)
    {
      var myExternalSystem = new ExternalSystemsModel
      {
        Organization = orgCode,
        Description = description
      };

      return apiClient.Endpoints.ExternalSystems.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Description
    /// </summary> 
    public ExternalSystemsModel Edit(int id, string newDescription)
    {
      var myExternalSystem = apiClient.Endpoints.ExternalSystems.Get(id);
      myExternalSystem.Description = newDescription;

      return apiClient.Endpoints.ExternalSystems.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.ExternalSystems.Delete(id);
    }
  }
}
