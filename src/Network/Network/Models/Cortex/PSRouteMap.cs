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
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSRouteMap : PSChildResource
    {
        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "AssociatedInboundConnections", Target = ViewControl.Table)]
        public List<string> AssociatedInboundConnections { get; set; }

        [Ps1Xml(Label = "AssociatedOutboundConnections", Target = ViewControl.Table)]
        public List<string> AssociatedOutboundConnections { get; set; }

        [Ps1Xml(Label = "RouteMap Rules", Target = ViewControl.Table)]
        public List<PSRouteMapRule> Rules { get; set; }

        [JsonIgnore]
        public string AssociatedInboundConnectionsText
        {
            get { return JsonConvert.SerializeObject(AssociatedInboundConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AssociatedOutboundConnectionsText
        {
            get { return JsonConvert.SerializeObject(AssociatedOutboundConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RouteMapRulesText
        {
            get { return JsonConvert.SerializeObject(Rules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }

    public class PSRouteMapRule : PSChildResource
    {
        public List<PSRouteMapRuleCriterion> MatchCriteria { get; set; }

        public List<PSRouteMapRuleAction> Actions { get; set; }

        public string NextStepIfMatched { get; set; }

        [JsonIgnore]
        public string MatchCriteriaText
        {
            get { return JsonConvert.SerializeObject(MatchCriteria, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ActionsText
        {
            get { return JsonConvert.SerializeObject(Actions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }

    public class PSRouteMapRuleCriterion : PSChildResource
    {
        public string MatchCondition { get; set; }

        public List<string> RoutePrefix { get; set; }

        public List<string> Community { get; set; }

        public List<string> AsPath { get; set; }
    }

    public class PSRouteMapRuleAction : PSChildResource
    {
        public string Type { get; set; }

        public List<PSRouteMapRuleActionParameter> Parameters { get; set; }

        [JsonIgnore]
        public string ParametersText
        {
            get { return JsonConvert.SerializeObject(Parameters, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }

    public class PSRouteMapRuleActionParameter : PSChildResource
    {
        public List<string> RoutePrefix { get; set; }

        public List<string> Community { get; set; }

        public List<string> AsPath { get; set; }
    }
}