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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class for the command let that creates a new instance of the Data Migration Service.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationProject", DefaultParameterSetName = ComponentNameParameterSet), OutputType(typeof(PSProject))]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsProject")]
    public class GetProjectCmdlet : DataMigrationCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "PSDataMigrationService Object.")]
        [ValidateNotNull]
        [Alias("DataMigrationService")]
        public PSDataMigrationService InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "DataMigrationService Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the resource group."
                )]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "Database Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        [Alias("ProjectName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ComponentObjectParameterSet))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.ServiceName = InputObject.Name;
            }

            if (this.ParameterSetName.Equals(ResourceIdParameterSet))
            {
                DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = ids.ResourceGroupName;
                this.ServiceName = ids.ServiceName;
            }

            IList<PSProject> results = new List<PSProject>();

            if ((MyInvocation.BoundParameters.ContainsKey("ServiceName") || !string.IsNullOrEmpty(ServiceName))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(ResourceGroupName))
                && (MyInvocation.BoundParameters.ContainsKey("Name") || !string.IsNullOrEmpty(Name)))
            {
                results.Add(new PSProject(DataMigrationClient.Projects.Get(this.ResourceGroupName, this.ServiceName, this.Name)));
            }
            else if ((MyInvocation.BoundParameters.ContainsKey("ServiceName") || !string.IsNullOrEmpty(ServiceName))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(ResourceGroupName)))
            {
                DataMigrationClient.Projects.EnumerateProjects(ResourceGroupName, ServiceName)
                    .ForEach(item =>
                    {
                        results.Add(new PSProject(item));
                    });
            }
            else
            {
                throw new PSArgumentException("When specifying the ServiceName parameter the ResourceGroup parameter must also be used");
            }

            WriteObject(results, true);
        }
    }
}
