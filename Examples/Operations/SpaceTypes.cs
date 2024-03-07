using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceTypes : Base
  {
    public SpaceTypes(ApiClient apiClient) : base(apiClient) { }
    
    public SpaceTypesModel Get(string code)
    {
      return apiClient.Endpoints.SpaceTypes.Get(code);
    }

    public SearchResponse<SpaceTypesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.SpaceTypes.Search($"substringof('{searchValue}', {nameof(SpaceTypesModel.Description)})");
    }
  }
}
