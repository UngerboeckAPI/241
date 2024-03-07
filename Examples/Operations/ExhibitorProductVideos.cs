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
  public class ExhibitorProductVideos : Base
  {
    public ExhibitorProductVideos(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExhibitorProductVideosModel Get(int id)
    {
      return apiClient.Endpoints.ExhibitorProductVideos.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorProductVideosModel> Search(string propertyToSearchBy, string searchValue)
    {
      return apiClient.Endpoints.ExhibitorProductVideos.Search(String.Empty, $"{propertyToSearchBy} eq '{searchValue}'");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorProductVideosModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.ExhibitorProductVideos.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for OrgCode and ExhibitorID, Title, Link, Description
    /// </summary>  
    public ExhibitorProductVideosModel Add(string orgCode, int exhibitorID, string title, string link, string description)
    {
      var myExhibitorProductVideo = new ExhibitorProductVideosModel
      {
        OrganizationCode = orgCode,
        ExhibitorID = exhibitorID,
        Title = title,
        Link = link,
        Description = description
      };

      return apiClient.Endpoints.ExhibitorProductVideos.Add(myExhibitorProductVideo);
    }

    /// <summary>
    /// A basic edit example for Title, Link, Description
    /// </summary> 
    public ExhibitorProductVideosModel Edit(int id, string newTitle, string newLink, string newDescription)
    {
      var myExhibitorProductVideo = apiClient.Endpoints.ExhibitorProductVideos.Get(id);

      myExhibitorProductVideo.Title = newTitle;
      myExhibitorProductVideo.Link = newLink;
      myExhibitorProductVideo.Description = newDescription;
      myExhibitorProductVideo.OrganizationCode = "10";

      return apiClient.Endpoints.ExhibitorProductVideos.Update(myExhibitorProductVideo);
    }
  }
}
