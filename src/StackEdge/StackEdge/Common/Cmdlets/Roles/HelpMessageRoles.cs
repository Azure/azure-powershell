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


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Roles
{
    internal class HelpMessageRoles
    {
        internal const string Name = "Name of the Role";
        internal const string ObjectName = "Iot Role";
        internal const string ConnectionStringHelpMessage = "To Provide Connection Strings";
        internal const string IotDeviceConnectionStringHelpMessage = "Please provide connection string of IOT Device";
        internal const string IotEdgeDeviceConnectionStringHelpMessage = "Please provide connection string of Edge Device";
        internal const string DeviceProperty = "To Provide Device Properties";
        internal const string RoleStatusHelpMessage = "Provide the status enable/disable";
        internal const string PlatformHelpMessage = "Provide the Platform, for ex: Linux";
        internal const string IotHostHubHelpMessage = "Hosthub address";
        internal const string IotDeviceAccessKeyHelpMessage = "Iot Device Access Key";
        internal const string IotEdgeDeviceId = "Id of the Iot Edge Device";
        internal const string IotDeviceIdHelpMessage = "Device Id of the Iot Device";
        internal const string IotEdgeDeviceAccessKeyHelpMessage = "Access key of the Iot Edge device";
        internal const string ShouldBeFromSameHostHub = "Connection strings must come from same Iot Hosthub";
        internal const string InvalidRoleType = "Invalid Role Type";
        internal const string ShareName = "Share(s) in a role";
        internal const string RoleStatusEnabled = "Enabled";
        internal const string RoleStatusDisabled = "Disabled";


        //Aliases
        internal const string NameAlias = "RoleName";
        internal const string InputObjectAlias = "Role";

    }
}