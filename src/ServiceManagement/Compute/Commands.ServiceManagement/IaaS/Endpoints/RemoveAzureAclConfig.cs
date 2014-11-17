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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Endpoints
{
    [Cmdlet(VerbsCommon.Remove, "AzureAclConfig"), OutputType(typeof(IPersistentVM))]
    public class RemoveAzureAclConfig : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Endpoint name")]
        public string EndpointName { get; set; }
        
        internal void ExecuteCommand()
        {
            var role = this.VM.GetInstance(); 

            var networkConfiguration = role.ConfigurationSets.OfType<NetworkConfigurationSet>().SingleOrDefault();

            if (networkConfiguration != null
                && networkConfiguration.InputEndpoints != null)
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
                 
                endpoint.EndpointAccessControlList = null;
            }

            this.WriteObject(this.VM);
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                this.ExecuteCommand();
            }
            catch (Exception ex)
            {
                this.WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }
}
