using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceVolume"), OutputType(typeof(VirtualDisk), typeof(IList<VirtualDisk>))]
    public class GetAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByParentObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDataContainerObject)]
        [ValidateNotNullOrEmpty]
        public DataContainer VolumeContainer { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }
        
        public override void ExecuteCmdlet()
        {
            try
            {
                var deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceId == null)
                {
                    WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                    WriteObject(null);
                    return;
                }
                
                switch (ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.IdentifyByParentObject:
                        var volumeInfoList = StorSimpleClient.GetAllVolumesFordataContainer(deviceId, VolumeContainer.InstanceId);
                        WriteObject(volumeInfoList.ListofVirtualDisks);
                        WriteVerbose(string.Format(Resources.ReturnedCountVolumeMessage, volumeInfoList.ListofVirtualDisks.Count, volumeInfoList.ListofVirtualDisks.Count > 1 ? "s" : String.Empty));
                        break;
                    case StorSimpleCmdletParameterSet.IdentifyByName:
                        var volumeInfo = StorSimpleClient.GetVolumeByName(deviceId, VolumeName);
                        if (volumeInfo != null 
                            && volumeInfo.VirtualDiskInfo != null 
                            && volumeInfo.VirtualDiskInfo.InstanceId != null)
                        {
                            WriteObject(volumeInfo.VirtualDiskInfo);
                            WriteVerbose(String.Format(Resources.FoundVolumeMessage, VolumeName));
                        }
                        else
                        {
                            WriteVerbose(String.Format(Resources.NotFoundVolumeMessage, VolumeName));
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}