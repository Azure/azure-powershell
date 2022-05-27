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

using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// The output model of config-related cmdlets.
    /// </summary>
    public class PSConfig
    {
        public string Key { get; }
        public object Value { get; }
        public ConfigScope Scope { get; } = ConfigScope.CurrentUser;
        public string AppliesTo { get; }
        public string HelpMessage { get; }
        public object DefaultValue { get; }
        public PSConfig(ConfigData config)
        {
            Value = config.Value;
            Scope = config.Scope;
            AppliesTo = config.AppliesTo;

            var def = config.Definition;
            Key = def.Key;
            HelpMessage = def.HelpMessage;
            DefaultValue = def.DefaultValue;
        }
    }
}
