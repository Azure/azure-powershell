
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
Create a in-memory object for CloudServiceVaultCertificate
.Description
Create a in-memory object for CloudServiceVaultCertificate

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultCertificate
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CloudService/new-AzCloudServiceCloudServiceVaultCertificateObject
#>
function New-AzCloudServiceVaultCertificateObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultCertificate')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="This is the URL of a certificate that has been uploaded to Key Vault as a secret..")]
        [string]
        $CertificateUrl
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultCertificate]::New()

        $Object.CertificateUrl = $CertificateUrl
        return $Object
    }
}

