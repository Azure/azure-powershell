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
    public class PSLinkTableRequest
    {
        public PSLinkTableRequest(LinkTableRequest linkTableRequest)
        {
            this.Id = linkTableRequest?.Id;
            this.Source = new PSLinkTableRequestSource(linkTableRequest?.Source);
            this.Target = new PSLinkTableRequestTarget(linkTableRequest?.Target);
            this.OperationType = linkTableRequest?.OperationType;
        }

        public string Id { get; set; }

        public PSLinkTableRequestSource Source { get; set; }

        public PSLinkTableRequestTarget Target { get; set; }

        public string OperationType { get; set; }
    }
}
