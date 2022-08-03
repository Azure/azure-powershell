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

using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NetAppFiles.Volume
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesExportPolicyRuleObject", SupportsShouldProcess = true), OutputType(typeof(PSNetAppFilesExportPolicyRule))]
    public class NewAzureNetAppFilesExportPolicyRuleObject : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Order index.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public int RuleIndex { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Read only access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UnixReadOnly { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Read and write access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UnixReadWrite { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Kerberos5 Read only access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Kerberos5ReadOnly { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Kerberos5 Read and write access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Kerberos5ReadWrite { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Kerberos5i Read only access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Kerberos5iReadOnly { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Kerberos5i Read and write access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Kerberos5iReadWrite { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Kerberos5p Read only access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Kerberos5p { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Kerberos5p Read and write access.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Kerberos5pReadWrite { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allows CIFS protocol.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Cifs { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allows NFSv3 protocol.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Nfsv3 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allows NFSv41 protocol.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Nfsv41 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Client ingress specification as comma separated string with IPv4 CIDRs, IPv4 host addresses and host names.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public string AllowedClient { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Has root access to volume.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter HasRootAccess { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies who is authorized to change the ownership of a file. restricted - Only root user can change the ownership of the file. unrestricted - Non-root users can change ownership of files that they own.",
             ParameterSetName = "ExportPolicyRule")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Restricted", "Unrestricted")]
        public string ChownMode { get; set; }


        public override void ExecuteCmdlet()
        {
            PSNetAppFilesExportPolicyRule exportPolicyRuleItem = new PSNetAppFilesExportPolicyRule()
            {
                RuleIndex = RuleIndex,
                UnixReadOnly = UnixReadOnly,
                UnixReadWrite = UnixReadWrite,
                Kerberos5ReadOnly = Kerberos5ReadOnly,
                Kerberos5ReadWrite = Kerberos5ReadWrite,
                Kerberos5iReadOnly = Kerberos5ReadOnly,
                Kerberos5iReadWrite = Kerberos5ReadWrite,
                Kerberos5pReadOnly = Kerberos5ReadOnly,
                Kerberos5pReadWrite = Kerberos5ReadWrite,
                Nfsv3 = Nfsv3,
                Nfsv41 = Nfsv41,
                Cifs = Cifs,
                HasRootAccess = HasRootAccess,
                AllowedClients = AllowedClient,
                ChownMode = ChownMode
            };
            WriteObject(exportPolicyRuleItem);
        }
    }
}
