using System.Net.Http;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class OrderAllergies : Base
  {
    public OrderAllergies(ApiClient apiClient): base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OrderAllergiesModel Get(int ID)
    {
      return apiClient.Endpoints.OrderAllergies.Get(ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OrderAllergiesModel> SearchByOrder(string orgCode, int orderNumber)
    {
      string oDataSearch = $"{nameof(OrderAllergiesModel.OrganizationCode)} eq '{orgCode}' and {nameof(OrderAllergiesModel.OrderNumber)} eq {orderNumber}";

      return apiClient.Endpoints.OrderAllergies.Search(oDataSearch);
    }

    /// <summary>
    /// Add a single Order Allergy to an existing Order
    /// </summary>
    /// <param name="profileAllergyID"></param>
    /// <param name="orgCode"></param>
    /// <param name="orderNumber"></param>
    public OrderAllergiesModel Add(int profileAllergyID, string orgCode, int orderNumber)
    {
      OrderAllergiesModel myOrderAllergy = new OrderAllergiesModel
      {
        ProfileAllergyID = profileAllergyID,
        OrganizationCode = orgCode,
        OrderNumber = orderNumber
      };

      return apiClient.Endpoints.OrderAllergies.Add(myOrderAllergy);
    }

    /// <summary>
    /// Remove an Order Allergy from an existing Order
    /// </summary>  
    /// <param name="ID">The Order Allergy ID to delete</param>
    /// <returns>Nothing if successful.</returns>
    public HttpResponseMessage Delete(int ID)
    {
      return apiClient.Endpoints.OrderAllergies.Delete(ID);
    }
  }
}
