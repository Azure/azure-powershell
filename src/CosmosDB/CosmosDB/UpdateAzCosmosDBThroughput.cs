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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    public class UpdateAzCosmosDBThroughput : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ThroughputHelpMessage)]
        [ValidateNotNull]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AutoscaleMaxThroughputHelpMessage)]
        [ValidateNotNull]
        public int? AutoscaleMaxThroughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ThroughputBucketsObjectHelpMessage)]
        [ValidateNotNull]
        public PSThroughputBucket[] ThroughputBucketsObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                PopulateFromParentObject();
            }
            else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                PopulateFromInputObject();
            }

            // Determine effective throughput buckets:
            // - If user omitted the parameter (null), fetch and preserve existing buckets via hook
            // - If user passed empty array, clear buckets by sending an empty list
            // - If user passed values, replace with those values
            PSThroughputBucket[] effectiveThroughputBuckets = ThroughputBucketsObject ?? GetExistingThroughputBuckets();

            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = ThroughputHelper.CreateThroughputSettingsObject(Throughput, AutoscaleMaxThroughput, effectiveThroughputBuckets);

            CallSDKMethod(throughputSettingsUpdateParameters);
        }

        public virtual void PopulateFromParentObject() { }
        public virtual void PopulateFromInputObject() { }
        public virtual void CallSDKMethod(ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters) { }
        protected virtual PSThroughputBucket[] GetExistingThroughputBuckets() { return null; }

    }
}
