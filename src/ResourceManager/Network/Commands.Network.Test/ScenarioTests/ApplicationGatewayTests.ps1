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

	$rgname = "rg01"
	$appgwName = "appgw01"
	$vnetName = "vnet01"
	$subnetName = "subnet01"
	$publicIpName = "publicip01"
	$gipconfigname = "gatewayip01"
	$fipconfig01Name = "frontendip01"
	$fipconfig02Name = "frontendip02"
	$poolName = "pool01"
	$frontendPort01Name = "frontendport01"
	$frontendPort02Name = "frontendport02"
	$poolSetting01Name = "setting01"
	$poolSetting02Name = "setting02"
	$listener01Name = "listener01"
	$listener02Name = "listener02"
	$rule01Name = "rule01"
	$rule02Name = "rule02"
    
	try 
	{
		# Create the resource group
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{Name = "testtag"; Value = "APPGw tag"} 
      
		# Create the Virtual Network
		$subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
 
		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

		# Create application gateway configuration
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $subnet

		$fipconfig01 = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfig01Name -PublicIPAddress $publicip
		$fipconfig02 = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfig02Name  -Subnet $subnet

		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses 1.1.1.1, 2.2.2.2, 3.3.3.3

		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$fp02 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort02Name  -Port 8080

		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -CookieBasedAffinity Disabled 
		$poolSetting02 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting02Name -Port 80 -Protocol Http -CookieBasedAffinity Enabled

		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig01 -FrontendPort $fp01
		$listener02 = New-AzureRmApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig02 -FrontendPort $fp02

		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -BackendHttpSettings $poolSetting02 -HttpListener $listener02 -BackendAddressPool $pool

		$sku = New-AzureRmApplicationGatewaySku -Name Standard_Small -Tier Standard -Capacity 2

		# Create Application Gateway
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01, $poolSetting02 -FrontendIpConfigurations $fipconfig01, $fipconfig02  -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RequestRoutingRules $rule01, $rule02 -Sku $sku

		# Get Application Gateway
		$getgw =  Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname


		# Add probe, request timeout, multi-hosting, URL routing to an exisitng gateway
		# Probe, request timeout, multi-site and URL routing are optional.
		$probeName = "probe01"
		$frontendPort03Name = "frontendport03"
		$poolSetting03Name = "setting03"
		$listener03Name = "listener03"
		$rule03Name = "rule03"
		$PathRule01Name = "pathrule01"
		$PathRule02Name = "pathrule02"
		$urlPathMapName = "urlpathmap01"

		# Adding new frontend port
		$getgw = Add-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $getgw -Name $frontendPort03Name  -Port 8888
		$fp = Get-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $getgw -Name $frontendPort03Name 

		# Add new probe
		$getgw = Add-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeName -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$probe = Get-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeName

		# Add listener that has hostname. Hostname is used to have multi-site
		$fipconfig = Get-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $getgw -Name $fipconfig02Name
		$getgw = Add-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp -HostName TestHostName
		$listener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name
		$pool = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $getgw -Name $poolName

		# Add new BackendHttpSettings that has probe and request timeout
		$getgw = Add-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name -Port 80 -Protocol Http -CookieBasedAffinity Disabled -Probe $probe -RequestTimeout 66
		$poolSetting = Get-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name

		# Add new URL routing
		$imagePathRule = New-AzureRmApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -BackendAddressPool $pool -BackendHttpSettings $poolSetting
		$videoPathRule = New-AzureRmApplicationGatewayPathRuleConfig -Name $PathRule02Name -Paths "/video" -BackendAddressPool $pool -BackendHttpSettings $poolSetting
		$getgw = Add-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $getgw -Name $urlPathMapName -PathRules $videoPathRule, $imagePathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting
		$urlPathMap = Get-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $getgw -Name $urlPathMapName

		# Add new rule with URL routing
		$getgw = Add-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $getgw -Name $rule03Name -RuleType PathBasedRouting -HttpListener $listener -UrlPathMap $urlPathMap

		# Modify existing application gateway with new configuration
		Set-AzureRmApplicationGateway -ApplicationGateway $getgw

		# Remove probe, request timeout, multi-site and URL routing from exiting gateway
		# Probe, request timeout, multi-site, URL routing are optional
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Remove probe
		$getgw = Remove-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeName

		# Remove URL path map
		$getgw = Remove-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $getgw -Name $urlPathMapName

		# Modify BackendHttpSettings to remove probe and request timeout
		$getgw = Set-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name -Port 80 -Protocol Http -CookieBasedAffinity Disabled
		$poolSetting = Get-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name

		# Modify listener to remove hostname. Hostname is used to have multi-site.
		$fp = Get-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $getgw -Name $frontendPort03Name 
		$fipconfig = Get-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $getgw -Name $fipconfig02Name
		$getgw = Set-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp
		$listener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name

		# Modify rule to remove URL rotuing
		$pool = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $getgw -Name $poolName
		$getgw = Set-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $getgw -Name $rule03Name -RuleType basic -HttpListener $listener -BackendHttpSettings $poolSetting -BackendAddressPool $pool

		# Modify existing application gateway with new configuration
		Set-AzureRmApplicationGateway -ApplicationGateway $getgw

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