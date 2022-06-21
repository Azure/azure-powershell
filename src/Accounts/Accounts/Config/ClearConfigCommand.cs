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

using Microsoft.Azure.Commands.Common.Exceptions;
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
    [Cmdlet("Clear", AzureRMConstants.AzureRMPrefix + "Config", SupportsShouldProcess = true, DefaultParameterSetName = ClearAll)]
    [OutputType(typeof(bool))]
    [CmdletPreview(PreviewMessage)]
    public class ClearConfigCommand : ConfigCommandBase, IDynamicParameters
    {
        private const string ClearByKey = "ClearByKey";
        private const string ClearAll = "ClearAll";

        private const string ProcessMessage = "Clear the configs that apply to {0} by the following keys: {1}.";

        private string ContinueMessageForClearAll => $"Clear all the configs that apply to {AppliesTo ?? "all the modules and cmdlets"} in scope {Scope}.";

        private string ProcessTarget => $"{Scope} scope";

        [Parameter(ParameterSetName = ClearAll, HelpMessage = "Do not ask for confirmation when clearing all configs.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "Returns true if cmdlet executes correctly.")]
        public SwitchParameter PassThru { get; set; }

        public new object GetDynamicParameters()
        {
            return GetDynamicParameters((ConfigDefinition config) =>
                new RuntimeDefinedParameter(
                    config.Key,
                    typeof(SwitchParameter),
                    new Collection<Attribute>() {
                        new ParameterAttribute {
                            ParameterSetName = ClearByKey,
                            HelpMessage = config.HelpMessage
                        }
                    }));
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            if (Scope != ConfigScope.Process && Scope != ConfigScope.CurrentUser)
            {
                throw new AzPSArgumentException($"When clearing configs, {nameof(Scope)} must be either {ConfigScope.Process} or {ConfigScope.CurrentUser}", nameof(Scope));
            }
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ClearByKey:
                    ClearConfigByKey();
                    break;
                case ClearAll:
                    ClearAllConfigs();
                    break;
            }
            if (PassThru)
            {
                WriteObject(true);
            }
        }

        private void ClearConfigByKey()
        {
            IEnumerable<string> configKeysFromInput = GetConfigsSpecifiedByUser()
                .Where(x => (SwitchParameter)x.Value)
                .Select(x => x.Key);
            if (!configKeysFromInput.Any())
            {
                WriteWarning($"Please specify the key(s) of the configs to clear. Run `help {MyInvocation.MyCommand.Name}` for more information.");
                return;
            }
            base.ConfirmAction(
                string.Format(ProcessMessage, AppliesTo ?? "all the modules and cmdlets", string.Join(", ", configKeysFromInput)),
                ProcessTarget,
                () => configKeysFromInput.ForEach(ClearConfigByKey));
        }

        private void ClearConfigByKey(string key)
        {
            ConfigManager.ClearConfig(new ClearConfigOptions(key, Scope)
            {
                AppliesTo = AppliesTo
            });
        }

        private void ClearAllConfigs()
        {
            ConfirmAction(Force, ContinueMessageForClearAll, ContinueMessageForClearAll, ProcessTarget, () =>
            {
                ConfigManager.ClearConfig(new ClearConfigOptions(null, Scope)
                {
                    AppliesTo = AppliesTo
                });
            });
        }
    }
}
