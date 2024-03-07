using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class RegistrationOrders : Base<RegistrationOrdersModel>
  {
    protected internal RegistrationOrders(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<RegistrationOrdersModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public RegistrationOrdersModel Get(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      return base.Get(new { orgCode, orderNumber }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public RegistrationOrdersModel Update(RegistrationOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      return base.Update(new { model.OrganizationCode, model.OrderNumber }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public RegistrationOrdersModel Add(RegistrationOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to move multiple Registration Orders to a different event or a different function on the same event.  This process replicates the "Move Order" functionality found in Ungerboeck's "Registration Orders" window.  If one or more orders fails to move, this endpoint will return a MoveOrdersBulkErrorsModel object.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>If one or more orders fails to move, this endpoint will return a MoveOrdersBulkErrorsModel object.</returns>
    public IEnumerable<MoveOrdersBulkErrorsModel> MoveOrdersBulk(MoveOrdersBulkModel moveBulkRegistrationOrdersInfo, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      System.Threading.Tasks.Task<IEnumerable<MoveOrdersBulkErrorsModel>> moveOrdersBulkErrorsTask =
       PutAsync<MoveOrdersBulkModel, IEnumerable<MoveOrdersBulkErrorsModel>>
        (Client, "RegistrationOrders/MoveOrdersBulk", moveBulkRegistrationOrdersInfo, options);

      return CustomSync(moveOrdersBulkErrorsTask);
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to move Registration Orders a different event or a different function on the same event.  This process replicates the "Move Order" functionality found in Ungerboeck's "Registration Orders" window.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful, response error message on fail.</returns>
    public HttpResponseMessage MoveOrder(MoveOrderModel moveRegistrationOrderInfo, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<MoveOrderModel, HttpResponseMessage>(Client, "RegistrationOrders/MoveOrder", moveRegistrationOrderInfo, options);
      return CustomSync(response);
    }

    /// <summary>
    /// Custom endpoint.  Calculate Taxes on a registration order
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Single RegistrationOrdersModel with tax calculations. This does not add or edit an order.</returns>
    public RegistrationOrdersModel CalculateTaxes(RegistrationOrdersModel registrationOrder, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      System.Threading.Tasks.Task<RegistrationOrdersModel> registrationOrderTask = PostAsync(Client, "RegistrationOrders/CalculateTaxes", registrationOrder, options);
      return CustomSync(registrationOrderTask);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Ungerboeck.Api.Models.Bulk.BulkResponseModel Bulk(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      return base.BulkSync(bulkRequestModel, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Task<Ungerboeck.Api.Models.Bulk.BulkResponseModel> BulkAsync(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.RegistrationOrders options = null)
    {
      return base.BulkAsync(bulkRequestModel, options);
    }
  }
}
