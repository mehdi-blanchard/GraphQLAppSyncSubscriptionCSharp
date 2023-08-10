using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SubTest
{
    internal class TodoGQL
    {
        public static int CHUNK_SIZE = 50;

        private static GraphQLHttpClient gql = null;

        public static bool InitializeGQL()
        {
            if (gql != null)
            {
                return true;
            }
            try
            {
                gql = new GraphQLHttpClient(new GraphQLHttpClientOptions
                {
                    EndPoint = new Uri(Constants.graphQlEndpoint),
                }, new NewtonsoftJsonSerializer());

                gql.HttpClient.DefaultRequestHeaders.Add("x-api-key", Constants.AppSyncApiKey);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<List<Todo>> GetTodos()
        {
            List<Todo> items = new List<Todo>();
            if (gql == null)
            {
                return items;
            }

            string nextToken = null;
            string next = null;

            do
            {
                GraphQLRequest request = TodoGQLRequests.GetTodoListRequest(next);
                if (request == null)
                {
                    return items;
                }
                try
                {
                    ResponseTypeTodos response = await SendQueryAsync<ResponseTypeTodos>(request);
                    if (response == null)
                    {
                        return items;
                    }

                    // The response
                    PropertyInfo dataProp = response.GetType().GetProperties().Where(x => x.PropertyType == typeof(Todos)).FirstOrDefault() as PropertyInfo;
                    if (dataProp == null)
                    {
                        return items;
                    }
                    Todos data = (Todos)dataProp.GetValue(response);

                    // The token
                    PropertyInfo tokenProp = data.GetType().GetProperties().Where(x => x.Name == "NextToken").FirstOrDefault() as PropertyInfo;
                    if (tokenProp != null)
                    {
                        nextToken = (string)tokenProp.GetValue(data);
                    }
                    if (!String.IsNullOrEmpty(nextToken))
                    {
                        next = $"nextToken: \"{nextToken}\"";
                    }

                    // The items
                    PropertyInfo itemsProp = data.GetType().GetProperties().Where(x => x.PropertyType == typeof(List<Todo>)).FirstOrDefault() as PropertyInfo;
                    List<Todo> batchItems = (List<Todo>)itemsProp.GetValue(data);
                    if (batchItems != null)
                    {
                        items.AddRange(batchItems);
                    }

                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                    throw;
                }

            } while (nextToken != null);
            return items;

        }

        public static async Task<TResponse> SendQueryAsync<TResponse>(GraphQLRequest request)
        {
            if (gql == null)
            {
                return default;
            }

            GraphQLResponse<TResponse> response = await gql.SendQueryAsync<TResponse>(request);
            return response.Data;
        }
    }
}
