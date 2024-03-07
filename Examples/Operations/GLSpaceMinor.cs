using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLSpaceMinor : Base
  {
    public GLSpaceMinor(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public GLSpaceMinorModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.GLSpaceMinor.Get(orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GLSpaceMinorModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GLSpaceMinor.Search(orgCode, $"{nameof(GLSpaceMinorModel.Code)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="orgCode">org code of object to Update</param>
    /// <param name="code">code of object to update</param>
    /// <returns></returns>
    public GLSpaceMinorModel Edit(string orgCode, string code, GLSpaceMinorModel glSpaceMinorModelNew)
    {
      var glSpaceMinorModel = apiClient.Endpoints.GLSpaceMinor.Get(orgCode, code);

      if (glSpaceMinorModel != null)
      {
        glSpaceMinorModel.Description = glSpaceMinorModelNew.Description;
        glSpaceMinorModel.Status = glSpaceMinorModelNew.Status;
      }

      return apiClient.Endpoints.GLSpaceMinor.Update(glSpaceMinorModel);
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public GLSpaceMinorModel Add()
    {
      var glSpaceMinor = new GLSpaceMinorModel
      {
        OrganizationCode = "10",
        Code = "GL6X",
        Description = "GL6X",
        Status = "A"
      };

      return apiClient.Endpoints.GLSpaceMinor.Add(glSpaceMinor);
    }

  }
}



