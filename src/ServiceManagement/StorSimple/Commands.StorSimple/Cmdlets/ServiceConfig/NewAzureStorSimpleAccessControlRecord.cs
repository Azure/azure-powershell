
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    /// <summary>
    /// Add New Access Control Record to the StorSimple Manager Service Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(JobStatusInfo))]

    public class NewAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
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
                    var jobStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncJobResponse(jobStatus, "create");
                    if(jobStatus.TaskResult == TaskResult.Succeeded)
                    {
                        var createdAcr = StorSimpleClient.GetAllAccessControlRecords()
                                            .Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(createdAcr);
                    }
                }
                else
                {
                    var jobResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncJobResponse(jobResponse, "create");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
        
