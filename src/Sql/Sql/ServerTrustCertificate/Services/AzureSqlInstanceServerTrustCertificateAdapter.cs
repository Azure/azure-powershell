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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Services
{
    /// <summary>
    /// Adapter for ServerTrustCertificate operations
    /// </summary>
    public class AzureSqlInstanceServerTrustCertificateAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlInstanceServerTrustCertificateCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlInstanceServerTrustCertificateCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a ServerTrustCertificate adapter
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlInstanceServerTrustCertificateAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlInstanceServerTrustCertificateCommunicator(Context);
        }

        /// <summary>
        /// Gets a server trust certificate in a managed instance
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="instanceName">The name of the managed instance</param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <returns>The managed instance</returns>
        public AzureSqlInstanceServerTrustCertificateModel GetServerTrustCertificate(string resourceGroupName, string instanceName, string certificateName)
        {
            var resp = Communicator.Get(resourceGroupName, instanceName, certificateName);
            return CreateServerTrustCertificateModelFromResponse(resourceGroupName, instanceName, resp);
        }

        /// <summary>
        /// Gets a list of all server trust certificates in managed instance
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="instanceName"></param>
        /// <returns>A list of all the server trust certificates</returns>
        public List<AzureSqlInstanceServerTrustCertificateModel> ListServerTrustCertificates(string resourceGroupName, string instanceName)
        {
            var resp = Communicator.List(resourceGroupName, instanceName);

            return resp.Select((cert) => CreateServerTrustCertificateModelFromResponse(resourceGroupName, instanceName, cert)).ToList();
        }

        /// <summary>
        /// Upserts a Server Trust Certificate to Azure SQL Managed Instance
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database ElasticPool</returns>
        internal AzureSqlInstanceServerTrustCertificateModel UpsertServerTrustCertificate(AzureSqlInstanceServerTrustCertificateModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.InstanceName, model.Name, new Management.Sql.Models.ServerTrustCertificate
            {
                PublicBlob = model.PublicKey,
            });

            return CreateServerTrustCertificateModelFromResponse(model.ResourceGroupName, model.InstanceName, resp);
        }

        /// <summary>
        /// Deletes a server trust certificate
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="instanceName">The name of the managed instance</param>
        /// <param name="certificateName">The name of the certificate to delete</param>
        public void RemoveServerTrustCertificate(string resourceGroupName, string instanceName, string certificateName)
        {
            Communicator.Remove(resourceGroupName, instanceName, certificateName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.ServerTrustCertificate to AzureSqlInstanceServerTrustCertificateModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="instanceName">The name of the managed instance</param>
        /// <param name="serverTrustCertificate">The management client server trust certificate response to convert</param>
        /// <returns>The converted server trust certificate model</returns>
        private static AzureSqlInstanceServerTrustCertificateModel CreateServerTrustCertificateModelFromResponse(string resourceGroupName, string instanceName, Management.Sql.Models.ServerTrustCertificate serverTrustCertificate)
        {
            AzureSqlInstanceServerTrustCertificateModel serverTrustCertificateModel = new AzureSqlInstanceServerTrustCertificateModel()
            {
                ResourceGroupName = resourceGroupName,
                InstanceName = instanceName,
                Id = serverTrustCertificate.Id,
                Type = serverTrustCertificate.Type,
                Name = serverTrustCertificate.CertificateName,
                PublicKey = "0x" + serverTrustCertificate.PublicBlob,
                Thumbprint = "0x" + serverTrustCertificate.Thumbprint
            };
            return serverTrustCertificateModel;
        }
    }
}
