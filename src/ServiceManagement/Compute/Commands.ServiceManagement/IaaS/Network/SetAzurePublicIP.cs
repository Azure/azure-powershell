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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Set, PublicIPNoun), OutputType(typeof(IPersistentVM))]
    public class SetAzurePublicIPCommand : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The Public IP Name.")]
        [ValidateNotNullOrEmpty]
        public string PublicIPName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Idle Timeout.")]
        [ValidateNotNullOrEmpty]
        public int? IdleTimeoutInMinutes { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "DNS name.")]
        [ValidateNotNullOrEmpty]
        public string DomainNameLabel { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var networkConfiguration = GetNetworkConfiguration();
            if (networkConfiguration == null)
            {
                throw new ArgumentOutOfRangeException(Resources.NetworkConfigurationNotFoundOnPersistentVM);
            }

            if (networkConfiguration.PublicIPs == null)
            {
                networkConfiguration.PublicIPs = new AssignPublicIPCollection();
            }
            
            if (networkConfiguration.PublicIPs.Any())
            {
                networkConfiguration.PublicIPs.First().Name = this.PublicIPName;
                if (this.ParameterSpecified("IdleTimeoutInMinutes"))
                {
                    networkConfiguration.PublicIPs.First().IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
                }

                if (this.ParameterSpecified("DomainNameLabel"))
                {
                    networkConfiguration.PublicIPs.First().DomainNameLabel = this.DomainNameLabel;
                }
                else
                {
                    networkConfiguration.PublicIPs.First().DomainNameLabel = null;
                }
            }
            else
            {
                networkConfiguration.PublicIPs.Add(
                    new AssignPublicIP
                    {
                        Name = this.PublicIPName,
                        IdleTimeoutInMinutes = this.ParameterSpecified("IdleTimeoutInMinutes") ? this.IdleTimeoutInMinutes : null,
                        DomainNameLabel = this.ParameterSpecified("DomainNameLabel") ? this.DomainNameLabel : null,
                    });
            }

            WriteObject(VM);
        }
        
        private bool ParameterSpecified(string parameterName)
        {
            // Check for parameters by name so we can tell the difference between 
            // the user not specifying them, and the user specifying null/empty.
            return this.MyInvocation.BoundParameters.ContainsKey(parameterName);
        }
    }
}
