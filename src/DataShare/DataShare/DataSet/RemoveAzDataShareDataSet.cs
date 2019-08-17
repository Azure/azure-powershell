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

namespace Microsoft.Azure.Commands.DataShare.DataSet
{
    using System;
    using System.Management.Automation;
    using System.Globalization;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;

    /// <summary>
    /// Defines Remove-AzDataShareDataSet cmdlets.
    /// </summary>
    [Cmdlet(
         "Remove",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareDataSet",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzDataShareDataSet : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "The resource group name of the azure data share account.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Data share account name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Azure data share account name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Data share name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Azure data share name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// Data set name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure data set name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.DataSet, "ResourceGroupName", "AccountName", "ShareName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the azure data set.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data set.",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.DataSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Azure data set object.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The azure data set object.")]
        [ValidateNotNullOrEmpty]
        public PSDataShareDataSet InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

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
                var parseResourceId = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = parseResourceId.ResourceGroupName;
                this.AccountName = parseResourceId.GetAccountName();
                this.ShareName = parseResourceId.GetShareName();
                this.Name = parseResourceId.GetDataSetName();
            }

            this.ConfirmAction(
                string.Format(Resources.ResourceRemovalConfirmation, this.Name),
                this.Name,
                () => this.DataShareManagementClient.DataSets.Delete(
                    this.ResourceGroupName,
                    this.AccountName,
                    this.ShareName,
                    this.Name));

            if (this.PassThru)
            {
                this.WriteObject(true);
            }
        }
    }
}