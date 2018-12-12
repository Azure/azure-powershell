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

using Microsoft.Azure.Management.DataFactories.Models;
using System;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSLinkedService
    {
        private LinkedService linkedService;

        public PSLinkedService()
        {
            linkedService = new LinkedService();
        }

        public PSLinkedService(LinkedService linkedService)
        {
            if (linkedService == null)
            {
                throw new ArgumentNullException("linkedService");
            }

            this.linkedService = linkedService;
        }

        public string LinkedServiceName
        {
            get
            {
                return linkedService.Name;
            }
            set
            {
                linkedService.Name = value;
            }
        }

        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }

        public LinkedServiceProperties Properties
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

        public string ProvisioningState
        {
            get { return Properties == null ? string.Empty : Properties.ProvisioningState; }
        }
    }
}
