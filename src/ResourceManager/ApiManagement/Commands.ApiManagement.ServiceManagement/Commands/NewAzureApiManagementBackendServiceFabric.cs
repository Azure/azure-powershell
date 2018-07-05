//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System.Collections;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, "AzureRmApiManagementBackendServiceFabric")]
    [OutputType(typeof(PsApiManagementServiceFabric))]
    public class NewAzureApiManagementBackendServiceFabric : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Service Fabric Cluster management Endpoints. This parameter is required.")]
        public string[] ManagementEndpoint { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = true,
           Mandatory = true,
           HelpMessage = "Client Certificate Thumbprint for the management endpoint. This parameter is required.")]
        public string ClientCertificateThumbprint { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Maximum number of retries when resolving a Service Fabric partition. " +
            "This parameter is optional and default value is 5.")]
        public int? MaxPartitionResolutionRetry { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Server X509 Certificate Names Collection. This parameter is optional.")]
        public Hashtable ServerX509Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Thumbprint of certificates cluster management service uses for tls communication." +
            "This parameter is optional.")]
        public string[] ServerCertificateThumbprint { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var serviceFabricObject = new PsApiManagementServiceFabric();
            serviceFabricObject.ManagementEndpoints = ManagementEndpoint;
            serviceFabricObject.ClientCertificateThumbprint = ClientCertificateThumbprint;
            if (MaxPartitionResolutionRetry.HasValue)
            {
                serviceFabricObject.MaxPartitionResolutionRetries = MaxPartitionResolutionRetry.Value;
            }

            if (ServerX509Name != null)
            {
                serviceFabricObject.ServerX509Names = ServerX509Name;
            }

            if (ServerCertificateThumbprint != null && ServerCertificateThumbprint.Length > 0)
            {
                serviceFabricObject.ServerCertificateThumbprint = ServerCertificateThumbprint;
            }
            WriteObject(serviceFabricObject);
        }
    }
}