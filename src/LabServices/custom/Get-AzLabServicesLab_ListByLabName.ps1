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

function Get-AzLabServicesLab_ListByLabName {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab])]
[CmdletBinding(PositionalBinding=$false)]
param(    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [System.String]
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [SupportsWildcards()]
    [System.String]
    ${WildcardName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {
    $currentLab = $PSBoundParameters.WildcardName
    $PSBoundParameters.Remove('WildcardName') > $null
    
    if ($(& $PSScriptRoot\Utilities\CheckForWildcards.ps1 -ResourceId $currentLab))
    {
        # Powershell Wildcards
        if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
            return Az.LabServices.private\Get-AzLabServicesLab_List1 @PSBoundParameters |  Where-Object { $_.Name -like $currentLab }
        } else {
            return Az.LabServices.private\Get-AzLabServicesLab_List @PSBoundParameters |  Where-Object { $_.Name -like $currentLab }
        }
    }
    else
    {        
        # Get all labs by name across RGs
        $PSBoundParameters.Add('Filter', "Name eq '$currentLab'")
        if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
            return Az.LabServices.private\Get-AzLabServicesLab_List1 @PSBoundParameters
        } else {
            return Az.LabServices.private\Get-AzLabServicesLab_List1 @PSBoundParameters
        }
    }
    
}

}
