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

using System.Collections.Generic;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Profile
{
    internal class SupportedResourceNames
    {
        public const string Arm = "Arm";
        public const string AadGraph = "AadGraph";
        public const string MSGraph = "MSGraph";
        public const string Batch = "Batch";
        public const string DataLake = "DataLake";
        public const string KeyVault = "KeyVault";
        public const string ResourceManager = "ResourceManager"; //endpoint is same as Arm

        public const string AnalysisServices = "AnalysisServices";
        public const string Attestation = "Attestation";
        public const string OperationalInsights = "OperationalInsights";
        public const string Storage = "Storage";
        public const string Synapse = "Synapse";
        public const string ManagedHsm = "ManagedHsm";
        public const string AppConfiguration = "AppConfiguration";
        public const string CommunicationEmail = "CommunicationEmail";

        internal static Dictionary<string, string> ResourceNameMap;
        internal static Dictionary<string, string> DataPlaneResourceNameMap;


        static SupportedResourceNames()
        {
            DataPlaneResourceNameMap = new Dictionary<string, string>()
                    {
                        { AadGraph, AzureEnvironment.Endpoint.GraphEndpointResourceId },
                        { MSGraph, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphEndpointResourceId },
                        { Batch, AzureEnvironment.Endpoint.BatchEndpointResourceId },
                        { DataLake, AzureEnvironment.Endpoint.DataLakeEndpointResourceId },
                        { KeyVault, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId },

                        { AnalysisServices, AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId },
                        { Attestation, AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId },
                        { OperationalInsights, AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId },
                        { Storage, "https://storage.azure.com/" }, //OAuth scope/resource id for Storage, does not add it to ExtenedEndpoint to avoid confusion with StorageEndpointSuffix
                        { Synapse, AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId },
                        { ManagedHsm, AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId },
                        { AppConfiguration, AzureEnvironment.ExtendedEndpoint.AzureAppConfigurationEndpointResourceId },
                        { CommunicationEmail, AzureEnvironment.ExtendedEndpoint.AzureCommunicationEmailEndpointResourceId }
                    };

            ResourceNameMap = new Dictionary<string, string>(DataPlaneResourceNameMap);
            ResourceNameMap.Add(Arm, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
            ResourceNameMap.Add(ResourceManager, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
        }
    }
}
