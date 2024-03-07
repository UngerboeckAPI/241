using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class States : Base
  {
    public States(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public StatesModel Get(string countryCode, string code)
    {
      return apiClient.Endpoints.States.Get(countryCode, code);
    }

    public StatesModel GetWithSelect(string countryCode, string code)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.States { Select = { nameof(StatesModel.Name) } };
      return apiClient.Endpoints.States.Get(countryCode, code, options);
    }


    /// <summary>
    /// A search example. Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<StatesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.States.Search($"{nameof(StatesModel.CountryCode)} eq '{searchValue}'");
    }
  }
}