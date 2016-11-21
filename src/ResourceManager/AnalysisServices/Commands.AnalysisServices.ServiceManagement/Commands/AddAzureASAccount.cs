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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using Microsoft.Azure.Commands.AnalysisServices.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.AnalysisServices.ServiceManagement
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Add", "AzureAnalysisServicesAccount", SupportsShouldProcess=true)]
    [Alias("Login-AzureAsAccount")]
    [OutputType(typeof(AsAzureProfile))]
    public class AddAzureASAccountCommand : AzurePSCmdlet, IModuleAssemblyInitializer
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Name of the Azure Analysis Services environment to which to logon to")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }
        
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Login credentials to the Azure Analysis Services environment")]
        public PSCredential Credential { get; set; }

        protected AsAzureEnvironment AsEnvironment;
           
        protected override AzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Managment context
                return null;
            }
        }

        protected override void SaveDataCollectionProfile()
        {
            // No data collection for this commandlet 
        }

        protected override void PromptForDataCollectionProfileIfNotExists()
        {
            // No data collection for this commandlet 
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
#pragma warning disable 0618
            if (EnvironmentName == null)
            {
                throw new PSInvalidOperationException(string.Format(Resources.UnknownEnvironment, ""));
            }
            else
            {
                if (AsAzureClientSession.Instance.Profile.Environments.ContainsKey(EnvironmentName))
                {
                    AsEnvironment = AsAzureClientSession.Instance.Profile.Environments[EnvironmentName];
                }
                else
                {
                    AsEnvironment = AsAzureClientSession.Instance.Profile.CreateEnvironment(EnvironmentName);
                }
            }
#pragma warning restore 0618
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            AsAzureAccount azureAccount = new AsAzureAccount();

            SecureString password = null;
            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }

#pragma warning disable 0618
            if (ShouldProcess(string.Format(Resources.LoginTarget, AsEnvironment.Name), "log in"))
            {
                var currentProfile = AsAzureClientSession.Instance.Profile;

                if (currentProfile.Context == null)
                {
                    AsAzureClientSession.Instance.SetCurrentContext(azureAccount, AsEnvironment);
                }

                var asAzureProfile = AsAzureClientSession.Instance.Login(currentProfile.Context, password);

                WriteObject(asAzureProfile);
            }
#pragma warning restore 0618
        }

        public void OnImport()
        {
            // Nothing to do on assembly initialize
        }
    }
}
