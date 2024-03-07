﻿using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Bulk;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class RegistrationOrders : Base
  {
    public RegistrationOrders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RegistrationOrdersModel Get(string orgCode, int orderNumber)
    {
      return apiClient.Endpoints.RegistrationOrders.Get( orgCode, orderNumber);
    }

    /// <summary>
    /// You can retrieve orders attached to order items by utilizing the Select ability of the odata string.  Be sure to include the [], as this denotes it's a nested model.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<RegistrationOrdersModel> GetWithOrderItems(string orgCode, int orderNumber)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[RegistrationOrderItems]" } };
      return apiClient.Endpoints.RegistrationOrders.Search(orgCode, $"OrderNumber eq {orderNumber}", options);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<RegistrationOrdersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.RegistrationOrders.Search(orgCode, $"{nameof(RegistrationOrdersModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<RegistrationOrdersModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for order user fields of Issue Class = R (registration), Issue Type code = 10, organization code = 10, and User Text 04 (TXT_04).  It will return orders where the value is "65OVER"
      return apiClient.Endpoints.RegistrationOrders.Search(orgCode, "R|10|10|UserText04 eq '65OVER'");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<RegistrationOrdersModel> RetrieveByOData(string orgCode, string oData)
    {
      return apiClient.Endpoints.RegistrationOrders.Search(orgCode, oData);
    }

    /// <summary>
    /// You can edit a registration order while editing its order items.  Note that the only editable properties for items will be the same ones editable in the item grid on the Ungerboeck Edit Registration Order window
    /// </summary>    
    public RegistrationOrdersModel EditWithOrderItems(string orgCode, int orderNbr, string newOrderStatus, string newOrderItemDescription, int newOrderItemQuantity)
    {
      IEnumerable<RegistrationOrdersModel> registrationOrders = GetWithOrderItems(orgCode, orderNbr).Results;

      if (!registrationOrders.Any()) throw new System.Exception("Order not found");
      
      var registrationOrder = registrationOrders.First();
      
      registrationOrder.OrderStatus = newOrderStatus;

      if (!registrationOrder.RegistrationOrderItems.Any()) throw new System.Exception("Order has no items");

      var item = registrationOrder.RegistrationOrderItems.First(); //We are grabbing the first item as an example

      //These are two editable fields for nested child items.  Most editable registration order item columns won't be editable in this context.  
      //Check the Edit Registration Orders window's Registration Order Items grid to see which fields are editable while updating an order.
      item.Description = newOrderItemDescription;
      item.Units = newOrderItemQuantity;

      return apiClient.Endpoints.RegistrationOrders.Update( registrationOrder);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus"></param>
    /// <param name="accountCode"></param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>
    /// <param name="registrants">This is an account code that you want to serve as a registrant on the order item generated by the order.  You can also set it as a list of comma-delimited account codes (ex: "CODE1,CODE2,CODE3") and it will make respective order items for each registrant.</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup.  This will pick the order items attached to the order registrants</param>
    /// <param name="orderItems">You can add on registration order items while adding a registration order.  For examples on how to fill out a registration order item, look to the RegistrationOrderItems add examples</param>
    /// <returns></returns>
    public RegistrationOrdersModel Add(string orgCode, int @event, string orderStatus, string accountCode, string priceList, string registrants, string registrantType, List<RegistrationOrderItemsModel> orderItems)
    {
      //Note that order number shouldn't be set for POST operations.  Ungerboeck will assign the order number automatically

      var myRegistrationOrder = new RegistrationOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        Account = accountCode,
        BillToAccount = accountCode,
        PriceList = priceList,
        Registrants = registrants,
        OrderStatus = orderStatus,
        RegistrantType = registrantType
      };

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      return apiClient.Endpoints.RegistrationOrders.Add( myRegistrationOrder);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus"></param>
    /// <param name="accountCode"></param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>
    /// <param name="registrants">This is an account code that you want to serve as a registrant on the order item generated by the order.  You can also set it as a list of comma-delimited account codes (ex: "CODE1,CODE2,CODE3") and it will make respective order items for each registrant.</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup.  This will pick the order items attached to the order registrants</param>
    /// <returns></returns>
    public RegistrationOrdersModel CalculateTaxes(string orgCode, int @event, string orderStatus, string accountCode, string priceList, string registrants, string registrantType, List<RegistrationOrderItemsModel> orderItems)
    {
      var myRegistrationOrder = new RegistrationOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        Account = accountCode,
        BillToAccount = accountCode,
        PriceList = priceList,
        Registrants = registrants,
        OrderStatus = orderStatus,
        RegistrantType = registrantType
      };

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      return apiClient.Endpoints.RegistrationOrders.CalculateTaxes(myRegistrationOrder);
    }

    /// <summary>
    /// Here's how to add a user field set with values to a new event
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus"></param>
    /// <param name="accountCode"></param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>
    /// <param name="registrants">This is an account code that you want to serve as a registrant on the order item generated by the order.  You can also set it as a list of comma-delimited account codes (ex: "CODE1,CODE2,CODE3") and it will make respective order items for each registrant.</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup.  This will pick the order items attached to the order registrants</param>
    /// <param name="issueType">This is the Issue Type code of the registration user field set.  Example string value "CK"</param>    
    /// <param name="userText05Value">This is just an example of the user fields you can set</param>
    public RegistrationOrdersModel AddWithUserFields(string orgCode, int @event, string orderStatus, string accountCode, string priceList, string registrants, string registrantType, string issueType, string userText05Value, List<RegistrationOrderItemsModel> orderItems)
    {
      //Note that order number shouldn't be set for POST operations.  Ungerboeck will assign the order number automatically

      var myRegistrationOrder = new RegistrationOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        Account = accountCode,
        BillToAccount = accountCode,
        PriceList = priceList,
        Registrants = registrants,
        OrderStatus = orderStatus,
        RegistrantType = registrantType        
      };

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      myRegistrationOrder.RegistrationOrderUserFieldSets = new List<UserFields>();
      var myUserField = new UserFields
      {
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserText05 = userText05Value //Set the value in the user field property
      };
      myRegistrationOrder.RegistrationOrderUserFieldSets.Add(myUserField); //Then add it back into the RegistrationOrdersModel object.  You can add multiple user field sets to the same registration order object before saving.
      
      return apiClient.Endpoints.RegistrationOrders.Add( myRegistrationOrder);
    }


    /// <summary>
    /// A basic edit example
    /// </summary> 
    public RegistrationOrdersModel Edit(string orgCode, int orderNumber, string newStatus, string newUserText)
    {
      var myRegistrationOrder = apiClient.Endpoints.RegistrationOrders.Get( orgCode, orderNumber);
      myRegistrationOrder.OrderStatus = newStatus;

      //User Defined Fields can also be changed.  The set picked here is arbitrary, but we recommend selecting based on the IssueType property.
      myRegistrationOrder.RegistrationOrderUserFieldSets.FirstOrDefault().UserText05 = newUserText;

      return apiClient.Endpoints.RegistrationOrders.Update( myRegistrationOrder);
    }

    public void MoveOrder(string orgCode, int orderNumber, int newEventID, int functionID)
    {
      var mymoveOrder = new MoveOrderModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionID
      };

      apiClient.Endpoints.RegistrationOrders.MoveOrder(mymoveOrder);
    }

    /// <summary>
    /// This is an example of how to move many orders at once
    /// </summary>
    /// <param name="orderNumber">OrderNumber is an array of integers for the various order numbers</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionID"></param>
    public IEnumerable<MoveOrdersBulkErrorsModel> MoveOrderBulk(string orgCode, int[] orderNumber, int newEventID, int functionID)
    {
      var myMoveBulkOrder = new MoveOrdersBulkModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionID
      };

      //Note: Function and KeepDateTimes properties are not used for Registration Orders.

      IEnumerable<MoveOrdersBulkErrorsModel> results = apiClient.Endpoints.RegistrationOrders.MoveOrdersBulk(myMoveBulkOrder);

      //For bulk operations, 200 only signifies that the process successfully ran.  Individual items might have had issues saving.  Check the response object for bulk errors.
      //One or more errors with saving the items if an error object was returned.        

      return results;
    
   }

    /// <summary>
    /// How to add a CloseDate on a registration order
    /// </summary> 
    public RegistrationOrdersModel AddCloseDate(string orgCode, int orderNumber, DateTime closeDate)
    {
      RegistrationOrdersModel myRegistrationOrder = apiClient.Endpoints.RegistrationOrders.Get(orgCode, orderNumber);
      myRegistrationOrder.CloseDate = closeDate;
      return apiClient.Endpoints.RegistrationOrders.Update(myRegistrationOrder);
    }

    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="RegistrationOrdersModel1">This contains a standard RegistrationOrdersModel object.  
    ///                                         A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="RegistrationOrdersModel2">This contains a standard RegistrationOrdersModel object.  
    ///                                        A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  
    ///                               If you are submitting a list of unrelated items to save, set this as false and the bulk save process 
    ///                               will attempt to continue saving if an item fails to save.  Note that certain errors will always result 
    ///                               in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(RegistrationOrdersModel RegistrationOrdersModel1, 
                                  string bulkOperation1, 
                                  RegistrationOrdersModel RegistrationOrdersModel2, 
                                  string bulkOperation2, 
                                  bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  
       * Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = RegistrationOrdersModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = RegistrationOrdersModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      return apiClient.Endpoints.RegistrationOrders.Bulk(myBulkRequest);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Task<BulkResponseModel> BulkAsync(RegistrationOrdersModel RegistrationOrdersModel1,
                                  string bulkOperation1,
                                  RegistrationOrdersModel RegistrationOrdersModel2,
                                  string bulkOperation2,
                                  bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  
       * Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = RegistrationOrdersModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = RegistrationOrdersModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      return apiClient.Endpoints.RegistrationOrders.BulkAsync(myBulkRequest);

    }
  }
}
