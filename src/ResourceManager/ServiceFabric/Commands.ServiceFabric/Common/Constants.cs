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

namespace Microsoft.Azure.Commands.ServiceFabric.Common
{
    public static class Constants
    {
        public const string DefaultCertificateStore = "my";
        public const string DefaultSku = "Standard_D1_v2";
        public const string DefaultTier = "Standard";
        public const string DefaultDurabilityLevel = "Bronze";
        public const int DefaultApplicationStartPort = 20000;
        public const int DefaultApplicationEndPort = 30000;
        public const int DefaultEphemeralStart = 49152;
        public const int DefaultEphemeralEnd = 65534;
        public const int DefaultClientConnectionEndpoint = 19000;
        public const int DefaultHttpGatewayEndpoint = 19080;
        public const int DefaultTcpPort = 19000;
        public const int DefaultHttpPort = 19080;
        public const int DefaultFrontendPortRangeStart = 3389;
        public const int DefaultFrontendPortRangeEnd = 4500;
        public const int DefaultBackendPort = 3389;

        public const string PublicIpAddressesType = "Microsoft.Network/publicIPAddresses";
        public const string VirtualMachineScaleSetsType = "Microsoft.Compute/virtualMachineScaleSets";
        public const string KeyVaultType = "Microsoft.KeyVault/vaults";
        public const string ServiceFabricType = "Microsoft.ServiceFabric/clusters";
        public const string ServieFabricTag = "Service Fabric";
        public const string ServiceFabricPublisher = "Microsoft.Azure.ServiceFabric";
        public const string IaaSDiagnostics = "IaaSDiagnostics";

        public const string ServiceFabricWindowsNodeExtName = "ServiceFabricNode";
        public const string ServiceFabricLinuxNodeExtName = "ServiceFabricLinuxNode";

        public const string SecretContentType = "application/x-pkcs12";

        public const string SelfSignedIssuerName = "Self";

        public const string SourceVaultValue = "sourceVaultValue";
        public const string CertificateThumbprint = "certificateThumbprint";
        public const string CertificateUrlValue = "certificateUrlValue";

        public const string SecSourceVaultValue = "secSourceVaultValue";
        public const string SecCertificateThumbprint = "secCertificateThumbprint";
        public const string SecCertificateUrlValue = "secCertificateUrlValue";


    }
}
