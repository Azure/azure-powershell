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
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSServiceGetResults
    {

        public PSServiceGetResults()
        {
        }

        public PSServiceGetResults(ServiceResource serviceGetResult)
        {
            if (serviceGetResult == null)
            {
                return;
            }

            Id = serviceGetResult.Id;
            InstanceSize = serviceGetResult.Properties.InstanceSize;
            InstanceCount = serviceGetResult.Properties.InstanceCount;
            Status = serviceGetResult.Properties.Status;
            CreationTime = serviceGetResult.Properties.CreationTime;;
        }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB Service
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets InstanceSize of the Cosmos DB Service
        /// </summary>
        [Ps1Xml(Label = "InstanceSize", Target = ViewControl.List)]
        public string InstanceSize { get; set; }

        /// <summary>
        /// Gets or sets InstanceCount of the Cosmos DB Service
        /// </summary>
        [Ps1Xml(Label = "InstanceCount", Target = ViewControl.List)]
        public int? InstanceCount { get; set; }

        /// <summary>
        /// Gets or sets Status of the Cosmos DB Service
        /// </summary>
        [Ps1Xml(Label = "Status", Target = ViewControl.List)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets CreationTime of the Cosmos DB Service
        /// </summary>
        [Ps1Xml(Label = "CreationTime", Target = ViewControl.List)]
        public DateTime? CreationTime { get; set; }
    }
}