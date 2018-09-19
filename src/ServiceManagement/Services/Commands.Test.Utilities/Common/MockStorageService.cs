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
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Moq;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// A class used to simulate the behavior of a storage account as far as existing,
    /// creation, and querying are concerned.
    /// </summary>
    public class MockStorageService
    {
        public class StorageAccountData
        {
            private string blobEndpoint;
            private string queueEndpoint;
            private string tableEndpoint;
            private string primaryKey;
            private string secondaryKey;

            private const string defaultPrimaryKey = "MNao3bm7t7B/x+g2/ssh9HnG0mEh1QV5EHpcna8CetYn+TSRoA8/SBoH6B3Ufwtnz3jZLSw9GEUuCTr3VooBWq==";
            private const string defaultSecondaryKey = "secondaryKey";

            public string Name { get; set; }

            public string BlobEndpoint
            {
                get
                {
                    return blobEndpoint ?? "http://awesome.blob.windows.core.net/";
                }
                set { blobEndpoint = value; }
            }

            public string QueueEndpoint
            {
                get { return queueEndpoint ?? "http://awesome.queue.windows.core.net/"; }
                set { queueEndpoint = value; }
            }

            public string TableEndpoint
            {
                get { return tableEndpoint ?? "http://awesome.table.windows.core.net"; }
                set { tableEndpoint = value; }
            }

            public string PrimaryKey
            {
                get { return primaryKey ?? defaultPrimaryKey; }
                set { primaryKey = value; }
            }

            public string SecondaryKey
            {
                get { return secondaryKey ?? defaultSecondaryKey; }
                set { secondaryKey = value; }
            }
        }

        private readonly List<StorageAccountData> accounts = new List<StorageAccountData>();

        public MockStorageService Add(Action<StorageAccountData> dataSetter)
        {
            var account = new StorageAccountData();
            dataSetter(account);
            accounts.Add(account);
            return this;
        }

        public void Clear()
        {
            accounts.Clear();
        }

        public void InitializeMocks(Mock<StorageManagementClient> mock)
        {
            mock.Setup(c => c.StorageAccounts.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns((string serviceName, CancellationToken cancellationToken) => CreateGetResponse(serviceName));

            mock.Setup(c => c.StorageAccounts.GetKeysAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns((string serviceName, CancellationToken cancellationToken) => CreateGetKeysResponse(serviceName));

            mock.Setup(c => c.StorageAccounts.CreateAsync(It.IsAny<StorageAccountCreateParameters>(), It.IsAny<CancellationToken>()))
                .Callback((StorageAccountCreateParameters createParameters, CancellationToken cancellationToken) => AddService(createParameters))
                .Returns(CreateCreateResponse);
        }

        private Task<StorageAccountGetResponse> CreateGetResponse(string serviceName)
        {
            Task<StorageAccountGetResponse> resultTask;
            var data = accounts.FirstOrDefault(a => a.Name == serviceName);
            if (data != null)
            {
                var storageServiceGetResponse = new StorageAccountGetResponse
                {
                    StorageAccount = new StorageAccount
                        {
                            Name = data.Name,
                            Properties = new StorageAccountProperties
                            {
                                Endpoints =
                                {
                                    new Uri(data.BlobEndpoint),
                                    new Uri(data.QueueEndpoint),
                                    new Uri(data.TableEndpoint)
                                }
                            }   
                        }
                };
                resultTask = Tasks.FromResult(storageServiceGetResponse);
            }
            else
            {
                resultTask = Tasks.FromException<StorageAccountGetResponse>(ClientMocks.Make404Exception());
            }
            return resultTask;
        }

        private Task<StorageAccountGetKeysResponse> CreateGetKeysResponse(string serviceName)
        {
            Task<StorageAccountGetKeysResponse> resultTask;
            var data = accounts.FirstOrDefault(a => a.Name == serviceName);
            if (data != null)
            {
                var response = new StorageAccountGetKeysResponse
                {
                    PrimaryKey = data.PrimaryKey,
                    SecondaryKey = data.SecondaryKey,
                    StatusCode = HttpStatusCode.OK
                };
                resultTask = Tasks.FromResult(response);
            }
            else
            {
                resultTask = Tasks.FromException<StorageAccountGetKeysResponse>(ClientMocks.Make404Exception());
            }
            return resultTask;
        }

        private void AddService(StorageAccountCreateParameters createParameters)
        {
            Add(a =>
            {
                a.Name = createParameters.Name;
            });
        }
        private Task<OperationStatusResponse> CreateCreateResponse()
        {
            return Tasks.FromResult(new OperationStatusResponse
            {
                RequestId = "unused",
                StatusCode = HttpStatusCode.OK,
                Status = OperationStatus.Succeeded
            });
        }
    }
}
