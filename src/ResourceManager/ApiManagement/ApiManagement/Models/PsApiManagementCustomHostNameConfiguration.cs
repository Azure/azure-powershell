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

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    using Helpers;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using System;

    public class PsApiManagementCustomHostNameConfiguration
    {
        public PsApiManagementCustomHostNameConfiguration()
        {
        }

        internal PsApiManagementCustomHostNameConfiguration(HostnameConfiguration hostnameConfigurationResource)
            : this()
        {
            if (hostnameConfigurationResource == null)
            {
                throw new ArgumentNullException("hostnameConfigurationResource");
            }

            CertificateInformation = hostnameConfigurationResource.Certificate != null ? new PsApiManagementCertificateInformation(hostnameConfigurationResource.Certificate) : null;
            Hostname = hostnameConfigurationResource.HostName;
            KeyVaultId = hostnameConfigurationResource.KeyVaultId;
            DefaultSslBinding = hostnameConfigurationResource.DefaultSslBinding;
            NegotiateClientCertificate = hostnameConfigurationResource.NegotiateClientCertificate;
            HostnameType = Mappers.MapHostnameType(hostnameConfigurationResource.Type);
        }

        public PsApiManagementCertificateInformation CertificateInformation { get; set; }

        public string EncodedCertificate { get; set; }

        public PsApiManagementHostnameType HostnameType { get; set; }

        public string CertificatePassword { get; set; }

        public string Hostname { get; set; }

        public string KeyVaultId { get; set; }

        public bool? DefaultSslBinding { get; set; }

        public bool? NegotiateClientCertificate { get; set; }
    }
}