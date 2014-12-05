
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
    /// Sets the Host IQN of the ACR in the StorSimple Manager Service Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(JobStatusInfo))]

    public class SetAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageACRName)]
        [ValidateNotNullOrEmpty]
        public string ACRName { get; set; }

        [Alias("IQN")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIQNforACR)]
        [ValidateNotNullOrEmpty]
        public string IQNInitiatorName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {

                var allACRs = StorSimpleClient.GetAllAccessControlRecords();
                var existingAcr = allACRs.Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
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
                        Deleted = new List<string>(),
                        Updated = new []
                        {
                            new AccessControlRecord()
                            {
                                GlobalId = existingAcr.GlobalId,
                                InitiatorName = IQNInitiatorName,
                                InstanceId = existingAcr.InstanceId,
                                Name = existingAcr.Name,
                                VolumeCount = existingAcr.VolumeCount
                            },
                        }
                    },
                    CredentialChangeList = new SacChangeList(),
                };

                if (WaitForComplete.IsPresent)
                {
                    var jobStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncJobResponse(jobStatus, "update");
                    if(jobStatus.TaskResult == TaskResult.Succeeded)
                    {
                        var updatedAcr = StorSimpleClient.GetAllAccessControlRecords()
                                            .Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(updatedAcr);
                    }
                }
                else
                {
                    var jobResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncJobResponse(jobResponse, "update");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

