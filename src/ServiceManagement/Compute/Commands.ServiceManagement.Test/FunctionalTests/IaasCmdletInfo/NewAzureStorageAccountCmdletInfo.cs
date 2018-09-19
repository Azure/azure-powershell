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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class NewAzureStorageAccountCmdletInfo : CmdletsInfo
    {
        public NewAzureStorageAccountCmdletInfo(string storageAccountName, string location, string affinity, string label, string description, string accountType)
        {
            this.cmdletName = Utilities.NewAzureStorageAccountCmdletName;

            this.cmdletParams.Add(new CmdletParam("StorageAccountName", storageAccountName));
            if (location != null)
            {
                this.cmdletParams.Add(new CmdletParam("Location", location));
            }
            if (affinity != null)
            {
                this.cmdletParams.Add(new CmdletParam("AffinityGroup", affinity));
            }
            if (label != null)
            {
                this.cmdletParams.Add(new CmdletParam("Label", label));
            }
            if (description != null)
            {
                this.cmdletParams.Add(new CmdletParam("Description", description));
            }

            if (!string.IsNullOrEmpty(accountType))
            {
                this.cmdletParams.Add(new CmdletParam("Type", accountType));
            }
        }
    }
}
