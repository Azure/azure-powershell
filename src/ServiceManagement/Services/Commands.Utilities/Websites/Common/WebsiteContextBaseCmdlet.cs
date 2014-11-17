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
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Common
{
    public abstract class WebsiteContextBaseCmdlet : WebsiteBaseCmdlet
    {
        protected bool websiteNameDiscovery;

        private string name;
        private string slot;

        public WebsiteContextBaseCmdlet()
        {
            websiteNameDiscovery = true;
        }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The web site name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // Convert to Unicode if necessary.
                name = IdnHelper.GetUnicode(value);
            }
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The web site slot name.")]
        [ValidateNotNullOrEmpty]
        public string Slot
        {
            get
            {
                return slot;
            }
            set
            {
                // Convert to Unicode if necessary.
                slot = IdnHelper.GetUnicode(value);
            }
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.IsNullOrEmpty(Name) && websiteNameDiscovery)
                {
                    // If the website name was not specified as a parameter try to infer it
                    Name = GitWebsite.ReadConfiguration().Name;
                }
                Slot = string.IsNullOrEmpty(Slot) ? WebsitesClient.GetSlotName(Name) : Slot;
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            Slot = null;
        }
    }
}
