﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Origin;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;

namespace Microsoft.Azure.Commands.Cdn.Origin
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnOrigin"), OutputType(typeof(PSOrigin))]
    public class SetAzureRmCdnOrigin : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN origin object.")]
        [ValidateNotNull]
        public PSOrigin CdnOrigin { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(MyInvocation.InvocationName,
               string.Format("{0} ({1})", CdnOrigin.Name, CdnOrigin.HostName),
               SetOrigin);
        }

        private void SetOrigin()
        {
            var origin = CdnManagementClient.Origins.Update(
                CdnOrigin.ResourceGroupName,
                CdnOrigin.ProfileName,
                CdnOrigin.EndpointName,
                CdnOrigin.Name,
                new OriginUpdateParameters(
                    hostName: CdnOrigin.HostName,
                    httpPort: CdnOrigin.HttpPort,
                    httpsPort: CdnOrigin.HttpsPort));

            WriteVerbose(Resources.Success);
            WriteObject(origin.ToPsOrigin());
        }
    }
}
