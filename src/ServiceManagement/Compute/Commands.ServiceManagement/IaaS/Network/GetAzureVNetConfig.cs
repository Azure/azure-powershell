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
using System.IO;
using System.Management.Automation;
using System.Net;
using Hyak.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Get, "AzureVNetConfig"), OutputType(typeof(VirtualNetworkConfigContext))]
    public class GetAzureVNetConfigCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(HelpMessage = "The file path to save the network configuration to.")]
        [ValidateNotNullOrEmpty]
        public string ExportToFile
        {
            get;
            set;
        }

        public VirtualNetworkConfigContext GetVirtualNetworkConfigProcess()
        {
            this.ValidateParameters();

            VirtualNetworkConfigContext result = null;

            InvokeInOperationContext(() =>
            {
                try
                {
                    WriteVerboseWithTimestamp(string.Format(Resources.AzureVNetConfigBeginOperation, CommandRuntime.ToString()));

                    var netcfg = this.NetworkClient.Networks.GetConfiguration();
                    var operation = GetOperation(netcfg.RequestId);

                    WriteVerboseWithTimestamp(string.Format(Resources.AzureVNetConfigCompletedOperation, CommandRuntime.ToString()));

                    if (netcfg != null)
                    {
                        // TODO: might want to change this to an XML object of some kind...
                        var xml = netcfg.Configuration;

                        var networkConfig = new VirtualNetworkConfigContext
                        {
                            XMLConfiguration = xml,
                            OperationId = operation.Id,
                            OperationDescription = CommandRuntime.ToString(),
                            OperationStatus = operation.Status.ToString()
                        };

                        if (!string.IsNullOrEmpty(this.ExportToFile))
                        {
                            networkConfig.ExportToFile(this.ExportToFile);
                        }

                        result = networkConfig;
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Response.StatusCode == HttpStatusCode.NotFound && !IsVerbose())
                    {
                        result = null;
                    }
                    else
                    {
                        WriteExceptionError(ex);
                    }
                }
            });

            return result;
        }

        protected override void OnProcessRecord()
        {
            var networkConfig = this.GetVirtualNetworkConfigProcess();

            if (networkConfig != null)
            {
                WriteObject(networkConfig, true);
            }
        }

        private void ValidateParameters()
        {
            if (!string.IsNullOrEmpty(this.ExportToFile) && !Directory.Exists(Path.GetDirectoryName(this.ExportToFile)))
            {
                throw new ArgumentException(Resources.NetworkConfigurationDirectoryDoesNotExist);
            }
        }
    }
}