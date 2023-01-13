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
    public class PSLinkConnection
    {
        public PSLinkConnection(LinkConnection linkConnection)
        {
            this.SourceDatabase = linkConnection?.SourceDatabase != null ? new PSLinkConnectionSourceDatabase(linkConnection?.SourceDatabase) : null;
            this.TargetDatabase = linkConnection?.TargetDatabase != null ? new PSLinkConnectionTargetDatabase(linkConnection?.TargetDatabase) : null;
            this.LandingZone = linkConnection?.LandingZone != null ? new PSLinkConnectionLandingZone(linkConnection?.LandingZone) : null;
            this.Compute = linkConnection?.Compute != null ? new PSLinkConnectionCompute(linkConnection?.Compute) : null;
        }

        public PSLinkConnectionSourceDatabase SourceDatabase{ get; set;}

        public PSLinkConnectionTargetDatabase TargetDatabase { get; set;}

        public PSLinkConnectionLandingZone LandingZone { get; set; }

        public PSLinkConnectionCompute Compute { get; set; }
    }
}
