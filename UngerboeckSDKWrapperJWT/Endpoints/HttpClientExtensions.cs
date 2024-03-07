using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  internal static class HttpClientExtensions
  {

    public static Task<HttpResponseMessage> PostAsJsonAsync(ApiClient client, string url, Dictionary<string, string> headers)
    {
      var dataAsString = JsonConvert.SerializeObject(null);
      var content = new StringContent(dataAsString);
      content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      AddHeaders(headers, content);

      return client.HttpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PostAsJsonAsync<T>(ApiClient client, string url, T data, Dictionary<string, string> headers)
    {
      var dataAsString = JsonConvert.SerializeObject(data);
      var content = new StringContent(dataAsString);
      content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      AddHeaders(headers, content);

      return client.HttpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJsonAsync<T>(ApiClient client, string url, T data, Dictionary<string, string> headers)
    {
      var dataAsString = JsonConvert.SerializeObject(data);
      var content = new StringContent(dataAsString);
      content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      AddHeaders(headers, content);

      return client.HttpClient.PutAsync(url, content);
    }

    public static Task<HttpResponseMessage> DeleteAsJsonAsync(ApiClient client, string requestUri, Dictionary<string, string> headers = null)
    {
      var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);

      AddHeaders(headers, request);

      return client.HttpClient.SendAsync(request);
    }

    private static void AddHeaders(Dictionary<string, string> headers, StringContent content)
    {
      foreach (KeyValuePair<string, string> header in headers)
      {
        content.Headers.Add(header.Key, header.Value);
      }
    }

    private static void AddHeaders(Dictionary<string, string> headers, HttpRequestMessage httpRequest)
    {
      if (headers == null) return;
      foreach (KeyValuePair<string, string> header in headers)
      {
        httpRequest.Headers.Add(header.Key, header.Value);
      }
    }
  }
}