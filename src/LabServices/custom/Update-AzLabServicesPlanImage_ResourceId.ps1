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

function Update-AzLabServicesPlanImage_ResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [System.String]
    ${ResourceId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
    # Is the image enabled
    ${EnabledState},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {
    $resourceHash = & $PSScriptRoot\Utilities\HandleImageResourceId.ps1 -ResourceId $ResourceId
    if ($resourceHash) {
        $resourceHash.Keys | ForEach-Object {
            $PSBoundParameters.Add($_, $($resourceHash[$_]))
        }
        $PSBoundParameters.Remove("ResourceId") > $null
        return Az.LabServices\Update-AzLabServicesPlanImage @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid Image Resource Id." -ErrorAction Stop
    }
}

}
