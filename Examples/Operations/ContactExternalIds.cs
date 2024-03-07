using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class ContactExternalIds : Base
  {
    public ContactExternalIds(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ContactExternalIdsModel Get(int id)
    {
      return apiClient.Endpoints.ContactExternalIds.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ContactExternalIdsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.ContactExternalIds.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for Numeric ID
    /// </summary>  
    public ContactExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string account, long numericId)
    {
      var myExternalSystem = new ContactExternalIdsModel
      {
        ExternalSystem = externalSystem,
        Subject = externalSystemSubject,
        Organization = organization,
        Contact = account,
        NumericID = numericId
      };

      return apiClient.Endpoints.ContactExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic add example for Text ID
    /// </summary>  
    public ContactExternalIdsModel Add(int externalSystem, int externalSystemSubject, string organization, string account, string textId)
    {
      var myExternalSystem = new ContactExternalIdsModel
      {
        ExternalSystem = externalSystem,
        Subject = externalSystemSubject,
        Organization = organization,
        Contact = account,
        TextID = textId
      };

      return apiClient.Endpoints.ContactExternalIds.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Numeric ID
    /// </summary> 
    public ContactExternalIdsModel Edit(int id, long newNumericId)
    {
      var myExternalSystem = apiClient.Endpoints.ContactExternalIds.Get(id);
      myExternalSystem.NumericID = newNumericId;

      return apiClient.Endpoints.ContactExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Text ID
    /// </summary> 
    public ContactExternalIdsModel Edit(int id, string newTextId)
    {
      var myExternalSystem = apiClient.Endpoints.ContactExternalIds.Get(id);
      myExternalSystem.TextID = newTextId;

      return apiClient.Endpoints.ContactExternalIds.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.ContactExternalIds.Delete(id);
    }
  }
}
