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

using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkedServiceReference
    {
        public PSLinkedServiceReference(LinkedServiceReference linkServiceReference)
        {
            this.Type = linkServiceReference?.Type;
            this.ReferenceName = linkServiceReference?.ReferenceName;
            this.Parameters = linkServiceReference?.Parameters;
        }

        public LinkedServiceReferenceType? Type { get; set; }

        public string ReferenceName { get; set; }

        public object Parameters { get; set; }
    }
}

