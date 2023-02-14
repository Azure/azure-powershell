// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Security;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeRole;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.Role;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Roles
{
    [Cmdlet(VerbsCommon.New, Constants.Role, DefaultParameterSetName = ConnectionStringParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeRoleNewCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string ConnectionStringParameterSet = "ConnectionStringParameterSet";
        private const string IotParameterSet = "IotParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ConnectionStringParameterSet,
            HelpMessage = HelpMessageRoles.ConnectionStringHelpMessage)]
        public SwitchParameter ConnectionString { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ConnectionStringParameterSet,
            HelpMessage = HelpMessageRoles.IotDeviceConnectionStringHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString IotDeviceConnectionString { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ConnectionStringParameterSet,
            HelpMessage = HelpMessageRoles.IotEdgeDeviceConnectionStringHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString IotEdgeDeviceConnectionString { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = IotParameterSet,
            HelpMessage = HelpMessageRoles.DeviceProperty)]
        public SwitchParameter DeviceProperty { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = IotParameterSet,
            HelpMessage = HelpMessageRoles.IotDeviceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string IotDeviceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = IotParameterSet,
            HelpMessage = HelpMessageRoles.IotDeviceAccessKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString IotDeviceAccessKey { get; set; }


        [Parameter(Mandatory = true,
            ParameterSetName = IotParameterSet,
            HelpMessage = HelpMessageRoles.IotEdgeDeviceId)]
        [ValidateNotNullOrEmpty]
        public string IotEdgeDeviceId { get; set; }

        private string iotDeviceAccessKey;


        [Parameter(Mandatory = true,
            ParameterSetName = IotParameterSet,
            HelpMessage = HelpMessageRoles.IotEdgeDeviceAccessKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString IotEdgeDeviceAccessKey { get; set; }

        private string iotEdgeDeviceAccessKey { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = IotParameterSet,
            HelpMessage = HelpMessageRoles.IotHostHubHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string IotHostHub { get; set; }

        private string iotDeviceHostHub { get; set; }
        private string iotEdgeDeviceHostHub { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.EncryptionKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString EncryptionKey { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageRoles.PlatformHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Windows", "Linux")]
        public string Platform { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageRoles.RoleStatusHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string RoleStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private const string HostName = "HostName";
        private const string DeviceId = "DeviceId";
        private const string SharedAccessKey = "SharedAccessKey";

        private ResourceModel GetResourceModel()
        {
            return RolesOperationsExtensions.Get(
                this.DataBoxEdgeManagementClient.Roles,
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }


        private string GetResourceNotFoundMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageRoles.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResourceModel();
                if (resource == null) return false;
                var msg = GetResourceNotFoundMessage();
                throw new Exception(msg);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private string GetConnectionString(string hostName, string deviceId, string sharedAccessKey)
        {
            return string.Format("HostName={0};DeviceId={1};SharedAccessKey={2}",
                hostName, deviceId, sharedAccessKey);
        }


        public static IoTRole GetIoTRoleObject(
            string deviceId,
            string edgeDeviceId,
            string ioTHostHub,
            string platform,
            AsymmetricEncryptedSecret iotDeviceSecret,
            AsymmetricEncryptedSecret iotEdgeDeviceSecret,
            string roleStatus)
        {
            var authentication = new Authentication() {SymmetricKey = new SymmetricKey(iotDeviceSecret)};
            var ioTDeviceInfo = new IoTDeviceInfo(deviceId, ioTHostHub, authentication: authentication);

            var edgeAuthentication = new Authentication()
                {SymmetricKey = new SymmetricKey(iotEdgeDeviceSecret)};
            var ioTEdgeDeviceInfo = new IoTDeviceInfo(edgeDeviceId, ioTHostHub, authentication: edgeAuthentication);

            return new IoTRole(platform, ioTDeviceInfo, ioTEdgeDeviceInfo, roleStatus);
        }


        private static void ThrowInvalidConnection(string message = "Invalid connection string")
        {
            throw new PSInvalidOperationException(message);
        }

        private static Dictionary<string, string> GetIotDeviceProperties(string connectionString)
        {
            var deviceProperties = new Dictionary<string, string>();
            var iotProps = connectionString.Split(';');
            foreach (var iotProp in iotProps)
            {
                var keyPos = iotProp.IndexOf('=');
                if (keyPos < 0 || keyPos >= iotProp.Length)
                {
                    ThrowInvalidConnection();
                }

                var k = iotProp.Substring(0, keyPos);
                var v = iotProp.Substring(keyPos + 1);
                deviceProperties.Add(k, v);
            }

            var keys = new List<string> {HostName, DeviceId, SharedAccessKey};

            foreach (var key in keys.Where(key => !deviceProperties.ContainsKey(key)))
            {
                ThrowInvalidConnection("Missing property " + key + " in connection string");
            }

            return deviceProperties;
        }

        private void ParseIotDeviceConnectionString()
        {
            var deviceProperties = GetIotDeviceProperties(this.IotDeviceConnectionString.ConvertToString());
            this.IotDeviceId = deviceProperties.GetOrNull(DeviceId);
            this.iotDeviceAccessKey = deviceProperties.GetOrNull(SharedAccessKey);
            this.iotDeviceHostHub = deviceProperties.GetOrNull(HostName);
        }

        private void ParseEdgeDeviceConnectionString()
        {
            var deviceProperties = GetIotDeviceProperties(this.IotEdgeDeviceConnectionString.ConvertToString());
            this.IotEdgeDeviceId = deviceProperties.GetOrNull(DeviceId);
            this.iotEdgeDeviceAccessKey = deviceProperties.GetOrNull(SharedAccessKey);
            this.iotEdgeDeviceHostHub = deviceProperties.GetOrNull(HostName);
        }

        private PSResourceModel CreateResourceModel()
        {
            var iotDeviceSecret = DataBoxEdgeManagementClient.Devices.GetAsymmetricEncryptedSecret(
                this.DeviceName,
                this.ResourceGroupName,
                GetConnectionString(this.IotHostHub, this.IotDeviceId, this.iotDeviceAccessKey),
                this.EncryptionKey.ConvertToString()
            );

            var iotEdgeDeviceSecret = DataBoxEdgeManagementClient.Devices.GetAsymmetricEncryptedSecret(
                this.DeviceName,
                this.ResourceGroupName,
                GetConnectionString(this.IotHostHub, this.IotEdgeDeviceId, this.iotEdgeDeviceAccessKey),
                this.EncryptionKey.ConvertToString()
            );

            var iotRole = GetIoTRoleObject(
                this.IotDeviceId,
                this.IotEdgeDeviceId,
                this.IotHostHub,
                this.Platform,
                iotDeviceSecret,
                iotEdgeDeviceSecret,
                this.RoleStatus
            );
            return new PSResourceModel(
                DataBoxEdgeManagementClient.Roles.CreateOrUpdate(
                    this.DeviceName, this.Name, iotRole,
                    this.ResourceGroupName)
            );
        }


        public override void ExecuteCmdlet()
        {
            if (ConnectionString.IsPresent)
            {
                ParseIotDeviceConnectionString();
                ParseEdgeDeviceConnectionString();
                int c = string.Compare(this.iotDeviceHostHub, this.iotEdgeDeviceHostHub);
                if (c != 0)
                {
                    ThrowInvalidConnection(HelpMessageRoles.ShouldBeFromSameHostHub);
                }
                else
                {
                    this.IotHostHub = this.iotDeviceHostHub;
                }
            }

            if (DeviceProperty.IsPresent)
            {
                this.iotEdgeDeviceAccessKey = this.IotEdgeDeviceAccessKey.ConvertToString();
                this.iotDeviceAccessKey = this.IotDeviceAccessKey.ConvertToString();
            }

            if (!ConnectionString.IsPresent && !DeviceProperty.IsPresent)
            {
                throw new Exception(
                    string.Format(
                        "Please select one of -'{0}' or -'{1}'",
                        nameof(this.ConnectionString),
                        nameof(this.DeviceProperty)));
            }


            if (this.ShouldProcess(this.Name,
                string.Format("Creating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageRoles.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSResourceModel>()
                {
                    CreateResourceModel()
                };

                WriteObject(results, true);
            }
        }
    }
}