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
    public class PSDatasetResource : PSSubResource
    {
        public PSDatasetResource(DatasetResource dataset, string workspaceName)
            : base(dataset?.Id,
                  dataset?.Name,
                  dataset?.Type,
                  dataset?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = dataset?.Properties;
        }

        public string WorkspaceName { get; set; }

        public Dataset Properties { get; set; }
    }
}
