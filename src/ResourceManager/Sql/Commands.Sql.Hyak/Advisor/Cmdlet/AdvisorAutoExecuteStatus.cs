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


namespace Microsoft.Azure.Commands.Sql.Advisor.Cmdlet
{
    /// <summary>
    /// Allowed values for updating Advisor Auto-execute Status
    /// </summary>
    public enum AdvisorAutoExecuteStatus
    {
        /// <summary>
        /// To explicitly enable auto-execute on the current resource for this advisor
        /// </summary>
        Enabled,

        /// <summary>
        /// To explicity disable auto-execute on the current resource for this advisor
        /// </summary>
        Disabled,

        /// <summary>
        /// To clear the explicit value previously set and inherit the default value from the parent of the current resource.
        /// </summary>
        Default
    }
}
