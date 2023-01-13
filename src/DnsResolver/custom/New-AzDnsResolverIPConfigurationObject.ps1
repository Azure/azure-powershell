
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
Create a in-memory object for IPConfiguration
.Description
Create a in-memory object for IPConfiguration

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IPConfiguration
.Link
https://docs.microsoft.com/powershell/module/az.dnsresolver/new-azdnsresolveripconfigurationobject
#>
function New-AzDnsResolverIPConfigurationObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IPConfiguration')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Private IP address of the IP configuration.")]
        [string]
        $PrivateIPAddress,
        [Parameter(HelpMessage="Private IP address allocation method.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.IPAllocationMethod]
        $PrivateIPAllocationMethod,
        [Parameter(HelpMessage="Resource ID.")]
        [string]
        $SubnetId
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IPConfiguration]::New()

        $Object.PrivateIPAddress = $PrivateIPAddress
        $Object.PrivateIPAllocationMethod = $PrivateIPAllocationMethod
        $Object.SubnetId = $SubnetId
        return $Object
    }
}

