using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Subjects.Checklist;

namespace Examples.Operations
{
  public class EventOpportunities : Base
  {
    public EventOpportunities(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventOpportunitiesModel Get(string orgCode, int meetingSequence)
    {
      return apiClient.Endpoints.EventOpportunities.Get( orgCode, meetingSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventOpportunitiesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.EventOpportunities.Search(orgCode, $"{nameof(EventOpportunitiesModel.MeetingSequence)} eq {searchValue}");
    }

    /// <summary>
    /// Simple add example
    /// </summary>
    /// <returns>Added EventOpportunitiesModel</returns>
    public EventOpportunitiesModel Add()
    {
      var eventOpportunitiesModel = new EventOpportunitiesModel
      {
        Description = "UPI Test Meeting",
        Account = "00027399",
        Organization = "10",
        PreferredStartDate = DateTime.UtcNow,
        PreferredEndDate = DateTime.UtcNow.AddDays(1),
        HousingStart = DateTime.UtcNow,
        HousingEnd = DateTime.UtcNow.AddDays(1),
        Status = "80"
      };

      return apiClient.Endpoints.EventOpportunities.Add(eventOpportunitiesModel);
    }

    /// <summary>
    /// Simple add example Temporary added for testing 
    /// </summary>
    /// <returns>Added EventOpportunitiesModel</returns>
    public EventOpportunitiesModel Add_Another()
    {
      var eventOpportunitiesModel = new EventOpportunitiesModel
      {
        Description = "UPI ABC Board Meet",
        Account = "00000083",
        Organization = "10",
        PreferredStartDate = Convert.ToDateTime("2021-02-20 00:00:00"),
        PreferredEndDate = Convert.ToDateTime("2021-02-23 00:00:00"),
        HousingStart = Convert.ToDateTime("2021-02-20 00:00:00"),
        HousingEnd = Convert.ToDateTime("2021-02-24 00:00:00"),
        Status = "30"
      };

      return apiClient.Endpoints.EventOpportunities.Add(eventOpportunitiesModel);
    }

    /// <summary>
    /// Simple example for generating an event opportunity with user defined fields to add
    /// </summary>
    /// <returns>Example Event Opportunities Model to Add</returns>
    public EventOpportunitiesModel GenerateAddUserDefinedFields()
    {
      var eventOpportunitiesModel = new EventOpportunitiesModel
      {
        Description = "My Event Opportunity with User Fields",
        Account = "00000083",
        Organization = "10",
        PreferredStartDate = Convert.ToDateTime("2023-02-20 00:00:00"),
        PreferredEndDate = Convert.ToDateTime("2023-02-23 00:00:00"),
        HousingStart = Convert.ToDateTime("2023-02-20 00:00:00"),
        HousingEnd = Convert.ToDateTime("2023-02-24 00:00:00"),
        Status = "30"
      };

      eventOpportunitiesModel.EventOpportunityUserFields = new UserFields
      {
        Class = "C",
        Type = "0A",
        UserText01 = "Text Value for your User Defined Field #1",
        UserText02 = "Text Value for your User Defined Field #2",
        UserNumber01 = 100
      };

      return eventOpportunitiesModel;
    }

    /// <summary>
    /// Simple add example for an event opportunity with user defined fields
    /// </summary>
    /// <returns>Added event opportunity model</returns>
    public EventOpportunitiesModel AddUserDefinedFields()
    {
      EventOpportunitiesModel eventOpportunitiesModel = GenerateAddUserDefinedFields();
      return apiClient.Endpoints.EventOpportunities.Add(eventOpportunitiesModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strOrgCode"></param>
    /// <param name="intMeetingSeq"></param>
    /// <param name="strDesc"></param>
    /// <returns>Updated EventOpportunitiesModel</returns>
    public EventOpportunitiesModel Edit(string strOrgCode, int intMeetingSeq, string strDesc)
    {
      var meeting = apiClient.Endpoints.EventOpportunities.Get( strOrgCode, intMeetingSeq);

      if (meeting != null)
      {
        meeting.Description = strDesc;
      }

      return apiClient.Endpoints.EventOpportunities.Update(meeting);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public EventOpportunitiesModel EditAdvanced(string orgCode, int meetingSequence, string desc)
    {
      var meetingToUpdate = apiClient.Endpoints.EventOpportunities.Get( orgCode, meetingSequence);

      meetingToUpdate.Opportunity = 3;
      meetingToUpdate.ContactIDLegacy = "";
      meetingToUpdate.LocalContactIDLegacy = "";
      meetingToUpdate.Description = desc;
      meetingToUpdate.PreferredStartDate = Convert.ToDateTime("2015-03-05 00:00:00");
      meetingToUpdate.Status = "80";
      meetingToUpdate.HQHotelName = "PQR Hotel name";
      meetingToUpdate.LastUploadDate = Convert.ToDateTime("1900-01-01 00:00:00");
      meetingToUpdate.ExhibitLocation = "";
      meetingToUpdate.PeakBlockedRooms = 2;
      meetingToUpdate.PeakOptionRooms = 5;
      meetingToUpdate.ChangedOn = Convert.ToDateTime("2020-10-26 16:43:05.467");
      meetingToUpdate.HostCity = "LA";
      meetingToUpdate.PreferredEndDate = Convert.ToDateTime("2015-03-05 00:00:00");
      meetingToUpdate.TotalAttend = 123;
      meetingToUpdate.Event = 0;
      meetingToUpdate.Account = "00027399";
      meetingToUpdate.AlternateStart = Convert.ToDateTime("2015-03-12 00:00:00");
      meetingToUpdate.AlternateEnd = Convert.ToDateTime("2015-03-12 00:00:00");
      meetingToUpdate.Salesperson = "00010483";
      meetingToUpdate.BulletinNumber = 0;
      meetingToUpdate.LocalAttend = 0;
      meetingToUpdate.HousingStart = Convert.ToDateTime("2015-03-04 00:00:00");
      meetingToUpdate.FirstIssued = Convert.ToDateTime("2015-03-05 00:00:00");
      meetingToUpdate.Booked = Convert.ToDateTime("2015-03-05 00:00:00");
      meetingToUpdate.DecisionDate = Convert.ToDateTime("1980-01-01 00:00:00");
      meetingToUpdate.DecisionDateNote = "Test Decision note";
      meetingToUpdate.RoomFlowRollUp = "N";
      meetingToUpdate.DecisionMadeBy = "";
      meetingToUpdate.HostedByUs = "Y";
      meetingToUpdate.Region = "";
      meetingToUpdate.EnteredOn = Convert.ToDateTime("2015-03-05 10:53:41.45");
      meetingToUpdate.Frequency = "";
      meetingToUpdate.HQHotel = "HQ Hotel";
      meetingToUpdate.CompetingSites = "";
      meetingToUpdate.ServicesRep = "";
      meetingToUpdate.SatelliteOfficeRep = "";
      meetingToUpdate.Category = "";
      meetingToUpdate.Class = "";
      meetingToUpdate.Type = "";
      meetingToUpdate.TotalMeetingRooms = 0;
      meetingToUpdate.ConcurrentMeetingRooms = 0;
      meetingToUpdate.LargestMeetingRoom = 0;
      meetingToUpdate.Referral = "N";
      meetingToUpdate.MarketClass = "";
      meetingToUpdate.LeadSource = "";
      meetingToUpdate.NumberDays = 1;
      meetingToUpdate.EconomicImpact = 0;
      meetingToUpdate.EconomicImpactNote = "";
      meetingToUpdate.SelectionProcess = "";
      meetingToUpdate.Definite = Convert.ToDateTime("2015-03-05 00:00:00");
      meetingToUpdate.PreferredMonth1 = "";
      meetingToUpdate.HousingEnd = Convert.ToDateTime("2015-03-05 00:00:00"); 
      meetingToUpdate.PreferredMonth2 = "";
      meetingToUpdate.PreferredMonth3 = "";
      meetingToUpdate.DMAICode = "";
      meetingToUpdate.CancelledLostDate = Convert.ToDateTime("1900-01-01 00:00:00");
      meetingToUpdate.CancellationReason1 = "";
      meetingToUpdate.CancellationReason2 = "";
      meetingToUpdate.CancellationReason3 = "";
      meetingToUpdate.Contact = "";
      meetingToUpdate.LocalContact = "";
      meetingToUpdate.DateNote1 = "";
      meetingToUpdate.DateNote2 = "";
      meetingToUpdate.LastMetLocally = "";
      meetingToUpdate.ExhibitSpace = "";
      meetingToUpdate.ExhibitOpenDay = "";
      meetingToUpdate.ExhibitOpenDate = Convert.ToDateTime("1900-01-01 00:00:00");
      meetingToUpdate.ExhibitCloseDay = "";
      meetingToUpdate.ExhibitCloseDate = Convert.ToDateTime("1900-01-01 00:00:00");
      meetingToUpdate.ExhibitMoveInDays = 0;
      meetingToUpdate.ExhibitMoveOutDays = 0;
      meetingToUpdate.ExhibitFreeMoveInDays = 0;
      meetingToUpdate.ExhibitFreeMoveOutDays = 0;
      meetingToUpdate.ExhibitNetArea = 0;
      meetingToUpdate.ExhibitGrossArea = 0;
      meetingToUpdate.Exhibit10x10s = 0;
      meetingToUpdate.Exhibit8x10s = 0;
      meetingToUpdate.ExhibitTabletops = 0;
      meetingToUpdate.PeakArrivalDay = "MON";
      meetingToUpdate.PeakArrivalDate = Convert.ToDateTime("1900-01-01 00:00:00");
      meetingToUpdate.PeakDepartureDay = "MON";
      meetingToUpdate.PeakDepartureDate = Convert.ToDateTime("1900-01-01 00:00:00");
      meetingToUpdate.AdviseBureau = "N";
      meetingToUpdate.BureauArrivalDeparture = "N";
      meetingToUpdate.HousingRateSingle = 0;
      meetingToUpdate.HousingRateDouble = 0;
      meetingToUpdate.BlockedRoomNights = 0;
      meetingToUpdate.BlockedRoomSuites = 0;
      meetingToUpdate.MeetingPlannerRooms = 0;
      meetingToUpdate.MeetingPlannerRoomSuites = 0;
      meetingToUpdate.MeetingPlannerPeakRooms = 0;
      meetingToUpdate.PickupRoomNights = 0;
      meetingToUpdate.PickupRoomSuites = 0;
      meetingToUpdate.PeakPickupRooms = 0;
      meetingToUpdate.MealFunctionsLocation = "";
      meetingToUpdate.MealFunctionsLargest = 0;
      meetingToUpdate.RegisteredAttend = 0;
      meetingToUpdate.RegistrationBy = " ";
      meetingToUpdate.MiscNbr1 = 0;
      meetingToUpdate.MiscNbr2 = 0;
      meetingToUpdate.UserNbr1 = 0;
      meetingToUpdate.UserNbr2 = 0;
      meetingToUpdate.Public = "N";
      meetingToUpdate.HousingBy = " ";
      meetingToUpdate.HousingRateRange = "";
      meetingToUpdate.Sensitivity = "1";
      meetingToUpdate.OptionNights = 0;
      meetingToUpdate.UserText01 = "User Text";
      meetingToUpdate.UserDate01 = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.UserDate02 = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.UserDate03 = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.UserDate04 = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.UserDate05 = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.UserNumber01 = 0;
      meetingToUpdate.Confidential = "N";
      meetingToUpdate.Upload = "N";
      meetingToUpdate.International = "N";
      meetingToUpdate.AlternateHousingStart = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.AlternateHousingEndDate = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.TentativeDate = Convert.ToDateTime("1990-01-01 00:00:00");
      meetingToUpdate.ICCAID = 0;
      meetingToUpdate.NumberofHotelsUsed = 0;
      meetingToUpdate.PeakRoomsHQHotel = 0;
      meetingToUpdate.CampaignSourceDesignation = "";
      meetingToUpdate.GroupProfile = 0;
      meetingToUpdate.LargestMeetingRoomArea = 0;
      meetingToUpdate.MINTID = 0;
      meetingToUpdate.WinPercentage = 0;
      meetingToUpdate.ExpectedCloseDate = Convert.ToDateTime("1900-01-01 00:00:00");

      return apiClient.Endpoints.EventOpportunities.Update(meetingToUpdate);
    }

    /// <summary>
    /// Simple example for generating an event opportunity with user defined fields with edited values
    /// </summary>
    /// <param name="strOrgCode"></param>
    /// <param name="intMeetingSeq"></param>
    /// <returns>Example Event Opportunities Model with Edits</returns>
    public EventOpportunitiesModel GenerateEditUserDefinedFields(string strOrgCode, int intMeetingSeq)
    {
      var eventOpportunity = apiClient.Endpoints.EventOpportunities.Get(strOrgCode, intMeetingSeq);
      eventOpportunity.EventOpportunityUserFields.UserText01 = "Edited Text Value for your User Defined Field #1";
      eventOpportunity.EventOpportunityUserFields.UserText02 = "Edited Text Value for your User Defined Field #2";
      eventOpportunity.EventOpportunityUserFields.UserNumber01 = 101;
      return apiClient.Endpoints.EventOpportunities.Update(eventOpportunity);
    }

    /// <summary>
    /// Simple edit example for an event opportunity with user defined fields
    /// </summary>
    /// <param name="strOrgCode"></param>
    /// <param name="intMeetingSeq"></param>
    /// <returns>Edited event opportunity model</returns>
    public EventOpportunitiesModel EditUserDefinedFields(string strOrgCode, int intMeetingSeq)
    {
      var eventOpportunity = GenerateEditUserDefinedFields(strOrgCode, intMeetingSeq);
      return apiClient.Endpoints.EventOpportunities.Update(eventOpportunity);
    }

    /// <summary>
    /// This example is designed to show sample values to use when creating a new event from an event opportunity
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="meetingSequence"></param>
    /// <returns></returns>
    public EventsModel CreateEvent(string orgCode, int meetingSequence)
    {
      return apiClient.Endpoints.EventOpportunities.CreateEvent(orgCode, meetingSequence);
    }

    /// <summary>
    /// This example is designed to show sample values to use when creating a new event from an event opportunity
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="meetingSequence"></param>
    /// <returns></returns>
    public Task<EventsModel> CreateEventAsync(string orgCode, int meetingSequence)
    {
      return apiClient.Endpoints.EventOpportunities.CreateEventAsync(orgCode, meetingSequence);
    }

    /// <summary>
    /// A basic example of adding a checklist to an EventOpportunity.
    /// </summary>
    /// <param name = "orgCode" >organization Code of an Event.</ param >
    /// < param name="checklistCode">The checklistCode code.You can find this on the Activitychecklist window in Ungerboeck under the "Code" field (Database column MM456_CL_CODE).</param>
    /// < param name="meetingSequenceId">This is the meeting sequence Id,This is for event opprotunity for identify the perticular Event Opportunity</param>
    /// <returns></returns>
    public HttpResponseMessage AddChecklist(string orgCode, string checklistCode, int meetingSequenceId)
    {
      var model = new AddChecklistModel()
      {
        ChecklistCode = checklistCode,
      };

      return apiClient.Endpoints.EventOpportunities.AddChecklist(orgCode, meetingSequenceId, model);
    }

    /// <summary>
    /// A basic example of adding a checklist to an EventOpportunity.
    /// </summary>
    /// <param name = "orgCode" >organization Code of an Event.</ param >
    /// < param name="checklistCode">checklistCode of an Event</param>
    /// < param name="meetingSequenceId">This is the meeting sequence Id,This is for event opprotunity for identify the perticular Event Opportunity</param>
    /// <param name = "checklistDetailSequence" >checklistDetailSequence of an Event</ param >
    /// <param name="recipients">recipients of an Event</param>
    /// <returns></returns>
    public HttpResponseMessage AddChecklistWithDetailSequnceAndReceipient(string orgCode, string checklistCode, int meetingSequenceId, int checklistDetailSequence, string recipients)
    {
      var model = new AddChecklistModel()
      {
        ChecklistCode = checklistCode,
      };

      if (checklistDetailSequence > 0  && recipients != string.Empty)
      {
        model.ChecklistDetails = new List<AddChecklistDetailsModel>();

        AddChecklistDetailsModel addChecklistDetailsModel = new AddChecklistDetailsModel();
        addChecklistDetailsModel.ChecklistDetailSequence = checklistDetailSequence;
        addChecklistDetailsModel.Recipients = recipients;
        model.ChecklistDetails.Add(addChecklistDetailsModel);
      }

      return apiClient.Endpoints.EventOpportunities.AddChecklist(orgCode, meetingSequenceId, model);
    }

    /// <summary>
    /// A basic example of adding a checklist to an EventOpportunity.
    /// </summary>
    /// <param name = "orgCode" >organization Code of an Event.</ param >
    /// < param name="checklistCode">checklistCode of an Event</param>
    /// < param name="meetingSequenceId">This is the meeting sequence Id,This is for event opprotunity for identify the perticular Event Opportunity</param>
    /// <param name = "addChecklistDetailsModelItems" >aThis is an modle to create list of recipent and ckecklist detail sequence so the each recipent have unquie Id which is called detail seq Eg:-ChecklistDetailSequence : 1, Recipients :"Coord1", "Coord2"</ param >
    /// <returns></returns>
    public HttpResponseMessage AddChecklistWithChecklistDetailModel(string orgCode, string checklistCode, int meetingSequenceId, List<AddChecklistDetailsModel> addChecklistDetailsModelItems)
    {
      var model = new AddChecklistModel()
      {
        ChecklistCode = checklistCode,
      };

      if (addChecklistDetailsModelItems != null && addChecklistDetailsModelItems.Count > 0)
      {
        model.ChecklistDetails = new List<AddChecklistDetailsModel>();
        model.ChecklistDetails.AddRange(addChecklistDetailsModelItems);
      }

      return apiClient.Endpoints.EventOpportunities.AddChecklist(orgCode, meetingSequenceId, model);
    }

  }
}

