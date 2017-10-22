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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Common.Storage.Adapters
{
    /// <summary>
    /// RDFE Storage Service
    /// </summary>
    public class CloudStorageService : IStorageService
    {
        string _name;
        List<string> _authenticationKeys = new List<string>();
        IAzureEnvironment _environment;
        Uri _blobEndpoint, _queueEndpoint, _tableEndpoint, _fileEndpoint;

        public CloudStorageService(string accountName,
            string[] authenticationKeys, IAzureEnvironment environment)
        {
            _name = accountName;
            foreach (var key in authenticationKeys)
            {
                _authenticationKeys.Add(key);
            }
            _environment = environment;

            _blobEndpoint = environment.GetStorageBlobEndpoint(accountName, true);
            _queueEndpoint = environment.GetStorageQueueEndpoint(accountName, true);
            _tableEndpoint = environment.GetStorageTableEndpoint(accountName, true);
            _fileEndpoint = environment.GetStorageFileEndpoint(accountName, true);
        }

        public Uri BlobEndpoint
        {
            get { return _blobEndpoint; }
        }

        public Uri FileEndpoint
        {
            get { return _fileEndpoint; }
        }

        public Uri QueueEndpoint
        {
            get { return _queueEndpoint; }
        }

        public Uri TableEndpoint
        {
            get { return _tableEndpoint; }
        }

        public string Name
        {
            get { return _name; }
        }

        public List<string> AuthenticationKeys
        {
            get { return _authenticationKeys; }
        }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
