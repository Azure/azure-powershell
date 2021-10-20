
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
Create a in-memory object for Lab Services Save Image.
.Description
Create a in-memory object for Lab Services Save Image.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISaveImageBody
.Link
https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesSaveImageObject
#>
function New-AzLabServicesSaveImageObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISaveImageBody')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory)]
        [String]
        ${Name},

        [Parameter(Mandatory)]
        [String]
        ${VirtualMachineId}
    )

    process {

        $saveImageBody = @{
            name = $Name
            labVirtualMachineId = $VirtualMachineId
        }
        return $saveImageBody | ConvertTo-Json -Depth 10
    }
}
