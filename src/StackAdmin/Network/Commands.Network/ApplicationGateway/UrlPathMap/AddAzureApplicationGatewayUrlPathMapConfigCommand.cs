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
    [Cmdlet(VerbsCommon.Add, "AzureRmApplicationGatewayUrlPathMapConfig"), OutputType(typeof(PSApplicationGateway))]
    public class AddAzureApplicationGatewayUrlPathMapConfigCommand : AzureApplicationGatewayUrlPathMapConfigBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var urlPathMap = this.ApplicationGateway.UrlPathMaps.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (urlPathMap != null)
            {
                throw new ArgumentException("URL path map with the specified name already exists");
            }

            urlPathMap = base.NewObject();
            this.ApplicationGateway.UrlPathMaps.Add(urlPathMap);

            WriteObject(this.ApplicationGateway);
        }
    }
}
