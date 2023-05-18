
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
Create a in-memory object for Extension
.Description
Create a in-memory object for Extension
#>
function New-AzCloudServiceExtensionObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.Extension')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Explicitly specify whether CRP can automatically upgrade typeHandlerVersion to higher minor versions when they become available.")]
        [bool]
        $AutoUpgradeMinorVersion,
        [Parameter(HelpMessage="Name.")]
        [string]
        $Name,
        [Parameter(HelpMessage="Protected settings for the extension which are encrypted before sent to the VM.")]
        [string]
        $ProtectedSetting,
        [Parameter(HelpMessage="Publisher.")]
        [string]
        $Publisher,
        [Parameter(HelpMessage="RolesAppliedTo.")]
        [string[]]
        $RolesAppliedTo,
        [Parameter(HelpMessage="Public settings for the extension.")]
        [string]
        $Setting,
        [Parameter(HelpMessage="Type.")]
        [string]
        $Type,
        [Parameter(HelpMessage="TypeHandlerVersion.")]
        [string]
        $TypeHandlerVersion
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.Extension]::New()

        $Object.AutoUpgradeMinorVersion = $AutoUpgradeMinorVersion
        $Object.Name = $Name
        $Object.ProtectedSetting = $ProtectedSetting
        $Object.Publisher = $Publisher
        $Object.RolesAppliedTo = $RolesAppliedTo
        $Object.Setting = $Setting
        $Object.Type = $Type
        $Object.TypeHandlerVersion = $TypeHandlerVersion
        return $Object
    }
}

