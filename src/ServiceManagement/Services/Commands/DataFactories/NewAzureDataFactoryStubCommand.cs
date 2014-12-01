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

using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.DataFactories
{
    /// <summary>
    /// In order to show warning for ADF cmdlets if client is using service management mode
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureDataFactory")]
    public class NewAzureDataFactoryStubCommand : AzurePSCmdlet
    {
        //Just to make sure there is no error messages for parameters when clients use "New-AzureDataFactory" 
        [Parameter(Mandatory = false)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public string Location { get; set; }

        [Parameter(Mandatory = false)]
        public Hashtable Tags { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            WriteWarning("You must be in AzureResourceManager mode to run Azure Data Factory cmdlets. To switch to AzureResourceManager mode, run Switch-AzureMode AzureResourceManager.");
        }
    }
}
