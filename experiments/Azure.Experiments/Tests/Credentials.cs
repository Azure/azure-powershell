using Microsoft.Rest;
using Newtonsoft.Json;
using System.IO;

namespace Microsoft.Azure.Experiments.Tests
{
    internal static class Credentials
    {
        public static Context Get()
        {
            var text = File.ReadAllText(@"c:\Users\sergey\Desktop\php-test.json");
            var c = JsonConvert.DeserializeObject<Configuration>(text);
            return new Context(new TokenCredentials(new TokenProvider(c)), c.subscriptionId);
        }
    }
}
