using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class ExternalSystemSubjects : Base
  {
    public ExternalSystemSubjects(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExternalSystemSubjectsModel Get(int id)
    {
      return apiClient.Endpoints.ExternalSystemSubjects.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExternalSystemSubjectsModel> Search(string propertyToSearchBy, string searchValue)
    {
      return apiClient.Endpoints.ExternalSystemSubjects.Search(String.Empty, $"{propertyToSearchBy} eq '{searchValue}'");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExternalSystemSubjectsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.ExternalSystemSubjects.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for OrgCode, Description
    /// </summary>  
    public ExternalSystemSubjectsModel Add(int externalSystem, int subject, string summary, bool active, int dataType, int maxLength)
    {
      var myExternalSystem = new ExternalSystemSubjectsModel
      {
        ExternalSystem = externalSystem,
        Subject = subject,
        Summary = summary,
        Active = active,
        DataType = dataType,
        MaxLength = maxLength
      };

      return apiClient.Endpoints.ExternalSystemSubjects.Add(myExternalSystem);
    }

    /// <summary>
    /// A basic edit example for Summary
    /// </summary> 
    public ExternalSystemSubjectsModel Edit(int id, string newSummary, bool newActive, int newDataType, int newMaxLength)
    {
      var myExternalSystem = apiClient.Endpoints.ExternalSystemSubjects.Get(id);
      myExternalSystem.Summary = newSummary;
      myExternalSystem.Active = newActive;
      myExternalSystem.DataType = newDataType;
      myExternalSystem.MaxLength = newMaxLength;

      return apiClient.Endpoints.ExternalSystemSubjects.Update(myExternalSystem);
    }

    /// <summary>
    /// A basic delete example.
    /// </summary>
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.ExternalSystemSubjects.Delete(id);
    }
  }
}
