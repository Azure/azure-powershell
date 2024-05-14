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
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    [Cmdlet("Update", AzureRMConstants.AzureRMPrefix + "Config", SupportsShouldProcess = true)]
    [Alias("Set-AzConfig")]
    [OutputType(typeof(PSConfig))]
    public class UpdateConfigCommand : ConfigCommandBase, IDynamicParameters
    {
        private const string ProcessMessage = "Update the configs that apply to \"{0}\" by the following keys: {1}.";
        private string ProcessTarget => $"Configs in scope {Scope}";

        public new object GetDynamicParameters() => GetDynamicParameters(
            (ConfigDefinition config) => new RuntimeDefinedParameter(
                config.Key, config.ValueType,
                new Collection<Attribute>() { new ParameterAttribute {
                    HelpMessage = config.HelpMessage,
                    ValueFromPipelineByPropertyName = true
                } }
            ));

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (AppliesTo == null)
            {
                AppliesTo = ConfigFilter.GlobalAppliesTo;
            }
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            if (Scope != ConfigScope.Process && Scope != ConfigScope.CurrentUser)
            {
                throw new AzPSArgumentException($"When updating configs, {nameof(Scope)} must be either {ConfigScope.Process} or {ConfigScope.CurrentUser}", nameof(Scope));
            }
        }

        public override void ExecuteCmdlet()
        {
            var configsFromInput = GetConfigsSpecifiedByUser();
            if (!configsFromInput.Any())
            {
                WriteWarning($"Please specify the key(s) of the configs to update. Run `help {MyInvocation.MyCommand.Name}` for more information.");
                return;
            }
            base.ConfirmAction(
                string.Format(ProcessMessage, AppliesTo, string.Join(", ", configsFromInput.Select(x => x.Key))),
                ProcessTarget,
                () => UpdateConfigs(configsFromInput));
        }

        private void UpdateConfigs(IEnumerable<(string, object)> configsToUpdate)
        {
            foreach ((string key, object value) in configsToUpdate)
            {
                ConfigData updated = ConfigManager.UpdateConfig(new UpdateConfigOptions(key, value, Scope)
                {
                    AppliesTo = AppliesTo
                });
                WriteObject(new PSConfig(updated));
            }
        }
    }
}
