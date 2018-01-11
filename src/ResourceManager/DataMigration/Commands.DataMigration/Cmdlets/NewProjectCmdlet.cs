// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewProjectCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance DMS Project.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationProject", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSProject))]
    [Alias("New-AzureRmDmsProject")]
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
            HelpMessage = "Data Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the instance of the Data Migration Service")]
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
        public ProjectSourcePlatform SourceType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Target platform type for project.")]
        [ValidateNotNullOrEmpty]
        public ProjectTargetPlatform TargetType { get; set; }

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
                param.SourceConnectionInfo = SourceConnection;
                param.TargetConnectionInfo = TargetConnection;
                param.SourcePlatform = SourceType;
                param.TargetPlatform = TargetType;
                param.Location = Location;

                response = DataMigrationClient.Projects.CreateOrUpdate(param, ResourceGroupName, ServiceName, Name);
            }
            catch (ApiErrorException ex)
            {
                ThrowAppropriateException(ex);
            }

            return response;
        }
    }
}
