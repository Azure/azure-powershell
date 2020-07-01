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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Management.Automation;
using System.Security;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RadiusServer", DefaultParameterSetName = "RadiusServer"), OutputType(typeof(PSRadiusServer))]
    public class NewAzRadiusServerCommand : NetworkBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "RadiusServer",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "External radius server address")]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            ParameterSetName = "RadiusServer",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "External radius server secret")]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            ParameterSetName = "RadiusServer",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "External radius server score")]
        public int RadiusServerScore { get; set; }

        public override void Execute()
        {
            base.Execute();
            var radiusServer = new PSRadiusServer();

            radiusServer.RadiusServerAddress = this.RadiusServerAddress;
            radiusServer.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);

            // default score value
            radiusServer.RadiusServerScore = (!this.MyInvocation.BoundParameters.ContainsKey("RadiusServerScore")) ? 30 : this.RadiusServerScore;

            WriteObject(radiusServer);
        }
    }
}
