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

using Azure;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public partial class SynapseAnalyticsArtifactsClient
    {
        private LibraryClient _libraryClient;

        LibraryClient LibraryClient
        {
            get
            {
                if (_libraryClient == null)
                {
                    lock (_lock)
                    {
                        if (_libraryClient == null)
                        {
                            _libraryClient = new LibraryClient(_endpoint, new AzureSessionCredential(_context));
                        }
                    }
                }

                return _libraryClient;
            }
        }


        public async Task<Response> CreatePackageAsync(string packageName)
        {
            LibraryCreateOperation operation = await LibraryClient.StartCreateAsync(packageName);
            return await operation.WaitForCompletionResponseAsync();
        }

        public async Task<Response> AppendPackageAsync(string packageName, Stream stream)
        {
            return await LibraryClient.AppendAsync(packageName, stream);
        }

        public LibraryResource GetPackage(string packageName)
        {
            return LibraryClient.Get(packageName).Value;
        }

        public async Task<LibraryResource> GetPackageAsync(string packageName)
        {
            try
            {
                return await LibraryClient.GetAsync(packageName);
            }
            catch (RequestFailedException ex)
            {
                throw CreateAzurePowerShellException(ex);
            }
        }

        public async Task<bool> TestPackageAsync(string packageName)
        {
            try
            {
                await GetPackageAsync(packageName);
                return true;
            }
            catch (AzPSResourceNotFoundCloudException)
            {
                return false;
            }
        }

        public IEnumerable<LibraryResource> GetPackagesByWorkspace()
        {
            return new List<LibraryResource>(LibraryClient.List());
        }

        public void DeletePackage(string packageName)
        {
            LibraryClient.StartDelete(packageName).Poll();
        }

        public async Task<Response> FlushPackageAsync(string packageName)
        {
            LibraryFlushOperation operation = await LibraryClient.StartFlushAsync(packageName);
            return await operation.WaitForCompletionResponseAsync();
        }
    }
}
