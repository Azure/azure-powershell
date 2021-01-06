
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
Create a in-memory object for LdapsSettings
.Description
Create a in-memory object for LdapsSettings

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServiceLdapsSettingsObject
#>
function New-AzADDomainServiceLdapsSettingObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $ExternalAccess,
        [Parameter(HelpMessage="A flag to determine whether or not Secure LDAP is enabled or disabled.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $Ldaps,
        [Parameter(HelpMessage="The path of certificate required to configure Secure LDAP.")]
        [System.String]
        $PfxCertificatePath,
        [Parameter(HelpMessage="The password to decrypt the provided Secure LDAP certificate pfx file.")]
        [System.Security.SecureString]
        $PfxCertificatePassword
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings]::New()

        $Object.ExternalAccess = $ExternalAccess
        $Object.Ldap = $Ldaps
        if ($PfxCertificatePath -and (Test-Path $PfxCertificatePath)) {
            $temp = Get-Content -Path $PfxCertificatePath -Encoding Byte
            $PfxCertificate =  [System.Convert]::ToBase64String($temp)
            $Object.PfxCertificate = $PfxCertificate
        }
        if ($PfxCertificatePassword) {
            $psTxt = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $PfxCertificatePassword
            $Object.PfxCertificatePassword = $psTxt
        }        

        return $Object
    }
}

