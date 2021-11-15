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

using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.Azure.ContainerRegistry;
using Microsoft.Azure.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry.DataPlaneOperations
{
    public class ContainerRegistryTagListOperation : ContainerRegistryDataPlaneOperationBase<PSTagList>
    {
        private readonly string _repositoryName;

        public ContainerRegistryTagListOperation(ContainerRegistryDataPlaneClient client, string repository) : base(client)
        {
            this._repositoryName = repository;
        }

        protected override string Resource
        {
            get
            {
                return "repository";
            }
        }

        protected override string Name
        {
            get
            {
                return this._repositoryName;
            }
        }

        protected override string Permission
        {
            get
            {
                return RepoAccessTokenPermission.METADATA_READ;
            }
        }

        public override PSTagList SendRequest()
        {
            TagList tags = _client
                                .GetClient()
                                .Tag
                                .GetListAsync(_repositoryName)
                                .GetAwaiter()
                                .GetResult();
            return new PSTagList(tags);
        }
    }
}
