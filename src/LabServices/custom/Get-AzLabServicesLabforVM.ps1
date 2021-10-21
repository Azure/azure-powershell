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
API to return the lab for a specific VM.
.Description
API to return the lab for a specific VM.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab
.Link
https://docs.microsoft.com/powershell/module/az.labservices/get-azlabserviceslabforvm
#>
function Get-AzLabServicesLabForVM {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ResourceId},
        
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}        
    )
    
    process {
        $PSBoundParameters = & $PSScriptRoot\Utilities\HandleVMResourceId.ps1 -ResourceId $ResourceId

        if ($PSBoundParameters) {
            $PSBoundParameters.Remove("VirtualMachineName") > $null
            $PSBoundParameters.Add("Name", $PSBoundParameters.LabName)
            $PSBoundParameters.Remove("LabName") > $null

            return Az.LabServices.private\Get-AzLabServicesLab_Get @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid Virtual Machine Resource Id." -ErrorAction Stop
        }
    }
}