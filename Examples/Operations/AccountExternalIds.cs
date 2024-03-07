using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class AccountExternalIds : Base
  {
    public AccountExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public AccountExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.AccountExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AccountExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.AccountExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public AccountExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string account, long numericId)
    {
      var myExternalSystem = new AccountExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        Account = account,
        NumericID = numericId
      };

      return apiClient.Endpoints.AccountExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public AccountExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string account, string textId)
    {
      var myExternalSystem = new AccountExternalIdsModel
      {
        ExternalSystem = externalSystem,
        ExternalSystemSubject = externalSystemSubject,
        Organization = organization,
        Account = account,
        TextID = textId
      };

      return apiClient.Endpoints.AccountExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public AccountExternalIdsModel Edit(int id, long newNumericId)
    {
      var myExternalSystem = apiClient.Endpoints.AccountExternalIds.Get(id);
      myExternalSystem.NumericID = newNumericId;

      return apiClient.Endpoints.AccountExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public AccountExternalIdsModel Edit(int id, string newTextId)
    {
      var myExternalSystem = apiClient.Endpoints.AccountExternalIds.Get(id);
      myExternalSystem.TextID = newTextId;

      return apiClient.Endpoints.AccountExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public AccountExternalIdsModel EditWithParameter(int id, string newTextId)
    {
      var myExternalSystem = apiClient.Endpoints.AccountExternalIds.Get(id);
      myExternalSystem.TextID = newTextId;

      return apiClient.Endpoints.AccountExternalIds.Update(id, myExternalSystem);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.AccountExternalIds.Delete(id);
    }
  }
}
