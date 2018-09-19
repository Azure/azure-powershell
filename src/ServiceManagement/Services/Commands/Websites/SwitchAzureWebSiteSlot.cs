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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Switches the existing slot with the production one.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "AzureWebsiteSlot", SupportsShouldProcess = true)]
    public class SwitchAzureWebsiteSlotCommand : WebsiteBaseCmdlet
    {
        private string name;
        private string slot1;
        private string slot2;

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

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The first slot to swap.")]
        [ValidateNotNullOrEmpty]
        public string Slot1
        {
            get
            {
                return slot1;
            }
            set
            {
                // Convert to Unicode if necessary.
                slot1 = IdnHelper.GetUnicode(value);
            }
        }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The second slot to swap (production by default).")]
        [ValidateNotNullOrEmpty]
        public string Slot2
        {
            get
            {
                return slot2;
            }
            set
            {
                // Convert to Unicode if necessary.
                slot2 = IdnHelper.GetUnicode(value);
            }
        }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm web site swap")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                // If the website name was not specified as a parameter try to infer it
                Name = GitWebsite.ReadConfiguration().Name;
            }

            Name = WebsitesClient.GetWebsiteNameFromFullName(Name);
            List<Site> sites = WebsitesClient.GetWebsiteSlots(Name);
            if (sites.Count < 2)
            {
                throw new PSInvalidOperationException(Resources.SwapWebsiteSlotRequire2SlotsWarning);
            }

            string slot1 = Slot1;
            string slot2 = Slot2;

            string[] slots = sites.Select(site => WebsitesClient.GetSlotName(site.Name) ?? WebsiteSlotName.Production.ToString()).ToArray();

            if (slot1 == null && slot2 == null)
            {
                // If slots not specified make sure there are only 2 slots and use them
                if (slots.Length == 2)
                {
                    slot1 = slots[0];
                    slot2 = slots[1];
                }
                else
                {
                    throw new PSInvalidOperationException(Resources.SwapWebsiteSlotSpecifySlotsWarning);
                }
            }
            else if (slot1 != null && slot2 != null)
            {
                // If both slots specified make sure they exist and use them
                VerifySlotExists(slots, slot1);
                VerifySlotExists(slots, slot2);
            }
            else
            {
                // If only one slot is specified make sure it exists and that there are only 2 slots
                if (slots.Length == 2)
                {
                    if (slot1 != null)
                    {
                        VerifySlotExists(slots, slot1);
                    }
                    if (slot2 != null)
                    {
                        VerifySlotExists(slots, slot2);
                    }

                    slot1 = slots[0];
                    slot2 = slots[1];
                }
                else
                {
                    throw new PSInvalidOperationException(Resources.SwapWebsiteSlotSpecifySlotsWarning);
                }
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.SwapWebsiteSlotWarning, Name, slot1, slot2),
                Resources.SwappingWebsite,
                Name,
                () => WebsitesClient.SwitchSlots(sites.First().WebSpace, Name, slot1, slot2));
        }

        private static void VerifySlotExists(string[] slots, string slotToCheck)
        {
            if (!slots.Any(slot => String.Equals(slotToCheck, slot, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(String.Format(CultureInfo.CurrentCulture, Resources.SwapWebsiteSlotInvalidSlotWarning, slotToCheck));
            }
        }
    }
}
