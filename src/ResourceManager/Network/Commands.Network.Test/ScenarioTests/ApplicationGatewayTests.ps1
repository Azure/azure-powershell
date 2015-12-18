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

	$rglocation = Get-ProviderLocation ResourceManagement
	$resourceTypeParent = "Microsoft.Network/applicationgateways"
	$location = Get-ProviderLocation $resourceTypeParent

	$rgname = "kagarg"
	$vnetName = "vnet01"
	$subnetName = "subnet01"
	$publicIpName = "publicip01" 
	$gipconfigname = "gatewayip01"
	$fipconfigName = "frontendip01"
	$poolName = "pool01"
	$frontendPort01Name = "frontendport01"
	$frontendPort02Name = "frontendport02"
	$poolSetting01Name = "setting01"
	$poolSetting02Name = "setting02"
	$probeName ="probe01"
	$listener01Name = "listener01"
	$listener02Name = "listener02"
	$rule01Name = "rule01"
	$rule02Name = "rule02"
	$appgwName = "appgw01"
    
	try 
	{
		# Create the resource group
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{Name = "testtag"; Value = "PS testing app gw"} 
      
		# Create the Virtual Network
		$subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
 
		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic 
 
		# Create application gateway configuration
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $subnet
		$fipconfig = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses 1.1.1.1, 2.2.2.2, 3.3.3.3
		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$fp02 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort02Name  -Port 8080
		$probe = New-AzureRmApplicationGatewayProbeConfig -Name $probeName -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol HTTP -CookieBasedAffinity Disabled -Probe $probe -RequestTimeout 66
		$poolSetting02 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting02Name -Port 80 -Protocol HTTP -CookieBasedAffinity Disabled
		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01
		$listener02 = New-AzureRmApplicationGatewayHttpListener -Name $listener02Name -Protocol http -FrontendIPConfiguration $fipconfig -FrontendPort $fp02
		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -BackendHttpSettings $poolSetting02 -HttpListener $listener02 -BackendAddressPool $pool
		$sku = New-AzureRmApplicationGatewaySku -Name Standard_Small -Tier Standard -Capacity 2

		# Create Application Gateway
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -Probes $probe -BackendHttpSettingsCollection $poolSetting01, $poolSetting02 -FrontendIpConfigurations $fipconfig  -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RequestRoutingRules $rule01, $rule02 -Sku $sku
 
		# Get Application Gateway
		$getgw =  Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
 
		# Start Application Gateway
		Start-AzureRmApplicationGateway -ApplicationGateway $getgw

		# Stop Application Gateway
		Stop-AzureRmApplicationGateway -ApplicationGateway $getgw
 
		# Delete Application Gateway
		Remove-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
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
function Compare-AzureRmApplicationGateway($actual, $expected)
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