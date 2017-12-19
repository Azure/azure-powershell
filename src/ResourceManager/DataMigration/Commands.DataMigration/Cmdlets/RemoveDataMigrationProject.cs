// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveDataMigrationProject.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataMigrationProject", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    [Alias("Remove-AzureRmDmsProject")]
    public class RemoveDataMigrationProject : DataMigrationCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "PSProject Object.")]
        [ValidateNotNull]
        [Alias("Project")]
        public PSProject InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Project Resource Id.")]
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
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        [Alias("ProjectName")]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "Delete any running task")]
        public SwitchParameter DeleteRunningTask { get; set; }

        [Parameter(HelpMessage = "Returns an true/false. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                string.Format(Resources.removingProject, Name),
                Resources.removeProject,
                Name,
                () =>
                {
                    if (this.ParameterSetName.Equals(ComponentObjectParameterSet))
                    {
                        this.ResourceGroupName = InputObject.ResourceGroupName;
                        this.ServiceName = InputObject.ServiceName;
                        this.Name = InputObject.Name;
                    }

                    if (this.ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = ids.ResourceGroupName;
                        this.ServiceName = ids.ServiceName;
                        this.Name = ids.ProjectName;
                    }

                    bool result = false;
                    try
                    {
                        DataMigrationClient.Projects.DeleteWithHttpMessagesAsync(ResourceGroupName, ServiceName, Name, DeleteRunningTask.IsPresent).GetAwaiter().GetResult();
                        result = true;
                    }
                    catch (ApiErrorException ex)
                    {
                        ThrowAppropriateException(ex);
                    }

                    if (PassThru.IsPresent)
                    {
                        WriteObject(result);
                    }
                });
        }
    }
}
