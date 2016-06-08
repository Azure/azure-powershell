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

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS
{
    internal static class WAPackCmdletParameterSets
    {
        internal const string Empty = "Empty";
        internal const string FromName = "FromName";
        internal const string FromId = "FromId";
        internal const string QuickCreate = "QuickCreate";
        internal const string CreateWindowsVMFromTemplate = "CreateVMFromTemplate";
        internal const string CreateVMFromOSDisks = "CreateVMFromOSDisk";
        internal const string FromVirtualMachineObject = "FromVirtualMachineObject";
        internal const string FromVMRoleObject = "FromVMRoleObject";
        internal const string FromCloudService = "FromCloudService";
        internal const string FromCloudServiceObject = "FromCloudServiceObject";
        internal const string FromVMNetworkObject = "FromVMNetworkObject";
        internal const string FromVMSubnetObject = "FromVMSubnetObject";
        internal const string UpdateVMSizeProfile = "UpdateVMSizeProfile";
        internal const string GetRDPFile = "GetRDPFile";
        internal const string CreateLinuxVMFromTemplate = "CreateLinuxVMFromTemplate";
    }
}
