using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Examples.Operations
{
  public class EventProfiles : Base
  {
    public EventProfiles(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventProfilesModel Get(string orgCode, int eventID)
    {
      return apiClient.Endpoints.EventProfiles.Get(orgCode, eventID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventProfilesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventProfiles.Search(orgCode, $"{nameof(EventProfilesModel.Description)} eq '{searchValue}'");
    }
  }
}
