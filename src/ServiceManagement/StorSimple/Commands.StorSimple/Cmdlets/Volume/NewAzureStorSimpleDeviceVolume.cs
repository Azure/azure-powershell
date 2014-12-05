using System;
using System.Management.Automation;
using System.Net;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Volume
{
    using Properties;
    using System.Collections.Generic;

    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceVolume"), OutputType(typeof(JobStatusInfo))]
    public class NewAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Container")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDataContainerObject)]
        [ValidateNotNullOrEmpty]
        public DataContainer VolumeContainer { get; set; }
        
        [Alias("Name")]
        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Alias("Size")]
        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeSize)]
        [ValidateNotNullOrEmpty]
        public Int64 VolumeSize { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeAcrList)]
        [ValidateNotNullOrEmpty]
        public List<AccessControlRecord> AccessControlRecords { get; set; }

        [Alias("AppType")]
        [Parameter(Position = 5, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeAppType)]
        [ValidateNotNullOrEmpty]
        public AppType VolumeAppType { get; set; }

        [Parameter(Position = 6, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeOnline)]
        [ValidateNotNullOrEmpty]
        public bool Online { get; set; }

        [Parameter(Position = 7, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeDefaultBackup)]
        [ValidateNotNullOrEmpty]
        public bool EnableDefaultBackup { get; set; }

        [Parameter(Position = 8, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeMonitoring)]
        [ValidateNotNullOrEmpty]
        public bool EnableMonitoring { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }
        
        public override void ExecuteCmdlet()
        {
            try
            {
                string deviceid = null;
                deviceid = StorSimpleClient.GetDeviceId(DeviceName);

                if (deviceid == null)
                {
                    WriteVerbose(Resources.NotFoundMessageDevice);
                    return;
                }

                //Virtual disk create request object
                var virtualDiskToCreate = new VirtualDiskRequest()
                {
                    Name = VolumeName,
                    AccessType = AccessType.ReadWrite,
                    AcrList = AccessControlRecords,
                    AppType = VolumeAppType,
                    IsDefaultBackupEnabled = EnableDefaultBackup,
                    SizeInBytes = VolumeSize,
                    DataContainer = VolumeContainer,
                    Online = Online,
                    IsMonitoringEnabled = EnableMonitoring
                };

                if (WaitForComplete.IsPresent)
                {
                    var jobstatus = StorSimpleClient.CreateVolume(deviceid, virtualDiskToCreate); ;
                    HandleSyncJobResponse(jobstatus, "create");
                    if(jobstatus.TaskResult == TaskResult.Succeeded)
                    {
                        var createdVolume = StorSimpleClient.GetVolumeByName(deviceid, VolumeName);
                        WriteObject(createdVolume.VirtualDiskInfo);
                    }
                }

                else
                {
                    var jobstatus = StorSimpleClient.CreateVolumeAsync(deviceid, virtualDiskToCreate); ;
                    HandleAsyncJobResponse(jobstatus, "create");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}