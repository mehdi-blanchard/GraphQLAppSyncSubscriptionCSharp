using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubTest
{
    internal class Constants
    {
        public static string graphQlEndpoint { get { return "https://XXXXXXXXX.appsync-api.YYYYYYYYY.amazonaws.com/graphql"; } }
        public static string realTimeEndpoint { get { return "wss://XXXXXXXXX.appsync-realtime-api.YYYYYYYYY.amazonaws.com/graphql"; } }
        public static string AppSyncApiKey { get { return "ZZZZZZZZZZZZZ"; } }   // Expires after 5 days!
    }
}
