using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class MarketSegments : Base
  {
    public MarketSegments(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public MarketSegmentsModel Get(string orgCode, string major, string minor)
    {
      return apiClient.Endpoints.MarketSegments.Get(orgCode, major, minor);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>
    public SearchResponse<MarketSegmentsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MarketSegments.Search(orgCode, $"{nameof(MarketSegmentsModel.Major)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example.
    /// </summary>
    /// <param name="major">The first part of the market segment code usually referred to as the major segment code</param>
    /// <param name="minor">The second part of the market segment code usually referred to as the minor segment code</param>
    /// <param name="description">Contains the description for this market segment.</param>
    /// <returns>A newly added, single Market Segment.</returns>
    public MarketSegmentsModel Add(string major, string minor, string description)
    {
      MarketSegmentsModel marketSegmentsModel = new MarketSegmentsModel()
      {
        Major = major,
        Minor = minor,
        Description = description
      };

      return apiClient.Endpoints.MarketSegments.Add(marketSegmentsModel);
    }

    /// <summary>
    /// A basic edit example.
    /// </summary>
    /// <param name="major">The first part of the market segment code usually referred to as the major segment code</param>
    /// <param name="minor">The second part of the market segment code usually referred to as the minor segment code</param>
    /// <param name="description">Contains the description for this market segment.</param>
    /// <returns>An updated, single Market Segment</returns>
    public MarketSegmentsModel Edit(string major, string minor, string description)
    {
      MarketSegmentsModel marketSegmentsModel = apiClient.Endpoints.MarketSegments.Get("10", major, minor); // Org code is no longer used for Market Segments. Defaulting it to 10.
      if (marketSegmentsModel != null)
      {
        marketSegmentsModel.Description = description;
      }

      return apiClient.Endpoints.MarketSegments.Update(marketSegmentsModel);
    }
  }
}