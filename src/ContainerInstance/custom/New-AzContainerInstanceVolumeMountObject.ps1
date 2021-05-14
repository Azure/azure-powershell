
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
Create a in-memory object for VolumeMount
.Description
Create a in-memory object for VolumeMount

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.VolumeMount
.Link
https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstanceVolumeMountObject
#>
function New-AzContainerInstanceVolumeMountObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.VolumeMount')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The path within the container where the volume should be mounted. Must not contain colon (:).")]
        [string]
        $MountPath,
        [Parameter(Mandatory, HelpMessage="The name of the volume mount.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The flag indicating whether the volume mount is read-only.")]
        [bool]
        $ReadOnly
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.VolumeMount]::New()

        $Object.MountPath = $MountPath
        $Object.Name = $Name
        $Object.ReadOnly = $ReadOnly
        return $Object
    }
}

