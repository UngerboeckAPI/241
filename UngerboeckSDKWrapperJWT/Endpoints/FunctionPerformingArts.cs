using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;


namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class FunctionPerformingArts : Base<FunctionPerformingArtsModel>
  {

    protected internal FunctionPerformingArts(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<FunctionPerformingArtsModel> Search(string searchOData, Search options = null)
    {
      return base.Search(null, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="id">The id of the Performing Art to Get.</param>
    /// <returns>A single model for this subject.</returns>
    public FunctionPerformingArtsModel Get(int id)
    {
      return base.Get(new { id });
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public FunctionPerformingArtsModel Update(FunctionPerformingArtsModel model)
    {
      return base.Update(new { model.ID }, model);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public FunctionPerformingArtsModel Add(FunctionPerformingArtsModel model, Ungerboeck.Api.Models.Options.Subjects.FunctionPerformingArts options = null)
    {
      return base.Add(model, options);
    }
  }
}
