
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
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(JobStatusInfo))]

    public class RemoveAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageSACObject)]
        [ValidateNotNullOrEmpty]
        public StorageAccountCredential SAC { get; set; }

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
                                  StorageAccountCredential existingSac = null;
                                  switch (ParameterSetName)
                                  {
                                      case StorSimpleCmdletParameterSet.IdentifyByName:
                                          var allSACs = StorSimpleClient.GetAllStorageAccountCredentials();
                                          existingSac = allSACs.Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                          break;
                                      case StorSimpleCmdletParameterSet.IdentifyByObject:
                                          existingSac = SAC;
                                          break;
                                  }
                                  if (existingSac == null)
                                  {
                                      WriteVerbose(Resources.NotFoundMessageStorageAccount);
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
                                        var jobStatus = StorSimpleClient.ConfigureService(serviceConfig);
                                        HandleSyncJobResponse(jobStatus, "delete");
                                    }
                                    else
                                    {
                                        var jobResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                                        HandleAsyncJobResponse(jobResponse, "delete");
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

