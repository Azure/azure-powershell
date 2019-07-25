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
    /// Defines Get-AzDataShareSet cmdlets.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareDataSet", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareDataSet))]
    public class GetAzDataShareDataSet : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account.",
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
        /// Name of azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// Name of azure data set.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data set name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.DataSet, "ResourceGroupName", "AccountName", "ShareName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the data set.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data set.",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.DataSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override  void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareName = parsedResourceId.GetShareName();
                this.Name = parsedResourceId.GetDataSetName();
            }

            if (this.Name != null)
            {
                try
                {
                    DataSet dataSet = this.DataShareManagementClient.DataSets.Get(
                        this.ResourceGroupName,
                        this.AccountName,
                        this.ShareName,
                        this.Name);

                    this.WriteObject(dataSet.ToPsObject());
                }
                catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
                }
            }
            else
            {
                string nextPageLink = null;
                var dataSetList = new List<DataSet>();

                do
                {
                    IPage<DataSet> dataSets = string.IsNullOrEmpty(nextPageLink)
                        ? this.DataShareManagementClient.DataSets.ListByShare(this.ResourceGroupName, this.AccountName, this.ShareName)
                        : this.DataShareManagementClient.DataSets.ListByShareNext(nextPageLink);

                    dataSetList.AddRange(dataSets.AsEnumerable());
                    nextPageLink = dataSets.NextPageLink;
                } while (nextPageLink != null);

                IEnumerable<PSDataShareDataSet> datasetsInShare = dataSetList.Select(dataSet => dataSet.ToPsObject());
                this.WriteObject(datasetsInShare, true);
            }
        }
    }
}
