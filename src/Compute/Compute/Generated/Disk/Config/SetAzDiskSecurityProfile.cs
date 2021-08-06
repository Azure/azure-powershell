﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskSecurityProfile", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDisk))]
    public class SetAzDiskSecurityProfile : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Alias("DiskSecurityProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disk Security Profile")]
        [ValidateNotNullOrEmpty]
        public PSDisk Disk { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets possible values include: TrustedLaunch")]
        [PSArgumentCompleter("TrustedLaunch")]
        public string SecurityType { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("DiskSecurityProfile", "Set"))
            {
                Run();
            }
        }

        private void Run()
        {
            if(this.Disk.SecurityProfile == null)
            {
                this.Disk.SecurityProfile = new DiskSecurityProfile();
            }

            this.Disk.SecurityProfile.SecurityType = SecurityType;

            WriteObject(this.Disk);
        }
    }

}