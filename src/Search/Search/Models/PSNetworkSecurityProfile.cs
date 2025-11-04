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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSNetworkSecurityProfile
    {
        [Ps1Xml(Label = "Network security profile name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Network security profile access rules version", Target = ViewControl.List, Position = 1)]
        public int? AccessRulesVersion { get; private set; }

        [Ps1Xml(Label = "Network security profile access rules", Target = ViewControl.List, Position = 2)]
        public IList<PSAccessRule> AccessRules { get; private set; }

        [Ps1Xml(Label = "Network security profile diagnostic settings version", Target = ViewControl.List, Position = 3)]
        public int? DiagnosticSettingsVersion { get; private set; }

        [Ps1Xml(Label = "Network security profile enabled log categories", Target = ViewControl.List, Position = 4)]
        public IList<string> EnabledLogCategories { get; private set; }

        public static explicit operator PSNetworkSecurityProfile(NetworkSecurityProfile v)
        {
            return new PSNetworkSecurityProfile()
            {
                Name = v.Name,
                AccessRulesVersion = v.AccessRulesVersion,
                AccessRules = v.AccessRules.Select(rule => (PSAccessRule)rule).ToList(),
                DiagnosticSettingsVersion = v.DiagnosticSettingsVersion,
                EnabledLogCategories = v.EnabledLogCategories,
            };
        }
    }
}
