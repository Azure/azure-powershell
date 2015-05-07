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
    /// Removes the Storage Account Cred specified from the StorSimple Service Config
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(TaskStatusInfo))]

    public class RemoveAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.SACObject)]
        [ValidateNotNullOrEmpty]
        public StorageAccountCredentialResponse SAC { get; set; }

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
                                  StorageAccountCredentialResponse existingSac = null;
                                  string sacName = null;

                                  switch (ParameterSetName)
                                  {
                                      case StorSimpleCmdletParameterSet.IdentifyByName:
                                          var allSACs = StorSimpleClient.GetAllStorageAccountCredentials();
                                          existingSac = allSACs.Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                          sacName = StorageAccountName;
                                          break;
                                      case StorSimpleCmdletParameterSet.IdentifyByObject:
                                          existingSac = SAC;
                                          sacName = SAC.Name;
                                          break;
                                  }
                                  if (existingSac == null)
                                  {
                                      throw new ArgumentException(string.Format(Resources.SACNotFoundWithName, sacName));
                                  }

                                  var serviceConfig = new ServiceConfiguration()
                                  {
                                      AcrChangeList = new AcrChangeList(),
                                      CredentialChangeList = new SacChangeList()
                                      {
                                          Added = new List<StorageAccountCredential>(),
                                          Deleted = new[] {existingSac.InstanceId},
                                          Updated = new List<StorageAccountCredential>()
                                      }
                                  };

                                    if (WaitForComplete.IsPresent)
                                    {
                                        WriteVerbose("About to run a task to remove your Storage Access Credential!");
                                        var taskStatus = StorSimpleClient.ConfigureService(serviceConfig);
                                        HandleSyncTaskResponse(taskStatus, "delete");
                                    }
                                    else
                                    {
                                        WriteVerbose("About to create a task to remove your Storage Access Credential!");
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

