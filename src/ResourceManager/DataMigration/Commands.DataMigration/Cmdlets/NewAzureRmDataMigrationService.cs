// <copyright file="NewAzureRmDataMigrationService.cs" company="Microsoft">Copyright (c) Microsoft Corporation.</copyright>

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Commands.DataMigration;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of the Data Migration Service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationService", SupportsShouldProcess = true), OutputType(typeof(PSDataMigrationService))]
    [Alias("New-AzureRmDms")]
    public sealed class NewAzureRmDataMigrationService : DataMigrationCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Data Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the instance of the Data Migration Service to be created. "
                          + "This corresponds to an Azure region.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SKU for DataMigration service instance, possible values are Basic_1vCore, Basic_2vCores, GeneralPurpose_4vCores"
        )]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the subnet under the specified virtual network to be used for the Data Migration Service instance.")]
        [ValidateNotNullOrEmpty]
        public string VirtualSubnetId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, Resources.createService))
            {
                // Write object in PowerShell
                WriteObject(new PSDataMigrationService(CreateService()));
            }
        }

        /// <summary>
        /// Helper method that calls the creation of an instance of the Data Migration Service
        /// </summary>
        /// <returns>The instance of PSDataMigrationService that was created.</returns>
        public DataMigrationService CreateService()
        {
            // Get the virtual subnet id from the network and the subnet name
            // string vnetId = GetVirtualSubnetId(SubnetName);

            // Create Sku 
            ServiceSku sku = new ServiceSku()
            {
                Name = Sku
            };

            // Create a DMS model
            DataMigrationService serviceParams = new DataMigrationService();
            serviceParams.Location = Location;
            serviceParams.Sku = sku;
            serviceParams.VirtualSubnetId = VirtualSubnetId;

            DataMigrationService response = null;
            try
            {
                response = DataMigrationClient.Services.CreateOrUpdate(serviceParams, ResourceGroupName, Name);
            }
            catch (ApiErrorException ex)
            {
                ThrowAppropriateException(ex);
            }

            return response;
        }
    }
}