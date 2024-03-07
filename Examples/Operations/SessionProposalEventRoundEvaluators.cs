using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class SessionProposalEventRoundEvaluators : Base
  {
    public SessionProposalEventRoundEvaluators(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SessionProposalEventRoundEvaluatorsModel Get(int id)
    {
      return apiClient.Endpoints.SessionProposalEventRoundEvaluators.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SessionProposalEventRoundEvaluatorsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.SessionProposalEventRoundEvaluators.Search($"{nameof(SessionProposalEventRoundEvaluatorsModel.EvaluatorId)} eq {searchValue}");
    }
  }
}