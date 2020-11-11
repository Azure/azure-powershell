
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for DigitalTwinsIdentity
.Description
Create a in-memory object for DigitalTwinsIdentity

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.DigitalTwinsIdentity
.Link
https://docs.microsoft.com/en-us/powershell/module/az.DigitalTwins/new-AzDigitalTwinsDigitalTwinsIdentityObject
#>
function New-AzDigitalTwinsDigitalTwinsIdentityObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.DigitalTwinsIdentity')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Name of Endpoint Resource.")]
        [string]
        $EndpointName,
        [Parameter(HelpMessage="Resource identity path.")]
        [string]
        $Id,
        [Parameter(HelpMessage="Location of DigitalTwinsInstance.")]
        [string]
        $Location,
        [Parameter(HelpMessage="The name of the resource group that contains the DigitalTwinsInstance.")]
        [string]
        $ResourceGroupName,
        [Parameter(HelpMessage="The name of the DigitalTwinsInstance.")]
        [string]
        $ResourceName,
        [Parameter(HelpMessage="The subscription identifier.")]
        [string]
        $SubscriptionId
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.DigitalTwinsIdentity]::New()

        $Object.EndpointName = $EndpointName
        $Object.Id = $Id
        $Object.Location = $Location
        $Object.ResourceGroupName = $ResourceGroupName
        $Object.ResourceName = $ResourceName
        $Object.SubscriptionId = $SubscriptionId
        return $Object
    }
}

