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
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.AdminTableService, SupportsShouldProcess = true)]
    public sealed class SetTableService : AdminCmdlet
    {
        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// CpuBasedKeepAliveThrottlingEnabled
        /// </summary>
        [Parameter]
        [SettingField]
        public bool? FrontEndCpuBasedKeepAliveThrottlingEnabled { get; set; }

        /// <summary>
        /// MemoryThrottlingEnabled
        /// </summary>
        [Parameter]
        [SettingField]
        public bool? FrontEndMemoryThrottlingEnabled { get; set; }

        protected override void Execute()
        {
            string confirmString;
            TableServiceWritableSettings settings = Tools.ToSettingsObject<SetTableService, TableServiceWritableSettings>(this, out confirmString);
            if (ShouldProcess(
                Resources.SetServiceDescription.FormatInvariantCulture(Resources.TableService, confirmString),
                Resources.SetServiceWarning.FormatInvariantCulture(Resources.TableService, confirmString),
                Resources.ShouldProcessCaption))
            {
                TableServiceGetResponse result = Client.TableService.Patch(ResourceGroupName, FarmName,
                    new TableServicePatchParameters
                    {
                        TableService = new TableServiceRequest
                        {
                            Settings = settings
                        }
                    });
                WriteObject(new TableServiceResponse(result.Resource));
            }
        }
    }
}