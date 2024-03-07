using System;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class RoomTypes : Base
  {
    public RoomTypes(ApiClient apiClient) : base(apiClient) { }

    public RoomTypesModel Get(string organizationCode, string code)
    {
      return apiClient.Endpoints.RoomTypes.Get(organizationCode, code);
    }

    /// <summary>
    /// A search example.
    /// </summary>
    /// <returns></returns>
    public SearchResponse<RoomTypesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.RoomTypes.Search(orgCode, $"{nameof(RoomTypesModel.Code)} eq '{searchValue}'");
    }

    /// <summary>
    /// Simple add method with only required properties.
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="code">This is the code value of the Room Type</param>
    /// <returns></returns>
    public RoomTypesModel AddSimple(string orgCode, string code, string description)
    {
      RoomTypesModel model = new RoomTypesModel
      {
        OrganizationCode = orgCode,
        Code = code,
        Description = description
      };

      return apiClient.Endpoints.RoomTypes.Add(model);
    }       

    public RoomTypesModel Edit(string orgCode, string code, RoomTypesModel updatedModel)
    {
      RoomTypesModel model = apiClient.Endpoints.RoomTypes.Get(orgCode, code);

      // Update all editable fields
      model.Retire = updatedModel.Retire;
      model.AlternateRoomType = updatedModel.AlternateRoomType;
      model.Description = updatedModel.Description;
      model.ResourceType = updatedModel.ResourceType;
      model.ResourceCode = updatedModel.ResourceCode;
      model.AlternateDescription1 = updatedModel.AlternateDescription1;
      model.AlternateDescription2 = updatedModel.AlternateDescription2;
      model.AlternateDescription3 = updatedModel.AlternateDescription3;
      model.AlternateDescription4 = updatedModel.AlternateDescription4;
      model.AlternateDescription5 = updatedModel.AlternateDescription5;
      model.AbbreviatedDescription = updatedModel.AbbreviatedDescription;
      model.AlternateAbbreviatedDescription1 = updatedModel.AlternateAbbreviatedDescription1;
      model.AlternateAbbreviatedDescription2 = updatedModel.AlternateAbbreviatedDescription2;
      model.AlternateAbbreviatedDescription3 = updatedModel.AlternateAbbreviatedDescription3;
      model.AlternateAbbreviatedDescription4 = updatedModel.AlternateAbbreviatedDescription4;
      model.AlternateAbbreviatedDescription5 = updatedModel.AlternateAbbreviatedDescription5;
      model.NumberofPersons = updatedModel.NumberofPersons;
      model.UserSortOrder = updatedModel.UserSortOrder;

      return apiClient.Endpoints.RoomTypes.Update(model);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>
    /// <param name="orgCode">Organization's code</param>
    /// <param name="code">This is the code value of the Room Type</param>
    public void Delete(string orgCode, string code)
    {
      apiClient.Endpoints.RoomTypes.Delete(orgCode, code);
    }

    /// <summary>
    /// This shows example values of every editable field for RoomTypes
    /// </summary>
    /// <param name="orgCode">Organization's code.</param>
    /// <param name="code">This is the code value of the Room Type</param>
    /// <returns>The newly updated room type</returns>
    public RoomTypesModel EditAdvanced(string orgCode, string code)
    {
      RoomTypesModel model = apiClient.Endpoints.RoomTypes.Get(orgCode, code);

      model = EditRoomType(model);

      return apiClient.Endpoints.RoomTypes.Update(model);
    }

    /// <summary>
    /// This changes all possible writable fields on add
    /// </summary>    
    public RoomTypesModel AddAdvanced()
    {
      RoomTypesModel model = GenerateNewRoomType();

      return apiClient.Endpoints.RoomTypes.Add(model);
    }

    public RoomTypesModel Add(RoomTypesModel model)
    {
      return apiClient.Endpoints.RoomTypes.Add(model);
    }

    /// <summary>
    /// Creates instance of RoomTypesModel.
    /// </summary>
    /// <returns>Instance of RoomTypesModel</returns>
    public RoomTypesModel GenerateNewRoomType()
    {
      return new RoomTypesModel
      {
        OrganizationCode = "10",
        Code = DateTime.Now.Ticks.ToString().Substring(0, 12),
        Description = "TestDescription",
        Retire = "N",
        ResourceType = "1DBL",
        ResourceCode = "TEST222",
        AbbreviatedDescription = "DTD",
        AlternateAbbreviatedDescription1 = "DTD1",
        AlternateAbbreviatedDescription2 = "DTD2",
        AlternateAbbreviatedDescription3 = "DTD3",
        AlternateAbbreviatedDescription4 = "DTD4",
        AlternateAbbreviatedDescription5 = "DTD5",
        AlternateDescription1 = "AlternateDummyTestDescription1",
        AlternateDescription2 = "AlternateDummyTestDescription2",
        AlternateDescription3 = "AlternateDummyTestDescription3",
        AlternateDescription4 = "AlternateDummyTestDescription4",
        AlternateDescription5 = "AlternateDummyTestDescription5",
        AlternateRoomType = "LUXALT",
        NumberofPersons = 3,
        UserSortOrder = 18
      };
    }

    /// <summary>
    /// Method which update all property values of RoomTypesModel.
    /// </summary>
    /// <param name="model">Model instance which properties must be edited.</param>
    /// <returns>Given instance of RoomTypesModel with edited values of all properties.</returns>
    public RoomTypesModel EditRoomType(RoomTypesModel model)
    {
      model.Description = "Edited";
      model.Retire = model.Retire == "Y" ? "N" : "Y";
      model.AbbreviatedDescription = "EDT";
      model.AlternateAbbreviatedDescription1 = "EDT1";
      model.AlternateAbbreviatedDescription2 = "EDT2";
      model.AlternateAbbreviatedDescription3 = "EDT3";
      model.AlternateAbbreviatedDescription4 = "EDT4";
      model.AlternateAbbreviatedDescription5 = "EDT5";
      model.AlternateDescription1 = "Edited1";
      model.AlternateDescription2 = "Edited2";
      model.AlternateDescription3 = "Edited3";
      model.AlternateDescription4 = "Edited4";
      model.AlternateDescription5 = "Edited5";
      model.AlternateRoomType = "ALT";
      model.NumberofPersons = 8;
      model.UserSortOrder = 2;
      
      return model;
    }
  }
}