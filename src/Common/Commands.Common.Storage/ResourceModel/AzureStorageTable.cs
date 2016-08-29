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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using Microsoft.WindowsAzure.Storage.Table;
    using System;

    /// <summary>
    /// Azure storage table object
    /// </summary>
    public class AzureStorageTable : AzureStorageBase
    {
        /// <summary>
        /// Cloud table object
        /// </summary>
        public CloudTable CloudTable { get; private set; }

        /// <summary>
        /// Table uri
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Azure storage table constructor
        /// </summary>
        /// <param name="table">Cloud table object</param>
        public AzureStorageTable(CloudTable table)
        {
            Name = table.Name;
            CloudTable = table;
            Uri = table.Uri;
        }
    }
}
