using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class EventOpportunityRevenue : Base
  {
    public EventOpportunityRevenue(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunityRevenueModel Get(int id)
    {
      return apiClient.Endpoints.EventOpportunityRevenue.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunityRevenueModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventOpportunityRevenue.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    public EventOpportunityRevenueModel Add(string organization,int eventOpportunity, string category,int forecast, int minimum, bool contracted)
    {
      var revenue = new EventOpportunityRevenueModel
      {
        OrganizationCode = organization,
        EventOpportunity = eventOpportunity,
        Category = category,
        Forecast = forecast,
        Minimum = minimum,
        Contracted = contracted
      };

      return apiClient.Endpoints.EventOpportunityRevenue.Add(revenue);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public EventOpportunityRevenueModel Edit(int id, int newForecast)
    {
      var revenue = apiClient.Endpoints.EventOpportunityRevenue.Get(id);
      revenue.Forecast = newForecast;

      return apiClient.Endpoints.EventOpportunityRevenue.Update(revenue);
    }
  }
}
