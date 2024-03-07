using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models.Search;
using System;

/// <summary>
/// Find endpoint calls for this subject here.
/// </summary>
namespace Examples.Operations
{
  public class FunctionPerformingArts : Base
  {
    public FunctionPerformingArts(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="functionPerformingArtsId">The id of the Performing Art to get.</param>
    /// <returns>A single model for this subject.</returns>
    public FunctionPerformingArtsModel Get(int functionPerformingArtsId)
    {
      return apiClient.Endpoints.FunctionPerformingArts.Get(functionPerformingArtsId);
    }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="orgCode">Organization code of Function Performing Art</param>
    /// <param name="functionId">Function Id of Function Performing Art</param>
    /// <returns>A list of this subject's model.</returns>
    public SearchResponse<FunctionPerformingArtsModel> Search(string orgCode, int functionId)
    {
      return apiClient.Endpoints.FunctionPerformingArts.Search($"{nameof(FunctionPerformingArtsModel.OrganizationCode)} eq '{orgCode}' AND {nameof(FunctionPerformingArtsModel.FunctionID)} eq {functionId}");
    }

    /// <summary>
    /// Add new Function Performing Art.
    /// </summary>
    /// <param name="orgCode">Organization code of Function Performing Art</param>
    /// <param name="functionId">Function Id of Function Performing Art</param>
    /// <param name="eventId">Event Id of Function Performing Art</param>
    /// <returns></returns>
    public FunctionPerformingArtsModel Add(string orgCode, int functionId, int eventId)
    {
      var performingArtsModel = new FunctionPerformingArtsModel()
      {
        OrganizationCode = orgCode,
        FunctionID = functionId,
        EventID = eventId
      };

      return apiClient.Endpoints.FunctionPerformingArts.Add(performingArtsModel);
    }

    /// <summary>
    /// Basic edit example
    /// </summary>
    /// <param name="performingArtsId">Performing Art to update</param>
    /// <param name="functionId">the Function Id of Performing Art to update</param>
    /// <param name="orgCode">the Organization Code of Performing Art to update</param>
    /// <param name="totalTicketsSold">the updated Total Tickets Sold of Performing Art</param>
    /// <returns></returns>
    public FunctionPerformingArtsModel Edit(int performingArtsId, int totalTicketsSold, int functionId, string orgCode)
    {
      FunctionPerformingArtsModel performingArtsModel = apiClient.Endpoints.FunctionPerformingArts.Get(performingArtsId);
      if (performingArtsModel != null)
      {
        performingArtsModel.FunctionID = functionId;
        performingArtsModel.OrganizationCode = orgCode;
        performingArtsModel.TotalTicketsSold = totalTicketsSold;
      }

      return apiClient.Endpoints.FunctionPerformingArts.Update(performingArtsModel);
    }

  }
}

