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

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;

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
            HelpMessage = "Database Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the instance of the Database Migration Service to be created. "
                          + "This corresponds to an Azure region.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SKU for DataMigration service instance, possible values are Basic_1vCore, Basic_2vCores, GeneralPurpose_4vCores"
        )]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Basic_1vCore", "Basic_2vCores", "GeneralPurpose_4vCores")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the subnet under the specified virtual network to be used for the Database Migration Service instance.")]
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
        /// Helper method that calls the creation of an instance of the Database Migration Service
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