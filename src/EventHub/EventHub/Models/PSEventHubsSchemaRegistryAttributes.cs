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
using Microsoft.Azure.Management.EventHub.Models;
using System.Text;
using System.Collections;
using System.Linq;

namespace Microsoft.Azure.Commands.EventHub.Models
{
    public class PSEventHubsSchemaRegistryAttributes
    {
        public PSEventHubsSchemaRegistryAttributes(SchemaGroup schemaGroup)
        {
            if(schemaGroup != null)
            {
                SchemaCompatibility = schemaGroup.SchemaCompatibility;
                SchemaType = schemaGroup.SchemaType;

                if(schemaGroup.GroupProperties != null)
                {
                    var groupPropertiesDictionary = new Dictionary<string, string>(schemaGroup.GroupProperties);
                    GroupProperties = new Hashtable(groupPropertiesDictionary);
                }
                        

                if (schemaGroup.Id != null)
                    Id = schemaGroup.Id;

                if (schemaGroup.Name != null)
                    Name = schemaGroup.Name;

                if (schemaGroup.Location != null)
                    Location = schemaGroup.Location;

                if (schemaGroup.Type != null)
                    Type = schemaGroup.Type;
            }
        }


        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Namespace
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Schema Compatibility. ('Forward', 'Backward', 'None')
        /// </summary>
        public string SchemaCompatibility { get; set; }

        /// <summary>
        /// Schema Type. ('Avro')
        /// </summary>
        public string SchemaType { get; set; }

        public Hashtable GroupProperties { get; set; }

    }
}
