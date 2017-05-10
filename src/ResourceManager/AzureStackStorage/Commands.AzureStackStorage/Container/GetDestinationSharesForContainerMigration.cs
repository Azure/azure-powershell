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
using System.Linq;
using System.Threading;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// SYNTAX
    /// Get-ACSDestinationSharesForContainer  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///                  [-FarmName] {string} [-SourceShareName] {string} [{CommonParameters}] 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminDestinationShareForContainer)]
    public sealed class GetDesinationSharesForContainerMigration : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SourceShareName { get; set;}
        
        protected override void Execute()
        {
            DestinationShareListResponse response = this.Client.Shares.GetDestinationShares(this.ResourceGroupName, this.FarmName, this.SourceShareName);
            this.WriteObject(response.Shares.Select(_ => new ShareResponse(_)), true);
        }
    }
}
