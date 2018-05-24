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

using System.Collections;
using System.Linq;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, "AzureRmApiManagementBackendCredential")]
    [OutputType(typeof(PsApiManagementBackendCredential))]
    public class NewAzureApiManagementBackendCredential : AzureApiManagementCmdletBase
    {
        [Parameter(
           ValueFromPipelineByPropertyName = false,
           Mandatory = false,
           HelpMessage = "Client Certificate Thumbprints. This parameter is optional.")]
        public string[] CertificateThumbprint { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Query Parameter Values accepted by Backend. This parameter is optional.")]
        public Hashtable Query { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Header Parameter Values accepted by Backend. This parameter is optional.")]
        public Hashtable Header { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Authorization Scheme used for the Backend. This parameter is optional.")]
        public string AuthorizationHeaderScheme { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Authorization Header used for the Backend. This parameter is optional.")]
        public string AuthorizationHeaderParameter { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var backendCredentials = new PsApiManagementBackendCredential();

            if (CertificateThumbprint != null && CertificateThumbprint.Any())
            {
                backendCredentials.Certificate = CertificateThumbprint;
            }

            if (Header != null && Header.Count > 0)
            {
                backendCredentials.Header = Header;
            }

            if (Query != null && Query.Count > 0)
            {
                backendCredentials.Query = Query;
            }

            if (!string.IsNullOrEmpty(AuthorizationHeaderParameter) && !string.IsNullOrEmpty(AuthorizationHeaderScheme))
            {
                var authorization = new PsApiManagementAuthorizationHeaderCredential()
                {
                    Scheme = AuthorizationHeaderScheme,
                    Parameter = AuthorizationHeaderParameter
                };

                backendCredentials.Authorization = authorization;
            }

            WriteObject(backendCredentials);
        }
    }
}