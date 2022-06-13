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

using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers
{
    internal class EnvironmentVariablesConfigurationProvider : ConfigurationProvider
    {
        private EnvironmentVariableTarget _environmentVariableTarget;
        private IDictionary<string, EnvironmentVariableConfigurationParser> _environmentVariableParsers;
        private IEnvironmentVariableProvider _environmentVariableProvider;

        public EnvironmentVariablesConfigurationProvider(string id, EnvironmentVariablesConfigurationOptions options) : base(id)
        {
            _environmentVariableTarget = options.EnvironmentVariableTarget;
            _environmentVariableParsers = options.EnvironmentVariableParsers ?? new Dictionary<string, EnvironmentVariableConfigurationParser>();
            _environmentVariableProvider = options.EnvironmentVariableProvider;
        }

        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var environmentVariables = _environmentVariableProvider.List(_environmentVariableTarget);
            foreach (var i in _environmentVariableParsers)
            {
                string value = i.Value(environmentVariables);
                if (!string.IsNullOrEmpty(value))
                {
                    string key = ConfigPathHelper.GetPathOfConfig(i.Key);
                    data[key] = value;
                }
            }

            Data = data;
        }
    }
}
