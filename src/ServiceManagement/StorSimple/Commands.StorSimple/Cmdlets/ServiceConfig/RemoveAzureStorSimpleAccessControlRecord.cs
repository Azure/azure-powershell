
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
    /// Removes a ACR from the StorSimple Manager Service Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(JobStatusInfo))]

    public class RemoveAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageACRName)]
        [ValidateNotNullOrEmpty]
        public string ACRName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageACRObject)]
        [ValidateNotNullOrEmpty]
        public AccessControlRecord ACR { get; set; }

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
                                  AccessControlRecord existingAcr = null;
                                  switch (ParameterSetName)
                                  {
                                      case StorSimpleCmdletParameterSet.IdentifyByName:
                                          var allACRs = StorSimpleClient.GetAllAccessControlRecords();
                                          existingAcr = allACRs.Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                          break;
                                      case StorSimpleCmdletParameterSet.IdentifyByObject:
                                          existingAcr = ACR;
                                          break;
                                  }
                                  if (existingAcr == null)
                                  {
                                      WriteVerbose(Resources.NotFoundMessageACR);
                                      return;
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

