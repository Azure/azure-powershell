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

namespace Microsoft.Azure.Commands.ApiManagement.Helpers
{
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Models;

    public static class Extensions
    {
        public static HostnameConfiguration GetHostnameConfiguration(
            this PsApiManagementCustomHostNameConfiguration hostnameConfig)
        {
            if (hostnameConfig == null)
            {
                return null;
            }

            var hostnameConfiguration = new HostnameConfiguration(
                Mappers.MapHostnameType(hostnameConfig.HostnameType),
                hostnameConfig.Hostname);
            if (!string.IsNullOrWhiteSpace(hostnameConfig.EncodedCertificate))
            {
                hostnameConfiguration.EncodedCertificate = hostnameConfig.EncodedCertificate;
            }

            if (hostnameConfig.CertificatePassword != null)
            {
                hostnameConfiguration.CertificatePassword = hostnameConfig.CertificatePassword;
            }

            if (!string.IsNullOrWhiteSpace(hostnameConfig.KeyVaultId))
            {
                hostnameConfiguration.KeyVaultId = hostnameConfig.KeyVaultId;
            }

            if (hostnameConfig.DefaultSslBinding.HasValue)
            {
                hostnameConfiguration.DefaultSslBinding = hostnameConfig.DefaultSslBinding.Value;
            }

            if (hostnameConfig.NegotiateClientCertificate.HasValue)
            {
                hostnameConfiguration.NegotiateClientCertificate = hostnameConfig.NegotiateClientCertificate.Value;
            }

            return hostnameConfiguration;
        }

        public static CertificateConfiguration GetCertificateConfiguration(this PsApiManagementSystemCertificate systemCertificate)
        {
            if (systemCertificate == null)
            {
                return null;
            }

            var certificateConfiguration = new CertificateConfiguration(systemCertificate.StoreName);
            if (!string.IsNullOrWhiteSpace(systemCertificate.EncodedCertificate))
            {
                certificateConfiguration.EncodedCertificate = systemCertificate.EncodedCertificate;
            }

            if (systemCertificate.CertificatePassword != null)
            {
                certificateConfiguration.CertificatePassword = systemCertificate.CertificatePassword;
            }

            return certificateConfiguration;
        }
    }
}
