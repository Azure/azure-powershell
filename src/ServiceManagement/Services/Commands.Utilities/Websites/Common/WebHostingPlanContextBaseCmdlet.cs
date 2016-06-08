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
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Common
{
    public abstract class WebHostingPlanContextBaseCmdlet : WebsiteBaseCmdlet
    {
        [Alias("WebSpace")]
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The web space name where hosting plan belongs.")]
        [ValidateNotNullOrEmpty]
        public string WebSpaceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The web hosting plan name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(WebSpaceName))
            {
                throw new ArgumentNullException("WebSpace", Properties.Resources.Argument_WebSpaceMissing);
            }
        }
    }
}
