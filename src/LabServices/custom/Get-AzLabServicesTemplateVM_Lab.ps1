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
API to get the template vm for the lab.
.Description
API to get the template vm for the lab.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine
.Link
https://docs.microsoft.com/powershell/module/az.labservices/Get-AzLabServicesTemplateVM
#>
function Get-AzLabServicesTemplateVM_Lab {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab]
        ${Lab},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {
        $PSBoundParameters = $Lab.BindResourceParameters($PSBoundParameters)
        $PSBoundParameters.Remove("Lab") > $null

        return Az.LabServices\Get-AzLabServicesTemplateVM @PSBoundParameters
    }
    
    }
    