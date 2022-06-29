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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    public abstract class ConfigCommandBase : AzureRMCmdlet
    {
        public const string PreviewMessage = "The cmdlet group \"AzConfig\" is in preview. Feedback is welcome: https://aka.ms/azpsissue";

        private readonly RuntimeDefinedParameterDictionary _dynamicParameters = new RuntimeDefinedParameterDictionary();

        protected IConfigManager ConfigManager { get; }
        protected IEnumerable<ConfigDefinition> ConfigDefinitions
        {
            get
            {
                if (_configDefinitions == null)
                {
                    _configDefinitions = ConfigManager.ListConfigDefinitions();
                }
                return _configDefinitions;
            }
        }
        private IEnumerable<ConfigDefinition> _configDefinitions;

        public ConfigCommandBase() : base()
        {
            if (!AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager))
            {
                throw new AzPSApplicationException($"Unexpected error: {nameof(IConfigManager)} has not been registered to the current session.");
            }
            ConfigManager = configManager;
        }

        [Parameter(HelpMessage = "Specifies what part of Azure PowerShell the config applies to. Possible values are:\n- \"" + ConfigFilter.GlobalAppliesTo + "\": the config applies to all modules and cmdlets of Azure PowerShell.\n- Module name: the config applies to a certain module of Azure PowerShell. For example, \"Az.Storage\".\n- Cmdlet name: the config applies to a certain cmdlet of Azure PowerShell. For example, \"Get-AzKeyVault\".\nIf not specified, when getting or clearing configs, it defaults to all the above; when updating, it defaults to \"" + ConfigFilter.GlobalAppliesTo + "\".")]
        [ValidateNotNullOrEmpty]
        public string AppliesTo { get; set; }

        [Parameter(HelpMessage = "Determines the scope of config changes, for example, whether changes apply only to the current process, or to all sessions started by this user. By default it is CurrentUser.")]
        public ConfigScope Scope { get; set; } = ConfigScope.CurrentUser;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            ValidateParameters();
        }

        protected virtual void ValidateParameters()
        {
            if (!AppliesToHelper.TryParseAppliesTo(AppliesTo, out _))
            {
                throw new AzPSArgumentException($"{nameof(AppliesTo)} must be a valid module name, a cmdlet name, or \"{ConfigFilter.GlobalAppliesTo}\"", nameof(AppliesTo));
            }
        }

        protected object GetDynamicParameters(Func<ConfigDefinition, RuntimeDefinedParameter> mapConfigToParameter)
        {
            _dynamicParameters.Clear();
            foreach (var config in ConfigDefinitions)
            {
                _dynamicParameters.Add(config.Key, mapConfigToParameter(config));
            }
            return _dynamicParameters;
        }

        /// <summary>
        /// Gets the dynamic parameters and their values if specified.
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<(string Key, object Value)> GetConfigsSpecifiedByUser()
        {
            var configs = new Dictionary<string, object>();
            foreach (var param in _dynamicParameters.Values.Where(p => p.IsSet))
            {
                yield return (param.Name, param.Value);
            }
        }
    }
}
