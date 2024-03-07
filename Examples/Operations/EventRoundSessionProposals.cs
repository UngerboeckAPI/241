using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class EventRoundSessionProposals : Base
  {
    public EventRoundSessionProposals(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventRoundSessionProposalsModel Get(int id)
    {
      return apiClient.Endpoints.EventRoundSessionProposals.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventRoundSessionProposalsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.EventRoundSessionProposals.Search($"{nameof(EventRoundSessionProposalsModel.SessionProposal)} eq {searchValue}");
    }
  }
}