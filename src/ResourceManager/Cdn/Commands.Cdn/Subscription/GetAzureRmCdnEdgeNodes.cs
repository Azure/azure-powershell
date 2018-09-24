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

using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System.Linq;
using Microsoft.Azure.Commands.Cdn.EdgeNodes;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnEdgeNodes"), OutputType(typeof(PSEdgeNode))]
    public class GetAzureRmCdnEdgeNodes : AzureCdnCmdletBase
    {

        public override void ExecuteCmdlet()
        {
            var resourceUsages = CdnManagementClient.EdgeNodes.List().Select(e => e.ToPsEdgeNode());

            WriteVerbose(Resources.Success);
            WriteObject(resourceUsages);
        }
    }
}
