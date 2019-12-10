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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using System.Management.Automation;

    public class AzureApplicationGatewayRewriteRuleUrlConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Url path value.")]
        public string ModifiedPath { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Url query string value.")]
        public string ModifiedQueryString { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to re-evaluate the url path map provided in path based request routing rules using modified path.")]
        public SwitchParameter Reroute { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayUrlConfiguration NewObject()
        {
            var urlConfiguration = new PSApplicationGatewayUrlConfiguration
            {
                ModifiedPath = this.ModifiedPath,
                ModifiedQueryString = this.ModifiedQueryString,
                Reroute = this.Reroute.IsPresent
            };

            return urlConfiguration;
        }
    }
}