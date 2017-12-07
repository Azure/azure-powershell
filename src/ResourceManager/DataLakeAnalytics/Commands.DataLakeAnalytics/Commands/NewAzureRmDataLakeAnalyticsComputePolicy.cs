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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataLakeAnalyticsComputePolicy", SupportsShouldProcess = true), OutputType(typeof(PSDataLakeAnalyticsComputePolicy))]
    [Alias("New-AdlAnalyticsComputePolicy")]
    public class NewAzureDataLakeAnalyticsComputePolicy : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Name of resource group under which you the account exists. Optional and will attempt to discover if not provided.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the account to add the compute policy to.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "Name of the compute policy to create.")]
        [ValidateNotNullOrEmpty]
        [Alias("ComputePolicyName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The Azure Active Directory object id for the user or group to apply the policy to.")]
        [ValidateNotNull]
        public Guid ObjectId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = true,
            HelpMessage = "The Azure Active Directory object type for the object ID passed in.")]
        [ValidateNotNull]
        [ValidateSet("User", "Group", "ServicePrincipal", IgnoreCase = true)]
        public string ObjectType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The maximum supported analytics units per job for this policy. Either this, MinPriorityPerJob, or both parameters must be specified.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        [Alias("MaxDegreeOfParallelismPerJob")]
        public int? MaxAnalyticsUnitsPerJob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The minimum supported priority per job for this policy. Either this, MaxAnalyticsUnitsPerJob, or both parameters must be specified.")]
        [ValidateNotNull]
        [ValidateRange(0, int.MaxValue)]
        public int? MinPriorityPerJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!MinPriorityPerJob.HasValue && !MaxAnalyticsUnitsPerJob.HasValue)
            {
                throw new ArgumentException(Resources.MissingComputePolicyField);
            }

            ConfirmAction(
                string.Format(
                    Resources.NewDataLakeComputePolicy,
                    Name,
                    MinPriorityPerJob.HasValue ? "\r\nMinPriorityPerJob: " + MinPriorityPerJob.Value : string.Empty,
                    MaxAnalyticsUnitsPerJob.HasValue ? "\r\nMaxAnalyticsUnitsPerJob: " + MaxAnalyticsUnitsPerJob.Value : string.Empty),
                Name, () =>
                {
                    WriteObject(
                        this.DataLakeAnalyticsClient.CreateComputePolicy(
                            ResourceGroupName,
                            Account,
                            Name,
                            ObjectId,
                            ObjectType,
                            MaxAnalyticsUnitsPerJob,
                            MinPriorityPerJob));
                });
        }
    }
}
