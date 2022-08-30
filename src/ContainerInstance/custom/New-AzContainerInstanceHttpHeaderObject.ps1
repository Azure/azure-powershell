
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
Create a in-memory object for HttpHeader
.Description
Create a in-memory object for HttpHeader
.Link
https://docs.microsoft.com/powershell/module/az.ContainerInstance/New-AzContainerInstanceHttpHeaderObject
#>
function New-AzContainerInstanceHttpHeaderObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.HttpHeader')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The header name.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The header value..")]
        [string]
        $Value
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.HttpHeader]::New()

        $Object.Name = $Name
        $Object.Value = $Value
        return $Object
    }
}

