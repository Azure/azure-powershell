
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
Create a in-memory object for LoadBalancerFrontendIPConfiguration
.Description
Create a in-memory object for LoadBalancerFrontendIPConfiguration
#>
function New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.LoadBalancerFrontendIPConfiguration')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Name of FrontendIpConfigration.")]
        [string]
        $Name,
        [Parameter(ParameterSetName="DefaultParameterSet", HelpMessage="Resource Id.")]
        [string]
        $PublicIPAddressId,
        [Parameter(ParameterSetName="PrivateIP", HelpMessage="Private IP Address")]
        [string]
        $PrivateIPAddress,
        [Parameter(ParameterSetName="PrivateIP", HelpMessage="Subnet ID")]
        [string]
        $SubnetId
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.LoadBalancerFrontendIPConfiguration]::New()

        $Object.Name = $Name
        if ($PSBoundParameters.ContainsKey("PublicIPAddressId")) {
            $Object.PublicIPAddressId = $PublicIPAddressId
        }
        if ($PSBoundParameters.ContainsKey("PrivateIPAddress")) {
            $Object.privateIPAddress = $PrivateIPAddress
            $Object.SubnetId = $SubnetId
        }
        
        return $Object
    }
}

