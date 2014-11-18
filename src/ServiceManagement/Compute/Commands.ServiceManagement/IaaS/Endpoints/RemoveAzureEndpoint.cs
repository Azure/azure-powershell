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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Endpoints
{
    [Cmdlet(VerbsCommon.Remove, "AzureEndpoint"), OutputType(typeof(IPersistentVM))]
    public class RemoveAzureInputEndpointCommand : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Endpoint Name")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            var endpoints = GetInputEndpoints();
            var endpoint = endpoints.SingleOrDefault(ep => String.Compare(ep.Name, Name, StringComparison.OrdinalIgnoreCase) == 0);
            if (endpoint == null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.EndpointCanNotBeFoundInVMConfiguration, Name)),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
            }

            endpoints.Remove(endpoint);

            WriteObject(VM, true);
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

        protected Collection<InputEndpoint> GetInputEndpoints()
        {
            var role = VM.GetInstance();

            var networkConfiguration = role.ConfigurationSets
                                        .OfType<NetworkConfigurationSet>()
                                        .SingleOrDefault();

            if (networkConfiguration == null)
            {
                networkConfiguration = new NetworkConfigurationSet();
                role.ConfigurationSets.Add(networkConfiguration);
            }

            if (networkConfiguration.InputEndpoints == null)
            {
                networkConfiguration.InputEndpoints = new Collection<InputEndpoint>();
            }

            var inputEndpoints = networkConfiguration.InputEndpoints;

            return inputEndpoints;
        }
    }
}
