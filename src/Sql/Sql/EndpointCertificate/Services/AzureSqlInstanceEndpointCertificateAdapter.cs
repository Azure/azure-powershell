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
using Microsoft.Azure.Commands.Sql.EndpointCertificate.Model;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.EndpointCertificate.Services
{
    /// <summary>
    /// Adapter for EndpointCertificate operations
    /// </summary>
    public class AzureSqlInstanceEndpointCertificateAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlInstanceEndpointCertificateCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlInstanceEndpointCertificateCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a EndpointCertificate adapter
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlInstanceEndpointCertificateAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlInstanceEndpointCertificateCommunicator(Context);
        }

        /// <summary>
        /// Gets a endpoint certificate in a managed instance
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="endpointType">Type of endpoint</param>
        /// <returns>The managed instance</returns>
        public AzureSqlInstanceEndpointCertificateModel GetEndpointCertificate(string resourceGroupName, string instanceName, string endpointType)
        {
            var resp = Communicator.Get(resourceGroupName, instanceName, endpointType);
            return CreateEndpointCertificateModelFromResponse(resourceGroupName, instanceName, resp);
        }

        /// <summary>
        /// Gets a list of all endpoint certificates in managed instance
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <returns>A list of all the endpoint certificates</returns>
        public List<AzureSqlInstanceEndpointCertificateModel> ListEndpointCertificates(string resourceGroupName, string instanceName)
        {
            var resp = Communicator.List(resourceGroupName, instanceName);

            return resp.Select((cert) => CreateEndpointCertificateModelFromResponse(resourceGroupName, instanceName, cert)).ToList();
        }

        /// <summary>
        /// Convert a Management.Sql.Models.EndpointCertificate to AzureSqlInstanceEndpointCertificateModel
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="endpointCertificate">The management client endpoint certificate response to convert</param>
        /// <returns>The converted endpoint certificate model</returns>
        private static AzureSqlInstanceEndpointCertificateModel CreateEndpointCertificateModelFromResponse(string resourceGroupName, string instanceName, Management.Sql.Models.EndpointCertificate endpointCertificate)
        {
            AzureSqlInstanceEndpointCertificateModel endpointCertificateModel = new AzureSqlInstanceEndpointCertificateModel()
            {
                ResourceGroupName = resourceGroupName,
                InstanceName = instanceName,
                Id = endpointCertificate.Id,
                Type = endpointCertificate.Type,
                Name = endpointCertificate.Name,
                PublicKey = "0x" + endpointCertificate.PublicBlob,
            };
            return endpointCertificateModel;
        }
    }
}
