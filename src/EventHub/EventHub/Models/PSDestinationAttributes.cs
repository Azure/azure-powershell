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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    public class PSDestinationAttributes
    {
        public PSDestinationAttributes()
        { }

        public PSDestinationAttributes(Microsoft.Azure.Management.EventHub.Models.Destination destinationResource)
        {
            if (destinationResource != null)
            {
                Name = destinationResource.Name;
                StorageAccountResourceId = destinationResource.StorageAccountResourceId;
                BlobContainer = destinationResource.BlobContainer;
                ArchiveNameFormat = destinationResource.ArchiveNameFormat;
            }
        }
               

        /// <summary>
        /// Gets or sets name for capture destination
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets resource id of the storage account to be used to
        /// create the blobs
        /// </summary>
        public string StorageAccountResourceId { get; set; }

        /// <summary>
        /// Gets or sets blob container Name
        /// </summary>
        public string BlobContainer { get; set; }

        /// <summary>
        /// Gets or sets blob naming convention for archive, e.g.
        /// {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}.
        /// Here all the parameters (Namespace,EventHub .. etc) are mandatory
        /// irrespective of order
        /// </summary>
        public string ArchiveNameFormat { get; set; }
    }
}
