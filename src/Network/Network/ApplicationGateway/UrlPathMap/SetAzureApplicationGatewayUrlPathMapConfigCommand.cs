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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayUrlPathMapConfig"), OutputType(typeof(PSApplicationGateway))]
    public class SetAzureApplicationGatewayUrlPathMapConfigCommand : AzureApplicationGatewayUrlPathMapConfigBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var oldUrlPathMap = this.ApplicationGateway.UrlPathMaps.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (oldUrlPathMap == null)
            {
                throw new ArgumentException("Url Path Map with the specified name does not exist");
            }

            var newUrlPathMap = base.NewObject();

            this.ApplicationGateway.UrlPathMaps.Remove(oldUrlPathMap);
            this.ApplicationGateway.UrlPathMaps.Add(newUrlPathMap);

            WriteObject(this.ApplicationGateway);
        }
    }
}
