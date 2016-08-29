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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    public abstract class DtlPolicyCmdletBase : DevTestLabsCmdletBase
    {
        protected abstract string PolicyName { get; }

        #region Input Parameter Definitions

        protected const string ParameterSetEnable = "Enable";
        protected const string ParameterSetDisable = "Disable";

        /// <summary>
        /// Enable.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            ParameterSetName = ParameterSetEnable,
            HelpMessage = "Whether to enable the policy.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enable { get; set; }

        /// <summary>
        /// Disable.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 3,
            ParameterSetName = ParameterSetDisable,
            HelpMessage = "Whether to disable the policy.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Disable { get; set; }

        #endregion Input Parameter Definitions
    }
}
