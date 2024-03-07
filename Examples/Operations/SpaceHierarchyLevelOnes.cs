using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceHierarchyLevelOnes : Base
  {
    public SpaceHierarchyLevelOnes(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceHierarchyLevelOnesModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelOnes.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceHierarchyLevelOnesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelOnes.Search(orgCode, $"{nameof(SpaceHierarchyLevelOnesModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    public SpaceHierarchyLevelOnesModel Add(string orgCode, string description)
    {
      var spaceHierarchyLevelOne = new SpaceHierarchyLevelOnesModel
      {
        Organization = orgCode,
        Description = description
      };

      return apiClient.Endpoints.SpaceHierarchyLevelOnes.Add(spaceHierarchyLevelOne);
    }


    /// <summary>
    /// A basic edit example
    /// </summary> 
    public SpaceHierarchyLevelOnesModel Edit(string orgCode, int levelOneSequence, string newDescription)
    {
      SpaceHierarchyLevelOnesModel spaceHierarchyLevelOne = apiClient.Endpoints.SpaceHierarchyLevelOnes.Get(orgCode, levelOneSequence);

      spaceHierarchyLevelOne.Description = newDescription;

      return apiClient.Endpoints.SpaceHierarchyLevelOnes.Update(spaceHierarchyLevelOne);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string orgCode, int levelOneSequence)
    {
      apiClient.Endpoints.SpaceHierarchyLevelOnes.Delete(orgCode, levelOneSequence);
    }

    /// <summary>
    /// A delete example with a replacement value. Value should be level one and level two sequences as a pipe delimited string. Example "3|24"
    /// </summary>
    public void DeleteReplace(string orgCode, int levelOneSequence, string replaceValue)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.SpaceHierarchyLevelOnes() { ReplaceUsedHierarchy = replaceValue, BypassConfirmDeleteLevelTwosCheck = true };
      apiClient.Endpoints.SpaceHierarchyLevelOnes.Delete(orgCode, levelOneSequence, options);
    }
  }
}
