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
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    public interface IStorageService
    {
        /// <summary>
        /// The blob service endpoint
        /// </summary>
        Uri BlobEndpoint { get; }

        /// <summary>
        /// The file service endpoint
        /// </summary>
        Uri FileEndpoint { get; }

        /// <summary>
        /// The queue service endpoint
        /// </summary>
        Uri QueueEndpoint { get; }

        /// <summary>
        /// The table service endpoint
        /// </summary>
        Uri TableEndpoint { get; }

        /// <summary>
        /// The storage account name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Authentication keys for the storage account
        /// </summary>
        List<string> AuthenticationKeys { get; }
    }
}
