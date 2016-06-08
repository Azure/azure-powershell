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

using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Model
{

    using AutomationManagement = Microsoft.Azure.Management.Automation;

    /// <summary>
    /// DSC Onboarding Meta Configuration
    /// </summary>
    public class DscOnboardingMetaconfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DscOnboardingMetaconfig"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account.
        /// </param>
        /// <param name="dscOnboardingMetaConfig">
        /// The dsc onboarding meta configuration.
        /// </param>/// 
        public DscOnboardingMetaconfig(string resourceGroupName, string automationAccountName, AutomationManagement.Models.AgentRegistration dscOnboardingMetaConfig)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.DscMetaConfiguration = dscOnboardingMetaConfig.DscMetaConfiguration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DscOnboardingMetaconfig"/> class.
        /// </summary>
        public DscOnboardingMetaconfig()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the dsc meta configuration information
        /// </summary>
        public string DscMetaConfiguration { get; set; }

    }
}
