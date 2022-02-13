
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
Create a in-memory object for ForestTrust
.Description
Create a in-memory object for ForestTrust

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServiceForestTrust
#>
function New-AzADDomainServiceForestTrust {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Friendly Name.")]
        [string]
        $FriendlyName,
        [Parameter(HelpMessage="Remote Dns ips.")]
        [string]
        $RemoteDnsIP,
        [Parameter(HelpMessage="Trust Direction.")]
        [string]
        $TrustDirection,
        [Parameter(HelpMessage="Trust Password.")]
        [System.Security.SecureString]
        $TrustPassword,
        [Parameter(HelpMessage="Trusted Domain FQDN.")]
        [string]
        $TrustedDomainFqdn
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust]::New()

        $Object.FriendlyName = $FriendlyName
        $Object.RemoteDnsIP = $RemoteDnsIP
        $Object.TrustDirection = $TrustDirection
        if ($PSBoundParameters.ContainsKey('TrustPassword')) {
            $psTxt = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $TrustPassword
            $Object.TrustPassword = $psTxt
        } 
        $Object.TrustedDomainFqdn = $TrustedDomainFqdn
        return $Object
    }
}

