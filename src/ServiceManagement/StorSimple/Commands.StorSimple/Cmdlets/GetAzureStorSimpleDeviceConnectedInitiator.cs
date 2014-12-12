using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    /// <summary>
    /// Lists all the connected ISCSI initiators
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceConnectedInitiator"), OutputType(typeof(List<IscsiConnection>))]
    public class GetAzureStorSimpleDeviceConnectedInitiator : StorSimpleCmdletBase
    {
        [Alias("ID")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceId)]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        //not overriding BeginProcessing so resource context validation will happen here

        public override void ExecuteCmdlet()
        {
            try
            {
                List<IscsiConnection> iscsiConnections = null;
                var currentResourceName = StorSimpleClient.GetResourceContext().ResourceName;
                String deviceIdFinal = null;
                if(ParameterSetName == StorSimpleCmdletParameterSet.IdentifyByName)
                {
                    var deviceToUse = StorSimpleClient.GetAllDevices().Where(x => x.FriendlyName.Equals(DeviceName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (deviceToUse == null)
                    {
                        WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, currentResourceName , DeviceName));
                        WriteObject(null);
                        return;
                    }
                    deviceIdFinal = deviceToUse.DeviceId;
                }
                else
                    deviceIdFinal = DeviceId;

                //verify that this device is configured
                this.VerifyDeviceConfigurationCompleteForDevice(deviceIdFinal);
                iscsiConnections = StorSimpleClient.GetAllIscsiConnections(deviceIdFinal);
                WriteObject(iscsiConnections);
                WriteVerbose(String.Format(Resources.IscsiConnectionGet_StatusMessage,iscsiConnections.Count, (iscsiConnections.Count > 1?"s":String.Empty)));
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}