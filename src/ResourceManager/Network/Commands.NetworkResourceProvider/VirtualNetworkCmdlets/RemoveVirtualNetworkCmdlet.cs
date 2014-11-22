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

using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.WindowsAzure;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
     [Cmdlet(VerbsCommon.Remove, VirtualNetworkCmdletName)]
    public class RemoveVirtualNetworkCmdlet : VirtualNetworkBaseClient
    {

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Execute the Delete VirtualNetwork call
            var vnetDeleteResponse = this.VirtualNetworkClient.Delete(this.ResourceGroupName, this.Name);

            WriteObject(vnetDeleteResponse);
        }
    }
}
