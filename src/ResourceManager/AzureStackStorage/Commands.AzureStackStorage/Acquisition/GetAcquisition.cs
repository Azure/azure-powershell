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
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{

    /// <summary>
    /// Get an acquisition by ID or list acquisitions
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminAcquisition)]
    public sealed class GetAdminAcquisition : AdminCmdlet
    {
        const string ListAcquisitionSet = "ListAcquisitionSet";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        ///     AcquisitionId
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ListAcquisitionSet)]
        public string TenantSubscriptionId { get; set; }

        /// <summary>
        ///     AcquisitionId
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ListAcquisitionSet)]
        public string StorageAccountName { get; set; }

        /// <summary>
        ///     AcquisitionId
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ListAcquisitionSet)]
        public string Container { get; set; }

        protected override void Execute()
        {
            switch (ParameterSetName)
            {
                case ListAcquisitionSet:
                {
                    string filter = Tools.GenerateAcquisitionQueryFilterString(TenantSubscriptionId, StorageAccountName,
                        Container);
                    var result = Client.Acquisitions.List(ResourceGroupName, FarmName, filter);
                    WriteObject(result.Acquisitions.Select(_=> new AcquisitionResponse(_)), true);
                    break;
                }
                default:
                    throw new ArgumentException("Bad parameter set");
            }
        }
        }
}