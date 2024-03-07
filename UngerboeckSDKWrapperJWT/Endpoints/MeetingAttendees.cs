using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class MeetingAttendees : Base<MeetingAttendeesModel>
  {
    protected internal MeetingAttendees(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<MeetingAttendeesModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(string.Empty, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public MeetingAttendeesModel Get(int id, Ungerboeck.Api.Models.Options.Subjects.MeetingAttendees options = null)
    {
      return base.Get(new { id }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public MeetingAttendeesModel Update(MeetingAttendeesModel model, Ungerboeck.Api.Models.Options.Subjects.MeetingAttendees options = null)
    {
      return base.Update(new { model.ID }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public MeetingAttendeesModel Add(MeetingAttendeesModel model, Ungerboeck.Api.Models.Options.Subjects.MeetingAttendees options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Use this endpoint to delete a single entry of this subject.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public HttpResponseMessage Delete(int id, Ungerboeck.Api.Models.Options.Subjects.MeetingAttendees options = null)
    {
      return base.Delete(new { id }, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Ungerboeck.Api.Models.Bulk.BulkResponseModel Bulk(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.MeetingAttendees options = null)
    {
      return base.BulkSync(bulkRequestModel, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Task<Ungerboeck.Api.Models.Bulk.BulkResponseModel> BulkAsync(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.MeetingAttendees options = null)
    {
      return base.BulkAsync(bulkRequestModel, options);
    }

  }
}
