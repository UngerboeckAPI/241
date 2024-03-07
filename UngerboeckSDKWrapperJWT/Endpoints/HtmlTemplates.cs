using Ungerboeck.Api.Models.Subjects.HtmlTemplates;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class HtmlTemplates : Base<Models.Subjects.UngerboeckModel>
  {
    protected internal HtmlTemplates(ApiClient api) : base(api) { }

    /// <summary>
    /// Custom endpoint.  Gets the Html Template parameters for the template being resolved.
    /// </summary>
    /// <param name="orgCode">Org Code to get configuration from</param>
    /// <param name="sequenceNumber">Template Sequence</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HtmlTemplateParametersModel, showing the parameters used to resolve the template</returns>
    public HtmlTemplateParametersModel GetParameters(string orgCode, int sequenceNumber, Models.Options.Subjects.HtmlTemplates options = null)
    {
      return CustomSync(GetParametersAsync(orgCode, sequenceNumber, options));
    }

    /// <summary>
    /// Custom endpoint.  Gets the Html Template parameters for the template being resolved.
    /// </summary>
    /// <param name="orgCode">Org Code to get configuration from</param>
    /// <param name="sequenceNumber">Template Sequence</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HtmlTemplateParametersModel, showing the parameters used to resolve the template</returns>
    public Task<HtmlTemplateParametersModel> GetParametersAsync(string orgCode, int sequenceNumber, Models.Options.Subjects.HtmlTemplates options = null)
    {
      Task<HtmlTemplateParametersModel> templateTask = GetAsync<HtmlTemplateParametersModel>(Client, $"HtmlTemplates/{orgCode}/{sequenceNumber}/GetParameters", options);
      return templateTask;
    }

    /// <summary>
    /// Custom endpoint. Resolves the template with the request passed in.
    /// </summary>
    /// <param name="htmlTemplateRequestModel">The request properties of the template</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>ReportResponseModel containing the report</returns>
    public HtmlTemplateResponseModel ResolveTemplate(HtmlTemplateRequestModel htmlTemplateRequestModel, Models.Options.Subjects.HtmlTemplates options = null)
    {
      return CustomSync(ResolveTemplateAsync(htmlTemplateRequestModel, options));
    }

    /// <summary>
    /// Custom endpoint. Resolves the template with the request passed in.
    /// </summary>
    /// <param name="htmlTemplateRequestModel">The request properties of the template</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>ReportResponseModel containing the report</returns>
    public Task<HtmlTemplateResponseModel> ResolveTemplateAsync(HtmlTemplateRequestModel htmlTemplateRequestModel, Models.Options.Subjects.HtmlTemplates options = null)
    {
      Task<HtmlTemplateResponseModel> templateRequestModelTask = PutAsync<HtmlTemplateRequestModel, HtmlTemplateResponseModel>(Client,
          $"HtmlTemplates/ResolveTemplate", htmlTemplateRequestModel, options);
      return templateRequestModelTask;
    }
  }
}
