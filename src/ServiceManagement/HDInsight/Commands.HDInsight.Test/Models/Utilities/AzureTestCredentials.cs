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

using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    public class StorageAccountCredentials
    {
        public string Container { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
    }

    public class AlternativeEnvironment
    {
        public string Endpoint { get; set; }
        public string Namespace { get; set; }
        public Guid SubscriptionId { get; set; }
    }

    public class MetastoreCredentials
    {
        public string Database { get; set; }
        public string Description { get; set; }
        public string SqlServer { get; set; }
    }

    public class ResourceProviderProperty
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class KnownCluster
    {
        public string Cluster { get; set; }
        public string DnsName { get; set; }
        public string Version { get; set; }
    }

    public enum EnvironmentType
    {
        Production,
        Current,
        Next,
        DogFood
    }

    public class CreationDetails
    {
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public StorageAccountCredentials[] AdditionalStorageAccounts { get; set; }

        public StorageAccountCredentials DefaultStorageAccount { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public MetastoreCredentials[] HiveStores { get; set; }

        public string Location { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public MetastoreCredentials[] OozieStores { get; set; }
    }

    [Serializable]
    public class AzureTestCredentials
    {
        public string AccessToken { get; set; }
        public string AzurePassword { get; set; }
        public string AzureUserName { get; set; }
        public string Certificate { get; set; }
        public string CloudServiceName { get; set; }
        public string CredentialsName { get; set; }
        public string Endpoint { get; set; }
        public EnvironmentType EnvironmentType { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public CreationDetails[] Environments { get; set; }

        public string HadoopUserName { get; set; }
        public string InvalidCertificate { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public ResourceProviderProperty[] ResourceProviderProperties { get; set; }

        public Guid SubscriptionId { get; set; }
        public KnownCluster WellKnownCluster { get; set; }
    }
}
