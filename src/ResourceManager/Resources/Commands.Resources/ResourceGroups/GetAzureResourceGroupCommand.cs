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

using Microsoft.Azure.Commands.Resources.Models;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Filters resource groups.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRMResourceGroup"), OutputType(typeof(List<PSResourceGroup>))]
    public class GetAzureResourceGroupCommand : ResourcesBaseCmdlet
    {
        [Alias("ResourceGroupName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "GetSingle")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultiple")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultiple")]
        public SwitchParameter Detailed { get; set; }
        
        protected override void ProcessRecord()
        {
            if(this.Tag != null)
            {
                WriteWarning("The Tag parameter is being deprecated and will be removed in a future release.");
            }
            if(this.Detailed.IsPresent)
            {
                WriteWarning("The Detailed switch parameter is being deprecated and will be removed in a future release.");
            }
            WriteWarning("The output object of this cmdlet will be modified in a future release.");
            var detailed = Detailed.IsPresent || !string.IsNullOrEmpty(Name);
            WriteObject(ResourcesClient.FilterResourceGroups(Name, Tag, detailed), true);
        }
    }
}