# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
API to get lab plan images.
.Description
API to get lab plan images.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage
.Link
https://docs.microsoft.com/powershell/module/az.labservices/get-azlabservicesplanimage
#>
function Get-AzLabServicesPlanImage_ListByDisplayName {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [System.String]
        ${LabPlanName},
   
        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${DisplayName},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {
        
        $PSBoundParameters.Add('Filter',"Properties/DisplayName eq '$($PSBoundParameters.DisplayName)'")
        $PSBoundParameters.Remove('DisplayName') > $null
        return Az.LabServices\Get-AzLabServicesPlanImage @PSBoundParameters
    }
    
}
    