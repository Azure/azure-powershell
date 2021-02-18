using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common
{
    static class Constants
    {
        //Device Command List
        internal const string AzurePrefix = "Az";
        internal const string ServiceName = "StackEdge";

        //Device Comands
        internal const string Device = AzurePrefix + ServiceName + "Device";
        internal const string Alert = AzurePrefix + ServiceName + "Alert";
        internal const string Order = AzurePrefix + ServiceName + "Order";
        internal const string Action = AzurePrefix + ServiceName + "Device" + "Action";
        internal const string User = AzurePrefix + ServiceName + "User";
        internal const string Sac = AzurePrefix + ServiceName + "StorageAccountCredential";
        internal const string Role = AzurePrefix + ServiceName + "Role";
        internal const string Share = AzurePrefix + ServiceName + "Share";
        internal const string EdgeStorageAccount = AzurePrefix + ServiceName + "StorageAccount";
        internal const string EdgeStorageContainer = AzurePrefix + ServiceName + "StorageContainer";
        internal const string Trigger = AzurePrefix + ServiceName + "Trigger";
        internal const string BandwidthSchedule = AzurePrefix + ServiceName + "BandwidthSchedule";
        internal const string Test = AzurePrefix + ServiceName + "Test";
        internal const string ResourceAlreadyExists = " already exists with name ";

        //Alias Constants
        internal const string ResourceNameAlias = "ResourceName";
        internal const string ResourceAlias = "Resource";
        internal const string DeviceAlias = "Device";

        //Job Comands
        internal const string Job = AzurePrefix + ServiceName + "Job";

        //Arm providers
        internal const string DataBoxEdgeDeviceProvider = "Microsoft.DataBoxEdge/DataBoxEdgeDevices";
        internal const string DevicesPath = "DataBoxEdgeDevices/";

        //HelpMessage
        internal const string InputObjectHelpMessage = "Input Object";
        internal const string DeviceNameHelpMessage = "Device Name";
        internal const string ResourceIdHelpMessage = "Azure ResourceId";
        internal const string ResourceGroupNameHelpMessage = "Resource Group Name";
        internal const string NameHelpMessage = "Resource Name";
        internal const string PassThruHelpMessage = "returns true if successful";
        internal const string AsJobHelpMessage = "Run cmdlet in the background";
        internal const string PsDeviceObjectHelpMessage = "Please provide corresponding device object";

        internal const string EncryptionKeyHelpMessage = "Encryption key of the Edge device";

        internal const string NotFoundStringInException = "could not find";

        
    }
}