using System.Net;
using Newtonsoft.Json;
using RestaurantDataService.Helpers.Interfaces;
using RestaurantDataService.Models;

namespace RestaurantDataService.Helpers;

public class RemoteCalls : IRemoteCalls
{
    private readonly IDatabaseHelper _databaseHelper;  
    public RemoteCalls(IDatabaseHelper databaseHelper)
    {
        _databaseHelper = databaseHelper;
    }
    public async Task<YemeksepetiVendorResponseModel> GetRequestAsync(string endpoint)
    {
        using (HttpClient httpClient = new HttpClient(new HttpClientHandler
                   { AutomaticDecompression = DecompressionMethods.All }))
        {
            // Add headers copied from the browser
            httpClient.DefaultRequestHeaders.Add("Accept", Environment.GetEnvironmentVariable("ACCEPT"));
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", Environment.GetEnvironmentVariable("ACCEPT_ENCODING"));
            httpClient.DefaultRequestHeaders.Add("Accept-Language", Environment.GetEnvironmentVariable("ACCEPT_LANGUAGE"));
            httpClient.DefaultRequestHeaders.Add("Api-Version", Environment.GetEnvironmentVariable("API_VERSION"));
            httpClient.DefaultRequestHeaders.Add("Connection", Environment.GetEnvironmentVariable("CONNECTION"));
            httpClient.DefaultRequestHeaders.Add("dps-session-id", Environment.GetEnvironmentVariable("DPS_SESSION_ID"));
            httpClient.DefaultRequestHeaders.Add("Host", Environment.GetEnvironmentVariable("HOST"));
            httpClient.DefaultRequestHeaders.Add("Origin", Environment.GetEnvironmentVariable("ORIGIN"));
            httpClient.DefaultRequestHeaders.Add("perseus-client-id", Environment.GetEnvironmentVariable("PERSEUS_CLIENT_ID"));
            httpClient.DefaultRequestHeaders.Add("perseus-session-id", Environment.GetEnvironmentVariable("PERSEUS_SESSION_ID"));
            httpClient.DefaultRequestHeaders.Add("Referer", Environment.GetEnvironmentVariable("REFERER"));
            httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", Environment.GetEnvironmentVariable("SEC_FETCH"));
            httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", Environment.GetEnvironmentVariable("SEC_FETCH_MODE"));
            httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", Environment.GetEnvironmentVariable("SEC_FETCH_SITE"));
            httpClient.DefaultRequestHeaders.Add("TE", Environment.GetEnvironmentVariable("TE"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", Environment.GetEnvironmentVariable("USER_AGENT"));
            httpClient.DefaultRequestHeaders.Add("X-FP-API-KEY", Environment.GetEnvironmentVariable("X_FP_API_KEY"));
            httpClient.DefaultRequestHeaders.Add("X-PD-Language-ID", Environment.GetEnvironmentVariable("X_PD_Language_ID"));

            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                HttpResponseMessage httpResponse = httpClient.GetAsync(endpoint).GetAwaiter()
                    .GetResult();
                string responseBody = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                
                
                
                var result = new YemeksepetiVendorResponseModel();
                var contentType = httpResponse.Content.Headers.ContentType;

                if (contentType != null &&
                    contentType.MediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    result = JsonConvert.DeserializeObject<YemeksepetiVendorResponseModel>(responseBody, settings);
                    
                    // Write raw json data to database
                    _databaseHelper.WriteRawRestaurantData(result?.Data?.RestaurantId,
                        result?.Data?.YemeksepetiRestaurantCode, responseBody);
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}