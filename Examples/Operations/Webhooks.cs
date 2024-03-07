using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Webhooks : Base
  {
    public Webhooks(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public WebhooksModel Get(int sequenceNbr)
    {
      return apiClient.Endpoints.Webhooks.Get(sequenceNbr);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<WebhooksModel> Search(string searchValue)
    {
      return apiClient.Endpoints.Webhooks.Search($"{nameof(WebhooksModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <param name="description">This will be a general description on the webhook</param>
    /// <param name="url">A URL where your webhook client is listening for the incoming webhooks (ex: https://mysite.com/WebhookClient)</param>
    /// <returns></returns>
    public WebhooksModel Add(string description, string url)
    {
      var model = new WebhooksModel
      {
        Description = description,
        TriggerAction = (int) USISDKConstants.Webhooks.TriggerActions.AccountUpdated,
        WebServiceURL = url
      };

      return apiClient.Endpoints.Webhooks.Add(model);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <returns>The updated webhook</returns>
    public WebhooksModel Edit(int sequenceNumber, string description)
    {
      var model = apiClient.Endpoints.Webhooks.Get(sequenceNumber);

      model.Description = description;

      return apiClient.Endpoints.Webhooks.Update(model);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sequenceNumber)
    {
      apiClient.Endpoints.Webhooks.Delete(sequenceNumber);
    }

    /// <summary>
    /// This shows example values of every editable field for Webhooks
    /// </summary>
    /// <param name="sequenceNumber">This is the identifying sequence number for the webhook</param>
    /// <returns>The newly updated webhook</returns>
    public WebhooksModel EditAdvanced(int sequenceNumber)
    {
      var webhook = apiClient.Endpoints.Webhooks.Get(sequenceNumber);

      webhook = GenerateEditWebhook(webhook);

      return apiClient.Endpoints.Webhooks.Update(webhook);
    }

    /// <summary>
    /// This changes all possible writable fields on add
    /// </summary>    
    public WebhooksModel AddAdvanced(string rand)
    {
      WebhooksModel model = GenerateAddWebhook();

      return apiClient.Endpoints.Webhooks.Add(model);
    }

    public WebhooksModel GenerateAddWebhook()
    {
      return new WebhooksModel
      {
        //All these fields are editable.  See existing entries for example values and codes.

        Description = "This webhook activates our marketing email process after an account was added",
        IgnoreforApi = true,
        IsAsynchronous = "Y", //Y or N
        SecretKey = "PutALongSecretHereOrLeaveBlankToAutoGenerate",
        Status = "A", //A for Active, I for Inactive
        Timeout = 50,
        TriggerAction = (int)USISDKConstants.Webhooks.TriggerActions.AccountUpdated,
        WebServiceURL = "https://mywebhooksite.com",
        EncryptionKey = "TheseAreOptional" //Optional. Needs to be either 16 or 32 characters
      };
    }

    public WebhooksModel GenerateEditWebhook(WebhooksModel editWebhook)
    {
      //All these fields are editable.  See existing entries for example values and codes.

      editWebhook.Description = "This webhook is now for a calender sync process";
      editWebhook.IgnoreforApi = false;
      editWebhook.IsAsynchronous = "N";
      editWebhook.SecretKey = "PutALongSecretHereOrLeaveBlankToAutoGenerate";
      editWebhook.Status = "I"; //A for Active, I for Inactive
      editWebhook.Timeout = 50;
      editWebhook.TriggerAction = (int)USISDKConstants.Webhooks.TriggerActions.AccountUpdated;
      editWebhook.WebServiceURL = "https://mywebhooksite.com";
      editWebhook.EncryptionKey = "TheseAreOptional"; //Optional. Needs to be either 16 or 32 characters
      
      return editWebhook;
    }

  }
}
