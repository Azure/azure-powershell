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


namespace Microsoft.Azure.Commands.DataShare.Account
{
    using System.Management.Automation;
    using System;
    using System.Globalization;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;

    /// <summary>
    /// Defines Remove-AzDataShareAccount cmdlets.
    /// </summary>
    [Cmdlet(
         "Remove",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareAccount",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(bool))]
    public class RemoveAzDataShareAccount : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "The resource group name of azure data share account.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Azure data share account name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data share account.",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.Account)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Azure data share account object.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The azure data share account object.")]
        [ValidateNotNullOrEmpty]
        public PSDataShareAccount InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceId = null;

            if (this.ParameterSetName.Equals(
                ParameterSetNames.ResourceIdParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                resourceId = this.ResourceId;
            }

            if (this.ParameterSetName.Equals(ParameterSetNames.ObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                resourceId = this.InputObject.Id;
            }

            if (!string.IsNullOrEmpty(resourceId))
            {
                var parsedResourceId = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.GetAccountName();
            }

            this.ConfirmAction(
                this.Force,
                string.Format(Resources.ResourceRemovalConfirmation, this.Name),
                string.Format(Resources.ResourceRemovedMessage, this.Name),
                this.Name,
                () => this.DataShareManagementClient.Accounts.Delete(this.ResourceGroupName, this.Name));

            if (this.PassThru)
            {
                this.WriteObject(true);
            }
        }
    }
}