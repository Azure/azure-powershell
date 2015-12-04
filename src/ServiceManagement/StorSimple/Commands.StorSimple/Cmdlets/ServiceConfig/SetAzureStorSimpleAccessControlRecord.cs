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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Sets the Host IQN of the ACR in the StorSimple Manager Service Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(TaskStatusInfo))]

    public class SetAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.ACRName)]
        [ValidateNotNullOrEmpty]
        public string ACRName { get; set; }

        [Alias("IQN")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.IQNforACR)]
        [ValidateNotNullOrEmpty]
        public string IQNInitiatorName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.ACRNewName)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {

                var allACRs = StorSimpleClient.GetAllAccessControlRecords();
                var existingAcr = allACRs.Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (existingAcr == null)
                {
                    throw new ArgumentException(string.Format(Resources.NotFoundMessageACR, ACRName));
                }
                
                var serviceConfig = new ServiceConfiguration()
                {
                    AcrChangeList = new AcrChangeList()
                    {
                        Added = new List<AccessControlRecord>(),
                        Deleted = new List<string>(),
                        Updated = new []
                        {
                            new AccessControlRecord()
                            {
                                GlobalId = existingAcr.GlobalId,
                                InitiatorName = IQNInitiatorName,
                                InstanceId = existingAcr.InstanceId,
                                Name = (!string.IsNullOrWhiteSpace(NewName) ? NewName : existingAcr.Name),
                                VolumeCount = existingAcr.VolumeCount
                            },
                        }
                    },
                    CredentialChangeList = new SacChangeList(),
                };

                if (WaitForComplete.IsPresent)
                {
                    WriteVerbose("About to run a task to update your Access Control Record!"); 
                    var taskStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncTaskResponse(taskStatus, "update");
                    if (taskStatus.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var updatedAcr = StorSimpleClient.GetAllAccessControlRecords()
                                            .Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(updatedAcr);
                    }
                }
                else
                {
                    WriteVerbose("About to create a task to update your Access Control Record!");
                    var taskResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncTaskResponse(taskResponse, "update");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

