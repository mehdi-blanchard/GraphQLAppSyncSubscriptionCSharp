using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SubTest
{
    internal class RTGQLConnect
    {
        private GraphQLHttpClient _graphQlClient;

        public GraphQLHttpClient GQLClient
        {
            get { return _graphQlClient; }
        }

        public void InitializeGQL()
        {
            var options = new GraphQLHttpClientOptions().ConfigureAppSync(Constants.graphQlEndpoint, Constants.realTimeEndpoint, Constants.AppSyncApiKey);
            _graphQlClient = new GraphQLHttpClient(options, new NewtonsoftJsonSerializer());
        }

        public async Task InitializeConnection()
        {
            if (_graphQlClient == null)
            {
                throw new Exception("Client Not initialized");
            }
            try
            {
                await _graphQlClient.InitializeWebsocketConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
