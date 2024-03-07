using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Organizations : Base
  {
    public Organizations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OrganizationsModel Get(string orgCode)
    {
      return apiClient.Endpoints.Organizations.Get(orgCode);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OrganizationsModel> Search(string searchValue)
    {
      return apiClient.Endpoints.Organizations.Search($"{nameof(OrganizationsModel.OrganizationName)} eq '{searchValue}'");
    }
  }
}
