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

namespace Microsoft.Azure.Commands.DataShare.DataSetMapping
{
    using System;
    using System.Collections.Generic;
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
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines Get-AzDataShareDataSetMapping cmdlets.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareDataSetMapping", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareDataSetMapping))]
    public class GetAzDataShareDataSetMapping : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of azure data share account.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }


        /// <summary>
        /// Name of azure data share subscription name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share subscription name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareSubscriptionName { get; set; }

        /// <summary>
        /// Name of data set mappings.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data set mapping name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.DataSetMapping, "ResourceGroupName", "AccountName", "ShareSubscriptionName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the data set mapping.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data set mapping.",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.DataSetMapping)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareSubscriptionName = parsedResourceId.GetShareSubscriptionName();
                this.Name = parsedResourceId.GetDataSetMappingName();
            }

            if (this.Name != null)
            {
                try
                {
                    DataSetMapping dataSetMapping = this.DataShareManagementClient.DataSetMappings.Get(
                        this.ResourceGroupName,
                        this.AccountName,
                        this.ShareSubscriptionName,
                        this.Name);

                    this.WriteObject(dataSetMapping.ToPsObject());
                }
                catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
                }
            }
            else
            {
                string nextPageLink = null;
                List<DataSetMapping> dataSetMappingList = new List<DataSetMapping>();

                do
                {
                    IPage<DataSetMapping> datasetMappings = string.IsNullOrEmpty(nextPageLink)
                        ? this.DataShareManagementClient.DataSetMappings.ListByShareSubscription(this.ResourceGroupName, this.AccountName, this.ShareSubscriptionName)
                        : this.DataShareManagementClient.DataSetMappings.ListByShareSubscriptionNext(nextPageLink);

                    dataSetMappingList.AddRange(datasetMappings.AsEnumerable());
                    nextPageLink = datasetMappings.NextPageLink;
                } while (nextPageLink != null);

                IEnumerable<PSDataShareDataSetMapping> datasetsInShareSubscription = dataSetMappingList.Select(dataSetMapping => dataSetMapping.ToPsObject());
                this.WriteObject(datasetsInShareSubscription, true);
            }
        }
    }
}
