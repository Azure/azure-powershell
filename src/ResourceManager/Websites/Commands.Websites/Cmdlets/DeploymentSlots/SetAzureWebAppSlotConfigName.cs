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

using System.Management.Automation;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.DeploymentSlots
{
    [Cmdlet(VerbsCommon.Set, "AzureRmWebAppSlotConfigName")]
    public class SetAzureWebAppSlotConfigName : WebAppBaseCmdlet
    {
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Names of app settings that need to marked as slot settings", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] AppSettingNames { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "Names of connection strings that need to marked as slot settings", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] ConnectionStringNames { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Remove all app settings")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter RemoveAllAppSettingNames { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Remove all connection string names")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter RemoveAllConnectionStringNames { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if ((RemoveAllAppSettingNames)
                && AppSettingNames != null)
            {
                throw new ValidationMetadataException("Please either provide a list of app setting names or set RemoveAllSettingNames option to true");
            }

            if((RemoveAllConnectionStringNames)
                && ConnectionStringNames != null)
            {
                throw new ValidationMetadataException("Please either provide a list of connection string names or set RemoveAllConnectionStringNames option to true");
            }

            var appSettingNames = RemoveAllAppSettingNames.IsPresent ? new string[0] : AppSettingNames;
            var connectionStringNames = RemoveAllConnectionStringNames.IsPresent ? new string[0] : ConnectionStringNames;
            WriteObject(WebsitesClient.SetSlotConfigNames(ResourceGroupName, Name, appSettingNames, connectionStringNames));
        }
    }
}
