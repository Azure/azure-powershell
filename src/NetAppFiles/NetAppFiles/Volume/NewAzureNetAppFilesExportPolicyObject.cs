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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NetAppFiles.Volume
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesExportPolicyObject", SupportsShouldProcess = true), OutputType(typeof(PSNetAppFilesVolumeExportPolicy))]
    public class NewAzureNetAppFilesExportPolicyObject : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "List of items which need to be included into endpont scope.",
             ParameterSetName = "ExportPolicyObject")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesExportPolicyRule[] Rule { get; set; }

        public override void ExecuteCmdlet()
        {
            PSNetAppFilesVolumeExportPolicy exportPolicyItem = new PSNetAppFilesVolumeExportPolicy();
            if(Rule != null)
            {
                exportPolicyItem.Rules = Rule;
            }
            WriteObject(exportPolicyItem);
        }
    }
}
