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
// ----------------------------------------------------------------------------------using Azure.Analytics.Synapse.Artifacts.Models;

using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkConnectionDetailedStatus
    {
        public PSLinkConnectionDetailedStatus(LinkConnectionDetailedStatus detailedStatus, string workspaceName)
        {
            this.WorkspaceName = workspaceName;
            this.Id = detailedStatus?.Id;
            this.Name = detailedStatus?.Name;
            this.IsApplyingChanges = detailedStatus?.IsApplyingChanges;
            this.IsPartiallyFailed = detailedStatus?.IsPartiallyFailed;
            this.StartTime = detailedStatus?.StartTime;
            this.StopTime = detailedStatus?.StopTime;
            this.Status = detailedStatus?.Status;
            this.ContinuousRunId = detailedStatus?.ContinuousRunId;
            this.Error = detailedStatus?.Error;
        }

        public string WorkspaceName { get; set; }

        public string Id { get; }

        public string Name { get; }
    
        public bool? IsApplyingChanges { get; }

        public bool? IsPartiallyFailed { get; }

        public object StartTime { get; }

        public object StopTime { get; }

        public string Status { get; }

        public string ContinuousRunId { get; }

        public object Error { get; }
    }
}
