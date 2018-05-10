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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Cmdlet for getting Data Migration Service resource
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmDataMigrationService", DefaultParameterSetName = ResourceGroupSet), OutputType(typeof(IList<PSDataMigrationService>))]
    [Alias("Get-AzureRmDms")]
    public class GetAzureDataMigrationService : DataMigrationCmdlet
    {
        private const string ResourceGroupSet = "ResourceGroupSet";
        private const string ServiceNameGroupSet = "ServiceNameGroupSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "DataMigrationService Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ServiceNameGroupSet,
            HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = ResourceGroupSet, Mandatory = false)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the data migration service.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ServiceNameGroupSet,
            HelpMessage = "Name of Database Migration Service.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ResourceIdParameterSet))
            {
                DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = ids.ResourceGroupName;
                this.Name = ids.ServiceName;
            }

            IList<PSDataMigrationService> results = new List<PSDataMigrationService>();

            if ((MyInvocation.BoundParameters.ContainsKey("Name") || !string.IsNullOrEmpty(Name))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(ResourceGroupName)))
            {
                results.Add(new PSDataMigrationService(DataMigrationClient.Services.Get(this.ResourceGroupName, this.Name)));
            }
            else if (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(ResourceGroupName))
            {
                DataMigrationClient.Services.EnumerateServicesByResouceGroup(ResourceGroupName)
                    .ForEach(item =>
                    {
                        results.Add(new PSDataMigrationService(item));
                    });
            }
            else if (!MyInvocation.BoundParameters.ContainsKey("Name") || string.IsNullOrEmpty(Name))
            {
                DataMigrationClient.Services.EnumerateServicesBySubcription()
                     .ForEach(item =>
                     {
                         results.Add(new PSDataMigrationService(item));
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
