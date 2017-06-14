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
    using AutomationManagement = Azure.Management.Automation;

    /// <summary>
    /// The Variable.
    /// </summary>
    public class Variable : BaseProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Variable"/> class.
        /// </summary>
        /// <param name="variable">
        /// The varaiable.
        /// </param>
        /// <param name="automationAccoutName">
        /// The automation account name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public Variable(AutomationManagement.Models.Variable variable, string automationAccoutName, string resourceGroupName)
        {
            Requires.Argument("variable", variable).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.Name = variable.Name;
            this.CreationTime = variable.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = variable.Properties.LastModifiedTime.ToLocalTime();

            if (variable.Properties.Value == null || variable.Properties.IsEncrypted)
            {
                this.Value = null;
            }
            else
            {
                this.Value = PowerShellJsonConverter.Deserialize(variable.Properties.Value);
            }

            this.Description = variable.Properties.Description;
            this.Encrypted = variable.Properties.IsEncrypted;
            this.AutomationAccountName = automationAccoutName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable"/> class.
        /// </summary>
        public Variable()
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public bool Encrypted { get; set; }
    }
}
