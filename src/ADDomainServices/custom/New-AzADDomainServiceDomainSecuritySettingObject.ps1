
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
Create a in-memory object for DomainSecuritySettings
.Description
Create a in-memory object for DomainSecuritySettings

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServiceDomainSecuritySettingsObject
#>
function New-AzADDomainServiceDomainSecuritySettingObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="A flag to determine whether or not NtlmV1 is enabled or disabled.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $NtlmV1,
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $SyncKerberosPassword,
        [Parameter(HelpMessage="A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $SyncNtlmPassword,
        [Parameter(HelpMessage="A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $SyncOnPremPassword,
        [Parameter(HelpMessage="A flag to determine whether or not TlsV1 is enabled or disabled.")]        
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $TlsV1
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings]::New()

        $Object.NtlmV1 = $NtlmV1
        $Object.SyncKerberosPassword = $SyncKerberosPassword
        $Object.SyncNtlmPassword = $SyncNtlmPassword
        $Object.SyncOnPremPassword = $SyncOnPremPassword
        $Object.TlsV1 = $TlsV1
        return $Object
    }
}

