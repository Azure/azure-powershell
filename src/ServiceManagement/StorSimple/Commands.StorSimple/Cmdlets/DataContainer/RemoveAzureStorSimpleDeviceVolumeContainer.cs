using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceVolumeContainer"), OutputType(typeof(JobStatusInfo))]
    public class RemoveAzureStorSimpleDeviceVolumeContainer : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDataContainerName)]
        [ValidateNotNullOrEmpty]
        public DataContainer VolumeContainer { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                          Resources.RemoveWarningVolume,
                          Resources.RemoveConfirmationVolume,
                          string.Empty,
                          () =>
                          {
                              try
                              {
                                  var deviceid = StorSimpleClient.GetDeviceId(DeviceName);

                                  if (deviceid == null)
                                  {
                                      WriteObject(Resources.NotFoundMessageDevice);
                                      return;
                                  }
                                  
                                    if (WaitForComplete.IsPresent)
                                    {
                                        var jobstatusInfo = StorSimpleClient.DeleteDataContainer(deviceid, VolumeContainer.InstanceId);
                                        HandleSyncJobResponse(jobstatusInfo, "delete");
                                    }
                                    else
                                    {
                                        var jobresult = StorSimpleClient.DeleteDataContainerAsync(deviceid, VolumeContainer.InstanceId);
                                        HandleAsyncJobResponse(jobresult, "delete");
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