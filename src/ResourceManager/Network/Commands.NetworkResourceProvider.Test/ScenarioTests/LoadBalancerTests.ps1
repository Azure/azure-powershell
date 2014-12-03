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
.SYNOPSIS
Tests creating new simple virtualNetwork.
#>
function Test-LoadBalancerCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
	$lbName = Get-ResourceName
	$frontendName = Get-ResourceName
	$backendAddressPoolName = Get-ResourceName
	$probeName = Get-ResourceName
	$inboundNatRuleName = Get-ResourceName
	$lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $nic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -Subnet $vnet.Properties.Subnets[0]

		$frontend = New-AzureLoadBalancerFrontendIpConfig -Name $frontendName -AllocationMethod Dynamic -Subnet $vnet.Properties.Subnets[0]
		$backendAddressPool = New-AzureLoadBalancerBackendAddressPoolConfigCmdlet -Name $backendAddressPoolName -BackendIpConfiguration $nic.Properties.IpConfigurations[0]
		$probe = New-AzureLoadBalancerProbeConfigCmdlet -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
		$inboundNatRule = New-AzureLoadBalancerInboundNatRuleConfigCmdlet -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -BackendIpConfiguration $nic.Properties.IpConfigurations[0] -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInSeconds 15 -EnableFloatingIP
		$lbrule = New-AzureLoadBalancerRuleConfigCmdlet -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInSeconds 15 -EnableFloatingIP
		$actualLb = New-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}