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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Get, "AzureWinRMUri"), OutputType(typeof(Uri), typeof(List<Uri>))]
    public class GetAzureWinRMUri : IaaSDeploymentManagementCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the virtual machine to get.")]
        public string Name
        {
            get;
            set;
        }

        protected override void ExecuteCommand()
        {
            base.ExecuteCommand();
            ExecuteCommandBody();
        }

        public void ExecuteCommandBody()
        {
            if (CurrentDeploymentNewSM == null)
            {
                return;
            }

            if (CurrentDeploymentNewSM.Uri == null)
            {
                throw new ArgumentOutOfRangeException(Resources.CurrentDeploymentDoesNotHaveUrl);
            }
            if (CurrentDeploymentNewSM.RoleInstances == null)
            {
                throw new ArgumentOutOfRangeException(Resources.CurrentDeploymentDoesNotHaveVMs);
            }

            if (String.IsNullOrEmpty(Name))
            {
                var result = CurrentDeploymentNewSM.RoleInstances.Select(GetUri).Where(uri => uri != null).ToList();
                if(!result.Any())
                {
                    return;
                }
                WriteObject(result, true);
            }
            else
            {
                var roleInstance =
                    CurrentDeploymentNewSM.RoleInstances.Where(r => r.RoleName != null).FirstOrDefault(
                        r => r.RoleName.Equals(Name, StringComparison.InvariantCultureIgnoreCase));

                if (roleInstance == null)
                {
                    throw new ArgumentOutOfRangeException(String.Format(Resources.RoleInstanceCanNotBeFoundWithName, Name));
                }

                var uri = GetUri(roleInstance);
                WriteObject(uri, true);
            }
        }

        private Uri GetUri(RoleInstance roleInstance)
        {
            if (roleInstance == null)
            {
                throw new ArgumentOutOfRangeException(Resources.RoleInstanceCanNotBeFound);
            }
            
            if (roleInstance.InstanceEndpoints == null)
            {
                throw new ArgumentOutOfRangeException(string.Format(Resources.NoEndpointFoundForVM, roleInstance.RoleName));
            }
            var winRmEndPoint = roleInstance.InstanceEndpoints.FirstOrDefault(i => i.LocalPort == WinRMConstants.HttpsListenerPort);
            if (winRmEndPoint == null)
            {
                return null;
            }

            var builder = new UriBuilder(CurrentDeploymentNewSM.Uri)
            {
                Port = winRmEndPoint.Port,
                Scheme = "https"
            };
            var uri = builder.Uri;
            return uri;
        }
    }
}