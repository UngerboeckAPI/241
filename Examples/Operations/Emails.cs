using System.Collections.Generic;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Subjects.Emails;
using Ungerboeck.Api.Models.Subjects.HtmlTemplates;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class Emails : Base
  {
    public Emails(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// Sends an email through Ungerboeck
    /// </summary>
    public EmailsModel Send(List<string> toAddresses, string emailSubject, string emailBody, string orgCode)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email through Ungerboeck with a Carbon Copy (cc) address
    /// </summary>
    public EmailsModel SendWithCC(List<string> toAddresses, List<string> ccAddresses, string emailSubject, string emailBody, string orgCode)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      foreach (string address in ccAddresses)
      {
        emailsModel.CCAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email through Ungerboeck to multiple recipients as a Blind Carbon Copy (bcc)
    /// </summary>
    public EmailsModel SendAsBCCOnly(List<string> bccAddresses, string emailSubject, string emailBody, string orgCode)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode
      };

      foreach (string address in bccAddresses)
      {
        emailsModel.BCCAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email through Ungerboeck and save the email as an event document. Please see the document examples to save the email to other areas
    /// </summary>
    public EmailsModel SendAndSaveAsEventDocument(List<string> toAddresses, string emailSubject, string emailBody, string orgCode, int eventId)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode,
        SaveAsUngerboeckDocument = new DocumentsModel
        {
          Event = eventId
        }
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email through Ungerboeck and save the email as an order document. Please see the document examples to save the email to other areas
    /// </summary>
    public EmailsModel SendAndSaveAsOrderDocument(List<string> toAddresses, string emailSubject, string emailBody, string orgCode, int orderNbr)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode,
        SaveAsUngerboeckDocument = new DocumentsModel
        {
          Order = orderNbr
        }
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email with attachments through Ungerboeck. One attachment is hard coded while the other created from information that was passed in.
    /// This example will save the email and the attachment as event documents. Please see the document examples to save the email to other areas
    /// </summary>
    public EmailsModel SendAndSaveWithAttachments(List<string> toAddresses, string emailSubject, string emailBody, string orgCode, int eventId, string filename, string description, string fileData)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode,
        SaveAsUngerboeckDocument = new DocumentsModel
        {
          Event = eventId
        }
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      emailsModel.Attachments.Add(new AttachmentModel
      {
        Description = description, //This will become the filename
        FileName = filename, //This is only used to get the document extension
        FileData = fileData //This is the contents of the file as a Base64 endcoded string
      });

      //Due to the relationship bewteen the Description and FileName properties the following code
      //will produce an attachment with the filename: 'This is a second example attachment.txt'
      emailsModel.Attachments.Add(new AttachmentModel
      {
        Description = "This is a second example attachment",
        FileName = "Example.txt",
        FileData = "SGVsbG8gV29ybGQh"
      });

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email through Ungerboeck and mark the email as urgent/high priority
    /// </summary>
    public EmailsModel SendAsUrgent(List<string> toAddresses, string emailSubject, string emailBody, string orgCode)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = emailSubject,
        HtmlText = emailBody,
        Organization = orgCode,
        FlagForImportance = true
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }

    /// <summary>
    /// Sends an email through Ungerboeck using a template stored in Ungerboeck. See the HtmlTemplates examples for how to retrieve and resolve templates
    /// </summary>
    public EmailsModel SendUsingTemplate(List<string> toAddresses, string orgCode, HtmlTemplateResponseModel htmlTemplateResponse)
    {
      EmailsModel emailsModel = new EmailsModel
      {
        EmailSubject = htmlTemplateResponse.Subject,
        HtmlText = htmlTemplateResponse.Data,
        Organization = orgCode
      };

      foreach (string address in toAddresses)
      {
        emailsModel.SendToAddresses.Add(new EmailAccountModel
        {
          EmailAddress = address
        });
      }

      foreach (HtmlAttachmentModel attachment in htmlTemplateResponse.Attachments)
      {
        emailsModel.Attachments.Add(new AttachmentModel
        {
          Description = attachment.Description,
          FileData = attachment.FileData,
          FileName = attachment.FileName,
        });
      }

      return apiClient.Endpoints.Emails.Send(emailsModel);
    }
  }
}
