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
                    WriteObject(Resources.NotFoundMessageDevice);
                    return;
                }

                if (VolumeContainerName == null)
                {
                    var dataContainerList = StorSimpleClient.GetAllDataContainers(deviceid);
                    WriteVerbose(String.Format(Resources.ReturnedCountDataContainerMessage, dataContainerList.DataContainers.Count));
                    WriteObject(dataContainerList.DataContainers);
                }
                else
                {
                    var dataContainer = StorSimpleClient.GetDataContainer(deviceid, VolumeContainerName);
                    if(dataContainer != null && dataContainer.DataContainerInfo != null)
                    {
                        WriteVerbose(String.Format(Resources.FoundDataContainerMessage, VolumeContainerName));
                    }
                    else
                    {
                        WriteVerbose(String.Format(Resources.NotFoundDataContainerMessage, VolumeContainerName));
                    }
                    WriteObject(dataContainer.DataContainerInfo);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}