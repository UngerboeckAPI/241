using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLAccountAnalysisCodes : Base
  {
    public GLAccountAnalysisCodes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public GLAccountAnalysisCodesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.GLAccountAnalysisCodes.Get(orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GLAccountAnalysisCodesModel> Search(string orgCode, string searchValue)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[GLAccountAnalysisCodeDetails]" } };
      return apiClient.Endpoints.GLAccountAnalysisCodes.Search(orgCode, $"{nameof(GLAccountAnalysisCodesModel.LabelName)} eq '{searchValue}'", options);
    }

    public SearchResponse<GLAccountAnalysisCodesModel> GetWithAccountAnalysisCodeDetails(string orgCode, string code)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[GLAccountAnalysisCodeDetails]" } };
      return apiClient.Endpoints.GLAccountAnalysisCodes.Search(orgCode, $"{nameof(GLAccountAnalysisCodesModel.Code)} eq '{code}'", options);
    }

  }
}



