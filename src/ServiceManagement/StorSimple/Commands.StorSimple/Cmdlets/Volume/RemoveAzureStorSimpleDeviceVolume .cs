using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceVolume"), OutputType(typeof(TaskStatusInfo))]
    public class RemoveAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeId)]
        [ValidateNotNullOrEmpty]
        public VirtualDisk Volume { get; set; }

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
                                      WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                                      WriteObject(null);
                                      return;
                                  }

                                  string volumeId = string.Empty;
                                  switch(ParameterSetName)
                                  {
                                      case StorSimpleCmdletParameterSet.IdentifyByObject:
                                          volumeId = Volume.InstanceId;
                                          break;
                                      case StorSimpleCmdletParameterSet.IdentifyByName:
                                          var volumeInfo = StorSimpleClient.GetVolumeByName(deviceid, VolumeName);
                                          if (volumeInfo == null)
                                          {
                                              WriteVerbose(Resources.NotFoundMessageVirtualDisk);
                                              return;
                                          }
                                          volumeId = volumeInfo.VirtualDiskInfo.InstanceId;
                                          break;
                                  }

                                  if (WaitForComplete.IsPresent)
                                  {
                                      WriteVerbose("About to run a job to remove your volume!");
                                      var jobstatus = StorSimpleClient.RemoveVolume(deviceid, volumeId);
                                      HandleSyncTaskResponse(jobstatus, "delete");
                                  }
                                  else
                                  {
                                      WriteVerbose("About to run a job to remove your volume!");
                                      var jobresponse = StorSimpleClient.RemoveVolumeAsync(deviceid, volumeId);
                                      HandleAsyncTaskResponse(jobresponse, "delete");
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