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

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    /// <summary>
    /// Routing rules for TiP
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    [KnownType(typeof(RampUpRule))]
    public class RoutingRule
    {
        [DataMember]
        public string Name { get; set; }
    }

    /// <summary>
    /// Routing rules for ramp up testing
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class RampUpRule : RoutingRule
    {
        [DataMember]
        public string ActionHostName { get; set; }
        [DataMember]
        public double ReroutePercentage { get; set; }
        [DataMember]
        public double? ChangeStep { get; set; }
        [DataMember]
        public int? ChangeIntervalInMinutes { get; set; }
        [DataMember]
        public double? MinReroutePercentage { get; set; }
        [DataMember]
        public double? MaxReroutePercentage { get; set; }
        [DataMember]
        public string ChangeDecisionCallbackUrl { get; set; }

        public override string ToString()
        {
            return string.Format("Type:RampUpRule, Name:{0}, ActionHostName:{1}, ReroutePercentage:{2}", Name, ActionHostName, ReroutePercentage);
        }
    }
}
