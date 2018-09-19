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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.PersistentVMs
{
    public class MediaLinkFactory
    {
        private CloudStorageAccount currentStorage;
        private readonly string serviceName;
        private string roleName;
        private DateTime dateTimeCreated;
        private string containerName;
        private long counter;

        public MediaLinkFactory(CloudStorageAccount currentStorage, string serviceName, string roleName) : 
            this(currentStorage, serviceName, roleName, "vhds")
        {
        }

        public MediaLinkFactory(CloudStorageAccount currentStorage, string serviceName, string roleName, string containerName)
        {
            this.currentStorage = currentStorage;
            this.serviceName = serviceName;
            this.roleName = roleName;
            this.containerName = containerName;
            dateTimeCreated = DateTime.Now;
        }

        public Uri Create()
        {
            string vhdname = String.Format("{0}-{1}-{2}-{3}.vhd", serviceName, roleName, DateTimeToString(), counter++);
            string blobEndpoint = currentStorage.BlobEndpoint.AbsoluteUri;
            return new Uri(GeneralUtilities.EnsureTrailingSlash(GeneralUtilities.EnsureTrailingSlash(blobEndpoint) + containerName) + vhdname);
        }

        private string DateTimeToString()
        {
            return String.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}",dateTimeCreated.Year, dateTimeCreated.Month, dateTimeCreated.Day,
                                 dateTimeCreated.Hour, dateTimeCreated.Minute, dateTimeCreated.Second, dateTimeCreated.Millisecond);
        }
    }
}