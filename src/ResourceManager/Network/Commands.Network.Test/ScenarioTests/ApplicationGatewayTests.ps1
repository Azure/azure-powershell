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
Application gateway tests
#>
function Test-ApplicationGatewayCRUD
{
	# Setup	

	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$domainNameLabel = Get-ResourceName
	$vnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$vnetGatewayConfigName = Get-ResourceName
	$rglocation = Get-ProviderLocation ResourceManagement
	$resourceTypeParent = "Microsoft.Network/applicationgateways"
	$location = Get-ProviderLocation $resourceTypeParent

	$gipconfigname = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$poolName = Get-ResourceName
	$poolSettingName = Get-ResourceName
	$frontendPortName = Get-ResourceName
	$listenerName = Get-ResourceName
	$ruleName = Get-ResourceName
	$appgwName = Get-ResourceName
    
	try 
	{
		# Create the resource group
		$resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
      
		# Create the Virtual Network
		$subnet = New-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnet = Get-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the Application Gateway
		$gipconfig = New-AzureApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $subnet
		$pool = New-AzureApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses 1.1.1.1, 2.2.2.2, 3.3.3.3
		$poolSetting = New-AzureApplicationGatewayBackendHttpSettings -Name $poolSettingName  -Port 80 -Protocol HTTP -CookieBasedAffinity Disabled
		$fp = New-AzureApplicationGatewayFrontendPort -Name $frontendPortName  -Port 80
		$fipconfig = New-AzureApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$listener = New-AzureApplicationGatewayHttpListener -Name $listenerName  -Protocol http -FrontendIPConfiguration $fipconfig -FrontendPort $fp
		$rule = New-AzureApplicationGatewayRequestRoutingRule -Name $ruleName -RuleType basic -BackendHttpSettings $poolSetting -HttpListener $listener -BackendAddressPool $pool
		$sku = New-AzureApplicationGatewaySku -Name Standard_Small -Tier Standard -Capacity 2

		$actual = New-AzureApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting -FrontendIpConfigurations $fipconfig  -GatewayIpConfigurations $gipconfig -FrontendPorts $fp -HttpListeners $listener -RequestRoutingRules $rule -Sku $sku
		$expected =  Get-AzureApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Compare-AzureApplicationGateway $actual $expected
		
		Stop-AzureApplicationGateway -ApplicationGateway $expected
		Remove-AzureApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Compare application gateways
#>
function Compare-AzureApplicationGateway($actual, $expected)
{
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.Sku.Name $actual.Sku.Name
	Assert-AreEqual $expected.Sku.Tier $actual.Sku.Tier
	Assert-AreEqual $expected.Sku.Capacity $actual.Sku.Capacity
	Assert-AreEqual $expected.FrontendPorts.Count $actual.FrontendPorts.Count
	Assert-AreEqual $expected.SslCertificates.Count $actual.SslCertificates.Count
	Assert-AreEqual $expected.BackendAddressPools.Count $actual.BackendAddressPools.Count
	Assert-AreEqual $expected.BackendHttpSettingsCollection.Count $actual.BackendHttpSettingsCollection.Count
	Assert-AreEqual $expected.HttpListeners.Count $actual.HttpListeners.Count
	Assert-AreEqual $expected.RequestRoutingRules.Count $actual.RequestRoutingRules.Count
}