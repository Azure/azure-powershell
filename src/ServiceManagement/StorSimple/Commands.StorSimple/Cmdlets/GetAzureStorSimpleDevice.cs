using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Management.Automation;
using Microsoft.WindowsAzure;
using System.Linq;
using System;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;
    using System.Collections.Generic;

    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDevice", DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),
        OutputType(typeof(List<DeviceDetails>), typeof(IEnumerable<DeviceInfo>))]
    public class GetAzureStorSimpleDevice : StorSimpleCmdletBase
    {
        [Alias("ID")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceId)]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceType)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceModel)]
        [ValidateNotNullOrEmpty]
        public string ModelID { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceConfigRequired)]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var deviceInfos = StorSimpleClient.GetAllDevices();
                switch(ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.IdentifyByName:
                        deviceInfos = deviceInfos.Where(x => x.FriendlyName.Equals(DeviceName, System.StringComparison.InvariantCultureIgnoreCase));
                        break;
                    case StorSimpleCmdletParameterSet.IdentifyById:
                        deviceInfos = deviceInfos.Where(x => x.DeviceId.Equals(DeviceId, System.StringComparison.InvariantCultureIgnoreCase));
                        break;
                    default:
                        break;
                }
                
                if (Type != null)
                {
                    DeviceType deviceType;
                    bool parseSuccess = Enum.TryParse(Type, true, out deviceType);
                    if (parseSuccess)
                    {
                        deviceInfos = deviceInfos.Where(x => x.Type.Equals(deviceType));
                    }
                }

                if (ModelID != null)
                {
                    deviceInfos = deviceInfos.Where(x => x.ModelDescription.Equals(ModelID, System.StringComparison.InvariantCultureIgnoreCase));
                }

                if (Detailed.IsPresent)
                {
                    List<DeviceDetails> deviceDetailsList = new List<DeviceDetails>();
                    foreach (var deviceInfo in deviceInfos)
                    {
                        deviceDetailsList.Add(StorSimpleClient.GetDeviceDetails(deviceInfo.DeviceId));
                    }
                    WriteObject(deviceDetailsList, true);
                }

                else
                {
                    WriteObject(deviceInfos, true);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}