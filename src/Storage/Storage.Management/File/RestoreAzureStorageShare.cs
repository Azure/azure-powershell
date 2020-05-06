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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageShareNounStr, DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSShare))]
    public class RestoreAzureStorageShareCommand : StorageFileBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// ShareObject Parameter Set
        /// </summary>
        private const string ShareObjectParameterSet = "ShareObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        //[Parameter(Mandatory = false,
        //    HelpMessage = "Target share Name, which will be restored to.")]
        //public string ShareName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("Share")]
        [Parameter(Mandatory = true,
            HelpMessage = "Deleted Share object, which will be restored",
            ValueFromPipeline = true,
            ParameterSetName = ShareObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSShare InputObject { get; set; }

        [Alias("N", "ShareName")]
        [Parameter(Mandatory = true,
            HelpMessage = "Deleted Share Name, which will be restored.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Deleted Share Name, which will be restored.",
            ParameterSetName = AccountObjectParameterSet)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Deleted Share Version, which will be restored from.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Deleted Share Version, which will be restored from.",
            ParameterSetName = AccountObjectParameterSet)]
        public string DeletedShareVersion { get; set; }

        //[Parameter(Mandatory = false)]
        //    public SwitchParameter PassThru { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case ShareObjectParameterSet:
                    if(InputObject.Deleted != true)
                    {
                        throw new ArithmeticException(string.Format("The input share {0} is not deleted, so can't restore.", this.InputObject.Name));
                    }
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.StorageAccountName = InputObject.StorageAccountName;
                    this.Name = InputObject.Name;
                    this.DeletedShareVersion = InputObject.Version;
                    break;
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                default:
                    break;
            }

            if (ShouldProcess(this.Name, "Restore Share"))
            {
                this.StorageClient.FileShares.Restore(
                                    this.ResourceGroupName,
                                    this.StorageAccountName,
                                    this.Name,
                                    this.Name,
                                    this.DeletedShareVersion);


                var Share = this.StorageClient.FileShares.Get(
                           this.ResourceGroupName,
                           this.StorageAccountName,
                           this.Name);
                WriteObject(new PSShare(Share));
            }
        }
    }
}
