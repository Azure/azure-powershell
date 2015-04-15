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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extesnions.CustomScript
{
    public class SetAzureVMCustomScriptExtensionCmdletInfo:CmdletsInfo
    {

        private SetAzureVMCustomScriptExtensionCmdletInfo(PersistentVM vm, string referenceName, string version, bool forceUpdate)
        {
            cmdletName = Utilities.SetAzureVMCustomScriptExtensionCmdletName;
            cmdletParams.Add(new CmdletParam("VM", vm));
            if (!string.IsNullOrEmpty(version))
            {
                cmdletParams.Add(new CmdletParam("Version", version));
            }
            if (!string.IsNullOrEmpty(referenceName))
            {
                cmdletParams.Add(new CmdletParam("ReferenceName", referenceName));
            }
            if (forceUpdate)
            {
                cmdletParams.Add(new CmdletParam("ForceUpdate"));
            }
        }

        private SetAzureVMCustomScriptExtensionCmdletInfo(PersistentVM vm, string run, string argument, string referenceName, string version, bool forceUpdate)
            : this(vm, referenceName, version, forceUpdate)
        {
            if (!string.IsNullOrEmpty(run))
            {
                cmdletParams.Add(new CmdletParam("Run", run));
            }
            if (!string.IsNullOrEmpty(argument))
            {
                cmdletParams.Add(new CmdletParam("Argument", argument));
            }
        }

        // SetCustomScriptExtensionByUrisParamSetName
        public SetAzureVMCustomScriptExtensionCmdletInfo(PersistentVM vm, string referenceName, string version, string[] fileUri, string run, string argument, bool forceUpdate)
            :this(vm, run, argument, referenceName, version, forceUpdate)
        {
            if (fileUri != null)
            {
                cmdletParams.Add(new CmdletParam("FileUri", Utilities.ConvertToJsonArray(fileUri)));
            }
        }

        // DisableCustomScriptExtensionParamSetName
        public SetAzureVMCustomScriptExtensionCmdletInfo(PersistentVM vm, string referenceName, string version, bool disable, bool forceUpdate)
            : this(vm, referenceName, version, forceUpdate)
        {
            if (disable)
            {
                cmdletParams.Add(new CmdletParam("Disable"));
            }
        }

        // SetCustomScriptExtensionByContainerBlobsParamSetName
        public SetAzureVMCustomScriptExtensionCmdletInfo(PersistentVM vm, string[] fileName, string storageAccountName, string storageEndpointSuffix, string containerName,
              string storageAccountKey, string run, string argument, string referenceName, string version, bool forceUpdate)
            : this(vm, run, argument, referenceName, version, forceUpdate)
        {
            if (fileName.Length > 0)
            {
                cmdletParams.Add(new CmdletParam("FileName", fileName));
            }
            if (!string.IsNullOrEmpty(containerName))
            {
                cmdletParams.Add(new CmdletParam("ContainerName", containerName));
            }
            if (!string.IsNullOrEmpty(storageAccountName))
            {
                cmdletParams.Add(new CmdletParam("StorageAccountName", storageAccountName));
            }
            if (!string.IsNullOrEmpty(storageEndpointSuffix))
            {
                cmdletParams.Add(new CmdletParam("StorageEndpointSuffix", storageEndpointSuffix));
            }
            if (!string.IsNullOrEmpty(storageAccountKey))
            {
                cmdletParams.Add(new CmdletParam("StorageAccountKey", storageAccountKey));
            }
        }
    }
}
