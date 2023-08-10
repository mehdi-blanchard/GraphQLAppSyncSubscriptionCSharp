using GraphQL;
using GraphQL.Client.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SubTest
{
    public static class GraphQLHttpClientOptionsEx
    {
        //--- Types ---
        private class AppSyncHeader
        {

            //--- Properties ---

            [JsonPropertyName("host")]
            public string Host { get; set; }

            [JsonPropertyName("x-api-key")]
            public string ApiKey { get; set; }
        }

        private class AuthorizedAppSyncHttpRequest : GraphQLHttpRequest
        {

            //--- Fields ---
            private readonly string _authorization;

            //--- Constructors ---
            public AuthorizedAppSyncHttpRequest(GraphQLRequest request, string authorization) : base(request)
                => _authorization = authorization;

            //--- Methods ---
            public override HttpRequestMessage ToHttpRequestMessage(GraphQLHttpClientOptions options, GraphQL.Client.Abstractions.IGraphQLJsonSerializer serializer)
            {
                var result = base.ToHttpRequestMessage(options, serializer);
                result.Headers.Add("X-Api-Key", _authorization);
                return result;
            }
        }

        //--- Extension Methods ---
        public static GraphQLHttpClientOptions ConfigureAppSync(
            this GraphQLHttpClientOptions options,
            string graphQlEndpoint,
            string apiKey
        )
        {
            var appSyncHost = new Uri(graphQlEndpoint).Host.Split('.');
            var realTimeEndpoint = $"wss://{appSyncHost[0]}.appsync-realtime-api.{appSyncHost[2]}.amazonaws.com/graphql";
            return ConfigureAppSync(options, graphQlEndpoint, realTimeEndpoint, apiKey);
        }

        public static GraphQLHttpClientOptions ConfigureAppSync(
            this GraphQLHttpClientOptions options,
            string graphQlEndpoint,
            string realTimeEndpoint,
            string apiKey
        )
        {

            // set GraphQL endpoint
            options.EndPoint = new Uri(graphQlEndpoint);

            // initialize authentication JSON data-structure
            var header = new AppSyncHeader
            {
                Host = options.EndPoint.Host,
                ApiKey = apiKey
            };

            // set real-time endpoint
            options.WebSocketEndPoint = new Uri(realTimeEndpoint
                + $"?header={Convert.ToBase64String(Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(header)))}"
                + "&payload=e30="
            );

            // TEST PRE-PROCESS 1
            // set pre-processor to add authentication HTTP header to request
            //options.PreprocessRequest = (request, client) => {
            //    return Task.FromResult((GraphQLHttpRequest)new AuthorizedAppSyncHttpRequest(request, apiKey));
            //};

            // TEST PRE-PROCESS 2
            // set subscription pre-processor to generate the correct AppSync payload for subscriptions
            //options.PreprocessSubscriptionRequest = (request, client) => {
            options.PreprocessRequest = (request, client) =>
            {
                GraphQLHttpRequest result;

                // check if request has to be modified
                if (request is GraphQLHttpRequest httpRequest)
                {

                    // use request as-is
                    result = httpRequest;
                }
                else if (!request.ContainsKey("data"))
                {

                    // wrap request in an AppSync compatible envelope
                    result = new GraphQLHttpRequest
                    {
                        ["data"] = System.Text.Json.JsonSerializer.Serialize(request),
                        ["extensions"] = new
                        {
                            authorization = header
                        }
                    };
                }
                else
                {

                    // use request as-is
                    result = new GraphQLHttpRequest(request);
                }
                return Task.FromResult(result);
            };

            // TEST PRE-PROCESS 3 (edom18)
            //options.PreprocessRequest = (req, client) =>
            //{
            //    GraphQLHttpRequest result = new AuthorizedAppSyncHttpRequest(req, Constants.GQLServerAPIKey)
            //    {
            //        ["data"] = JsonConvert.SerializeObject(req),
            //        ["extensions"] = new
            //        {
            //            authorization = header,
            //        }
            //    };
            //    return Task.FromResult(result);
            //};

            return options;
        }
    }
}
