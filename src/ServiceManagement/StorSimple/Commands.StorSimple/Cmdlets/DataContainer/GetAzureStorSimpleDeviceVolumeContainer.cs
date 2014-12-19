using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;
    using System.Collections.Generic;

    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceVolumeContainer"),OutputType(typeof(DataContainer), typeof(IList<DataContainer>))]
    public class GetAzureStorSimpleDeviceVolumeContainer : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDataContainerName)]
        [ValidateNotNullOrEmpty]
        public string VolumeContainerName { get; set; }

        public override void ExecuteCmdlet()
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

                if (VolumeContainerName == null)
                {
                    var dataContainerList = StorSimpleClient.GetAllDataContainers(deviceid);
                    WriteObject(dataContainerList.DataContainers);
                    WriteVerbose(String.Format(Resources.ReturnedCountDataContainerMessage, dataContainerList.DataContainers.Count, dataContainerList.DataContainers.Count > 1 ? "s" : String.Empty));
                }
                else
                {
                    var dataContainer = StorSimpleClient.GetDataContainer(deviceid, VolumeContainerName);
                    if(dataContainer != null 
                        && dataContainer.DataContainerInfo != null
                        && dataContainer.DataContainerInfo.InstanceId != null)
                    {
                        WriteObject(dataContainer.DataContainerInfo);
                        WriteVerbose(String.Format(Resources.FoundDataContainerMessage, VolumeContainerName));
                    }
                    else
                    {
                        WriteVerbose(String.Format(Resources.NotFoundDataContainerMessage, VolumeContainerName));
                    }
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}