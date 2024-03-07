using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class EventOpportunitySpaceRequirementsProposedSpaces : Base
  {
    public EventOpportunitySpaceRequirementsProposedSpaces(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunitySpaceRequirementsProposedSpacesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirementsProposedSpaces.Search(orgCode, $"{nameof(EventOpportunitySpaceRequirementsProposedSpacesModel.Space)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunitySpaceRequirementsProposedSpacesModel Get(int id)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirementsProposedSpaces.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunitySpaceRequirementsProposedSpacesModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirementsProposedSpaces.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    public EventOpportunitySpaceRequirementsProposedSpacesModel Add(string organization, int eventOppSpaceReq, string spaceCode)
    {
      var spaceRequirement = new EventOpportunitySpaceRequirementsProposedSpacesModel
      {
        OrganizationCode = organization,
        EventOpportunitySpaceRequirement = eventOppSpaceReq,
        Space = spaceCode
      };

      return apiClient.Endpoints.EventOpportunitySpaceRequirementsProposedSpaces.Add(spaceRequirement);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public HttpResponseMessage Delete(int id)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirementsProposedSpaces.Delete(id);
    }
  }
}
