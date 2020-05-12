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

using System.Collections.Generic;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSLinkedService
    {
        public PSLinkedService() {}

        public PSLinkedService(string id = default(string), string name = default(string), string type = default(string), string resourceId = default(string), string writeAccessResourceId = default(string), string provisioningState = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.ResourceId = resourceId;
            this.WriteAccessResourceId = writeAccessResourceId;
            this.ProvisioningState = provisioningState;
            this.Tags = tags;
        }

        public PSLinkedService(LinkedService service)
        {
            if (service != null)
            {
                this.Id = service.Id;
                this.Name = service.Name;
                this.Type = service.Type;
                this.ResourceId = service.ResourceId;
                this.WriteAccessResourceId = service.WriteAccessResourceId;
                this.ProvisioningState = service.ProvisioningState;
                this.Tags = service.Tags;
            }
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ResourceId { get; set; }

        public string WriteAccessResourceId { get; set; }

        public string ProvisioningState { get; private set; }

        public IDictionary<string, string> Tags { get; set; }

        public LinkedService getLinkedService()
        {
            return new LinkedService(this.Id, this.Name, this.Type, this.ResourceId, this.WriteAccessResourceId, this.ProvisioningState, this.Tags);
        }
    }
}
