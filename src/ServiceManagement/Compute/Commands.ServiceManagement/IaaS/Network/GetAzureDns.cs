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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.PersistentVMs
{
    [Cmdlet(VerbsCommon.Get, "AzureDns"), OutputType(typeof(DnsServerList))]
    public class GetAzureDnsCommand : PSCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "DnsSettings Returned from Get-AzureDeployment")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public DnsSettings DnsSettings
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            if (DnsSettings != null && DnsSettings.DnsServers != null)
            {
                WriteObject(DnsSettings.DnsServers, true);
            }
        }

        protected override void ProcessRecord()
        {
            ExecuteCommand();
        }
    }
}