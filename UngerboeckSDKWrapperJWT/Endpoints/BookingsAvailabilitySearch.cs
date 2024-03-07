using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Options;
using Ungerboeck.Api.Models.Options.Subjects;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Subjects.AvailabilitySearch;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class BookingsAvailabilitySearch : Base<RequestModel>
  {
    public BookingsAvailabilitySearch(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// Use this endpoint to search for a list of potential booking dates and times
    /// </summary>
    /// <param name="body">This should contain a filled model of this subject. Note that any null model properties will be ignored.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>List of available timeslots and correlating spaces</returns>
    public Task<List<ResponseModel>> AvailabilitySearchAsync(RequestModel body, Ungerboeck.Api.Models.Options.Subjects.BookingsAvailabilitySearch options = null)
    {
      return base.PostAsync<RequestModel, List<ResponseModel>>(Client,$"Bookings/AvailabilitySearch", body, options);
    }
  }
}
