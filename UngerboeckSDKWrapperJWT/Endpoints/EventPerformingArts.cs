using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;


namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class EventPerformingArts : Base<EventPerformingArtsModel>
  {

    protected internal EventPerformingArts(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <returns>A list of this subject's model.</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<EventPerformingArtsModel> Search(string searchOData)
    {
      return base.Search(null, searchOData);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="id">The id of the Performing Art to Get.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public EventPerformingArtsModel Get(int id, Ungerboeck.Api.Models.Options.Subjects.EventPerformingArts options = null)
    {
      return base.Get(new { id }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public EventPerformingArtsModel Update(EventPerformingArtsModel model, Ungerboeck.Api.Models.Options.Subjects.EventPerformingArts options = null)
    {
      return base.Update(new { model.PerformingArtID }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public EventPerformingArtsModel Add(EventPerformingArtsModel model, Ungerboeck.Api.Models.Options.Subjects.EventPerformingArts options = null)
    {
      return base.Add(model, options);
    }
  }
}
