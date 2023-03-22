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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSRouteMap : PSChildResource
    {
        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "RouteMap Rules", Target = ViewControl.Table)]
        public List<string> AssociatedInboundConnections { get; set; }

        [Ps1Xml(Label = "RouteMap Rules", Target = ViewControl.Table)]
        public List<string> AssociatedOutboundConnections { get; set; }

        [Ps1Xml(Label = "RouteMap Rules", Target = ViewControl.Table)]
        public List<PSRouteMapRule> Rules { get; set; }

        [JsonIgnore]
        public string RouteMapRulesText
        {
            get { return JsonConvert.SerializeObject(Rules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }

    public class PSRouteMapRule
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Label = "MatchCriteria", Target = ViewControl.Table)]
        public List<PSRouteMapRuleCriterion> MatchCriteria { get; set; }

        [Ps1Xml(Label = "Actions", Target = ViewControl.Table)]
        public List<PSRouteMapRuleAction> Actions { get; set; }

        [Ps1Xml(Label = "NextStepIfMatched ", Target = ViewControl.Table)]
        public string NextStepIfMatched { get; set; }
    }

    public class PSRouteMapRuleCriterion
    {
        [Ps1Xml(Label = "MatchCondition", Target = ViewControl.Table)]
        public string MatchCondition { get; set; }

        [Ps1Xml(Label = "RoutePrefix", Target = ViewControl.Table)]
        public List<string> RoutePrefix { get; set; }

        [Ps1Xml(Label = "Community", Target = ViewControl.Table)]
        public List<string> Community { get; set; }

        [Ps1Xml(Label = "AsPath", Target = ViewControl.Table)]
        public List<string> AsPath { get; set; }
    }

    public class PSRouteMapRuleAction
    {
        [Ps1Xml(Label = "Type", Target = ViewControl.Table)]
        public string Type { get; set; }

        [Ps1Xml(Label = "Parameter", Target = ViewControl.Table)]
        public List<PSRouteMapRuleActionParameter> Parameters { get; set; }
    }

    public class PSRouteMapRuleActionParameter
    {
        [Ps1Xml(Label = "RoutePrefix", Target = ViewControl.Table)]
        public List<string> RoutePrefix { get; set; }

        [Ps1Xml(Label = "Community", Target = ViewControl.Table)]
        public List<string> Community { get; set; }

        [Ps1Xml(Label = "AsPath", Target = ViewControl.Table)]
        public List<string> AsPath { get; set; }
    }
}