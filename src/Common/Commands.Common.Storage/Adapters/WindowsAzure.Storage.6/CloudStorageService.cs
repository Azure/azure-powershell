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
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Common.Storage.Adapters
{
    public class CloudStorageService : IStorageService
    {
        string _name;
        List<string> _authenticationKeys = new List<string>();
        IAzureEnvironment _environment;
        AzureStorageContext _context;
        public CloudStorageService(string accountName,
            string[] authenticationKeys, IAzureEnvironment environment)
        {
            _name = accountName;
            foreach (var key in authenticationKeys)
            {
                _authenticationKeys.Add(key);
            }
            _environment = environment;
           var storage = new CloudStorageAccount(new StorageCredentials(accountName, authenticationKeys.First()),
                new StorageUri(environment.GetStorageBlobEndpoint(accountName, true)),
                new StorageUri(environment.GetStorageQueueEndpoint(accountName, true)),
                new StorageUri(environment.GetStorageTableEndpoint(accountName, true)),
                new StorageUri(environment.GetStorageFileEndpoint(accountName, true)));
            _context = new AzureStorageContext(storage);
        }

        public Uri BlobEndpoint
        {
            get { return new Uri(_context.BlobEndPoint); }
        }

        public Uri FileEndpoint
        {
            get { return new Uri(_context.FileEndPoint); }
        }

        public Uri QueueEndpoint
        {
            get { return new Uri(_context.QueueEndPoint); }
        }

        public Uri TableEndpoint
        {
            get { return new Uri(_context.TableEndPoint); }
        }

        public string Name
        {
            get { return _name; }
        }

        public List<string> AuthenticationKeys
        {
            get { return _authenticationKeys; }
        }

        public IStorageContext Context
        {
            get
            {
                return _context;
            }
        }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
