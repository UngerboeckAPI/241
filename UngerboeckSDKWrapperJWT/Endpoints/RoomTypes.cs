using System.Net.Http;
using Ungerboeck.Api.Models.Options;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class RoomTypes : Base<RoomTypesModel>
  {
    protected internal RoomTypes(ApiClient api) : base(api) { }

    public new Ungerboeck.Api.Models.Search.SearchResponse<RoomTypesModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="organizationCode">Organization code</param>
    /// <param name="code">Room type</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public RoomTypesModel Get(string organizationCode, string code, Ungerboeck.Api.Models.Options.Subjects.RoomTypes options = null)
    {
      return base.Get(new { organizationCode, code }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject. Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public RoomTypesModel Update(RoomTypesModel model, Ungerboeck.Api.Models.Options.Subjects.RoomTypes options = null)
    {
      return base.Update(new { model.OrganizationCode, model.Code }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject. Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public RoomTypesModel Add(RoomTypesModel model, Ungerboeck.Api.Models.Options.Subjects.RoomTypes options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Use this endpoint to delete a single entry of this subject.
    /// </summary>
    /// <param name="organizationCode">Organization code.</param>
    /// <param name="code">Room type.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public HttpResponseMessage Delete(string organizationCode, string code, Ungerboeck.Api.Models.Options.Subjects.RoomTypes options = null)
    {
      return base.Delete(new { organizationCode, code }, options);
    }
  }
}