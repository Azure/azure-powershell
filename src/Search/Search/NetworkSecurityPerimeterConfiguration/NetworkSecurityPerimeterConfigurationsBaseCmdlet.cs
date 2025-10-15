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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Management.Search.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    public abstract class NetworkSecurityPerimeterConfigurationsBaseCmdlet : SearchServiceBaseCmdlet
    {
        protected const string NetworkSecurityPerimeterConfigurationNameHelpMessage =
            "Azure AI Search Service network security perimeter configuration name in the format of {NSP perimeter guid}.{association name}";

        protected void WriteNetworkSecurityPerimeterConfiguration(NetworkSecurityPerimeterConfiguration configuration)
        {
            if (configuration != null)
            {
                WriteObject(new PSNetworkSecurityPerimeterConfiguration(configuration));
            }
        }

        protected void WriteNetworkSecurityPerimeterConfigurationsList(IEnumerable<NetworkSecurityPerimeterConfiguration> configurations)
        {
            var output = new List<PSNetworkSecurityPerimeterConfiguration>();
            if (configurations != null)
            {
                output = configurations.Select(config => new PSNetworkSecurityPerimeterConfiguration(config)).ToList();
            }

            WriteObject(output, true);
        }
    }
}
