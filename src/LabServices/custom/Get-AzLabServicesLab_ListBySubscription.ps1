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
API to get labs.
.Description
API to get labs.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab
.Link
https://docs.microsoft.com/powershell/module/az.labservices/get-azlabserviceslab
#>
function Get-AzLabServicesLab_ListBySubscription {
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
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {
        return Az.LabServices.internal\Get-AzLabServicesLab @PSBoundParameters
    }
    
}
    