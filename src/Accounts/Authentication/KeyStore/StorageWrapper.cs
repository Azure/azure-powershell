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
using Microsoft.Identity.Client.Extensions.Msal;
using System.Diagnostics;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    internal class StorageWrapper : IStorage
    {
        public StorageCreationProperties StorageCreationProperties { get; set; }

        public TraceSource LoggerSource { get; set; }

        private Storage _storage = null;

        public StorageWrapper()
        {

        }

        public IStorage Create()
        {
            _storage = Storage.Create(StorageCreationProperties, LoggerSource);
            return this;
        }

        public void Clear()
        {
            _storage.Clear(ignoreExceptions: true);
        }

        public byte[] ReadData()
        {
            return _storage.ReadData();
        }

        public void VerifyPersistence()
        {
            _storage.VerifyPersistence();
        }

        public void WriteData(byte[] data)
        {
            _storage.WriteData(data);
        }
    }
}