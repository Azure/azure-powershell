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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public static class ExtensionParameterPropertyHelper
    {
        public const string ServiceNameHelpMessage = "Cloud service name.";
        public const string SlotHelpMessage = "Production (default) or Staging";
        public const string RoleHelpMessage = "Default All Roles, or specify ones for Named Roles.";
        public const string X509CertificateHelpMessage = "X509Certificate used to encrypt the content in private configuration.";
        public const string CertificateThumbprintHelpMessage = "Thumbprint of a certificate used for encryption.";
        public const string ThumbprintAlgorithmHelpMessage = "Algorithm associated with the Thumbprint.";
        public const string UninstallConfigurationHelpMessage = "If specified, uninstall all extension configurations in this type from the cloud service.";
        public const string PublicConfigurationHelpMessage = "Extension Public Configuration.";
        public const string PrivateConfigurationHelpMessage = "Extension Private Configuration.";
        public const string ProviderNamespaceHelpMessage = "Extension Provider Namespace";
        public const string ExtensionNameHelpMessage = "Extension Name";
        public const string VersionHelpMessage = "Extension Version";
        public const string ExtensionIdHelpMessage = "Extension ID";
        public const string ExtensionStateHelpMessage = "Extension State.  It is either Enable, Disable or Uninstall";
    }
}
