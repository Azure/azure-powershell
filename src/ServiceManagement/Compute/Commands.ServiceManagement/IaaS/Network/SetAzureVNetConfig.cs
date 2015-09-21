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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Set, "AzureVNetConfig"), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureVNetConfigCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Path to the Network Configuration file (.xml).")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationPath
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            ValidateParameters();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(this.ConfigurationPath);

                var netParams = new NetworkSetConfigurationParameters
                {
                    Configuration = sr.ReadToEnd()
                };

                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.NetworkClient.Networks.SetConfiguration(netParams));
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.ExecuteCommand();
        }

        private void ValidateParameters()
        {
            if (!File.Exists(ConfigurationPath))
            {
                throw new ArgumentException(Resources.NetworkConfigurationFilePathDoesNotExist);
            }
        }
    }
}
