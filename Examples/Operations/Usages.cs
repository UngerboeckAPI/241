using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace Examples.Operations
{
  public class Usages : Base
  {
    public Usages(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public UsagesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Usages.Get(orgCode, code);
    }

    /// <summary>
    /// An example of retrieving a specific usage's data
    /// </summary>
    /// <param name="usageID"></param>
    public SearchResponse<UsagesModel> Search(string code, string orgCode)
    {
      return apiClient.Endpoints.Usages.Search(orgCode, $"{nameof(UsagesModel.Code)} eq '{code}' ");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<UsagesModel> SearchByOrgCodeAndDescription(string orgCode, string description)
    {
      return apiClient.Endpoints.Usages.Search(orgCode, $"{nameof(UsagesModel.OrganizationCode)} eq '{orgCode}' AND {nameof(UsagesModel.Description)} eq '{description}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <param name="organizationCode">The Organization Code of the Usage being added.</param>
    /// <param name="code">The ID of the usage being added.</param>
    /// <param name="description">The initial description for the Usage being added.</param>
    /// <returns></returns>
    public UsagesModel Add(string organizationCode, string code, string description)
    {
      var usage = new UsagesModel
      {
        OrganizationCode = organizationCode,
        Code = code,
        Description = description
      };

      return apiClient.Endpoints.Usages.Add(usage);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="organizationCode">The Organization Code of the Usage being edited.</param>
    /// <param name="code">The ID of the usage being edited.</param>
    /// <param name="description">The updated Description of the Usage.</param>
    /// <returns></returns>
    public UsagesModel Edit(string organizationCode, string code, string description)
    {
      var usage = apiClient.Endpoints.Usages.Get(organizationCode, code);

      usage.Description = description;

      return apiClient.Endpoints.Usages.Update(usage);
    }
  }
}
