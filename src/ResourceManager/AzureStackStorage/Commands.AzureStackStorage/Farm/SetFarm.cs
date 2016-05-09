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
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Set-Farm  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [[-SettingPollingIntervalInSeconds] {int}] [-FarmName] {string} [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.AdminFarm, SupportsShouldProcess = true)]
    public sealed class SetAdminFarm : AdminCmdlet
    {
        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNull]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? SettingsPollingIntervalInSecond { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpsPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public string CorsAllowedOriginsList { get; set; }

        ///
        [Parameter]
        [SettingField]
        public string DataCenterUriHostSuffixes { get; set; }

        protected override void Execute()
        {
            string confirmString;
            FarmSettings settings = Tools.ToSettingsObject<SetAdminFarm, FarmSettings>(this, out confirmString);

            if (ShouldProcess(
                Resources.SetFarmDescription.FormatInvariantCulture(FarmName, confirmString),
                Resources.SetFarmWarning.FormatInvariantCulture(FarmName, confirmString),
                Resources.ShouldProcessCaption))
            {

                FarmUpdateParameters parameters = new FarmUpdateParameters
                {
                    Farm = new FarmBase { Settings = settings }
                };

                FarmGetResponse response = Client.Farms.Update(ResourceGroupName, FarmName, parameters);

                WriteObject(new FarmResponse(response.Farm));
            }
        }
    }
}