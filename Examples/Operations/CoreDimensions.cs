using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CoreDimensions : Base
  {
    public CoreDimensions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CoreDimensionsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.CoreDimensions.Get(orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CoreDimensionsModel> Search(string orgCode, string searchValue)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[CoreDimensionDetails]" } };
      return apiClient.Endpoints.CoreDimensions.Search(orgCode, $"{nameof(CoreDimensionsModel.LabelName)} eq '{searchValue}'", options);
    }

    public SearchResponse<CoreDimensionsModel> GetWithCoreDimensionDetails(string orgCode, string code)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[CoreDimensionDetails]" } };
      return apiClient.Endpoints.CoreDimensions.Search(orgCode, $"{nameof(CoreDimensionsModel.Code)} eq '{code}'", options);
    }
  }
}



