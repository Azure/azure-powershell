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
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Add", "AzureAnalysisServicesAccount", SupportsShouldProcess=true)]
    [Alias("Login-AzureAsAccount")]
    [OutputType(typeof(AsAzureProfile))]
    public class AddAzureASAccountCommand : AzurePSCmdlet, IModuleAssemblyInitializer
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "Name of the Azure Analysis Services environment to which to logon to")]
        public string RolloutEnvironment { get; set; }
        
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
            if (string.IsNullOrEmpty(RolloutEnvironment))
            {
                RolloutEnvironment = AsAzureClientSession.GetDefaultEnvironmentName();
            }

            if (AsAzureClientSession.Instance.Profile.Environments.ContainsKey(RolloutEnvironment))
            {
                AsEnvironment = (AsAzureEnvironment)AsAzureClientSession.Instance.Profile.Environments[RolloutEnvironment];
            }
            else
            {
                AsEnvironment = AsAzureClientSession.Instance.Profile.CreateEnvironment(RolloutEnvironment);
            }
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

            if (ShouldProcess(string.Format(Resources.LoginTarget, AsEnvironment.Name), "log in"))
            {
                var currentProfile = AsAzureClientSession.Instance.Profile;
                var currentContext = currentProfile.Context;

                // If there is no current context create one. If there is one already then
                // if the current credentials (userid) match the one that is already in context then use it.
                // if either the userid that is logging in or the environment to which login is happening is
                // different than the one in the context then clear the current context and proceed to login.
                // At any given point in time, we should only have one context i.e. one user logged in to one
                // environment.
                if (currentContext == null || Credential == null ||
                    string.IsNullOrEmpty(currentContext.Account.Id) || 
                    !currentContext.Account.Id.Equals(Credential.UserName) ||
                    !RolloutEnvironment.Equals(currentContext.Environment.Name))
                {
                    AsAzureClientSession.Instance.SetCurrentContext(azureAccount, AsEnvironment);
                }

                var asAzureProfile = AsAzureClientSession.Instance.Login(currentProfile.Context, password);

                WriteObject(asAzureProfile);
            }
        }

        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AnalysisServicesDataplaneStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This will throw exception for tests, ignore.
            }
        }
    }
}
