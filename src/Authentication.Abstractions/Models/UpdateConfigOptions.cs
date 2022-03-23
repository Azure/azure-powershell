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
    /// Options for updating a config. Used as input of <see cref="IConfigManager.UpdateConfig(UpdateConfigOptions)"/>
    /// </summary>
    public class UpdateConfigOptions
    {
        public UpdateConfigOptions(string key, object value, ConfigScope scope)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Scope = scope;
            Value = value;
        }

        public string Key { get; }
        public object Value { get; }
        public ConfigScope Scope { get; set; }

        /// <summary>
        /// Specifies a module or cmdlet that the config applies to.
        /// If null, it applies to all.
        /// </summary>
        public string AppliesTo { get; set; } = null;
    }
}
