using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLSpaceMajor : Base
  {
    public GLSpaceMajor(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public GLSpaceMajorModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.GLSpaceMajor.Get(orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GLSpaceMajorModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GLSpaceMajor.Search(orgCode, $"{nameof(GLSpaceMajorModel.Code)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="orgCode">org code of object to Update</param>
    /// <param name="code">code of object to update</param>
    /// <returns></returns>
    public GLSpaceMajorModel Edit(string orgCode, string code, GLSpaceMajorModel glSpaceMajorModelNew)
    {
      var glSpaceMajorModel = apiClient.Endpoints.GLSpaceMajor.Get(orgCode, code);

      if (glSpaceMajorModel != null)
      {
        glSpaceMajorModel.Description = glSpaceMajorModelNew.Description;
        glSpaceMajorModel.Status = glSpaceMajorModelNew.Status;
      }

      return apiClient.Endpoints.GLSpaceMajor.Update(glSpaceMajorModel);
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public GLSpaceMajorModel Add()
    {
      var glSpaceMajor = new GLSpaceMajorModel
      {
        OrganizationCode = "10",
        Code = "20",
        Description = "20",
        Status = "A"
      };

      return apiClient.Endpoints.GLSpaceMajor.Add(glSpaceMajor);
    }

  }
}



