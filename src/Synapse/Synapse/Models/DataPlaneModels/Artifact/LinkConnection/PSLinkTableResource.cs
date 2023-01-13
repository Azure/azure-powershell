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

using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkTableResource
    {
        public PSLinkTableResource(LinkTableResource linkTableResource, string workspaceName, string linkConnectionName)
        {
            this.WorkspaceName = workspaceName;
            this.LinkConnectionName = linkConnectionName;
            this.Id = linkTableResource?.Id;
            this.Name = linkTableResource?.Name;
            this.Source = new PSLinkTableRequestSource(linkTableResource?.Source);
            this.Target = new PSLinkTableRequestTarget(linkTableResource?.Target);
        }

        public string WorkspaceName { get; set; }

        public string LinkConnectionName { get; set; }

        public string Id { get; }

        public string Name { get; }

        public PSLinkTableRequestSource Source { get; }

        public PSLinkTableRequestTarget Target { get; }
    }
}
