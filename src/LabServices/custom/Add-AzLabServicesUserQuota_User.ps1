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
API to add additional user quota.
.Description
API to add additional user quota.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser
.Link
https://docs.microsoft.com/powershell/module/az.labservices/Add-AzLabServicesUserQuota
#>
function Add-AzLabServicesUserQuota_User {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.User]
        ${User},
   
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
        [System.TimeSpan]
        # The amount of usage quota time the user gets in addition to the current user quota.
        ${UsageQuotaToAddToExisting},

    
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}    

    )
    
    process {
        $PSBoundParameters.Remove('AdditionalUsageQuota') > $null
        $PSBoundParameters = $User.BindResourceParameters($PSBoundParameters)
        $quota = $User.AdditionalUsageQuota + $UsageQuotaToAddToExisting
        $PSBoundParameters.Add('AdditionalUsageQuota', $quota)
        $PSBoundParameters.Remove('User') > $null
        $PSBoundParameters.Remove('UsageQuotaToAddToExisting') > $null
        return Az.LabServices\Update-AzLabServicesUser @PSBoundParameters
    }
    
}
    