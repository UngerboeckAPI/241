using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ManagementReportCodes : Base
  {
    public ManagementReportCodes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ManagementReportCodesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.ManagementReportCodes.Get(orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ManagementReportCodesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.ManagementReportCodes.Search(orgCode, $"{nameof(ManagementReportCodesModel.Code)} eq '{searchValue}'");
    }

  }
}



