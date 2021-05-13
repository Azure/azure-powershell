
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
Create a in-memory object for ContainerPort
.Description
Create a in-memory object for ContainerPort

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPort
.Link
https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstancePortObject
#>
function New-AzContainerInstancePortObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPort')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The port number exposed within the container group.")]
        [int]
        $Port,
        [Parameter(HelpMessage="The protocol associated with the port.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol])]
        [string]
        $Protocol
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPort]::New()

        $Object.Port = $Port
        $Object.Protocol = $Protocol
        return $Object
    }
}

