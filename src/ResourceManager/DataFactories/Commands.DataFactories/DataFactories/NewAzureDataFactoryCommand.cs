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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.New, Constants.DataFactory, SupportsShouldProcess = true), 
        OutputType(typeof(PSDataFactory))]
    public class NewAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The geographic region to create the data factory.")]
        [LocationCompleter("Microsoft.DataFactory/datafactories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The tags of the data factory.")]
        [Obsolete("New-AzureRmDataFactory: -Tags will be removed in favor of -Tag in an upcoming breaking change release.  Please start using the -Tag parameter to avoid breaking scripts.")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
#pragma warning disable CS0618
            CreatePSDataFactoryParameters parameters = new CreatePSDataFactoryParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = Name,
                Location = Location,
                Tags = Tag,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };
#pragma warning restore CS0618

            WriteObject(DataFactoryClient.CreatePSDataFactory(parameters));
        }
    }
}