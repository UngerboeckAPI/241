using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
namespace Examples.Operations
{
  public class SpaceHierarchyLevelTwos : Base
  {
    public SpaceHierarchyLevelTwos(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceHierarchyLevelTwosModel Get(string orgCode, int levelOneSequence, int levelTwoSequence)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelTwos.Get( orgCode, levelOneSequence, levelTwoSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceHierarchyLevelTwosModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelTwos.Search(orgCode, $"{nameof(SpaceHierarchyLevelTwosModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add examble
    /// </summary>
    public SpaceHierarchyLevelTwosModel Add(string orgCode, int levelOneSequence, string description, int sort)
    {
      SpaceHierarchyLevelTwosModel model = new SpaceHierarchyLevelTwosModel()
      {
        Organization = orgCode,
        Level1Sequence = levelOneSequence,
        Description = description,
        Sort = sort
      };
      return apiClient.Endpoints.SpaceHierarchyLevelTwos.Add(model);
    }

    /// <summary>
    /// A basic edit example.
    /// </summary>
    public SpaceHierarchyLevelTwosModel Edit(string orgCode, int levelOneSequence, int levelTwoSequence, string newDescription)
    {
      SpaceHierarchyLevelTwosModel model = apiClient.Endpoints.SpaceHierarchyLevelTwos.Get(orgCode, levelOneSequence, levelTwoSequence);

      model.Description = newDescription;

      return apiClient.Endpoints.SpaceHierarchyLevelTwos.Update(model);
    }

    /// <summary>
    /// A simple delete example.
    /// </summary>
    public void Delete(string orgCode, int levelOneSequence, int levelTwoSequence)
    {
      apiClient.Endpoints.SpaceHierarchyLevelTwos.Delete(orgCode, levelOneSequence, levelTwoSequence);
    }

    /// <summary>
    /// A delete example with a replacement value. Value should be level one and level two sequences as a pipe delimited string. Example "3|24"
    /// </summary>
    public void DeleteReplace(string orgCode, int levelOneSequence, int levelTwoSequence, string replaceValue)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.SpaceHierarchyLevelTwos() { ReplaceUsedHierarchy = replaceValue };
      apiClient.Endpoints.SpaceHierarchyLevelTwos.Delete(orgCode, levelOneSequence, levelTwoSequence, options);
    }
  }
}
