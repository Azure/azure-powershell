// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveDataMigrationService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataMigrationService", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    [Alias("Remove-AzureRmDms")]
    public class RemoveDataMigrationService : DataMigrationCmdlet
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
            HelpMessage = "The name of the Data Migration Service.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
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
                string.Format(Resources.removeService, Name),
                Resources.removeService,
                Name,
                () =>
                {
                    if (this.ParameterSetName.Equals(ComponentObjectParameterSet))
                    {
                        this.ResourceGroupName = InputObject.ResourceGroupName;
                        this.Name = InputObject.Name;
                    }

                    if (this.ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = ids.ResourceGroupName;
                        this.Name = ids.ServiceName;
                    }

                    bool result = false;
                    try
                    {
                        DataMigrationClient.Services.DeleteWithHttpMessagesAsync(ResourceGroupName, Name, DeleteRunningTask.IsPresent).GetAwaiter().GetResult();
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
