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

using Microsoft.AzureStack.Management.StorageAdmin;
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///         Get-Farm [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [[-FarmName] {string}] [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminFarm)]
    public sealed class GetAdminFarm : AdminCmdlet
    {
        /// <summary>
        /// Farm identifier
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNullOrEmpty]
        public string FarmName
        {
            get;
            set;
        }

        protected override void Execute()
        {
            if (string.IsNullOrEmpty(FarmName) == false)
            {
                FarmGetResponse response = Client.Farms.Get(ResourceGroupName, FarmName);
                WriteObject(new FarmResponse(response.Farm));
            }
            else
            {
                FarmListResponse response = Client.Farms.List(ResourceGroupName);

                WriteObject(response.Farms.Select(_ => new FarmResponse(_)), true);
            }
        }
    }
}
