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

using Microsoft.WindowsAzure.Commands.Common.Storage;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class ARMStorageService : IStorageService
    {
        Azure.Management.Storage.Models.StorageAccount _account;
        List<string> _authenticationKeys = new List<string>();
        public ARMStorageService(Azure.Management.Storage.Models.StorageAccount account,
            params string[] authenticationKeys)
        {
            _account = account;
            foreach (var key in authenticationKeys)
            {
                _authenticationKeys.Add(key);
            }
        }

        public Uri BlobEndpoint
        {
            get { return _account.PrimaryEndpoints.Blob; }
        }

        public Uri FileEndpoint
        {
            get { return _account.PrimaryEndpoints.File; }
        }

        public Uri QueueEndpoint
        {
            get { return _account.PrimaryEndpoints.Queue; }
        }

        public Uri TableEndpoint
        {
            get { return _account.PrimaryEndpoints.Table; }
        }

        public string Name
        {
            get { return _account.Name; }
        }

        public List<string> AuthenticationKeys
        {
            get { return _authenticationKeys; }
        }

        /// <summary>
        /// Get the resource group name from a storage account resource Id
        /// </summary>
        /// <param name="resourceId">The resource Id for the storage account</param>
        /// <returns>The resource group containing the storage account</returns>
        public static string ParseResourceGroupFromId(string resourceId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens == null || tokens.Length < 4)
                {
                    throw new ArgumentOutOfRangeException("resourceId");
                }

                return tokens[3];
            }

            return null;
        }

    }
}
