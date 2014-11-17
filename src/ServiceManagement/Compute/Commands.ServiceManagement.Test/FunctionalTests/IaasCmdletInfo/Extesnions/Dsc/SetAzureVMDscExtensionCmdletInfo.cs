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

using System.Collections;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extesnions.Dsc
{
    public class SetAzureVMDscExtensionCmdletInfo: CmdletsInfo
    {
        public SetAzureVMDscExtensionCmdletInfo(
            string              version,
            IPersistentVM       vm,
            string              configurationArchive,
            AzureStorageContext storageContext = null,
            string              containerName = null,
            string              configurationName = null,
            Hashtable           configurationArgument = null,
            string              configurationDataPath = null
        ) 
        {
            cmdletName = Utilities.SetAzureVMDscExtensionCmdletName;

            cmdletParams.AddRange(
                new CmdletParam [] {
                    new CmdletParam("Version", version),
                    new CmdletParam("VM", vm),
                    new CmdletParam("ConfigurationArchive", configurationArchive),
                });

            if (storageContext != null)
            {
                cmdletParams.Add(new CmdletParam("StorageContext", storageContext));
            }
            if (containerName != null)
            {
                cmdletParams.Add(new CmdletParam("ContainerName", containerName));
            }
            if (configurationName != null)
            {
                cmdletParams.Add(new CmdletParam("ConfigurationName", configurationName));
            }
            if (configurationArgument != null)
            {
                cmdletParams.Add(new CmdletParam("ConfigurationArgument", configurationArgument));
            }
            if (configurationDataPath != null)
            {
                cmdletParams.Add(new CmdletParam("ConfigurationDataPath", configurationDataPath));
            }
        }
    }
}
