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
    /// Removes a ACR from the StorSimple Manager Service Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(TaskStatusInfo))]

    public class RemoveAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.ACRName)]
        [ValidateNotNullOrEmpty]
        public string ACRName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.ACRObject)]
        [ValidateNotNullOrEmpty]
        public AccessControlRecord ACR { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                          Resources.RemoveWarningACR,
                          Resources.RemoveConfirmationACR,
                          string.Empty,
                          () =>
                          {
                              try
                              {
                                  AccessControlRecord existingAcr = null;
                                  string acrName = null;
                                  switch (ParameterSetName)
                                  {
                                      case StorSimpleCmdletParameterSet.IdentifyByName:
                                          var allACRs = StorSimpleClient.GetAllAccessControlRecords();
                                          existingAcr = allACRs.Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                          acrName = ACRName;
                                          break;
                                      case StorSimpleCmdletParameterSet.IdentifyByObject:
                                          existingAcr = ACR;
                                          acrName = ACR.Name;
                                          break;
                                  }
                                  if (existingAcr == null)
                                  {
                                      throw new ArgumentException(string.Format(Resources.NotFoundMessageACR, acrName));
                                  }
                                  
                                    var serviceConfig = new ServiceConfiguration()
                                    {
                                        AcrChangeList = new AcrChangeList()
                                        {
                                            Added = new List<AccessControlRecord>(),
                                            Deleted = new[] { existingAcr.InstanceId },
                                            Updated = new List<AccessControlRecord>()
                                        },
                                        CredentialChangeList = new SacChangeList(),
                                    };

                                    if (WaitForComplete.IsPresent)
                                    {
                                        WriteVerbose("About to run a task to remove your ACR!");
                                        var taskStatus = StorSimpleClient.ConfigureService(serviceConfig);
                                        HandleSyncTaskResponse(taskStatus, "delete");
                                    }
                                    else
                                    {
                                        WriteVerbose("About to create a task to remove your ACR!");
                                        var taskResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                                        HandleAsyncTaskResponse(taskResponse, "delete");
                                    }
                              }
                              catch (Exception exception)
                              {
                                  this.HandleException(exception);
                              }
                          });
        }
    }
}

