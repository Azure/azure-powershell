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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayIPConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the application gateway IP configuration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "ID of subnet where application gateway gets its address from")]
        [ValidateNotNullOrEmpty]
        public string Subnet { get; set; }
        
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();            
        }
    }
}
