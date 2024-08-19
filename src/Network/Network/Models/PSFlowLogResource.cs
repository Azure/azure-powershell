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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSFlowLogResource : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string TargetResourceId { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string TargetResourceGuid { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string StorageId { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string EnabledFilteringCriteria { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? Enabled { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSManagedServiceIdentity Identity { get; set; }

        public PSRetentionPolicyParameters RetentionPolicy { get; set; }

        public PSFlowLogFormatParameters Format { get; set; }

        public PSTrafficAnalyticsProperties FlowAnalyticsConfiguration { get; set; }

        [JsonIgnore]
        public string RetentionPolicyText
        {
            get { return JsonConvert.SerializeObject(this.RetentionPolicy, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string FormatText
        {
            get { return JsonConvert.SerializeObject(this.Format, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IdentityText
        {
            get { return JsonConvert.SerializeObject(Identity, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string FlowAnalyticsConfigurationText
        {
            get { return JsonConvert.SerializeObject(this.FlowAnalyticsConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
