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
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
namespace Microsoft.Azure.Commands.DataFactoryV2
{
    partial class DataFactoryClient
    {
        public virtual PSPrivateLinkResources GetPrivateLinkResource(string resourceGroupName, string dataFactoryName)
        {
            PrivateLinkResourcesWrapper response = this.DataFactoryManagementClient.PrivateLinkResources.Get(resourceGroupName, dataFactoryName);

            if (response == null)
            {
                return null;
            }

            return new PSPrivateLinkResources(response, resourceGroupName, dataFactoryName);
        }
    }
}
