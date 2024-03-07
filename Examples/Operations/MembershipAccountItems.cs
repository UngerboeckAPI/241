using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class MembershipAccountItems: Base
  {
    public MembershipAccountItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MembershipAccountItemsModel Get(int id)
    {
      return apiClient.Endpoints.MembershipAccountItems.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MembershipAccountItemsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.MembershipAccountItems.Search($"{nameof(MembershipAccountItemsModel.AccountMembershipId)} eq {searchValue}");
    }
  }
}
