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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// A version-independent representation of storage data plane endpoints for a storage account
    /// </summary>
    public interface IStorageContext : IExtensibleModel
    {
        /// <summary>
        /// The name of the storage account
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The location of the blob service
        /// </summary>
        string BlobEndPoint { get; }

        /// <summary>
        /// The location fo the table service
        /// </summary>
        string TableEndPoint { get; }

        /// <summary>
        /// The location fo the queue service
        /// </summary>
        string QueueEndPoint { get; }

        /// <summary>
        /// The location fo the file service
        /// </summary>
        string FileEndPoint { get; }

        /// <summary>
        /// A self reference
        /// </summary>
        IStorageContext Context { get;}

        /// <summary>
        /// The name of the storage account (same as name), used for backward compatibility
        /// </summary>
        string StorageAccountName { get; }

        /// <summary>
        /// The domain name suffix for services associated with this storage account
        /// </summary>
        string EndPointSuffix { get; }

        /// <summary>
        /// A connection string for data plane connections to the storage account
        /// </summary>
        string ConnectionString { get; }
    }
}
