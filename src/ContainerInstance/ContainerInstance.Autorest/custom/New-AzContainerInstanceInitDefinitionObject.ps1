
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
Create a in-memory object for InitContainerDefinition
.Description
Create a in-memory object for InitContainerDefinition
.Link
https://learn.microsoft.com/powershell/module/az.ContainerInstance/new-AzContainerInstanceInitDefinitionObject
#>
function New-AzContainerInstanceInitDefinitionObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.InitContainerDefinition')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.OutputBreakingChangeAttribute("Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.InitContainerDefinition", "15.0.0", "9.0.0", "2025/11/03", ReplacementCmdletOutputType = "Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.InitContainerDefinition", DeprecatedOutputProperties = ("EnvironmentVariable, InstanceViewEvent, VolumeMount, Command, CapabilityDrop, CapabilityAdd"), NewOutputProperties = ("EnvironmentVariable, InstanceViewEvent, VolumeMount, Command, CapabilityDrop, CapabilityAdd. This parameter will be changed from single object to 'List'."))]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The command to execute within the init container in exec form.")]
        [string[]]
        $Command,
        [Parameter(HelpMessage="The environment variables to set in the init container.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IEnvironmentVariable[]]
        $EnvironmentVariable,
        [Parameter(HelpMessage="The image of the init container.")]
        [string]
        $Image,
        [Parameter(Mandatory, HelpMessage="The name for the init container.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The volume mounts available to the init container.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IVolumeMount[]]
        $VolumeMount
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.InitContainerDefinition]::New()

        $Object.Command = $Command
        $Object.EnvironmentVariable = $EnvironmentVariable
        $Object.Image = $Image
        $Object.Name = $Name
        $Object.VolumeMount = $VolumeMount
        return $Object
    }
}

