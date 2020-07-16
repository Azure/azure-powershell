
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
Create a in-memory object for VaultSecretGroup
.Description
Create a in-memory object for VaultSecretGroup

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.VaultSecretGroup
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CloudService/new-AzCloudServiceVaultSecretGroupObject
#>
function New-AzCloudServiceVaultSecretGroupObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.VaultSecretGroup')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Resource Id.")]
        [string]
        $SourceVaultId,
        [Parameter(HelpMessage="The list of key vault references in SourceVault which contain certificates.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.IVaultCertificate[]]
        $VaultCertificate
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.VaultSecretGroup]::New()

        $Object.SourceVaultId = $SourceVaultId
        $Object.VaultCertificate = $VaultCertificate
        return $Object
    }
}

