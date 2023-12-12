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
Create a in-memory object for Vault Secret Group
.Description
Create a in-memory object for Secret Group
#>

function New-AzCloudServiceVaultSecretGroupObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudServiceVaultSecretGroup')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(
        [Parameter(HelpMessage="Key Vault Resource Id.")]
        [string]
        $Id,

        [Parameter(HelpMessage="This is the URL of a certificate that has been uploaded to Key Vault as a secret.")]
        [string[]]
        $CertificateUrl
    )

    process {
              $certificateUrls = @()
              ForEach ($url in $CertificateUrl)
              {
                     $cloudServiceVaultCertificate = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudServiceVaultCertificate]::New()
                     $cloudServiceVaultCertificate.CertificateUrl = $url
                     $certificateUrls = $certificateUrls + $cloudServiceVaultCertificate
              }

              $cloudServiceVaultSecretGroup = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudServiceVaultSecretGroup]::New()
              $cloudServiceVaultSecretGroup.SourceVaultId = $Id
              $cloudServiceVaultSecretGroup.VaultCertificate = $certificateUrls

        return $cloudServiceVaultSecretGroup
    }
}
