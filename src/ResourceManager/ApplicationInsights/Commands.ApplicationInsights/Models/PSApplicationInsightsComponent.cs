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

using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ApplicationInsights.Models
{
    public class PSApplicationInsightsComponent
    {
        public PSApplicationInsightsComponent(ApplicationInsightsComponent component)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(component.Id);
            this.Name = component.Name;
            this.Id = component.Id;
            this.Location = component.Location;
            this.Tags = component.Tags;
            this.Kind = component.Kind;
            this.Type = component.Type;
            this.AppId = component.AppId;
            this.ApplicationType = component.ApplicationType;
            this.CreationDate = component.CreationDate;
            this.FlowType = component.FlowType;
            this.HockeyAppId = component.HockeyAppId;
            this.HockeyAppToken = component.HockeyAppToken;
            this.InstrumentationKey = component.InstrumentationKey;
            this.ProvisioningState = component.ProvisioningState;
            this.RequestSource = component.RequestSource;
            this.SamplingPercentage = component.SamplingPercentage;
            this.TenantId = component.TenantId;
        }

        public string Id { get; set; }

        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

        public string Kind { get; set; }

        public string Location { get; set; }

        public string Type { get; set; }

        public string AppId { get; set; }

        public string ApplicationType { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public DateTime? CreationDate { get; set; }

        public string FlowType { get; set; }

        public string HockeyAppId { get; set; }

        public string HockeyAppToken { get; set; }

        public string InstrumentationKey { get; set; }

        public string ProvisioningState { get; set; }

        public string RequestSource { get; set; }

        public double? SamplingPercentage { get; set; }

        public string TenantId { get; set; }

        public static PSApplicationInsightsComponent Create(ApplicationInsightsComponent component)
        {
            var result = new PSApplicationInsightsComponent(component);

            return result;
        }

        private static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }
    }

    public class PSApplicationInsightsComponentTableView : PSApplicationInsightsComponent
    {
        public PSApplicationInsightsComponentTableView(ApplicationInsightsComponent component) 
            : base(component)
        {
        }
    }
}