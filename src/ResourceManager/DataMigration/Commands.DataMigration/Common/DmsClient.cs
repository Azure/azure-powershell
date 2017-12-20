// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DmsClient.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.DataMigration;

namespace Microsoft.Azure.Commands.DataMigration.Common
{
    public partial class DmsClient
    {

        public IDataMigrationServiceClient DataMigrationServiceClient { get; set; }


        public DmsClient(IAzureContext context)
                : this(AzureSession.Instance.ClientFactory.CreateArmClient<DataMigrationServiceClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public DmsClient(IDataMigrationServiceClient dmsClient)
        {
            this.DataMigrationServiceClient = dmsClient;
        }
    }
}
