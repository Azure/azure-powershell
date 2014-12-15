
using System;
using System.Management.Automation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    /// <summary>
    /// Removes the Storage Account Cred specified from the StorSimple Service Config
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(TaskStatusInfo))]

    public class RemoveAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageSACObject)]
        [ValidateNotNullOrEmpty]
        public StorageAccountCredentialResponse SAC { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
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
                                      WriteObject(null);
                                      WriteVerbose(String.Format(Resources.SACNotFoundWithName, sacName));
                                      return;
                                  }
                                  
                                    var serviceConfig = new ServiceConfiguration()
                                    {
                                    AcrChangeList = new AcrChangeList(),
                                    CredentialChangeList = new SacChangeList()
                                    {
                                        Added = new List<StorageAccountCredential>(),
                                        Deleted = new[] { existingSac.InstanceId },
                                        Updated = new List<StorageAccountCredential>()
                                    }
                                    };

                                    if (WaitForComplete.IsPresent)
                                    {
                                        WriteVerbose("About to run a job to remove your Storage Access Credential!");
                                        var jobStatus = StorSimpleClient.ConfigureService(serviceConfig);
                                        HandleSyncTaskResponse(jobStatus, "delete");
                                    }
                                    else
                                    {
                                        WriteVerbose("About to create a job to remove your Storage Access Credential!");
                                        var jobResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                                        HandleAsyncTaskResponse(jobResponse, "delete");
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

