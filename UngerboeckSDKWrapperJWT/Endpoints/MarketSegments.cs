using Ungerboeck.Api.Models.Options;
using Ungerboeck.Api.Models.Subjects;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class MarketSegments : Base<MarketSegmentsModel>
  {
    protected internal MarketSegments(ApiClient api) : base(api)
    {
    }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<MarketSegmentsModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public MarketSegmentsModel Get(string orgCode, string major, string minor, Ungerboeck.Api.Models.Options.Subjects.MarketSegments options = null)
    {
      return base.Get(new { orgCode, major, minor }, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public MarketSegmentsModel Add(MarketSegmentsModel model, Ungerboeck.Api.Models.Options.Subjects.MarketSegments options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public MarketSegmentsModel Update(MarketSegmentsModel model, Ungerboeck.Api.Models.Options.Subjects.MarketSegments options = null)
    {
      string orgCode = "10"; // Defaulting it to 10. Org code is no longer used for market segments but the PUT endpoint URL has orgCode as a parameter.
      return base.Update(new { orgCode, model.Major, model.Minor }, model, options);
    }
  }
}