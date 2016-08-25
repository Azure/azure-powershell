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

using System;

namespace LocalModels
{
    public class Collection : Microsoft.WindowsAzure.Management.RemoteApp.Models.Collection
    {
        public DateTime LastModifiedLocalTime { get; set; }
        public Collection(Microsoft.WindowsAzure.Management.RemoteApp.Models.Collection col)
        {
            AdInfo = col.AdInfo;
            PlanName = col.PlanName;
            Type = col.Type;
            CustomRdpProperty = col.CustomRdpProperty;
            Description = col.Description;
            DnsServers = col.DnsServers;
            LastErrorCode = col.LastErrorCode;
            LastModifiedTimeUtc = col.LastModifiedTimeUtc;
            LastModifiedLocalTime = col.LastModifiedTimeUtc.ToLocalTime();
            MaxSessions = col.MaxSessions;
            Mode = col.Mode;
            Name = col.Name;
            OfficeType = col.OfficeType;
            ReadyForPublishing = col.ReadyForPublishing;
            Region = col.Region;
            SessionWarningThreshold = col.SessionWarningThreshold;
            Status = col.Status;
            SubnetName = col.SubnetName;
            TemplateImageName = col.TemplateImageName;
            TrialOnly = col.TrialOnly;
            VNetName = String.IsNullOrWhiteSpace(col.VNetName) || col.VNetName.StartsWith ("simplevnet-") ? "" : col.VNetName;
            AclLevel = col.AclLevel;
        }
    }
}
