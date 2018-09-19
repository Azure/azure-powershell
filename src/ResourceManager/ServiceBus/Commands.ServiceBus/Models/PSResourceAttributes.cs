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

using Microsoft.Azure.Management.ServiceBus.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    public class PSResourceAttributes
    {
        public PSResourceAttributes(Resource resource)
        {
            if (resource != null)
            {
                Id = resource.Id;
                Name = resource.Name;
                Type = resource.Type;
                //Location = resource.Location;
            }
        }

        public PSResourceAttributes() { }


        /// <summary>
        /// Resource Id
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Resource name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Resource type
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Resource location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Resource tags
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }



    }
}
