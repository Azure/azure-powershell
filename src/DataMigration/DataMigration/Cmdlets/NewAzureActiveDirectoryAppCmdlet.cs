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
using System.Security;
using Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of AzureActiveDirectoryApp.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationAzureActiveDirectoryApp", SupportsShouldProcess = true), OutputType(typeof(PSAzureActiveDirectoryApp))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsAadApp")]
    public class NewAzureActiveDirectoryAppCmdlet : DataMigrationCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "Azure Active Directory Application Id")]
        [ValidateNotNullOrEmpty]
        [Alias("AppId")]
        public string ApplicationId { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Azure Active Directory Key")]
        [ValidateNotNullOrEmpty]
        [Alias("Key")]
        public SecureString AppKey { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.ApplicationId, Resources.createAadApp))
            {
                base.ExecuteCmdlet();

                PSAzureActiveDirectoryApp aadApp = new PSAzureActiveDirectoryApp(this.DefaultContext.Tenant.Id)
                {
                    ApplicationId = ApplicationId,
                    AppKey = AppKey,
                };

                WriteObject(aadApp);
            }
        }
    }
}
