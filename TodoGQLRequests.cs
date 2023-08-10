using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubTest
{
    internal class TodoGQLRequests
    {
        public static GraphQLRequest GetTodoListRequest(string next)
        {
            return new GraphQLRequest
            {
                Query = $@"
                        query {{ 
                          listTodos{(next != null ? "(" + next + ")" : "")} {{
                            items {{
                              id
                              name
                              description
                              status
                            }}
                            nextToken
                          }}
                        }}"
            };
        }

        public static GraphQLRequest TodoCreatedSubscriptionRequest()
        {
            return new GraphQLRequest
            {
                Query = $@"
                        subscription {{ 
                          onCreateTodo {{
                              id
                              name
                              description
                              status
                          }}
                        }}"
            };
        }

    }
}

