
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
Create a in-memory object for Container with no default values
.Description
Create a in-memory object for Container with no default values
.Link
https://learn.microsoft.com/powershell/module/az.ContainerInstance/New-AzContainerInstanceNoDefaultObject
#>
function New-AzContainerInstanceNoDefaultObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(
        [Parameter(Mandatory, HelpMessage="The user-provided name of the container instance.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The key value pairs dictionary in the config map to set in the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IConfigMapKeyValuePairs]
        $ConfigMapKeyValuePair
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container]::New()

        $Object.ConfigMapKeyValuePair = $ConfigMapKeyValuePair
        $Object.Name = $Name
        return $Object
    }
}

