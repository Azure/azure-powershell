
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
Create a in-memory object for CloudServiceRoleProfileProperties
.Description
Create a in-memory object for CloudServiceRoleProfileProperties
#>
function New-AzCloudServiceRoleProfilePropertiesObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudServiceRoleProfileProperties')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Name of role profile.")]
        [string]
        $Name,
        [Parameter(HelpMessage="Specifies the number of role instances in the cloud service.")]
        [long]
        $SkuCapacity,
        [Parameter(HelpMessage="The sku name.")]
        [string]
        $SkuName,
        [Parameter(HelpMessage="SkuTier.")]
        [string]
        $SkuTier
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudServiceRoleProfileProperties]::New()

        $Object.Name = $Name
        $Object.SkuCapacity = $SkuCapacity
        $Object.SkuName = $SkuName
        $Object.SkuTier = $SkuTier
        return $Object
    }
}

