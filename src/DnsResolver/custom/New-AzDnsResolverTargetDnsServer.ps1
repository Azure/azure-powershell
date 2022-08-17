
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
Create a in-memory object for Target DNS server
.Description
Create a in-memory object for Target DNS server

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.TargetDnsServer
.Link
https://docs.microsoft.com/powershell/module/az.dnsresolver/new-azdnsresolvertargetdnsserverobject
#>
function New-AzDnsResolverTargetDnsServerObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.TargetDnsServer')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="DNS server IP address.")]
        [string]
        $IPAddress,
        [Parameter(HelpMessage="DNS server port.")]
        [int]
        $Port = 53
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.TargetDnsServer]::New()

        $Object.IPAddress = $IPAddress
        $Object.Port = $Port
        return $Object
    }
}

