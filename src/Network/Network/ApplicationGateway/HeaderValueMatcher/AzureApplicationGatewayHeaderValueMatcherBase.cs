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
//

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayHeaderValueMatcherBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Pattern to look for in the header values")]
        [AllowEmptyString()]
        public string Pattern { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set this flag to ignore during pattern matching")]
        public SwitchParameter IgnoreCase { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set this flag to negate the result of pattern matching against a header value")]
        public SwitchParameter Negate { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayHeaderValueMatcher NewObject()
        {
            var headerValueMatcherObj = new PSApplicationGatewayHeaderValueMatcher
            {
                Pattern = this.Pattern,
                IgnoreCase = this.IgnoreCase.IsPresent,
                Negate = this.Negate.IsPresent
            };

            return headerValueMatcherObj;
        }
    }
}
