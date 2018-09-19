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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.SubscriptionCmdletInfo
{
    public class GetAzureSubscriptionCmdletInfo : CmdletsInfo
    {
        public GetAzureSubscriptionCmdletInfo(string subscriptionId, bool currentSubscription, bool defaultSubscription, bool extendedDetails)
        {
            cmdletName = Utilities.GetAzureSubscriptionCmdletName;

            if (!string.IsNullOrEmpty(subscriptionId))
            {
                this.cmdletParams.Add(new CmdletParam("SubscriptionId", subscriptionId));
            }
            if (currentSubscription)
            {
                this.cmdletParams.Add(new CmdletParam("Current"));
            }
            if (defaultSubscription)
            {
                this.cmdletParams.Add(new CmdletParam("Default"));
            }
            if (extendedDetails)
            {
                this.cmdletParams.Add(new CmdletParam("ExtendedDetails"));
            }
        }
    }
}
