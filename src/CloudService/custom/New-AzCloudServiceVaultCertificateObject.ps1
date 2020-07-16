
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
Create a in-memory object for VaultCertificate
.Description
Create a in-memory object for VaultCertificate

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.VaultCertificate
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CloudService/new-AzCloudServiceVaultCertificateObject
#>
function New-AzCloudServiceVaultCertificateObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.VaultCertificate')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="For Windows VMs, specifies the certificate store on the Virtual Machine to which the certificate should be added. The specified certificate store is implicitly in the LocalMachine account. <br><br>For Linux VMs, the certificate file is placed under the /var/lib/waagent directory, with the file name &lt;UppercaseThumbprint&gt;.crt for the X509 certificate file and &lt;UppercaseThumbprint&gt;.prv for private key. Both of these files are .pem formatted.")]
        [string]
        $CertificateStore,
        [Parameter(HelpMessage="This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: <br><br> {<br>  `"data`":`"<Base64-encoded-certificate>`",<br>  `"dataType`":`"pfx`",<br>  `"password`":`"<pfx-file-password>`"<br>}.")]
        [string]
        $CertificateUrl
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200601.VaultCertificate]::New()

        $Object.CertificateStore = $CertificateStore
        $Object.CertificateUrl = $CertificateUrl
        return $Object
    }
}

