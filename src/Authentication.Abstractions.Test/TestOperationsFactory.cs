using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;

namespace Authentication.Abstractions.Test
{
    public class TestOperationsFactory : IHttpOperationsFactory
    {
        public const string Name = "HttpClientOperations";
        private static readonly HttpClient Client = new HttpClient();

        public static IHttpOperationsFactory Create()
        {
            return new TestOperationsFactory();
        }

        public IHttpOperations GetHttpOperations()
        {
            return new TestClientOperations(Client);
        }

        private class TestClientOperations : IHttpOperations
        {
            private readonly HttpClient _client;

            public TestClientOperations(HttpClient client)
            {
                _client = client;
            }

            public async Task<HttpResponseMessage> GetAsync(string requestUri)
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                    {Content = new StringContent(File.ReadAllText(@"TestData\GoodArmResponse.json"))};
                return await Task.FromResult(httpResponseMessage);
            }
        }
    }
}