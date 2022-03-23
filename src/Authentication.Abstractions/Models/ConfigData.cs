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

using System;

namespace Microsoft.Azure.PowerShell.Common.Config
{
    /// <summary>
    /// Wrapper for both definition and value of a config. Used as output of some API of <see cref="IConfigManager"/>.
    /// </summary>
    public class ConfigData
    {
        public ConfigData(ConfigDefinition config, object value, ConfigScope scope, string appliesTo)
        {            
            Definition = config ?? throw new ArgumentNullException(nameof(config));
            Value = value;
            Scope = scope;
            AppliesTo = appliesTo;
        }

        public ConfigDefinition Definition { get; }

        public object Value { get; }

        /// <summary>
        /// Specifies a module or cmdlet that the config applies to.
        /// If null, it applies to all.
        /// </summary>
        public string AppliesTo { get; }

        public ConfigScope Scope { get; }
    }
}
