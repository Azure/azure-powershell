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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.New, "AzureSSHKey"), OutputType(typeof(LinuxProvisioningConfigurationSet.SSHKeyPair), typeof(LinuxProvisioningConfigurationSet.SSHPublicKey))]
    public class NewAzureSSHKeyCommand : Cmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "keypair", HelpMessage = "Add a key pair")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter KeyPair
        {
            get;
            set;
        }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "publickey", HelpMessage = "Add a public")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter PublicKey
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Fingerprint of the SSH Key Pair")]
        [ValidateNotNullOrEmpty]
        public string Fingerprint
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "Path of the SSH Key Pair")]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            if (KeyPair.IsPresent)
            {
                var keypair = new LinuxProvisioningConfigurationSet.SSHKeyPair {Fingerprint = Fingerprint, Path = Path};
                WriteObject(keypair, true);
            }
            else
            {
                var keypair = new LinuxProvisioningConfigurationSet.SSHPublicKey {Fingerprint = Fingerprint, Path = Path};
                WriteObject(keypair, true);
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
