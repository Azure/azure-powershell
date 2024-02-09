﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlTriggerGetPropertiesResource 
    {
        public PSSqlTriggerGetPropertiesResource()
        {
        }        
        
        public PSSqlTriggerGetPropertiesResource(SqlTriggerGetPropertiesResource sqlTriggerGetPropertiesResource)
        {
            if (sqlTriggerGetPropertiesResource == null)
            {
                return;
            }

            Id = sqlTriggerGetPropertiesResource.Id;
            Body = sqlTriggerGetPropertiesResource.Body;
            TriggerType = sqlTriggerGetPropertiesResource.TriggerType;
            TriggerOperation = sqlTriggerGetPropertiesResource.TriggerOperation;
            _rid = sqlTriggerGetPropertiesResource._rid;
            _ts = sqlTriggerGetPropertiesResource._ts;
            _etag = sqlTriggerGetPropertiesResource._etag;
        }


        //
        // Summary:
        //     Gets or sets name of the Cosmos DB SQL trigger
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets body of the Trigger
        public string Body { get; set; }
        //
        // Summary:
        //     Gets or sets type of the Trigger. Possible values include: 'Pre', 'Post'
        public string TriggerType { get; set; }
        //
        // Summary:
        //     Gets or sets the operation the trigger is associated with. Possible values include:
        //     'All', 'Create', 'Update', 'Delete', 'Replace'
        public string TriggerOperation { get; set; }
        //
        // Summary:
        //     Gets a system generated property. A unique identifier.
        public string _rid { get; set; }
        //
        // Summary:
        //     Gets a system generated property that denotes the last updated timestamp of the
        //     resource.
        public object _ts { get; set; }
        //
        // Summary:
        //     Gets a system generated property representing the resource etag required for
        //     optimistic concurrency control.
        public string _etag { get; set; }

    }
}
