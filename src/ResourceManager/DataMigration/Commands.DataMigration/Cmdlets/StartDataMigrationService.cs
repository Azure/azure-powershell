// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartDataMigrationService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Commands.DataMigration.Common;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "AzureRmDataMigrationService", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Start-AzureRmDmsService")]
    public class StartDataMigrationService :DataMigrationCmdlet
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
        [Alias("ServiceName")]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Returns an true/false. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.startService))
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
                    DataMigrationClient.Services.StartWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult();
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
            }
        }
    }
}
