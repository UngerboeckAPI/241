using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class ExhibitorInBoothEvents : Base
  {
    public ExhibitorInBoothEvents(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExhibitorInBoothEventsModel Get(string orgCode, int id)
    {
      return apiClient.Endpoints.ExhibitorInBoothEvents.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorInBoothEventsModel> Search(string propertyToSearchBy, string searchValue)
    {
      return apiClient.Endpoints.ExhibitorInBoothEvents.Search(String.Empty, $"{propertyToSearchBy} eq '{searchValue}'");
    }
    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorInBoothEventsModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.ExhibitorInBoothEvents.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for OrgCode and ExhibitorID, Title, Link, Description
    /// </summary>  
    public ExhibitorInBoothEventsModel Add(string orgCode, int exhibitorID, string title, string link, string description, DateTime eventDate)
    {
      var myExhibitorProductVideo = new ExhibitorInBoothEventsModel
      {
        OrganizationCode = orgCode,
        ExhibitorID = exhibitorID,
        Title = title,
        EventLink = link,
        Description = description,
        EventDate = eventDate
      };

      return apiClient.Endpoints.ExhibitorInBoothEvents.Add(myExhibitorProductVideo);
    }

    /// <summary>
    /// A basic edit example for Title, EventLink, EventDescription, EventDate
    /// </summary> 
    public ExhibitorInBoothEventsModel Edit(int id, string newTitle, string newLink, string newDescription, DateTime newEventDate)
    {
      var myExhibitorProductVideo = apiClient.Endpoints.ExhibitorInBoothEvents.Get(id);

      myExhibitorProductVideo.Title = newTitle;
      myExhibitorProductVideo.EventLink = newLink;
      myExhibitorProductVideo.Description = newDescription;
      myExhibitorProductVideo.EventDate = newEventDate;
      myExhibitorProductVideo.OrganizationCode = "10";

      return apiClient.Endpoints.ExhibitorInBoothEvents.Update(myExhibitorProductVideo);
    }
  }
}
