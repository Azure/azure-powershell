// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Rest.Azure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication.Test
{
    public class TestHttpOperationsFactory : IHttpOperationsFactory
    {
        ITestOutputHelper _output;
        private TestHttpOperationsFactory()
        {
        }

        IDictionary<string, object> _responses = new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        public IHttpOperations<T> GetHttpOperations<T>() where T : class, ICacheable
        {
            var result = new TestHttpOperations<T>(_responses, _output);
            return result;
        }

        public IHttpOperations<T> GetHttpOperations<T>(bool useCaching) where T :  class, ICacheable
        {
            var result = new TestHttpOperations<T>(_responses, _output);
            return result;
        }

        public static IHttpOperationsFactory Create<T>(IDictionary<string, T> responses, ITestOutputHelper output)
        {
            var factory = new TestHttpOperationsFactory();
            factory._output = output;
            foreach (var response in responses)
            {
                output.WriteLine($"[TestHttpOperationsFactory]:  Adding request response pair {response.Key} => {response.Value}");
                factory._responses.Add(response.Key, response.Value);
            }

            return factory;
        }

        class TestHttpOperations<T> : IHttpOperations<T>
        {
            ITestOutputHelper _output;
            IDictionary<string, T> _responses = new ConcurrentDictionary<string, T>(StringComparer.OrdinalIgnoreCase);

            public TestHttpOperations(IDictionary<string, T> responses, ITestOutputHelper output)
            {
                _output = output;
                foreach (var responsePair in responses)
                {
                    output.WriteLine($"[TestHttpOperations]:  Adding request response pair {responsePair.Key} => {responsePair.Value}");
                    _responses.Add(responsePair);
                }
            }
            public TestHttpOperations(IDictionary<string, object> responses, ITestOutputHelper output)
            {
                _output = output;
                foreach (var responsePair in responses)
                {
                    output.WriteLine($"[TestHttpOperations]:  Adding request response pair {responsePair.Key} => {responsePair.Value}");
                    _responses.Add(responsePair.Key, (T)(responsePair.Value));
                }
            }

            public Task DeleteAsync(string requestUri, CancellationToken token)
            {
                throw new NotImplementedException();
            }

            public Task<T> GetAsync(string requestUri, CancellationToken token)
            {
                if (!_responses.ContainsKey(requestUri))
                {
                    throw new CloudException(string.Format("Unexpected request Uri '{0}'", requestUri));
                }

                var output = _responses[requestUri];

                _output.WriteLine($"[TestHttpOperations]: Sent Response ({output}) to request GET {requestUri}");
                return Task.FromResult(output);
            }

            public Task<bool> HeadAsync(string requestUri, CancellationToken token)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<T>> ListAsync(string requestUri, CancellationToken token)
            {
                throw new NotImplementedException();
            }

            public Task<T> PutAsync(string requestUri, T payload, CancellationToken token)
            {
                throw new NotImplementedException();
            }

            public IHttpOperations<T> WithHeader(string name, IEnumerable<string> value)
            {
                // Allow the client to set one or more headers, but we are not using these in validation
                return this;
            }
        }
    }
}
