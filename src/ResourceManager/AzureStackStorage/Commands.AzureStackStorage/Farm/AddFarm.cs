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

using System.Globalization;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    ///     SYNTAX
    ///         Add-Farm [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-SettingAccessString] {string} [-Region] {string} [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.AdminFarm, SupportsShouldProcess = true)]
    public sealed class AddAdminFarm : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Farm identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        ///     setting access string. ex: file:\\localhost\db1\settings
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string SettingAccessString { get; set; }

        /// <summary>
        ///     Location of the farm
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Location{ get; set; }

        
        protected override void Execute()
        {
            if (ShouldProcess(
                 Resources.AddFarmDescription.FormatInvariantCulture(FarmName),
                 Resources.AddFarmWarning.FormatInvariantCulture(FarmName),
                 Resources.ShouldProcessCaption))
            {
                FarmCreateParameters request = new FarmCreateParameters
                {
                    Location = Location,

                    Properties = new FarmCreate
                    {
                        SettingAccessString = SettingAccessString
                    }
                };

                FarmGetResponse response = Client.Farms.Create(ResourceGroupName, FarmName, request);

                WriteObject(new FarmResponse(response.Farm));
            }
        }
    }
}