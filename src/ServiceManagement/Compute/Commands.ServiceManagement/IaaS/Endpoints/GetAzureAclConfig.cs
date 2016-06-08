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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Endpoints
{
    [Cmdlet(VerbsCommon.Get, "AzureAclConfig"), OutputType(typeof(NetworkAclObject))]
    public class GetAzureAclConfig : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "Endpoint name")]
        public string EndpointName { get; set; }

        internal void ExecuteCommand()
        {
            var role = this.VM.GetInstance(); 

            var networkConfiguration = role.ConfigurationSets.OfType<NetworkConfigurationSet>().SingleOrDefault();

            if (networkConfiguration != null 
                && networkConfiguration.InputEndpoints != null)
            {
                if (string.IsNullOrEmpty(this.EndpointName))
                {
                    var ret = new List<NetworkAclObject>();
                    foreach (var endpoint in networkConfiguration.InputEndpoints)
                    {
                        ret.Add(endpoint.EndpointAccessControlList);
                    }

                    this.WriteObject(ret, true);
                }
                else
                {
                    var endpoint = (from e in networkConfiguration.InputEndpoints
                                    where e.Name.Equals(this.EndpointName, StringComparison.InvariantCultureIgnoreCase)
                                    select e).SingleOrDefault();

                    if (endpoint == null)
                    {
                        this.ThrowTerminatingError(
                            new ErrorRecord(
                                    new InvalidOperationException(
                                        string.Format(
                                            CultureInfo.InvariantCulture,
                                            Resources.EndpointCanNotBeFoundInVMConfiguration,
                                            this.EndpointName)),
                                    string.Empty,
                                    ErrorCategory.InvalidData,
                                    null));
                    }

                    NetworkAclObject acl = endpoint.EndpointAccessControlList ?? new NetworkAclObject();
                    this.WriteObject(acl);
                }
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }
}
