using Ungerboeck.Api.Models.Subjects;
using System.Net.Http;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class Emails : Base<UngerboeckModel>
  {
    protected internal Emails(ApiClient api) : base(api) { }

    public EmailsModel Send(EmailsModel emailRequest, Ungerboeck.Api.Models.Options.Subjects.Emails options = null)
    {
      System.Threading.Tasks.Task<EmailsModel> reportsTask = PostAsync(Client, 
        $"Emails/Send", emailRequest, options);
      return CustomSync(reportsTask);
    }
  }
}
