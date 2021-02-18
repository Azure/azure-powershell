// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.DataShare.Share
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;

    /// <summary>
    /// Defines Set-AzDataShare cmdlet.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShare", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet, SupportsShouldProcess = true),
     OutputType(typeof(PSDataShare))]
    public class SetAzDataShare : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data share",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.Share)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Azure data share object.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Azure data share object")]
        [ValidateNotNullOrEmpty]
        public PSDataShare InputObject { get; set; }

        /// <summary>
        /// Description of the Data Share
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Description of Data Share")]
        public string Description { get; set; }

        /// <summary>
        /// Terms of Use of Data Share
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Terms of Use for Data Share")]
        public string TermsOfUse { get; set; }

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
                if (this.Name == null)
                {
                    throw new PSArgumentNullException(
                        string.Format(CultureInfo.InvariantCulture, Resources.ResourceArgumentInvalid));
                }

                resourceId = this.InputObject.Id;
            }

            if (!string.IsNullOrEmpty(resourceId))
            {
                var parseResourceId = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = parseResourceId.ResourceGroupName;
                this.AccountName = parseResourceId.GetAccountName();
                this.Name = parseResourceId.GetShareName();
            }

            Share existingShare = null;

            try
            {
                existingShare = this.DataShareManagementClient.Shares.Get(
                    this.ResourceGroupName,
                    this.AccountName,
                    this.Name);
            }
            catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
            }

            if (this.Description != null || this.TermsOfUse != null)
            {
                this.ConfirmAction(
                    Resources.ResourceUpdataConfirmation,
                    this.Name,
                    () => this.UpdateShare(existingShare));

            }
            else
            {
                this.WriteObject(existingShare.ToPsObject());
            }
        }


        private void UpdateShare(Share existingShare)
        {
            Share dataShare = this.DataShareManagementClient.Shares.Create(
                this.ResourceGroupName,
                this.AccountName,
                this.Name,
                new Share()
                {
                    ShareKind = existingShare.ShareKind,
                    Description = this.Description ?? existingShare.Description,
                    Terms = this.TermsOfUse ?? existingShare.Terms
                });

            this.WriteObject(dataShare.ToPsObject());
        }
    }
}
