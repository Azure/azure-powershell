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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance DMS Project.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationProject", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSProject))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsProject")]
    public class NewProjectCmdlet : DataMigrationCmdlet
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
            HelpMessage = "Azure Database Migration Service (classic) Resource Id.")]
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
            HelpMessage = "Azure Database Migration Service (classic) Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the instance of the Azure Database Migration Service (classic)")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        [Alias("ProjectName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Source platform type for project.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SQL")]
        public string SourceType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Target platform type for project.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SQLDB", "SQLMI")]
        public string TargetType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source Connection Info.")]
        [ValidateNotNullOrEmpty]
        public ConnectionInfo SourceConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Target Connection Info.")]
        [ValidateNotNullOrEmpty]
        public ConnectionInfo TargetConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Database Infos.")]
        [ValidateNotNullOrEmpty]
        public DatabaseInfo[] DatabaseInfo { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.createProject))
            {
                base.ExecuteCmdlet();

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

                WriteObject(new PSProject(CreateProject()));
            }
        }

        private Project CreateProject()
        {
            Project response = null;

            try
            {
                Project param = new Project();
                if (MyInvocation.BoundParameters.ContainsKey("DatabaseInfo"))
                {
                    param.DatabasesInfo = DatabaseInfo.ToList();
                }
                param.SourceConnectionInfo = SourceConnection as ConnectionInfo;
                param.TargetConnectionInfo = TargetConnection as ConnectionInfo;
                param.SourcePlatform = SourceType;
                param.TargetPlatform = TargetType;
                param.Location = Location;

                response = DataMigrationClient.Projects.CreateOrUpdate(ResourceGroupName, ServiceName, Name, param);
            }
            catch (ApiErrorException ex)
            {
                ThrowAppropriateException(ex);
            }

            return response;
        }
    }
}
