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

using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "Config")]
    [OutputType(typeof(PSConfig))]
    public class GetConfigCommand : ConfigCommandBase, IDynamicParameters
    {
        public GetConfigCommand() : base()
        {
        }

        public new object GetDynamicParameters()
        {
            return GetDynamicParameters((ConfigDefinition config) =>
                new RuntimeDefinedParameter(
                    config.Key,
                    typeof(SwitchParameter),
                    new Collection<Attribute>() {
                        new ParameterAttribute {
                            HelpMessage = config.HelpMessage
                        }
                    }));
        }

        public override void ExecuteCmdlet()
        {
            ConfigFilter filter = CreateConfigFilter();

            IEnumerable<ConfigData> configs = ConfigManager.ListConfigs(filter);
            WriteObject(configs.Select(x => new PSConfig(x)), true);
        }

        private ConfigFilter CreateConfigFilter()
        {
            ConfigFilter filter = new ConfigFilter() { AppliesTo = AppliesTo };
            if (this.IsParameterBound(c => c.Scope))
            {
                filter.Scope = Scope;
            }
            IEnumerable<string> configKeysFromInput = GetConfigsSpecifiedByUser()
                .Where(x => (SwitchParameter)x.Value)
                .Select(x => x.Key);
            if (configKeysFromInput.Any())
            {
                filter.Keys = configKeysFromInput;
            }

            return filter;
        }
    }
}
