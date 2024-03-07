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
  public class ExhibitorSocialMedia : Base
  {
    public ExhibitorSocialMedia(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExhibitorSocialMediaModel Get(string orgCode, int id)
    {
      return apiClient.Endpoints.ExhibitorSocialMedia.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorSocialMediaModel> Search(string propertyToSearchBy, string searchValue)
    {
      return apiClient.Endpoints.ExhibitorSocialMedia.Search(String.Empty, $"{propertyToSearchBy} eq '{searchValue}'");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorSocialMediaModel> Search(string propertyToSearchBy, int searchValue)
    {
      return apiClient.Endpoints.ExhibitorSocialMedia.Search(String.Empty, $"{propertyToSearchBy} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example for OrgCode and ExhibitorID, Title, Link, Description
    /// </summary>  
    public ExhibitorSocialMediaModel Add(string orgCode, int exhibitorID, int platform, string link)
    {
      var myExhibitorSocialMediaPlatform = new ExhibitorSocialMediaModel
      {
        OrganizationCode = orgCode,
        ExhibitorID = exhibitorID,
        Platform = platform,
        Link = link
      };

      return apiClient.Endpoints.ExhibitorSocialMedia.Add(myExhibitorSocialMediaPlatform);
    }

    /// <summary>
    /// A basic edit example for comments
    /// </summary> 
    public ExhibitorSocialMediaModel Edit(int id, int newPlatform, string newLink)
    {
      var myExhibitorSocialMediaPlatform = apiClient.Endpoints.ExhibitorSocialMedia.Get(id);

      myExhibitorSocialMediaPlatform.Platform = newPlatform;
      myExhibitorSocialMediaPlatform.Link = newLink;
      myExhibitorSocialMediaPlatform.OrganizationCode = "10";

      return apiClient.Endpoints.ExhibitorSocialMedia.Update(myExhibitorSocialMediaPlatform);
    }
  }
}
