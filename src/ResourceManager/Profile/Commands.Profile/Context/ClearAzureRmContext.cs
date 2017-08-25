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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsCommon.Clear, "AzureRmContext", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ClearAzureRmContext : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage ="Clear the context only for the current PowerShell session, or for all sessions.")]
        public ContextModificationScope Scope { get; set; } = ContextModificationScope.Process;

        [Parameter(Mandatory = false, HelpMessage="Return a value indicating success or failure")]
        public SwitchParameter PassThrough { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Delete all users and groups from the global scope without prompting")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
           switch(Scope)
            {
                case ContextModificationScope.Process:
                    ConfirmAction("Remove all accounts and subscriptions for the current process", "Current process context", 
                        () => 
                        {
                            bool result = false;
                            if (AzureRmProfileProvider.Instance != null)
                            {
                                AzureRmProfileProvider.Instance.ResetDefaultProfile();
                                result = true;
                            }
                            else if (PassThrough.IsPresent)
                            {
                                WriteObject(result);
                            }
                        });
                    break;
                case ContextModificationScope.CurrentUser:
                    ConfirmAction(Force.IsPresent, "Remove all accounts and subscriptiosn in all sessions for the current user.", "Remove all accounts and subscriptions for all sessiosn started by the current user", "All contexts for the current user", 
                        () => 
                        {
                            bool result = false;
                            var session = AzureSession.Instance;
                            var contextFilePath = Path.Combine(session.ARMProfileDirectory, session.ARMProfileFile);
                            if (session.DataStore.FileExists(contextFilePath))
                            {
                                session.DataStore.DeleteFile(contextFilePath);
                                if (AzureRmProfileProvider.Instance != null)
                                {
                                    AzureRmProfileProvider.Instance.ResetDefaultProfile();
                                    result = true; ;
                                }
                            }

                            if (PassThrough.IsPresent)
                            {
                                WriteObject(result);
                            }
                        },
                        () =>
                        {
                            var session = AzureSession.Instance;
                            var contextFilePath = Path.Combine(session.ARMProfileDirectory, session.ARMProfileFile);
                            return session.DataStore.FileExists(contextFilePath);
                        });
                    break;
            }
        }
    }
}
