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

namespace Microsoft.Azure.Commands.DataShare.SynchronizationSetting
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using System.Globalization;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;

    /// <summary>
    /// Defines the Remove-AzDataShareSynchronizationSetting cmdlet.
    /// </summary>
    [Cmdlet(
         "Remove",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareSynchronizationSetting",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(bool))]
    public class RemoveAzureDataShareSynchronizationSetting : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "The resource group name of the azure data share account")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Azure Data Share Account name")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// The name of the azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// The name of the synchronization setting to delete.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Synchronization setting name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.SynchronizationSetting, "ResourceGroupName", "AccountName", "ShareName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of synchronization setting.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the synchronization setting",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.SynchronizationSetting)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Share synchronization setting object.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The Azure Data Share Synchronization setting.")]
        [ValidateNotNullOrEmpty]
        public PSDataShareSynchronizationSetting InputObject { get; set; }

        /// <summary>
        /// Indicates whether you want to see deleted object or not
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        [Parameter]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceId = null;

            if (ParameterSetNames.ResourceIdParameterSet.Equals(
                this.ParameterSetName,
                StringComparison.OrdinalIgnoreCase))
            {
                resourceId = this.ResourceId;
            }

            if (ParameterSetNames.ObjectParameterSet.Equals(this.ParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                resourceId = this.InputObject.Id;
            }

            if (!string.IsNullOrEmpty(resourceId))
            {
                var parsedResourceIdentifier = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = parsedResourceIdentifier.ResourceGroupName;
                this.AccountName = parsedResourceIdentifier.GetAccountName();
                this.ShareName = parsedResourceIdentifier.GetShareName();
                this.Name = parsedResourceIdentifier.GetSynchronizationSettingName();
            }

            var func = (Func<string, string, string, string, OperationResponse>)this.DataShareManagementClient
                .SynchronizationSettings.Delete;

            void Action() => func(this.ResourceGroupName, this.AccountName, this.ShareName, this.Name);
            this.ConfirmAction(
                string.Format(Resources.ResourceRemovalConfirmation, this.Name),
                this.Name,
                Action);

            if (this.PassThru)
            {
                this.WriteObject(true);
            }
        }
    }
}