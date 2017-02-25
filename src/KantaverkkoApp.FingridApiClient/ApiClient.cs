using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KantaverkkoApp.DataModel;
using KantaverkkoApp.FingridApiClient.Exceptions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KantaverkkoApp.FingridApiClient
{
    public class ApiClient
    {
        private readonly Uri _uri;
        private readonly HttpClient _httpClient;

        public ApiClient(string apiUrl, string apiKey)
        {
            _uri = new Uri(apiUrl);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<IList<Event>> GetEvents(DateTime startTime, DateTime endTime, VariableType variableType)
        {
            var response =
                await
                    _httpClient.GetAsync(
                        QueryHelpers.AddQueryString(
                            new Uri(_uri, $"/v1/variable/{(int) variableType}/events/json").AbsoluteUri,
                            new Dictionary<string, string>
                            {
                                {"start_time", startTime.ToString("s") + "Z"},
                                {"end_time", endTime.ToString("s") + "Z"},
                                {"variable_id", ((int) variableType).ToString()}
                            }));

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException();
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException();
                case HttpStatusCode.NotFound:
                    throw new InvalidEventTypeException();
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    throw new RowCountLimitExceededException();
                case HttpStatusCode.ServiceUnavailable:
                    throw new MaintenanceException();
            }

            var content = await response.Content.ReadAsStringAsync();

            var events = JsonConvert.DeserializeObject<List<Event>>(content, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });

            return events.OrderByDescending(x => x.StartTime).ToList();
        } 
    }
}
