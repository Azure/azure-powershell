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
API to get lab schedule.
.Description
API to get lab schedule.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule
.Link
https://docs.microsoft.com/powershell/module/az.labservices/get-azlabservicesschedule
#>
function Get-AzLabServicesSchedule_LabObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ResourceId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {

        $PSBoundParameters = & $PSScriptRoot\Utilities\HandleScheduleResourceId.ps1 -ResourceId $ResourceId

        if ($PSBoundParameters) {
            return Az.LabServices\Get-AzLabServicesSchedule @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid Schedule Resource Id." -ErrorAction Stop
        }

    }
    
    }
    