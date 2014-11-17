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
    public class SelectAzureSubscriptionCmdletInfo : CmdletsInfo
    {
        public SelectAzureSubscriptionCmdletInfo(string subscriptionName)
        {
            cmdletName = "Select-AzureSubscription";
            cmdletParams.Add(new CmdletParam("SubscriptionName", subscriptionName));
            cmdletParams.Add(new CmdletParam("Default"));
        }

        public SelectAzureSubscriptionCmdletInfo(string subscriptionName, bool isDefault, bool clear, string subscriptionDataFile)
        {
            cmdletName = "Select-AzureSubscription";
            cmdletParams.Add(new CmdletParam("SubscriptionName", subscriptionName));
            if (isDefault)
            {
                cmdletParams.Add(new CmdletParam("Default"));
            }
            if (clear)
            {
                cmdletParams.Add(new CmdletParam("Clear"));
            }
            if (subscriptionDataFile != null)
            {
                cmdletParams.Add(new CmdletParam("SubscriptionDataFile", subscriptionDataFile));
            }
        }
    }
}