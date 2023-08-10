# GraphQLAppSyncSubscriptionCSharp

I am trying to implement Subscriptions with [graphql-client](https://github.com/graphql-dotnet/graphql-client) using both [#372 (comment1)](https://github.com/graphql-dotnet/graphql-client/issues/372#issuecomment-964576257) and [#372 (comment2)](https://github.com/graphql-dotnet/graphql-client/issues/372#issuecomment-990590565), and also referring to this [AppSync Websocket guide](https://docs.aws.amazon.com/appsync/latest/devguide/real-time-websocket-client.html)

I've copied [bjorg](https://github.com/bjorg/GraphQlAppSyncTest/tree/main/MyApp)'s GraphQLHttpClientOptionsEx.cs extension class (just replaced options.PreprocessSubscriptionRequest that doesn't exist to options.PreprocessRequest)
I've also tried with edom18 similar solution just in case.

My queries are working but I keep getting the same error when I call CreateSubscriptionStream:

**{"{\"payload\":{\"errors\":[{\"message\":\"SubProtocolNotSupportedError\",\"errorCode\":400}]},\"type\":\"connection_error\"}"}**

If I call InitializeWebsocketConnection I get the error: 

**"The remote party closed the WebSocket connection without completing the close handshake"**

Any help would be much appreciated.

**Step 1**
Your GraphQL schema needs a Todo model as shown below
```
enum TodoStatus {
  NOT_STARTED
  IN_PROGRESS
  DONE
  REJECTED
}
type Todo @model {
  id: ID!
  name: String!
  description: String!
  status: TodoStatus!
}
```

**Step 2**
Update the file Constants.cs with your AppSync settings

**Step 3**
Run the App
First Click "Get Todos" to make sure the query is running fine
Then Click either "Initialize Connection" or "Subscribe to Todos"

![image](https://github.com/mehdi-blanchard/GraphQLAppSyncSubscriptionCSharp/assets/9731893/640f4631-a326-43a8-ad8b-4c76b99c361a)
