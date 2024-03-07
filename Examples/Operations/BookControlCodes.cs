using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class BookControlCodes : Base
  {
    public BookControlCodes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public BookControlCodesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.BookControlCodes.Get(orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BookControlCodesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.BookControlCodes.Search(orgCode, $"{nameof(BookControlCodesModel.Code)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="orgCode">org code of object to Update</param>
    /// <param name="code">code of object to update</param>
    /// <returns></returns>
    public BookControlCodesModel Edit(string orgCode, string code, BookControlCodesModel bookControlCodeModelNew)
    {
      var bookControlCodeModel = apiClient.Endpoints.BookControlCodes.Get(orgCode, code);

      if (bookControlCodeModel != null)
      {
        bookControlCodeModel.Description = bookControlCodeModelNew.Description;
        bookControlCodeModel.Status = bookControlCodeModelNew.Status;
      }

      return apiClient.Endpoints.BookControlCodes.Update(bookControlCodeModel);
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public BookControlCodesModel Add()
    {
      var bookControlCode = new BookControlCodesModel
      {
        OrgCode = "10",
        Code = "APITEST",
        Description = "API Test Book Control",
        Status = "A"
      };

      return apiClient.Endpoints.BookControlCodes.Add(bookControlCode);
    }

  }
}



