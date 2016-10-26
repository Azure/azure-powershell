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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Add", "AzureASAccount", SupportsShouldProcess=true)]
    [Alias("Login-AzureASAccount")]
    [OutputType(typeof(AsAzureProfile))]
    public class AddAzureASAccountCommand : AzurePSCmdlet, IModuleAssemblyInitializer
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the environment containing the account to log into")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Credential")]
        public PSCredential Credential { get; set; }

        protected AsAzureEnvironment AsEnvironment;
           
        protected override AzureContext DefaultContext
        {
            get
            {
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
                throw new PSInvalidOperationException(string.Format(Properties.Resources.UnknownEnvironment, EnvironmentName));
            }
            else
            {
                if (AsAzureClientUtility.Instance.Profile.Environments.ContainsKey(EnvironmentName))
                {
                    AsEnvironment = AsAzureClientUtility.Instance.Profile.Environments[EnvironmentName];
                }
                else
                {
                    AsEnvironment = AsAzureClientUtility.Instance.Profile.CreateEnvironment(EnvironmentName);
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
            if (ShouldProcess(string.Format(Properties.Resources.LoginTarget, AsEnvironment.Name), "log in"))
            {
                var currentProfile = AsAzureClientUtility.Instance.Profile;

                if (currentProfile.Context == null)
                {
                    AsAzureClientUtility.Instance.SetCurrentContext(azureAccount, AsEnvironment);
                }

                var asAzureProfile = AsAzureClientUtility.Instance.Login(currentProfile.Context, password);
                WriteObject(asAzureProfile);
            }
#pragma warning restore 0618
        }

        /// <summary>
        /// Load global aliases for ARM
        /// </summary>
        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AzureRmProfileStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This will throw exception for tests, ignore.
            }
        }

    }
}
