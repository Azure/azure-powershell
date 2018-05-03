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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeAnalyticsComputePolicy", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlAnalyticsComputePolicy")]
    public class RemoveAzureDataLakeAnalyticsComputePolicy : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Name of resource group under which you the account exists. Optional and will attempt to discover if not provided.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the account to remove the compute policy from.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "Name of the compute policy to remove.")]
        [ValidateNotNullOrEmpty]
        [Alias("ComputePolicyName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return true upon successful deletion.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                string.Format(Resources.RemoveDataLakeAnalyticsComputePolicy, Name),
                Name,
                () =>
                {
                    DataLakeAnalyticsClient.DeleteComputePolicy(ResourceGroupName, Account, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
