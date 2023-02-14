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
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the Get-AzDataShareSynchronizationSetting cmdlet.
    /// </summary>
    [Cmdlet(
         "Get",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareSynchronizationSetting",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareSynchronizationSetting))]
    public class GetAzDataShareSynchronizationSetting : AzureDataShareCmdletBase
    {

        /// <summary>
        /// The resource group name of azure data share account name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource group name of azure data share account",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
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
        /// Name of the data share
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// Name of the synchronization setting to get
        /// </summary>
        [Parameter(
            HelpMessage = "Name for Synchronization Setting",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.SynchronizationSetting, "ResourceGroupName", "AccountName", "ShareName")]
        public string Name { get; set; }

        /// <summary>
        /// The resource id of azure data share synchronization setting.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data share synchronization setting",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.SynchronizationSetting)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(
                ParameterSetNames.ResourceIdParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                var resourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.AccountName = resourceId.GetAccountName();
                this.ShareName = resourceId.GetShareName();
                this.Name = resourceId.GetSynchronizationSettingName();
            }

            if (this.Name == null)
            {
                var settingsPage = this.DataShareManagementClient.SynchronizationSettings.ListByShare(
                    this.ResourceGroupName,
                    accountName: this.AccountName,
                    shareName: this.ShareName);
                this.WriteObject(
                    settingsPage.AsEnumerable().Select(
                        syncSettings => (syncSettings as ScheduledSynchronizationSetting).ToPsObject()),
                    true);
                while (settingsPage.NextPageLink != null)
                {
                    settingsPage = this.DataShareManagementClient.SynchronizationSettings.ListByShareNext(
                        settingsPage.NextPageLink);
                    this.WriteObject(
                        settingsPage.AsEnumerable().Select(
                            syncSettings => (syncSettings as ScheduledSynchronizationSetting).ToPsObject()),
                        true);
                }
            }
            else
            {
                try
                {
                    var setting = this.DataShareManagementClient.SynchronizationSettings.Get(
                        resourceGroupName: this.ResourceGroupName,
                        accountName: this.AccountName,
                        shareName: this.ShareName,
                        synchronizationSettingName: this.Name) as ScheduledSynchronizationSetting;
                    this.WriteObject(setting.ToPsObject());
                }
                catch (DataShareErrorException exception) when (exception.Response.StatusCode.Equals(
                    HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
                }
            }
        }
    }
}