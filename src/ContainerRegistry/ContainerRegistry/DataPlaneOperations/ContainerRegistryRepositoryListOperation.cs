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

using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry.DataPlaneOperations
{
    public class ContainerRegistryRepositoryListOperation : ContainerRegistryDataPlaneOperationBase<IList<string>>
    {
        private const int _defaultPagination = 100;
        private readonly int? _first;

        public ContainerRegistryRepositoryListOperation(ContainerRegistryDataPlaneClient client, int? first) : base(client) 
        {
            this._first = first;
        }

        public override IList<string> SendRequest()
        {
            int? first = _first;
            string last = default(string);
            IList<string> repositories = null;

            bool hasNext = true;
            while (hasNext)
            {
                hasNext = false;
                int? size = _defaultPagination;
                if (first != null)
                {
                    size = first > _defaultPagination ? _defaultPagination : first;
                    first -= size;
                }

                var response = _client
                    .GetClient()
                    .Repository
                    .GetListWithHttpMessagesAsync(last: last, n: size)
                    .GetAwaiter()
                    .GetResult();

                IList<string> names = response.Body.Names;
                if (repositories == null)
                {
                    repositories = new List<string>();
                }
                if (names != null && names.Count != 0)
                {
                    foreach (string name in names)
                    {
                        repositories.Add(name);
                    }
                }

                if (first != null && first <= 0)
                {
                    break;
                }

                string nextLink = response.Headers.Link;
                if (nextLink != null && nextLink.Length != 0)
                {
                    try
                    {
                        last = GetLastListed(nextLink);
                        hasNext = true;
                    }
                    catch
                    {
                        throw new PSInvalidOperationException(string.Format("Invalid next link: {0}", nextLink));
                    }
                }
            }

            return repositories;
        }
    }
}
