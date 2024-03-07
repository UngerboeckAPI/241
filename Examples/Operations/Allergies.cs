using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;

namespace Examples.Operations
{
  public class Allergies : Base
  {
    public Allergies(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public AllergiesModel Get(int ID)
    {
      return apiClient.Endpoints.Allergies.Get(ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<AllergiesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.Allergies.Search($"{nameof(AllergiesModel.Description)} eq '{searchValue}'");
    }
  }
}
