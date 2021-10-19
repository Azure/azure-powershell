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
    public class PSPrivateEndpointConnection : AdfSubResource
    {
        private PrivateEndpointConnectionResource privateEndpointConnectionResource;

        public PSPrivateEndpointConnection()
        {
            privateEndpointConnectionResource = new PrivateEndpointConnectionResource();
        }

        public PSPrivateEndpointConnection(PrivateEndpointConnectionResource privateEndpointConnectionResource, string resourceGroupName, string factoryName)
        {
            if (privateEndpointConnectionResource == null)
            {
                throw new ArgumentNullException("privateEndpointConnectionResource");
            }

            this.privateEndpointConnectionResource = privateEndpointConnectionResource;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public override string Name
        {
            get
            {
                return privateEndpointConnectionResource.Name;
            }
        }

        public RemotePrivateEndpointConnection Properties
        {
            get
            {
                return privateEndpointConnectionResource.Properties;
            }
            set
            {
                privateEndpointConnectionResource.Properties = value;
            }
        }

        public override string Id
        {
            get
            {
                return this.privateEndpointConnectionResource.Id;
            }
        }

        public override string ETag
        {
            get
            {
                return this.privateEndpointConnectionResource.Etag;
            }
        }
    }
}
