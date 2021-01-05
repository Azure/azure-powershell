
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
Create a in-memory object for ResourceForestSettings
.Description
Create a in-memory object for ResourceForestSettings

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServiceResourceForestSettingsObject
#>
function New-AzADDomainServiceResourceForestSettingObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Resource Forest.")]
        [string]
        $ResourceForest,
        [Parameter(HelpMessage="List of settings for Resource Forest.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[]]
        $ForestTrust
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings]::New()

        $Object.ResourceForest = $ResourceForest
        $Object.Setting = $ForestTrust
        return $Object
    }
}

