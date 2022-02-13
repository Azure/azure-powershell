// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Cdn.AfdModels
{
    public class PSAfdOrigin : PSArmBaseResource
    {
        public string OriginGroupName { get; set; }

        public string HostName { get; set; }

        public int? HttpPort { get; set; }

        public int? HttpsPort { get; set; }

        public string OriginHostHeader { get; set; }

        public int? Priority { get; set; }

        public int? Weight { get; set; }

        public string EnabledState { get; set; }

        public string PrivateLinkId { get; set; }

        // public string PrivateLinkGroupId { get; set; } // confirm this field

        public string PrivateLinkLocation { get; set; }

        // public string PrivateLinkStatus { get; set; } // confirm this field

        public string PrivateLinkRequestMessage { get; set; }
    }
}
