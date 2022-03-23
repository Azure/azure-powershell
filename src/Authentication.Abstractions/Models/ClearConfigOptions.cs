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


namespace Microsoft.Azure.PowerShell.Common.Config
{
    public class ClearConfigOptions
    {
        public ClearConfigOptions(string key, ConfigScope scope)
        {
            Key = key;
            Scope = scope;
        }

        public string Key { get; }

        public ConfigScope Scope { get; set; }

        /// <summary>
        /// Specifies a module or cmdlet that the config applies to.
        /// If null, it applies to all.
        /// </summary>
        public string AppliesTo { get; set; } = null;
    }
}
