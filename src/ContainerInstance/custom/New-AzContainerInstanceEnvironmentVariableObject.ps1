
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
Create a in-memory object for EnvironmentVariable
.Description
Create a in-memory object for EnvironmentVariable

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EnvironmentVariable
.Link
https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstanceEnvironmentVariableObject
#>
function New-AzContainerInstanceEnvironmentVariableObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EnvironmentVariable')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The name of the environment variable.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The value of the secure environment variable.")]
        [SecureString]
        $SecureValue,
        [Parameter(HelpMessage="The value of the environment variable.")]
        [string]
        $Value
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EnvironmentVariable]::New()
        if ($PSBoundParameters.ContainsKey('SecureValue')) {
            $psTxt = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $PSBoundParameters['SecureValue']
        }
        $Object.Name = $Name
        $Object.SecureValue = $psTxt
        $Object.Value = $Value
        return $Object
    }
}

