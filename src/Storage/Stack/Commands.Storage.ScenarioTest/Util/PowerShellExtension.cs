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

using System.Management.Automation;

namespace Commands.Storage.ScenarioTest.Util
{
    public static class PowerShellExtension
    {
        /// <summary>
        /// Add string parameter if the value is not null or empty
        /// </summary>
        /// <param name="ps">PowerShell instance</param>
        /// <param name="parameter">Parameter name</param>
        /// <param name="value">Parameter value</param>
        public static void BindParameter(this PowerShell ps, string parameter, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                ps.AddParameter(parameter, value);
            }
        }

        /// <summary>
        /// Add bool parameter if the vlaue is true, since the default value for bool in powershell is false
        /// </summary>
        /// <param name="ps">PowerShell instance</param>
        /// <param name="parameter">Parameter name</param>
        /// <param name="value">Parameter value</param>
        public static void BindParameter(this PowerShell ps, string parameter, bool value)
        {
            if (value)
            {
                ps.AddParameter(parameter);
            }
        }

        /// <summary>
        /// Add object parameter if the vlaue is not null
        /// </summary>
        /// <param name="ps">PowerShell instance</param>
        /// <param name="parameter">Parameter name</param>
        /// <param name="value">Parameter value</param>
        public static void BindParameter(this PowerShell ps, string parameter, object value)
        {
            if (value != null)
            {
                ps.AddParameter(parameter, value);
            }
        }

        /// <summary>
        /// Add switch parameter
        /// </summary>
        /// <param name="ps">PowerShell instance</param>
        /// <param name="parameter">Parameter name</param>
        public static void BindParameter(this PowerShell ps, string parameter)
        {
            ps.AddParameter(parameter);
        }
    }
}
