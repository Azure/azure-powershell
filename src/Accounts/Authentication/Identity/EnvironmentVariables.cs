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
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal class EnvironmentVariables
    {
        public static string Username => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_USERNAME"));
        public static string Password => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_PASSWORD"));
        public static string TenantId => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_TENANT_ID"));
        public static List<string> AdditionallyAllowedTenants => (Environment.GetEnvironmentVariable("AZURE_ADDITIONALLY_ALLOWED_TENANTS") ?? string.Empty).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        public static string ClientId => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_CLIENT_ID"));
        public static string ClientSecret => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET"));
        public static string ClientCertificatePath => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH"));
        public static string ClientCertificatePassword => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PASSWORD"));
        public static bool ClientSendCertificateChain => EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_CLIENT_SEND_CERTIFICATE_CHAIN"));

        public static string IdentityEndpoint => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT"));
        public static string IdentityHeader => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("IDENTITY_HEADER"));
        public static string MsiEndpoint => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("MSI_ENDPOINT"));
        public static string MsiSecret => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("MSI_SECRET"));
        public static string ImdsEndpoint => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("IMDS_ENDPOINT"));
        public static string IdentityServerThumbprint => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("IDENTITY_SERVER_THUMBPRINT"));
        public static string PodIdentityEndpoint => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_POD_IDENTITY_AUTHORITY_HOST"));

        public static string Path => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("PATH"));

        public static string ProgramFilesX86 => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("ProgramFiles(x86)"));
        public static string ProgramFiles => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("ProgramFiles"));
        public static string AuthorityHost => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_AUTHORITY_HOST"));

        public static string AzureRegionalAuthorityName => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_REGIONAL_AUTHORITY_NAME"));

        public static string AzureFederatedTokenFile => GetNonEmptyStringOrNull(Environment.GetEnvironmentVariable("AZURE_FEDERATED_TOKEN_FILE"));

        private static string GetNonEmptyStringOrNull(string str)
        {
            return !string.IsNullOrEmpty(str) ? str : null;
        }

        private static bool EnvironmentVariableToBool(string str)
        {
            return (string.Equals(bool.TrueString, str, StringComparison.OrdinalIgnoreCase) || string.Equals("1", str, StringComparison.OrdinalIgnoreCase));
        }
    }
}
