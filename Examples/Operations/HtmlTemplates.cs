using System.Collections.Generic;
using System.Net.Http;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;
using System;
using Ungerboeck.Api.Models.Subjects.HtmlTemplates;

namespace Examples.Operations
{
  public class HtmlTemplates : Base
  {

    public HtmlTemplates(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// Get Parameters for HtmlTemplates
    /// </summary>
    public HtmlTemplateParametersModel GetParameters(string orgCode, int sequenceNumber)
    {
      HtmlTemplateParametersModel parametersModel = apiClient.Endpoints.HtmlTemplates.GetParameters(orgCode, sequenceNumber);

      return parametersModel;
    }

    /// <summary>
    /// Resolves a template and all of its attachments
    /// </summary>
    public HtmlTemplateResponseModel ResolveTemplate(HtmlTemplateRequestModel htmlTemplateRequestModel)
    {
      HtmlTemplateResponseModel htmlTemplateResponseModel = apiClient.Endpoints.HtmlTemplates.ResolveTemplate(htmlTemplateRequestModel);

      return htmlTemplateResponseModel;
    }

    /// <summary>
    /// Resolves a template and all of its attachments
    /// </summary>
    public HtmlTemplateResponseModel ResolveTemplateAysnc(HtmlTemplateRequestModel htmlTemplateRequestModel)
    {
      System.Threading.Tasks.Task<HtmlTemplateResponseModel> htmlTemplateResponseModel = apiClient.Endpoints.HtmlTemplates.ResolveTemplateAsync(htmlTemplateRequestModel);

      return htmlTemplateResponseModel.Result;
    }

    /// <summary>
    /// Resolves a template and all of its attachments
    /// </summary>
    public HtmlTemplateResponseModel ResolveTemplate()
    {
      HtmlTemplateRequestModel htmlTemplateRequestModel = new HtmlTemplateRequestModel();
      htmlTemplateRequestModel.Organization = "10";
      htmlTemplateRequestModel.TemplateSequence = 125;

      htmlTemplateRequestModel.Parameters.Add(new HtmlTemplateParameterValues("@ORGANIZATION", "10"));
      htmlTemplateRequestModel.Parameters.Add(new HtmlTemplateParameterValues("@ACCOUNT", "1234567890"));

      return ResolveTemplate(htmlTemplateRequestModel);
    }
  }
}
