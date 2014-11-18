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
    ///     Represents a Storage Account for an HD Insight Configuration.
    /// </summary>
    public class AzureHDInsightStorageAccount
    {
        /// <summary>
        ///     Gets or sets the Storage Account Key.
        /// </summary>
        public string StorageAccountKey { get; set; }

        /// <summary>
        ///     Gets or sets the Storage Account Name.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        ///     Overrides the ToString() method to return the storage account name.
        /// </summary>
        /// <returns>The string representation of this object.</returns>
        public override string ToString()
        {
            return this.StorageAccountName;
        }
    }
}
