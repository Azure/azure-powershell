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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet("Restart", "AzureRemoteAppVM", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High), OutputType(typeof(TrackingResult))]
    public class RestartAzureRemoteAppVm : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "User UPN")]
        public string UserUpn { get; set; }

        [Parameter(Mandatory = false,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Warning message shown to users connected to the VM before they are logged off")]
        public string LogoffMessage { get; set; }

        [Parameter(Mandatory = false,
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time to wait before logging off users on the VM (default is 60 seconds)")]
        public int LogoffWaitSeconds { get; set; }

        private RemoteAppVm GetVm(string collectionName, string userUpn)
        {
            CollectionVmsListResult response = null;
            
            response = CallClient(() => Client.Collections.ListVms(collectionName), Client.Collections);

            if (response != null && response.Vms != null)
            {
                foreach (RemoteAppVm vm in response.Vms)
                {
                    if (vm != null && vm.LoggedOnUserUpns != null)
                    {
                        foreach (string user in vm.LoggedOnUserUpns)
                        {
                            if (string.Compare(user, userUpn, true) == 0)
                            {
                                return vm;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public override void ExecuteCmdlet()
        {
            RemoteAppVm vm = GetVm(CollectionName, UserUpn);
            RestartVmCommandParameter restartDetails = null;
            OperationResultWithTrackingId result = null;

            if (vm == null)
            {
                WriteWarning(string.Format(Commands_RemoteApp.NoVmInCollectionForUser, UserUpn, CollectionName));
                
                return;
            }

            if (vm.LoggedOnUserUpns.Count > 1)
            {
                string otherLoggedInUsers = null;
                string warningCaption = null;
                string warningMessage = null;

                foreach (string user in vm.LoggedOnUserUpns)
                {
                    if (string.Compare(user, UserUpn, true) != 0)
                    {
                        otherLoggedInUsers += "\n" + user;
                    }
                }

                warningMessage = string.Format(Commands_RemoteApp.RestartVmWarningMessage, UserUpn, vm.VirtualMachineName, otherLoggedInUsers);
                warningCaption = string.Format(Commands_RemoteApp.RestartVmWarningCaption, vm.VirtualMachineName);

                WriteWarning(warningMessage);

                if (!ShouldProcess(null, Commands_RemoteApp.GenericAreYouSureQuestion, warningCaption))
                {
                    return;
                }
            }

            restartDetails = new RestartVmCommandParameter(vm.VirtualMachineName);
            restartDetails.LogoffWaitTimeInSeconds = LogoffWaitSeconds <= 0 ? 60 : LogoffWaitSeconds;
            restartDetails.LogoffMessage = string.IsNullOrEmpty(LogoffMessage) ? string.Format(Commands_RemoteApp.DefaultLogoffMessage, restartDetails.LogoffWaitTimeInSeconds) : LogoffMessage;

            result = CallClient(() => Client.Collections.RestartVm(CollectionName, restartDetails), Client.Collections);

            if (result != null)
            {
                TrackingResult trackingId = new TrackingResult(result);
                WriteObject(trackingId);
            }
        }
    }
}
