﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet("Clear", "AzConfig", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    [CmdletPreview(PreviewMessage)]
    public class ClearConfigCommand : ConfigCommandBase, IDynamicParameters
    {
        private const string ClearByKey = "ClearByKey";
        private const string ClearAll = "ClearAll";

        private const string ProcessMessage = "Clear the configs that apply to \"{0}\" by the following keys: {1}.";

        private string ContinueMessage => $"Clear all the configs that apply to \"{AppliesTo}\" in scope {Scope}?";
        private string ProcessTarget => $"Configs in scope {Scope}";

        [Parameter(ParameterSetName = ClearAll, Mandatory = true, HelpMessage = "Clear all configs.")]
        public SwitchParameter All { get; set; }

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
                string.Format(ProcessMessage, AppliesTo, string.Join(", ", configKeysFromInput)),
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
            ConfirmAction(Force, ContinueMessage, ContinueMessage, ProcessTarget, () =>
            {
                ConfigManager.ClearConfig(new ClearConfigOptions(null, Scope)
                {
                    AppliesTo = AppliesTo
                });
            });
        }
    }
}
