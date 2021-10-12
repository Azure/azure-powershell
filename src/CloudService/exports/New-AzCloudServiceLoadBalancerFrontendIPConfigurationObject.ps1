
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for LoadBalancerFrontendIPConfiguration
.Description
Create a in-memory object for LoadBalancerFrontendIPConfiguration
.Example
PS C:\> $publicIP = Get-AzPublicIpAddress -ResourceGroupName 'ContosoOrg' -Name 'ContosoPublicIP'
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
.Example
# Create role profile object
PS C:\> $subnet = New-AzVirtualNetworkSubnetConfig -Name "WebTier" -AddressPrefix "10.0.0.0/24" -WarningAction SilentlyContinue 
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -privateIPAddress '10.0.0.6' -subnetId $Subnet.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfiguration
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceloadbalancerfrontendipconfigurationobject
#>
function New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfiguration])]
[CmdletBinding(DefaultParameterSetName='DefaultParameterSet', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of FrontendIpConfigration.
    ${Name},

    [Parameter(ParameterSetName='DefaultParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Resource Id.
    ${PublicIPAddressId},

    [Parameter(ParameterSetName='PrivateIP')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Private IP Address
    ${PrivateIPAddress},

    [Parameter(ParameterSetName='PrivateIP')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Subnet ID
    ${SubnetId}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            DefaultParameterSet = 'Az.CloudService.custom\New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject';
            PrivateIP = 'Az.CloudService.custom\New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
