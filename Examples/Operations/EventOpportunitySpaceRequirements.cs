using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;
using System.Net.Http;

namespace Examples.Operations
{
  public class EventOpportunitySpaceRequirements : Base
  {
    public EventOpportunitySpaceRequirements(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunitySpaceRequirementsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirements.Search(orgCode, $"{nameof(EventOpportunitySpaceRequirementsModel.EventOpportunity)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunitySpaceRequirementsModel Get(int id)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirements.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunitySpaceRequirementsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.EventOpportunitySpaceRequirements.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    public EventOpportunitySpaceRequirementsModel Add(string organization, int eventOpportunity, string description, DateTime preferredStartDate, DateTime preferredStartTime, DateTime preferredEndDate, DateTime preferredEndTime)
    {
      var spaceRequirement = new EventOpportunitySpaceRequirementsModel
      {
        OrganizationCode = organization,
        EventOpportunity = eventOpportunity,
        Description = description,
        PreferredStartDate = preferredStartDate,
        PreferredEndDate = preferredEndDate,  
        PreferredStartTime = preferredStartTime,
        PreferredEndTime = preferredEndTime
      };

      return apiClient.Endpoints.EventOpportunitySpaceRequirements.Add(spaceRequirement);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public EventOpportunitySpaceRequirementsModel Edit(int id, string newDescription)
    {
      var spaceRequirement = apiClient.Endpoints.EventOpportunitySpaceRequirements.Get(id);
      spaceRequirement.Description = newDescription;

      return apiClient.Endpoints.EventOpportunitySpaceRequirements.Update(spaceRequirement);
    }
  }
}
