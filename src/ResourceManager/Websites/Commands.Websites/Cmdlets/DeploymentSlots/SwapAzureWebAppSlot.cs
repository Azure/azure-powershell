
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


using Microsoft.Azure.Commands.WebApps.Utilities;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.DeploymentSlots
{
    /// <summary>
    /// this commandlet will let you swap two web app slots using ARM APIs
    /// </summary>
    [Cmdlet("Swap", "AzureRmWebAppSlot", SupportsShouldProcess = true)]
    public class SwapAzureWebAppSlot : WebAppBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Name of the source slot.")]
        [ValidateNotNullOrEmpty]
        public string SourceSlotName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Name of the destination slot.")]
        [ValidateNotNullOrEmpty]
        public string DestinationSlotName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Swap with preview action to use")]
        [ValidateNotNullOrEmpty]
        public SwapWithPreviewAction? SwapWithPreviewAction { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "Flag to determine if VNet should be preserved")]
        [ValidateNotNullOrEmpty]
        public bool? PreserveVnet { get; set; }

        public override void ExecuteCmdlet()
        {

            base.ExecuteCmdlet();

            string actionMessage;
            string processMessage;

            GetConfirmActionMessages(out actionMessage, out processMessage);

            this.ConfirmAction(
                true,
                actionMessage,
                processMessage,
                Name,
                () =>
                {

                    if (!SwapWithPreviewAction.HasValue)
                    {
                        WebsitesClient.SwapSlot(ResourceGroupName, Name, SourceSlotName, DestinationSlotName, PreserveVnet);
                    }
                    else
                    {
                        switch (SwapWithPreviewAction.Value)
                        {

                            case Utilities.SwapWithPreviewAction.ApplySlotConfig:
                                WebsitesClient.SwapSlotWithPreviewApplySlotConfig(ResourceGroupName, Name, SourceSlotName, DestinationSlotName, PreserveVnet);
                                break;

                            case Utilities.SwapWithPreviewAction.CompleteSlotSwap:
                                WebsitesClient.SwapSlot(ResourceGroupName, Name, SourceSlotName, DestinationSlotName, PreserveVnet);
                                break;

                            case Utilities.SwapWithPreviewAction.ResetSlotSwap:
                                WebsitesClient.SwapSlotWithPreviewResetSlotSwap(ResourceGroupName, Name, SourceSlotName);
                                break;

                        }
                    }
                });
        }

        private void GetConfirmActionMessages(out string actionMessage, out string processMessage)
        {
            actionMessage = string.Empty;
            processMessage = string.Empty;

            if (!SwapWithPreviewAction.HasValue)
            {
                actionMessage = string.Format("Regular swap: Are you sure you want to swap {0} slot with {1} slot", SourceSlotName, DestinationSlotName);
                processMessage = "Regular swap: Swapping the Web App slots";
            }
            else
            {
                switch (SwapWithPreviewAction.Value)
                {

                    case Utilities.SwapWithPreviewAction.ApplySlotConfig:
                        actionMessage = string.Format("Swap with preview: Applying slot config from {0} slot onto {1} slot", DestinationSlotName, SourceSlotName);
                        processMessage = "Swap with preview: Applying slot config from destination slot onto source slot";
                        break;

                    case Utilities.SwapWithPreviewAction.CompleteSlotSwap:
                        actionMessage = string.Format("Swap with preview: Completing the current on-going slot swap operation between {0} and {1} slots", SourceSlotName, DestinationSlotName);
                        processMessage = "Swap with preview: Completing the current on-going slot swap operation";
                        break;

                    case Utilities.SwapWithPreviewAction.ResetSlotSwap:
                        actionMessage = string.Format("Swap with preview: Resetting the current on-going slot swap operation between {0} and {1} slots", SourceSlotName, DestinationSlotName);
                        processMessage = "Swap with preview: Resetting the current on-going slot swap operation";
                        break;

                }
            }
        }
    }
}
