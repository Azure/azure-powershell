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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.FrontDoor.Models
{
    public class PSPolicy : PSTrackedResource
    {
        public string PolicyMode { get; set; }

        public PSEnabledState? PolicyEnabledState { get; set; }

        public string RedirectUrl { get; set; }

        public ushort? CustomBlockResponseStatusCode { get; set; }

        public string CustomBlockResponseBody { get; set; }

        public PSEnabledState? RequestBodyCheck { get; set; }

        public List<PSCustomRule> CustomRules { get; set; }

        public List<PSManagedRule> ManagedRules { get; set; }

        public string Etag { get; set; }

        public string ProvisioningState { get; set; }
    }
}
