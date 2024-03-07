﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Options;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  [System.ComponentModel.Browsable(false)] //Hides from intellisense
  [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] //Hides from intellisense
  public abstract class Base<TGenericUngerboeckModel> where TGenericUngerboeckModel : UngerboeckModel
  {

    protected readonly ApiClient Client;    

    protected Base(ApiClient api)
    {
      Client = api;
    }

    /// <summary>
    /// Temporary - This is only here to support subjects without async methods yet
    /// </summary> 
    protected SearchResponse<TGenericUngerboeckModel> Search(string orgCode, string searchOData, Search options = null)
    {      
      return SearchSync(orgCode, searchOData, options);      
    }

    protected Task<SearchResponse<TGenericUngerboeckModel>> SearchAsync(string orgCode, string searchOData, Search options = null)
    {
      if (string.IsNullOrWhiteSpace(searchOData))
      {
        throw new Exception("searchOData parameter is empty.  Please set it to the desired filter using OData syntax.  If you want" +
            " all results, use \'All\' as the string value.");
      }

      string orderByURLParameter, pageSizeURLParameter, maxResultsURLParameter;
      string orderby = string.Empty;

      if (options == null)
      {
        orderByURLParameter = string.Empty;
        pageSizeURLParameter = string.Empty;
        maxResultsURLParameter = string.Empty;
      }
      else
      {

        if (options.OrderBy.Count > 0) orderby = string.Join(",", options.OrderBy);

        if (string.IsNullOrWhiteSpace(orderby))
        {
          orderByURLParameter = string.Empty;
        }
        else
        {
          orderByURLParameter = "$orderby=" + orderby;
        }

        pageSizeURLParameter = $"$page_size={options.PageSize}";
        maxResultsURLParameter = $"$maxresults={options.MaxResults}";

      }

      string subjectName = Util.GetSubjectName<TGenericUngerboeckModel>();

      string searchURL = $"{Client.HttpClient.BaseAddress}/api/v1/{subjectName}";
      if (!string.IsNullOrEmpty(orgCode)) searchURL += $"/{orgCode}";

      searchURL += $"?search={searchOData}{pageSizeURLParameter}{maxResultsURLParameter}{orderByURLParameter}"; // pagesize, maxresults and orderby are optional.      

      return CallSearch(searchURL, options);
    }

    ///<summary>
    ///Use this function to navigate through fetched search results.
    ///</summary>        
    ///<param name="searchMetadata">This contains info on the results of the search, returned in the original search response header.  It's pass by reference, so just include the same Ungerboeck.Api.Models.SearchMetadataModel you got from the original search.</param>
    ///<param name="navigationURL">This should be one of the URLs found in the Ungerboeck.Api.Models.SearchMetadataModel.Links class.  Use the full URL of where you want to navigate to (Ex: https://mywebsite/api/v1/Bookings/10?search=APISearch|5e9184e0-782c-4deb-ae17-e37927281ca0$page=2$page_size=10)</param>
    ///<param name="options">Use this to change default behaviors of the search.</param>
    ///<returns>A list of models</returns>
    public SearchResponse<TGenericUngerboeckModel> NavigateSearchList(string navigationURL, Search options = null)
    {
      return NavigateSearchListSync(navigationURL, options);      
    }

    protected SearchResponse<TGenericUngerboeckModel> NavigateSearchListSync(string navigationURL, Search options = null)
    {
      var task = Task.Run(async () => await NavigateSearchListAsync(navigationURL, options));
      return task.Result;
    }

    ///<summary>
    ///Use this function to navigate through fetched search results.
    ///</summary>        
    ///<param name="searchMetadata">This contains info on the results of the search, returned in the original search response header.  It's pass by reference, so just include the same Ungerboeck.Api.Models.SearchMetadataModel you got from the original search.</param>
    ///<param name="navigationURL">This should be one of the URLs found in the Ungerboeck.Api.Models.SearchMetadataModel.Links class.  Use the full URL of where you want to navigate to (Ex: https://mywebsite/api/v1/Bookings/10?search=APISearch|5e9184e0-782c-4deb-ae17-e37927281ca0$page=2$page_size=10)</param>
    ///<param name="options">Use this to change default behaviors of the search.</param>
    ///<returns>A list of models</returns>
    public Task<SearchResponse<TGenericUngerboeckModel>> NavigateSearchListAsync(string navigationURL, Search options = null)
    {
      return CallSearch(navigationURL, options);
    }

    private Task<SearchResponse<TGenericUngerboeckModel>> CallSearch(string searchURL, Search options)
    {
      return SearchAsync<TGenericUngerboeckModel>(Client, searchURL, options);      
    }

    /// <summary>
    /// Temporary - This is only here to support subjects without async methods yet
    /// </summary>    
    protected TGenericUngerboeckModel Get(object parameters, Base options = null)
    {      
      return GetSync(parameters, options);      
    }

    protected Task<TGenericUngerboeckModel> GetAsync(object parameters, Base options = null)
    {
      string uRL = Util.GetSubjectName<TGenericUngerboeckModel>();
      uRL += Util.BuildRESTfulURLFromParameters(parameters);

      return GetAsync<TGenericUngerboeckModel>(Client, uRL, options);      
    }

    /// <summary>
    /// Temporary - This is only here to support subjects without async methods yet
    /// </summary>
    protected TGenericUngerboeckModel Add(TGenericUngerboeckModel model, Base options = null)
    {
      return AddSync(model, options);
    }

    protected Task<TGenericUngerboeckModel> AddAsync(TGenericUngerboeckModel model, Base options = null)
    {
      string subjectName = Util.GetSubjectName<TGenericUngerboeckModel>();

      return PostAsync(Client, subjectName, model, options);      
    }


    protected SearchResponse<TGenericUngerboeckModel> SearchSync(string orgCode, string searchOData, Search options = null)
    {
      var task = Task.Run(async () => await SearchAsync(orgCode, searchOData, options));
      return task.Result;
    }

    protected TGenericUngerboeckModel GetSync(object parameters, Base options = null)
    {
      var task = Task.Run(async () => await GetAsync(parameters, options));
      return task.Result;     
    }

    protected TGenericUngerboeckModel UpdateSync(object parameters, TGenericUngerboeckModel model, Base options = null)
    {
      var task = Task.Run(async () => await UpdateAsync(parameters, model, options));
      return task.Result;
    }

    protected TGenericUngerboeckModel AddSync(TGenericUngerboeckModel model, Base options)
    {
      var task = Task.Run(async () => await AddAsync(model, options));
      return task.Result;
    }

    protected HttpResponseMessage DeleteSync(object parameters, Base options = null)
    {
      var task = Task.Run(async () => await DeleteAsync(parameters, options));
      return task.Result;
    }

    protected Ungerboeck.Api.Models.Bulk.BulkResponseModel BulkSync(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Base options = null)
    {
      var task = Task.Run(async () => await BulkAsync(bulkRequestModel, options));
      return task.Result;
    }

    /// <summary>
    /// This technique prevents deadlock when calling asynchronous functions synchronously
    /// </summary>    
    protected static T CustomSync<T>(Task<T> x)
    {      
      var task = Task.Run(async () => await x);
      return task.Result;
    }

    /// <summary>
    /// Temporary - This is only here to support subjects without async methods yet
    /// </summary>
    protected TGenericUngerboeckModel Update(object parameters, TGenericUngerboeckModel model, Base options = null)
    {
      return UpdateSync(parameters, model, options);
    }

    protected Task<TGenericUngerboeckModel> UpdateAsync(object parameters, TGenericUngerboeckModel model, Base options = null)
    {
      string uRl = Util.GetSubjectName<TGenericUngerboeckModel>();
      uRl += Util.BuildRESTfulURLFromParameters(parameters);

      return PutAsync(Client, uRl, model, options);      
    }

    /// <summary>
    /// Temporary - This is only here to support subjects without async methods yet
    /// </summary>
    protected HttpResponseMessage Delete(object parameters, Base options = null)
    {
      return DeleteSync(parameters, options);
    }

    protected Task<HttpResponseMessage> DeleteAsync(object parameters, Base options = null)
    {
      string uRL = Util.GetSubjectName<TGenericUngerboeckModel>();
      uRL += Util.BuildRESTfulURLFromParameters(parameters);

      return DeleteAsync(Client, uRL, options);      
    }

    /// <summary>
    /// Temporary - This is only here to support subjects without async methods yet
    /// </summary>
    protected Ungerboeck.Api.Models.Bulk.BulkResponseModel Bulk(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Base options = null)
    {
      return BulkSync(bulkRequestModel, options);
    }

    protected Task<Ungerboeck.Api.Models.Bulk.BulkResponseModel> BulkAsync(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Base options = null)
    {
      string uRL = $"Bulk/{Util.GetSubjectName<TGenericUngerboeckModel>()}";

      Task<Ungerboeck.Api.Models.Bulk.BulkResponseModel> bulkResponseModelTask = PostAsync<Ungerboeck.Api.Models.Bulk.BulkRequestModel, Ungerboeck.Api.Models.Bulk.BulkResponseModel>(Client, uRL, bulkRequestModel, options);
      return bulkResponseModelTask;
    }

    protected async Task<SearchResponse<T>> SearchAsync<T>(ApiClient client, string url, Base options) where T:TGenericUngerboeckModel
    {    
      HttpResponseMessage response = null;
      var headers = new Dictionary<string, string>();

      if (client.GlobalOptions.TargetLoadBalancedServer != null){
        string targetLoadBalancedServerCookie=string.Empty;
        foreach (string serverCookie in client.GlobalOptions.TargetLoadBalancedServer) targetLoadBalancedServerCookie += serverCookie.Substring(0, serverCookie.IndexOf(';')) + ";"; //Add targeted load balanaced server 
        if (headers.ContainsKey("Cookie")) headers.Remove("Cookie");
        headers.Add("Cookie", targetLoadBalancedServerCookie.Trim(';'));
      }

      PrepForLaunch(client, ref url, ref headers, ref options);       

      response = await CallSendAsync(client, url, response, headers).ConfigureAwait(false);

      if (await Util.ValidateResponse(client, response))
      {
        SetLoadBalancerCookie(client, response, headers);

        IEnumerable<T> list = await response.Content.ReadAsAsync<IEnumerable<T>>();  // Read back the item from the response
        string searchMetadata = response.Headers.GetValues("X-SearchMetadata").FirstOrDefault();
        SearchMetadataModel searchData = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchMetadataModel>(searchMetadata);
        return new SearchResponse<T>() { Results = list, SearchMetadata = searchData };
      }

      return default;
    }

    /// <summary>
    /// Normally, API use is load-balancer agnostic.
    /// When searching and paging is used, the same load balance server needs to be used.
    /// To manually choose which load-balanced server to call, we can collect and set a cookie that forces a particular balancer.
    /// </summary>
    private static void SetLoadBalancerCookie(ApiClient client, HttpResponseMessage response, Dictionary<string,string> headers)
    {
      IEnumerable<string> responseCookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
      if (responseCookies != null)
      {
        client.GlobalOptions.TargetLoadBalancedServer = new List<string>();

        foreach (var cookie in responseCookies)
        {
          if (cookie.StartsWith("AWS")) client.GlobalOptions.TargetLoadBalancedServer.Add(cookie);          
        }
      }
    }

    protected async Task<T> GetAsync<T>(ApiClient client, string url, Base options)
    {      
      HttpResponseMessage response = null;
      var headers = new Dictionary<string, string>();

      PrepForLaunch(client, ref url, ref headers, ref options);

      response = await CallSendAsync(client, url, response, headers).ConfigureAwait(false);

      return await HandleResponse<T>(client, response);      
    }

    private static async Task<HttpResponseMessage> CallSendAsync(ApiClient client, string url, HttpResponseMessage response, Dictionary<string, string> headers)
    {
      try
      {
        if (url != null && !url.Contains("/api/")) url = $"{client.HttpClient.BaseAddress}/api/v1/{url}"; //ensures base address is present

        using (var requestMessage =
          new HttpRequestMessage(HttpMethod.Get, url))
        {
          foreach (KeyValuePair<string, string> header in headers)
          {
            requestMessage.Headers.Add(header.Key, header.Value);
          }

          response = await client.HttpClient.SendAsync(requestMessage).ConfigureAwait(false);

          if (response?.Content?.Headers?.ContentType?.MediaType == "text/html"){
            throw new Exception($"Ungerboeck API has returned an html/text response.  Please make sure your UngerboeckURI is set properly and any search navigation links are correct.  Content returned: {response.Content.ReadAsStringAsync().Result}");
          }
        }        
      }
      catch (Exception ex)
      {
        SetHttpClientError(client, ex);
      }

      return response;
    }

    protected Task<T> PostAsync<T>(ApiClient client, string URL, T item, Base options)
    {
      return PostAsync<T, T>(client, URL, item, options);
    }

    protected async Task<U> PostAsync<T, U>(ApiClient client, string URL, T item, Base options)
    {
      HttpResponseMessage response = null;
      var headers = new Dictionary<string, string>();

      PrepForLaunch(client, ref URL, ref headers, ref options);
      try
      {
        if (item != null)
        {
          response = await HttpClientExtensions.PostAsJsonAsync(client, $"{client.HttpClient.BaseAddress}/api/v1/{URL}", item, headers).ConfigureAwait(false);
        }
        else
        {
          response = await HttpClientExtensions.PostAsJsonAsync(client, $"{client.HttpClient.BaseAddress}/api/v1/{URL}", headers).ConfigureAwait(false);
        }
      }
      catch (Exception ex)
      {
        SetHttpClientError(client, ex);
      }

      return await HandleResponse<U>(client, response);
    }


    private static async Task<U> HandleResponse<U>(ApiClient client, HttpResponseMessage response)
    {
      if (await Util.ValidateResponse(client, response) && response != null)
      {
        if (typeof(U) == typeof(HttpResponseMessage))
        {
          dynamic r = response; //return response directly
          return r;
        }

        return await response.Content.ReadAsAsync<U>();
      }
      return default;
    }

    protected Task<T> PutAsync<T>(ApiClient client, string URL, T item, Base options)
    {
      return PutAsync<T, T>(client, URL, item, options);
    }

    protected async Task<U> PutAsync<T, U>(ApiClient client, string URL, T item, Base options)
    {
      HttpResponseMessage response = null;
      var headers = new Dictionary<string, string>();
        
      PrepForLaunch(client, ref URL, ref headers, ref options);
      try
      {
        response = await HttpClientExtensions.PutAsJsonAsync(client, $"{client.HttpClient.BaseAddress}/api/v1/{URL}", item, headers).ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        SetHttpClientError(client, ex);
      }

      return await HandleResponse<U>(client, response);
    }

    protected async Task<HttpResponseMessage> DeleteAsync(ApiClient client, string URL, Base options)
    {
      HttpResponseMessage response = null;
      var headers = new Dictionary<string, string>();
        
      PrepForLaunch(client, ref URL, ref headers, ref options);
      try
      {
        response = await HttpClientExtensions.DeleteAsJsonAsync(client, $"{client.HttpClient.BaseAddress}/api/v1/{URL}", headers).ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        SetHttpClientError(client, ex);
      }

      return await HandleResponse<HttpResponseMessage>(client, response);   
    }

    protected void SetValidation(List<int> validationOverrides, bool? validation, ValidationCodes validationCode)
    {
      if (validation == true) validationOverrides.Add((int)validationCode); //Note the '== true' is needed due to a nullable boolean
    }
    protected void SetValidation(Dictionary<int, string> validationOverrides, bool? validation, ValidationCodes validationCode)
    {
      if (validation == true) validationOverrides.Add((int)validationCode, validation.ToString()); //Note the '== true' is needed due to a nullable boolean
    }

    protected void SetValidation(Dictionary<int, string> validationOverrides, string validation, ValidationCodes validationCode)
    {
      if (validation != null) validationOverrides.Add((int)validationCode, validation); 
    }

    protected async Task<string> GetResponseContentAsString(Task<HttpResponseMessage> task)
    {
      var response = await task;
      var contentTask = await response.Content.ReadAsStringAsync();
      return contentTask;
    }

    private static void SetHttpClientError(ApiClient client, Exception ex)
    {
      client.LastResponseError = new Ungerboeck.Api.Models.Errors.ApiErrors(400, "HttpCallFailed",
                $"HttpClient called failed.  Error returned: {ex.Message}",
                Ungerboeck.Api.Models.Errors.ErrorSources.Sdk);
    }

    private void PrepForLaunch(ApiClient client, ref string URL, ref Dictionary<string, string> headers, ref Ungerboeck.Api.Models.Options.Base options)
    {
      Util.SetOptions(ref options);
      if (AuthUtil.ShouldAutoRefresh(client)) AuthUtil.RefreshJWT(client);
      URL = Util.BuildSelect(URL, options);

      GetSubjectHeaders(ref headers, options);

      List<int> validationOverrides = new List<int>();
      Dictionary<int, string> validationOverridesValues = new Dictionary<int, string>();

      CollectValidationOverridesFromOptions(ref validationOverrides, headers, options);
      CollectValidationOverridesFromOptions(ref validationOverridesValues, headers, options);
      if (validationOverrides.Count > 0 || validationOverridesValues.Count > 0) AddValidationOverridesHeader(validationOverrides, validationOverridesValues, headers);
                  
      client.LastResponseError = null; //Clear out previous response errors, if any
    }

    protected virtual Dictionary<string, string> GetSubjectHeaders(ref Dictionary<string, string> headers, Models.Options.Base options)
    {
      return new Dictionary<string, string>();
    }

    protected virtual void CollectValidationOverridesFromOptions(ref List<int> validationOverrides, Dictionary<string, string> headers, Ungerboeck.Api.Models.Options.Base baseOptions)
    {
      return;
    }
    protected virtual void CollectValidationOverridesFromOptions(ref Dictionary<int, string> validationOverrides, Dictionary<string, string> headers, Ungerboeck.Api.Models.Options.Base baseOptions)
    {
      return;
    }

    internal virtual void AddValidationOverridesHeader(List<int> validationOverrides, Dictionary<int, string> validationOverridesValues, Dictionary<string, string> headers)
    {
      //Examples of valid headers:
      //[{"Code": 12015}]
      //[{"Code": 12015,"Value": ""}]
      //[{"Code": 12015,"Value": "Y"}]
      //
      //Or Multiple
      //[{"Code": 12015},{"Code": 12068}]
      //[{"Code": 12015,"Value": "Y"},{"Code": 12068,"Value": "X"}]
      //(As of Jan 2023, no values are used in overrides yet)


      string codes = $"[";

      foreach (int validationOverride in validationOverrides)
      {
        //Multiple gets formatted as  [{"Code": 12015,"Code": 12068}]

        codes = $"{codes}{{\"Code\": {validationOverride}}},";
      }

      foreach (var validationOverride in validationOverridesValues)
      {
        //[{"Code": 12015,"Value": "Y"},{"Code": 12068,"Value": "X"}]

        codes = $"{codes}{{\"Code\": {validationOverride.Key},\"Value\": \"{validationOverride.Value}\" }},";
      }

      codes = $"{codes.Trim(',')}]";

      headers.Add("X-ValidationOverrides", codes);
    }

    protected T GetOptions<T>(Base baseOptions)
    {
      if (baseOptions == null || baseOptions.GetType() != typeof(T)) return default(T);
      return (T)System.Convert.ChangeType(baseOptions, typeof(T));
    }
  }
}
