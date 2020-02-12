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

using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSTableGetPropertiesResource
    {
        public PSTableGetPropertiesResource()
        {
        }

        public PSTableGetPropertiesResource(TableGetPropertiesResource tableGetPropertiesResource)
        {
            Id = tableGetPropertiesResource.Id;
            _rid = tableGetPropertiesResource._rid;
            _ts = tableGetPropertiesResource._ts;
            _etag = tableGetPropertiesResource._etag;
        }

        //
        // Summary:
        //     Gets or sets name of the Cosmos DB table
        public string Id { get; set; }
        //
        // Summary:
        //     Gets a system generated property. A unique identifier.
        public string _rid { get; }
        //
        // Summary:
        //     Gets a system generated property that denotes the last updated timestamp of the
        //     resource.
        public object _ts { get; }
        //
        // Summary:
        //     Gets a system generated property representing the resource etag required for
        //     optimistic concurrency control.
        public string _etag { get; }
    }
}