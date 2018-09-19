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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSLinkedService : AdfSubResource
    {
        private LinkedServiceResource linkedService;

        public PSLinkedService()
        {
            linkedService = new LinkedServiceResource();
        }

        public PSLinkedService(LinkedServiceResource linkedService, string resourceGroupName, string factoryName)
        {
            if (linkedService == null)
            {
                throw new ArgumentNullException("linkedService");
            }

            this.linkedService = linkedService;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public override string Name
        {
            get
            {
                return linkedService.Name;
            }
        }

        public LinkedService Properties
        {
            get
            {
                return linkedService.Properties;
            }
            set
            {
                linkedService.Properties = value;
            }
        }

        public override string Id
        {
            get
            {
                return this.linkedService.Id;
            }
        }

        public override string ETag
        {
            get
            {
                return this.linkedService.Etag;
            }
        }
    }
}
