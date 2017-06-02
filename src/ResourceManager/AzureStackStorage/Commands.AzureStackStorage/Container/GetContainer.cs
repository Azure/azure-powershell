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
    /// Get-ACSContainer [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///                  [-FarmName] {string} [-ShareName] {string} [[-Intent] {Migration}] [-Count {MaxCount}] [{CommonParameters}] 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminContainer)]
    [Alias("Get-ACSContainer")]
    public sealed class GetContainer : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Default value of records to be returned when count is not specified
        /// </summary>
        internal const uint DefaultMaxCountOfRecords = 10;

        /// <summary>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set;}

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = false )]
        public ContainerGetIntent? Intent { get; set; }

        /// <summary>
        /// Storage Account Status
        /// </summary>
        [Parameter(Mandatory = false)]
        public uint? Count { get; set; }

        /// <summary>
        /// Start index of the 
        /// </summary>
        [Parameter(Mandatory = false)]
        public uint? StartIndex { get; set; }


        protected override void Execute()
        {
            if (null == this.Intent)
            {
                this.Intent = ContainerGetIntent.Migration;
            }

            if (null == this.Count)
            {
                this.Count = DefaultMaxCountOfRecords;
            }
            
            if(null == StartIndex)
            {
                this.StartIndex = 0;
            }

            ContainerListResponse response = this.Client.Shares.GetContainers(this.ResourceGroupName, this.FarmName, this.ShareName, this.Intent.ToString(), this.Count.ToString(), this.StartIndex.ToString() );
            this.WriteObject(response, true);
        }
    }
}
