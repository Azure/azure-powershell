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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    [Cmdlet(VerbsCommon.New, "AzureDns"), OutputType(typeof(DnsServer))]
    public class NewAzureDnsCommand : Cmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Name of the DNS Server")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "IP Address of the DNS Server")]
        [ValidateNotNullOrEmpty]
        public string IPAddress
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            WriteObject(new DnsServer {Address = IPAddress, Name = Name}, true);
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
