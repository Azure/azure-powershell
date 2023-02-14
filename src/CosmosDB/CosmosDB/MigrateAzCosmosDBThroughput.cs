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
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    public class MigrateAzCosmosDBThroughput : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ThroughputTypeHelpMessage)]
        [ValidateNotNull]
        [PSArgumentCompleter(ThroughputTypes.Autoscale, ThroughputTypes.Manual)]
        public string ThroughputType { get; set; }

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

            if (ThroughputType.Equals(ThroughputTypes.Autoscale, StringComparison.Ordinal)) 
            { 
                this.MigrateToAutoscaleSDKMethod();
            }
            else
            {
                this.MigrateToManualSDKMethod();
            }    
        }

        public virtual void PopulateFromParentObject() {}
        public virtual void PopulateFromInputObject() {}
        public virtual void MigrateToAutoscaleSDKMethod() {}
        public virtual void MigrateToManualSDKMethod() {}

        private static class ThroughputTypes
        {
            public const string Autoscale = "Autoscale";
            public const string Manual = "Manual";
        }
    }
}
