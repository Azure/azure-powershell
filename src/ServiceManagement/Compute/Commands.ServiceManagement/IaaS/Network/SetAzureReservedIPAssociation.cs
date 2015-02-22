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

using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.WindowsAzure.Management.Network;
using System.Net;
using System.Net.Security;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Set, ReservedIPConstants.AssociationCmdletNoun), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureReservedIPAssociationCmdlet : ServiceManagementBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "Reserved IP Name.")]
        [ValidateNotNullOrEmpty]
        public string ReservedIPName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "Hosted Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Name.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
            delegate
            {
                return true;
            });
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () =>
                {
                    var parameters = new NetworkReservedIPMobilityParameters
                    {
                        ServiceName = this.ServiceName,
                        DeploymentName = this.DeploymentName
                    };

                    return this.NetworkClient.ReservedIPs.Associate(this.ReservedIPName, parameters);
                });
        }
    }
}
