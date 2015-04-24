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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Add New Access Control Record to the StorSimple Manager Service Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(TaskStatusInfo))]

    public class NewAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
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

        public override void ExecuteCmdlet()
        {
            try
            {
                var serviceConfig = new ServiceConfiguration()
                {
                    AcrChangeList = new AcrChangeList()
                    {
                        Added = new[]
                        {
                            new AccessControlRecord()
                            {
                                GlobalId = null,
                                InitiatorName = IQNInitiatorName,
                                InstanceId = null,
                                Name = ACRName,
                                VolumeCount = 0
                            },
                        },
                        Deleted = new List<string>(),
                        Updated = new List<AccessControlRecord>()
                    },
                    CredentialChangeList = new SacChangeList(),
                };

                if (WaitForComplete.IsPresent)
                {
                    var taskStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncTaskResponse(taskStatus, "create");
                    if (taskStatus.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var createdAcr = StorSimpleClient.GetAllAccessControlRecords()
                                            .Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(createdAcr);
                    }
                }
                else
                {
                    var taskResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncTaskResponse(taskResponse, "create");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
        
