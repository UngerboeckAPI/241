using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class CampaignDetails : Base
  {
    public CampaignDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public CampaignDetailsModel Get(string orgCode, string campaignDesignation, string campaign, int sequenceNumber)
    {
      return apiClient.Endpoints.CampaignDetails.Get(orgCode, campaignDesignation, campaign, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CampaignDetailsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.CampaignDetails.Search(orgCode, $"{nameof(CampaignDetailsModel.CampaignDesignation)} eq '{searchValue}'");
    }

    /// <summary>
    /// Basic Add exmaple
    /// </summary>
    /// <param name="orgCode">Organization code where the campaign belongs</param>
    /// <param name="campaignDesignation">Designation code of campaign</param>
    /// <param name="campaign">Campaign Id of the campaign</param>
    /// <param name="account">Account code to add</param>
    /// <returns></returns>
    public CampaignDetailsModel Add(string orgCode, string campaignDesignation, string campaign, string account)
    {
      var campaignDetailsModel = new CampaignDetailsModel()
      {
        OrganizationCode = orgCode,
        CampaignDesignation = campaignDesignation,
        Campaign = campaign,
        Account = account
      };

      return apiClient.Endpoints.CampaignDetails.Add(campaignDetailsModel);
    }

    /// <summary>
    /// Basic Edit exmaple
    /// </summary>
    /// <param name="orgCode">Organization code where the campaign belongs</param>
    /// <param name="campaignDesignation">Designation code of campaign</param>
    /// <param name="campaign">Campaign Id of the campaign</param>
    /// <param name="sequenceNumber">Sequence number of the campaign detail</param>
    /// <param name="outgoingCalls">Number of outgoingcall to update</param>
    /// <returns></returns>
    public CampaignDetailsModel Edit(string orgCode, string campaignDesignation, string campaign, int sequenceNumber, int outgoingCalls)
    {
      CampaignDetailsModel campaignDetailsModel = apiClient.Endpoints.CampaignDetails.Get(orgCode, campaignDesignation, campaign, sequenceNumber);
      if (campaignDetailsModel != null)
      {
        campaignDetailsModel.OutgoingCalls = outgoingCalls;
      }

      return apiClient.Endpoints.CampaignDetails.Update(campaignDetailsModel);
    }

    /// <summary>
    /// Basic Delete exmaple
    /// </summary>
    /// <param name="orgCode">Organization code where the campaign belongs</param>
    /// <param name="campaignDesignation">Designation code of campaign</param>
    /// <param name="campaign">Campaign Id of the campaign</param>
    /// <param name="sequenceNumber">Sequence number of the campaign detail</param>
    public void Delete(string orgCode, string campaign, string campaignDesignation, int sequenceNumber)
    {
      apiClient.Endpoints.CampaignDetails.Delete(orgCode, campaign, campaignDesignation, sequenceNumber);
    }
  }
}
