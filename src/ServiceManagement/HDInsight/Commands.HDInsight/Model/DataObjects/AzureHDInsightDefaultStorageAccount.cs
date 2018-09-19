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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Represents a Default Storage Account used for an HDInsight cluster.
    /// </summary>
    public class AzureHDInsightDefaultStorageAccount : AzureHDInsightStorageAccount
    {
        /// <summary>
        ///     Creates a new default storage account object with the same attributes as the passed in storage account
        /// </summary>
        public AzureHDInsightDefaultStorageAccount(AzureHDInsightDefaultStorageAccount value) : base()
        {
            this.StorageAccountName = value.StorageAccountName;
            this.StorageAccountKey = value.StorageAccountKey;
            this.StorageContainerName = value.StorageContainerName;
        }

        /// <summary>
        ///     Creates an empty default storage account 
        /// </summary>
        public AzureHDInsightDefaultStorageAccount() : base()
        {
        }
        
        /// <summary>
        ///     Gets or sets the Storage Container for the Default Storage Account.
        /// </summary>
        public string StorageContainerName { get; set; }

        /// <summary>
        ///     Creates an SDK object from this Powershell object type.
        /// </summary>
        /// <returns>A storage account configuration.</returns>
        public WabStorageAccountConfiguration ToWabStorageAccountConfiguration()
        {
            return new WabStorageAccountConfiguration(this.StorageAccountName, this.StorageAccountKey, this.StorageContainerName);
        }
    }
}
