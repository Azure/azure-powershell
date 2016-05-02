// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    using System;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;

    [Cmdlet(VerbsCommon.Reset, "AzureRmServerManagementGatewayProfile")]
    public class ResetServerManagementGatewayProfileCmdlet : ServerManagementGatewayProfileCmdlet
    {
        // tells the service to regenerate the profile for a gateway

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteVerbose(string.Format("Regenerating profile for {0}/{1}", ResourceGroupName, GatewayName));
            Client.Gateway.RegenerateProfile(ResourceGroupName, GatewayName);
            WriteVerbose(string.Format("Successfully regenerated profile for {0}/{1}", ResourceGroupName, GatewayName));
        }
    }
}