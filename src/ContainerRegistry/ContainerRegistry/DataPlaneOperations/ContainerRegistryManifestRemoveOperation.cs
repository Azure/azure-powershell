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

namespace Microsoft.Azure.Commands.ContainerRegistry.DataPlaneOperations
{
    public class ContainerRegistryManifestRemoveOperation : ContainerRegistryDataPlaneOperationBase<bool>
    {
        private readonly string _repositoryName;
        private readonly string _manifestReference;

        public ContainerRegistryManifestRemoveOperation(ContainerRegistryDataPlaneClient client, string repository, string manifest) : base(client)
        {
            this._repositoryName = repository;
            this._manifestReference = manifest;
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
                return RepoAccessTokenPermission.DELETE_META_READ;
            }
        }

        public override bool SendRequest()
        {
            _client
            .GetClient()
            .Manifests
            .DeleteAsync(_repositoryName, _manifestReference)
            .GetAwaiter()
            .GetResult();
            return true;
        }
    }
}