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

function Test-AvailableSslOptions
{
	$result = Get-AzApplicationGatewayAvailableSslOptions
	Assert-NotNull $result
	Assert-NotNull $result.DefaultPolicy

	$result = Get-AzApplicationGatewaySslPredefinedPolicy
	Assert-NotNull $result
	Assert-True { $result.Count -gt 0 }
	Assert-NotNull $result[0].MinProtocolVersion
	Assert-True { $result[0].CipherSuites -gt 0 }

	$result = Get-AzApplicationGatewaySslPredefinedPolicy -Name AppGwSslPolicy20170401
	Assert-NotNull $result
	Assert-NotNull $result.MinProtocolVersion
	Assert-True { $result.CipherSuites -gt 0 }
}

function Test-AvailableWafRuleSets
{
	$result = Get-AzApplicationGatewayAvailableWafRuleSets

	Assert-NotNull $result
	Assert-NotNull $result.Value
	Assert-True { $result.Value.Count -gt 0 }
	Assert-NotNull $result.Value[0].Name
	Assert-NotNull $result.Value[0].RuleSetType
	Assert-NotNull $result.Value[0].RuleSetVersion
	Assert-NotNull $result.Value[0].RuleGroups
	Assert-True { $result.Value[0].RuleGroups.Count -gt 0 }
	Assert-NotNull $result.Value[0].RuleGroups[0].RuleGroupName
	Assert-NotNull $result.Value[0].RuleGroups[0].Rules
	Assert-True { $result.Value[0].RuleGroups[0].Rules.Count -gt 0 }
	Assert-NotNull $result.Value[0].RuleGroups[0].Rules[0].RuleId
}

<#
.SYNOPSIS
Application gateway tests
#>
function Test-ApplicationGatewayCRUD
{
	param 
	( 
		$basedir = "./" 
	) 

	# Setup	

	$rglocation = Get-ProviderLocation ResourceManagement
	$resourceTypeParent = "Microsoft.Network/applicationgateways"
	$location = Get-ProviderLocation $resourceTypeParent

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$nicSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName
	$fipconfig01Name = Get-ResourceName
	$fipconfig02Name = Get-ResourceName
	$poolName = Get-ResourceName
	$nicPoolName = Get-ResourceName
	$frontendPort01Name = Get-ResourceName
	$frontendPort02Name = Get-ResourceName
	$poolSetting01Name = Get-ResourceName
	$poolSetting02Name = Get-ResourceName
	$listener01Name = Get-ResourceName
	$listener02Name = Get-ResourceName
	$rule01Name = Get-ResourceName
	$rule02Name = Get-ResourceName
	$nic01Name = Get-ResourceName
	$nic02Name = Get-ResourceName
	$authCertName = Get-ResourceName
	$probe01Name = Get-ResourceName
	$probe02Name = Get-ResourceName
	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"
	$customError403Url02 = "http://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"
	$customError502Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/502.htm"
	$customError502Url02 = "http://mycustomerrorpages.blob.core.windows.net/errorpages/502.htm"

	try 
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"} 
      
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$nicSubnet = New-AzVirtualNetworkSubnetConfig  -Name $nicSubnetName -AddressPrefix 10.0.2.0/24
		$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $nicSubnet
		$vnet = Get-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
 		$nicSubnet = Get-AzVirtualNetworkSubnetConfig -Name $nicSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

		# create 2 nics to add to backend
		$nic01 = New-AzNetworkInterface -Name $nic01Name -ResourceGroupName $rgname -Location $location -Subnet $nicSubnet
		$nic02 = New-AzNetworkInterface -Name $nic02Name -ResourceGroupName $rgname -Location $location -Subnet $nicSubnet

		# Create application gateway configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig01 = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfig01Name -PublicIPAddress $publicip
		$fipconfig02 = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfig02Name  -Subnet $gwSubnet

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses 1.1.1.1, 2.2.2.2, 3.3.3.3
		# Add an empty backend address pool
		$nicPool = New-AzApplicationGatewayBackendAddressPool -Name $nicPoolName

		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name  -Port 8080

		$authCertFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$authcert01 = New-AzApplicationGatewayAuthenticationCertificate -Name $authCertName -CertificateFile $authCertFilePath
		
		# Create match with undefined statuscode list
		$match1 = New-AzApplicationGatewayProbeHealthResponseMatch -Body "helloworld"
		Assert-Null $match1.StatusCodes
		
		$probe01 = New-AzApplicationGatewayProbeConfig -Name $probe01Name -Match $match1 -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		
		$connectionDraining01 = New-AzApplicationGatewayConnectionDraining -Enabled $True -DrainTimeoutInSec 42
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -Probe $probe01 -CookieBasedAffinity Disabled -ConnectionDraining $connectionDraining01
		Assert-NotNull $poolSetting01.connectionDraining
		Assert-AreEqual $True $poolSetting01.connectionDraining.Enabled
		Assert-AreEqual 42 $poolSetting01.connectionDraining.DrainTimeoutInSec
		Assert-NotNull $poolSetting01.Probe
		
		# Create match with empty statuscode list
		$match2 = New-AzApplicationGatewayProbeHealthResponseMatch -Body "helloworld" -StatusCode "200"
		Assert-NotNull $match2.StatusCodes
		$match2.StatusCodes.RemoveAt(0)
		Assert-AreEqual 0 $match2.StatusCodes.Count

		$probe02 = New-AzApplicationGatewayProbeConfig -Name $probe02Name -Match $match2 -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8

		$poolSetting02 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting02Name -Probe $probe02 -Port 443 -Protocol Https -CookieBasedAffinity Enabled -AuthenticationCertificates $authcert01
		Assert-Null $poolSetting02.connectionDraining
		Assert-NotNull $poolSetting02.Probe
		
		# Test setting and removing connectiondraining
		Set-AzApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02 -Enabled $False -DrainTimeoutInSec 3600
		$connectionDraining02 = Get-AzApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02
		Assert-NotNull $connectionDraining02
		Assert-AreEqual $False $connectionDraining02.Enabled
		Assert-AreEqual 3600 $connectionDraining02.DrainTimeoutInSec
		Remove-AzApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02
		Assert-Null $poolSetting02.connectionDraining

		$ce01_listener = New-AzApplicationGatewayCustomError -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01
		$ce02_listener = New-AzApplicationGatewayCustomError -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url01

		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig01 -FrontendPort $fp01
		$listener02 = New-AzApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig02 -FrontendPort $fp02 -CustomErrorConfiguration $ce01_listener,$ce02_listener

		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -BackendHttpSettings $poolSetting02 -HttpListener $listener02 -BackendAddressPool $pool

		$sku = New-AzApplicationGatewaySku -Name WAF_Medium -Tier WAF -Capacity 2

		$sslPolicy = New-AzApplicationGatewaySslPolicy -DisabledSslProtocols TLSv1_0, TLSv1_1

		$disabledRuleGroup1 = New-AzApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_41_sql_injection_attacks" -Rules 981318,981320
		$disabledRuleGroup2 = New-AzApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_35_bad_robots"
		$exclusion1 = New-AzApplicationGatewayFirewallExclusionConfig -Variable "RequestHeaderNames" -Operator "StartsWith" -Selector "xyz"
		$exclusion2 = New-AzApplicationGatewayFirewallExclusionConfig -Variable "RequestArgNames" -Operator "Equals" -Selector "a"
		$firewallConfig = New-AzApplicationGatewayWebApplicationFirewallConfiguration -Enabled $true -FirewallMode Prevention -RuleSetType "OWASP" -RuleSetVersion "2.2.9" -DisabledRuleGroups $disabledRuleGroup1,$disabledRuleGroup2 -RequestBodyCheck $true -MaxRequestBodySizeInKb 80 -FileUploadLimitInMb 70 -Exclusion $exclusion1,$exclusion2

		$ce01_appgw = New-AzApplicationGatewayCustomError -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$ce02_appgw = New-AzApplicationGatewayCustomError -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url02

		# Create Application Gateway
		$job = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probe01, $probe02 -BackendAddressPools $pool, $nicPool -BackendHttpSettingsCollection $poolSetting01,$poolSetting02 -FrontendIpConfigurations $fipconfig01, $fipconfig02 -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RequestRoutingRules $rule01, $rule02 -Sku $sku -SslPolicy $sslPolicy -AuthenticationCertificates $authcert01 -WebApplicationFirewallConfiguration $firewallConfig -AsJob -CustomErrorConfiguration $ce01_appgw,$ce02_appgw
		$job | Wait-Job
		$appgw = $job | Receive-Job

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		Assert-AreEqual "Running" $getgw.OperationalState
		Compare-ConnectionDraining $poolSetting01 $getgw.BackendHttpSettingsCollection[0]
		Compare-ConnectionDraining $poolSetting02 $getgw.BackendHttpSettingsCollection[1]
		Compare-WebApplicationFirewallConfiguration $firewallConfig $getgw.WebApplicationFirewallConfiguration

		# Check probes
		Assert-NotNull $getgw.Probes
		Assert-AreEqual 2 $getgw.Probes.Count

		# Check that statuscode of probe[0] is still null
		Assert-NotNull $getgw.Probes[0]
		Assert-NotNull $getgw.Probes[0].Match
		Assert-Null $getgw.Probes[0].Match.StatusCodes

		# Check that statuscode of probe[1] is still an emtpy list
		Assert-NotNull $getgw.Probes[1]
		Assert-NotNull $getgw.Probes[1].Match
		Assert-NotNull $getgw.Probes[1].Match.StatusCodes
		Assert-AreEqual 1 $getgw.Probes[1].Match.StatusCodes.Count

		# Get Application Gateway backend health with expanded resource
		# $job = Get-AzApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname -ExpandResource "backendhealth/applicationgatewayresource" -AsJob
		# $job | Wait-Job
		# $backendHealth = $job | Receive-Job
		# Assert-NotNull $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

		# Get Application Gateway backend health without expanded resource
		$backendHealth = Get-AzApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname
		Assert-Null $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

		# add nics to application gateway backend address pool
		$nicPool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $getgw -Name $nicPoolName
        $nic01.IpConfigurations[0].ApplicationGatewayBackendAddressPools.Add($nicPool);
        $nic02.IpConfigurations[0].ApplicationGatewayBackendAddressPools.Add($nicPool);

		 # set the nics
        $nic01 = $nic01 | Set-AzNetworkInterface
        $nic02 = $nic02 | Set-AzNetworkInterface

		# Add probe, request timeout, multi-hosting, URL routing to an existing gateway
		# Probe, request timeout, multi-site and URL routing are optional.
		$probeName = Get-ResourceName
		$frontendPort03Name = Get-ResourceName
		$poolSetting03Name = Get-ResourceName
		$listener03Name = Get-ResourceName
		$rule03Name = Get-ResourceName
		$PathRule01Name = Get-ResourceName
		$PathRule02Name = Get-ResourceName
		$urlPathMapName = Get-ResourceName

		# Adding new frontend port
		$getgw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $getgw -Name $frontendPort03Name  -Port 8888
		$fp = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $getgw -Name $frontendPort03Name 

		# Add new probe
		$getgw = Add-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeName -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$probe = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeName

		# Add listener that has hostname. Hostname is used to have multi-site
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $getgw -Name $fipconfig02Name
		$getgw = Add-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp -HostName TestHostName
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name
		$pool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $getgw -Name $poolName

		# Add new BackendHttpSettings that has probe and request timeout
		$getgw = Add-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name -Port 80 -Protocol Http -CookieBasedAffinity Disabled -Probe $probe -RequestTimeout 66
		$poolSetting = Get-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name

		# Add new URL routing
		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -BackendAddressPool $pool -BackendHttpSettings $poolSetting
		$videoPathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule02Name -Paths "/video" -BackendAddressPool $pool -BackendHttpSettings $poolSetting
		$getgw = Add-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $getgw -Name $urlPathMapName -PathRules $videoPathRule, $imagePathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting
		$urlPathMap = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $getgw -Name $urlPathMapName

		# Add new rule with URL routing
		$getgw = Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $getgw -Name $rule03Name -RuleType PathBasedRouting -HttpListener $listener -UrlPathMap $urlPathMap

		# Modify existing application gateway with new configuration
		$job = Set-AzApplicationGateway -ApplicationGateway $getgw -AsJob
		$job | Wait-Job

		# Modify WAF config and verify that it can be retrieved
		$getgw = Set-AzApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $getgw -Enabled $true -FirewallMode Detection
		$firewallConfig2 = Get-AzApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $getgw		

		# Verify that default values got set
		Assert-AreEqual "OWASP"  $firewallConfig2.RuleSetType
		Assert-AreEqual "3.0"  $firewallConfig2.RuleSetVersion
		Assert-AreEqual $null  $firewallConfig2.DisabledRuleGroups
		Assert-AreEqual $True  $firewallConfig2.RequestBodyCheck
		Assert-AreEqual 128  $firewallConfig2.MaxRequestBodySizeInKb
		Assert-AreEqual 100  $firewallConfig2.FileUploadLimitInMb
		Assert-AreEqual $null  $firewallConfig2.Exclusions

		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw

		Compare-WebApplicationFirewallConfiguration $firewallConfig2 $getgw.WebApplicationFirewallConfiguration

		# Remove probe, request timeout, multi-site and URL routing from exiting gateway
		# Probe, request timeout, multi-site, URL routing are optional
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Remove probe
		$getgw = Remove-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeName

		# Remove URL path map
		$getgw = Remove-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $getgw -Name $urlPathMapName

		# Modify BackendHttpSettings to remove probe and request timeout
		$getgw = Set-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name -Port 80 -Protocol Http -CookieBasedAffinity Disabled
		$poolSetting = Get-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $getgw -Name $poolSetting03Name

		# Modify listener to remove hostname. Hostname is used to have multi-site.
		$fp = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $getgw -Name $frontendPort03Name 
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $getgw -Name $fipconfig02Name
		$getgw = Set-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener03Name

		# Modify rule to remove URL rotuing
		$pool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $getgw -Name $poolName
		$getgw = Set-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $getgw -Name $rule03Name -RuleType basic -HttpListener $listener -BackendHttpSettings $poolSetting -BackendAddressPool $pool

		# Get Custom Error from listener and appgw
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		$ce = Get-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url01 $ce.CustomErrorPageUrl

		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$ce = Get-AzApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url02 $ce.CustomErrorPageUrl

		#Set Custom Error on listener and appgw
		#(403 error page on listener change from $customError403Url01 to $customError403Url02)
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		Set-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$updatedgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$updatedlistener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $updatedgw -Name $listener02Name
		$ce = Get-AzApplicationGatewayHttpListenerCustomError -HttpListener $updatedlistener -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url02 $ce.CustomErrorPageUrl

		#(403 error page on appgw change from $customError403Url02 to $customError403Url01)
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Set-AzApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01
		$updatedgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$ce = Get-AzApplicationGatewayCustomError -ApplicationGateway $updatedgw -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url01 $ce.CustomErrorPageUrl

		#Remove Custom Error from listener and appgw
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		Remove-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus502
		$updatedgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$updatedlistener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $updatedgw -Name $listener02Name
		$ceConfigs = Get-AzApplicationGatewayHttpListenerCustomError -HttpListener $updatedlistener
		Assert-AreEqual 1 $ceConfigs.count
		Assert-AreEqual HttpStatus403 $ceConfigs[0].StatusCode

		Remove-AzApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus502
		$updatedgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$ceConfigs = Get-AzApplicationGatewayCustomError -ApplicationGateway $updatedgw
		Assert-AreEqual 1 $ceConfigs.count
		Assert-AreEqual HttpStatus403 $ceConfigs[0].StatusCode

		#Add Custom Error on listener and appgw
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		Add-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url01
		$updatedgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$updatedlistener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $updatedgw -Name $listener02Name
		$ceConfigs = Get-AzApplicationGatewayHttpListenerCustomError -HttpListener $updatedlistener
		Assert-AreEqual 2 $ceConfigs.count

		Add-AzApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url02
		$updatedgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$ceConfigs = Get-AzApplicationGatewayCustomError -ApplicationGateway $updatedgw
		Assert-AreEqual 2 $ceConfigs.count

		# Modify existing application gateway with new configuration
		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw

		Assert-AreEqual "Running" $getgw.OperationalState

		# Stop Application Gateway
		$job = Stop-AzApplicationGateway -ApplicationGateway $getgw -AsJob
		$job | Wait-Job
		$getgw = $job | Receive-Job

		Assert-AreEqual "Stopped" $getgw.OperationalState

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway tests
#>
function Test-ApplicationGatewayCRUD2
{
	param 
	( 
		$basedir = "./" 
	) 

	# Setup	

	$rglocation = Get-ProviderLocation ResourceManagement
	$resourceTypeParent = "Microsoft.Network/applicationgateways"
	$location = Get-ProviderLocation $resourceTypeParent

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$nicSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$frontendPort02Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName
	$listener02Name = Get-ResourceName

	$sslCert01Name = Get-ResourceName
	$sslCert02Name = Get-ResourceName

	$poolName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName

	$redirect01Name = Get-ResourceName
	$redirect02Name = Get-ResourceName
	$redirect03Name = Get-ResourceName
	$rule01Name = Get-ResourceName
	$rule02Name = Get-ResourceName

	$probeHttpName = Get-ResourceName

	try 
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"} 
      
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$nicSubnet = New-AzVirtualNetworkSubnetConfig  -Name $nicSubnetName -AddressPrefix 10.0.2.0/24
		$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $nicSubnet
		$vnet = Get-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
 		$nicSubnet = Get-AzVirtualNetworkSubnetConfig -Name $nicSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		# frontend part
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert01Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert01 = New-AzApplicationGatewaySslCertificate -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 443
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Https -SslCertificate $sslCert01 -FrontendIPConfiguration $fipconfig -FrontendPort $fp01
		$listener02 = New-AzApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp02

		# backend part
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$match = New-AzApplicationGatewayProbeHealthResponseMatch -Body "helloworld" -StatusCode "200-300","404"
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -Match $match
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		# rule part
		$redirect01 = New-AzApplicationGatewayRedirectConfiguration -Name $redirect01Name -RedirectType Permanent -TargetListener $listener01

		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -HttpListener $listener02 -RedirectConfiguration $redirect01

		$sku = New-AzApplicationGatewaySku -Name Standard_Medium -Tier Standard -Capacity 2

		# security part
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RedirectConfiguration $redirect01 -RequestRoutingRules $rule01, $rule02 -Sku $sku -SslPolicy $sslPolicy -SslCertificates $sslCert01 -EnableHttp2

		# Check get/set/remove for RedirectConfiguration
		$redirect02 = Get-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirect01Name
		Assert-AreEqual $redirect01.TargetListenerId $redirect02.TargetListenerId
		$getgw = Set-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirect01Name -RedirectType Permanent -TargetUrl "https://www.bing.com"

		$getgw = Add-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $getgw -Name $redirect03Name -RedirectType Permanent -TargetListener $listener01 -IncludePath $true
		$getgw = Remove-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $getgw -Name $redirect03Name

		# Check EnableHttp2 flag is true
		Assert-AreEqual $getgw.EnableHttp2 $true

		# Get for SslPolicy
		$sslPolicy01 = Get-AzApplicationGatewaySslPolicy -ApplicationGateway $getgw
		Assert-AreEqual $sslPolicy.MinProtocolVersion $sslPolicy01.MinProtocolVersion

		# Set for sslPolicy
		$getgw = Set-AzApplicationGatewaySslPolicy -ApplicationGateway $getgw -PolicyType Predefined -PolicyName AppGwSslPolicy20170401

		# Get Match
		$probeHttp01 = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeHttpName
		Assert-AreEqual $probeHttp.Match.Body $probeHttp01.Match.Body

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Check SSLCertificates
		Assert-NotNull $getgw.SslCertificates[0]
		Assert-Null $getgw.SslCertificates[0].Password

		# Use Set/Add Certificate
		$getgw = Set-AzApplicationGatewaySslCertificate -ApplicationGateway $getgw -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01
		Assert-NotNull $getgw.SslCertificates[0].Password

		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw02 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert02Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert2.pfx"
		$getgw = Add-AzApplicationGatewaySslCertificate -ApplicationGateway $getgw -Name $sslCert02Name -CertificateFile $sslCert02Path -Password $pw02

		# Modify existing application gateway with new configuration
		$getgw.EnableHttp2 = $false
		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw

		# Check EnableHttp2 flag is false
		Assert-AreEqual $getgw.EnableHttp2 $false

		Assert-AreEqual "Running" $getgw.OperationalState

		# Check SSLCertificates again
		Assert-AreEqual 2 $getgw.SslCertificates.Count
		Assert-NotNull $getgw.SslCertificates[0]
		Assert-NotNull $getgw.SslCertificates[1]
		Assert-Null $getgw.SslCertificates[0].Password
		Assert-Null $getgw.SslCertificates[1].Password

		# Stop Application Gateway
		$getgw = Stop-AzApplicationGateway -ApplicationGateway $getgw

		Assert-AreEqual "Stopped" $getgw.OperationalState
 
		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayCRUDRewriteRuleSet
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "westus2"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName

	$poolName = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName
    $rewriteRuleSetName2 = Get-ResourceName
	$rule01Name = Get-ResourceName

	$probeHttpName = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#Rewrite Rule Set
		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "abc" -HeaderValue "def"
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet
		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRule
		
		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool -RewriteRuleSet $rewriteRuleSet

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2

		# autoscale configuration
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3

		# security part
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -SslPolicy $sslPolicy -TrustedRootCertificate $trustedRoot01 -AutoscaleConfiguration $autoscaleConfig -RewriteRuleSet $rewriteRuleSet

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -ApplicationGateway $getgw
        Assert-NotNull $rewriteRuleSet
        Assert-AreEqual $rewriteRuleSet.RewriteRules.Count 1
        Assert-NotNull $rewriteRuleSet.RewriteRules[0].ActionSet

        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw
        Assert-NotNull $rewriteRuleSet
        Assert-AreEqual $rewriteRuleSet.Count 1

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		Assert-NotNull $getgw.RewriteRuleSets
		Assert-AreEqual 1 $getgw.RewriteRuleSets.Count

		$reqRoutingRule = Get-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $getgw -Name $rule01Name
		Assert-NotNull $reqRoutingRule.RewriteRuleSet
		Assert-AreEqual $getgw.RewriteRuleSets[0].Id $reqRoutingRule.RewriteRuleSet.Id

		# check trusted root
		$trustedRoot02 = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $getgw -Name $trustedRootCertName
		Assert-NotNull $trustedRoot02
		Assert-AreEqual $getgw.BackendHttpSettingsCollection[0].TrustedRootCertificates.Count 1

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		# Get for zones
		Assert-AreEqual $getgw.Zones.Count 2

		# Get for SslPolicy
		$sslPolicy01 = Get-AzApplicationGatewaySslPolicy -ApplicationGateway $getgw
		Assert-AreEqual $sslPolicy.MinProtocolVersion $sslPolicy01.MinProtocolVersion

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		Set-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw -MinCapacity 3 -MaxCapacity 10
		$autoscaleConfig02 = Get-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig02
		Assert-AreEqual $autoscaleConfig02.MinCapacity 3
		Assert-AreEqual $autoscaleConfig02.MaxCapacity 10

		# Next setup preparation

		# remove autoscale config
		$getgw = Remove-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw -Force
		$getgw = Set-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 3 -ApplicationGateway $getgw

		# Set
		$getgw01 = Set-AzApplicationGateway -ApplicationGateway $getgw

		#Rewrite Rule Set
        Assert-ThrowsLike { Add-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw01 -Name $rewriteRuleSetName -RewriteRule $rewriteRule } "*already exists*"
		$rewriteRuleSet = Add-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw01 -Name $rewriteRuleSetName2 -RewriteRule $rewriteRule
        $getgw = Set-AzApplicationGateway -ApplicationGateway $getgw01

        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw
        Assert-NotNull $rewriteRuleSet
        Assert-AreEqual $rewriteRuleSet.Count 2

        $rewriteRuleSet = Remove-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw01 -Name $rewriteRuleSetName2
        $getgw = Set-AzApplicationGateway -ApplicationGateway $getgw01

        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw
        Assert-NotNull $rewriteRuleSet
        Assert-AreEqual $rewriteRuleSet.Count 1

		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "ghi" -HeaderValue "jkl"
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$rewriteRule2 = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet

        Assert-ThrowsLike { Set-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw -Name "fakeName" -RewriteRule $rewriteRule2 } "*does not exist*"
        $rewriteRuleSet = Set-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw -Name $rewriteRuleSetName -RewriteRule $rewriteRule2
        $getgw = Set-AzApplicationGateway -ApplicationGateway $getgw01
        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw -Name $rewriteRuleSetName
        Assert-AreEqual $rewriteRuleSet.RewriteRules[0].Name $rewriteRule2.Name

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw01
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 3
		Assert-AreEqual $sku01.Name Standard_v2
		Assert-AreEqual $sku01.Tier Standard_v2

		# Stop Application Gateway
		$getgw1 = Stop-AzApplicationGateway -ApplicationGateway $getgw01

		Assert-AreEqual "Stopped" $getgw1.OperationalState

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway v2 tests
#>
function Test-ApplicationGatewayCRUD3
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$identityName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName

	$poolName = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName

	$rule01Name = Get-ResourceName

	$probeHttpName = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create Managed Identity
		$identity = New-AzUserAssignedIdentity -Name $identityName -Location $location -ResourceGroup $rgname

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2

		# autoscale configuration
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3

		# security part
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# appgw identity
		$appgwIdentity = New-AzApplicationGatewayIdentity -UserAssignedIdentity $identity.Id

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Identity $appgwIdentity -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -SslPolicy $sslPolicy -TrustedRootCertificate $trustedRoot01 -AutoscaleConfiguration $autoscaleConfig

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# check trusted root
		$trustedRoot02 = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $getgw -Name $trustedRootCertName
		Assert-NotNull $trustedRoot02
		Assert-AreEqual $getgw.BackendHttpSettingsCollection[0].TrustedRootCertificates.Count 1

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		# Get for zones
		Assert-AreEqual $getgw.Zones.Count 2

		# Get for SslPolicy
		$sslPolicy01 = Get-AzApplicationGatewaySslPolicy -ApplicationGateway $getgw
		Assert-AreEqual $sslPolicy.MinProtocolVersion $sslPolicy01.MinProtocolVersion

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		# Next: Manual sku gateway

		# remove autoscale config
		$getgw = Remove-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw -Force
		$getgw = Set-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 3 -ApplicationGateway $getgw

		# Set
		$getgw01 = Set-AzApplicationGateway -ApplicationGateway $getgw

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw01
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 3
		Assert-AreEqual $sku01.Name Standard_v2
		Assert-AreEqual $sku01.Tier Standard_v2

		# Next: Set Identity on an existing gateway without identity
		# First, Removing identity from the gateway
		Remove-AzApplicationGatewayIdentity -ApplicationGateway $getgw01

		# Set Application Gateway
		$getgw02 = Set-AzApplicationGateway -ApplicationGateway $getgw01
		Assert-Null $(Get-AzApplicationGatewayIdentity -ApplicationGateway $getgw01)

		# Set identity
		Set-AzApplicationGatewayIdentity -ApplicationGateway $getgw02 -UserAssignedIdentityId $identity.Id

		# Set Application Gateway
		$getgw03 = Set-AzApplicationGateway -ApplicationGateway $getgw02
		$identity01 = Get-AzApplicationGatewayIdentity -ApplicationGateway $getgw03
		Assert-AreEqual $identity01.UserAssignedIdentities.Count 1
		Assert-NotNull $identity01.UserAssignedIdentities.Values[0].PrincipalId
		Assert-NotNull $identity01.UserAssignedIdentities.Values[0].ClientId


		# Stop Application Gateway
		$getgw1 = Stop-AzApplicationGateway -ApplicationGateway $getgw01

		Assert-AreEqual "Stopped" $getgw1.OperationalState

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Compare connectionDraining of backendhttpsettings
#>
function Compare-ConnectionDraining($expected, $actual)
{
	$expectedConnectionDraining = Get-AzApplicationGatewayConnectionDraining -BackendHttpSettings $expected
	$actualConnectionDraining = Get-AzApplicationGatewayConnectionDraining -BackendHttpSettings $actual

	if($expectedConnectionDraining) 
	{
		Assert-NotNull $actualConnectionDraining
		Assert-AreEqual $expectedConnectionDraining.Enabled $actualConnectionDraining.Enabled
		Assert-AreEqual $expectedConnectionDraining.DrainTimeoutInSec $actualConnectionDraining.DrainTimeoutInSec

	}
	else 
	{
		Assert-Null $actualConnectionDraining
	}
}

<#
.SYNOPSIS
Compare web application firewall configuration
#>
function Compare-WebApplicationFirewallConfiguration($expected, $actual) 
{
	if($expected) 
	{
		Assert-NotNull $actual
		Assert-AreEqual $expected.Enabled $actual.Enabled
		Assert-AreEqual $expected.FirewallMode $actual.FirewallMode
		Assert-AreEqual $expected.RuleSetType $actual.RuleSetType
		Assert-AreEqual $expected.RuleSetVersion $actual.RuleSetVersion
		Assert-AreEqual $expected.RequestBodyCheck $actual.RequestBodyCheck
		Assert-AreEqual $expected.MaxRequestBodySizeInKb $actual.MaxRequestBodySizeInKb
		Assert-AreEqual $expected.FileUploadLimitInMb $actual.FileUploadLimitInMb

		if($expected.DisabledRuleGroups) 
		{
			Assert-NotNull $actual.DisabledRuleGroups
			Assert-AreEqual $expected.DisabledRuleGroups.Count $actual.DisabledRuleGroups.Count
			for($i = 0; $i -lt $expected.DisabledRuleGroups.Count; $i++) 
			{
				Compare-DisabledRuleGroup $expected.DisabledRuleGroups[$i] $actual.DisabledRuleGroups[$i]
			}
		}
		else
		{
			Assert-Null $actual.DisabledRuleGroups
		}

		if($expected.Exclusions) 
		{
			Assert-NotNull $actual.Exclusions
			Assert-AreEqual $expected.Exclusions.Count $actual.Exclusions.Count
			for($i = 0; $i -lt $expected.Exclusions.Count; $i++) 
			{
				Compare-Exclusion $expected.Exclusions[$i] $actual.Exclusions[$i]
			}
		}
		else
		{
			Assert-Null $actual.Exclusions
		}
	}
	else
	{
		Assert-Null $actual
	}
}

<#
.SYNOPSIS
Compare disabled rule groups
#>
function Compare-DisabledRuleGroup($expected, $actual) 
{
	if($expected) 
	{
		Assert-NotNull $actual
		Assert-AreEqual $expected.RuleGroupName $actual.RuleGroupName

		if($expected.Rules) 
		{
			Assert-NotNull $actual.Rules
			Assert-AreEqualArray $expected.Rules $actual.Rules
		}
		else
		{
			Assert-Null $actual.Rules
		}
	}
	else
	{
		Assert-Null $actual
	}
}

<#
.SYNOPSIS
Compare Exclusion List
#>
function Compare-Exclusion($expected, $actual) 
{
	if($expected) 
	{
		Assert-NotNull $actual
		Assert-AreEqual $expected.MatchVariable $actual.MatchVariable
		Assert-AreEqual $expected.SelectorMatchOperator $actual.SelectorMatchOperator
		Assert-AreEqual $expected.Selector $actual.Selector
	}
	else
	{
		Assert-Null $actual
	}
}

<#
.SYNOPSIS
Compare application gateways
#>
function Compare-AzApplicationGateway($expected, $actual)
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

	for($i = 0; $i -lt $actual.BackendHttpSettingsCollection.Count; $i++) 
	{
		Compare-ConnectionDraining $expected.BackendHttpSettingsCollection[$i] $actual.BackendHttpSettingsCollection[$i] 
	}

	Assert-AreEqual $expected.HttpListeners.Count $actual.HttpListeners.Count
	Assert-AreEqual $expected.RequestRoutingRules.Count $actual.RequestRoutingRules.Count
	Assert-AreEqual $expected.RedirectConfigurations.Count $actual.RedirectConfigurations.Count
}

<#
.SYNOPSIS
Application gateway v2 tests
#>
function Test-ApplicationGatewayCRUDSubItems
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$vnetName2 = Get-ResourceName
	$gwSubnetName2 = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName
	$gipconfigname2 = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$frontendPort02Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$fipconfigName2 = Get-ResourceName
	$listener01Name = Get-ResourceName

	$poolName = Get-ResourceName
	$poolName2 = Get-ResourceName
	$poolSetting01Name = Get-ResourceName
	$authCertName = Get-ResourceName

	$sslCert01Name = Get-ResourceName

	$rule01Name = Get-ResourceName

	$probeName = Get-ResourceName

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"
	$customError403Url02 = "http://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"

	$redirectName = Get-ResourceName
	$urlPathMapName = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRuleName2 = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 10.0.0.0/24
		$vnet2 = New-AzvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -sku Basic

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		$sslPolicy = New-AzApplicationGatewaySslPolicy -DisabledSslProtocols TLSv1_0, TLSv1_1

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_Medium -Tier Standard -Capacity 2

		$match1 = New-AzApplicationGatewayProbeHealthResponseMatch -Body "helloworld"

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -SslPolicy $sslPolicy -EnableFIPS

		# Authentication certificate operations
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$certFilePath2 = $basedir + "/ScenarioTests/Data/auth-cert.pfx"
		$sslCert01Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert02Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert2.pfx"
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw02 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force

		# Add all possible
		$appgw = Add-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName -CertificateFile $certFilePath
		$appgw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2 -BackendIPAddresses 10.11.12.13
		$appgw = Add-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2 -SubnetId $gwSubnet.Id -PrivateIpAddress 10.0.0.7
		$appgw = Add-AzApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01
		$appgw = Add-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01
		$appgw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name -Port 8080
		$appgw = Add-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName -Match $match1 -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$listener01 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		$appgw = Add-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName -RedirectType Permanent -TargetListener $listener01 -IncludePath $true
		$poolSetting01 = Get-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting01Name
		$pool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName
		$videoPathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRuleName -Paths "/video" -BackendAddressPool $pool -BackendHttpSettings $poolSetting01
		$appgw = Add-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01

		# Call Add on already existing items
		Assert-ThrowsLike { Add-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName -CertificateFile $certFilePath } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2 -BackendIPAddresses 10.11.12.13 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2 -SubnetId $gwSubnet.Id -PrivateIpAddress 10.0.0.7 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name -Port 8080 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName -Match $match1 -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName -RedirectType Permanent -TargetListener $listener01 -IncludePath $true } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress } "*already exists*"

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-AreEqual $appgw.AuthenticationCertificates.Count 1
		Assert-AreEqual $appgw.BackendAddressPools.Count 2
		Assert-AreEqual $appgw.FrontendIpConfigurations.Count 2
		Assert-AreEqual $appgw.CustomErrorConfigurations.Count 1
		Assert-AreEqual $appgw.SslCertificates.Count 1
		Assert-AreEqual $appgw.FrontendPorts.Count 2
		Assert-AreEqual $appgw.Probes.Count 1
		Assert-AreEqual $appgw.RedirectConfigurations.Count 1
		Assert-AreEqual $appgw.UrlPathMaps.Count 1

		# Get all possible
		$gipconfig = Get-AzApplicationGatewayIPConfiguration -ApplicationGateway $appgw -Name $gipconfigname
		$authCert = Get-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName
		$aPool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2
		$feip = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2
		$customError = Get-AzApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403
		$sslCert = Get-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name
		$fPort = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name
		$probe = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName
		$rule = Get-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule01Name

		Assert-NotNull $gipconfig
		Assert-NotNull $authCert
		Assert-NotNull $aPool
		Assert-NotNull $feip
		Assert-NotNull $customError
		Assert-NotNull $sslCert
		Assert-NotNull $fPort
		Assert-NotNull $probe
		Assert-NotNull $rule

		# List all possible
		$gipconfigs = Get-AzApplicationGatewayIPConfiguration -ApplicationGateway $appgw
		$authCerts = Get-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw
		$aPools = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw
		$feips = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw
		$customErrors = Get-AzApplicationGatewayCustomError -ApplicationGateway $appgw
		$sslCerts = Get-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw
		$fPorts = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw
		$probes = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw
		$poolSettings = Get-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw
		$listeners = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw
		$redirects = Get-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw
		$rules = Get-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw
		$maps = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw

		Assert-NotNull $gipconfigs
		Assert-AreEqual $gipconfigs.Count 1
		Assert-NotNull $authCerts
		Assert-AreEqual $authCerts.Count 1
		Assert-NotNull $aPools
		Assert-NotNull $aPools.Count 2
		Assert-NotNull $feips
		Assert-AreEqual $feips.Count 2
		Assert-NotNull $customErrors
		Assert-AreEqual $customErrors.Count 1
		Assert-NotNull $sslCerts
		Assert-AreEqual $sslCerts.Count 1
		Assert-NotNull $fPorts
		Assert-AreEqual $fPorts.Count 2
		Assert-NotNull $probes
		Assert-AreEqual $probes.Count 1
		Assert-NotNull $rules
		Assert-AreEqual $rules.Count 1
		Assert-NotNull $maps
		Assert-AreEqual $maps.Count 1

		$appgwsRG = Get-AzApplicationGateway -ResourceGroupName $rgname
		$appgwsAll = Get-AzApplicationGateway

		# Set all possible
		$appgw = Set-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName -CertificateFile $certFilePath2
		$appgw = Set-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2 -BackendIPAddresses 10.11.12.14
		$appgw = Set-AzApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$appgw = Set-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name -Port 8081
		$appgw = Set-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName -Match $match1 -Protocol Http -HostName "probeset.com" -Path "/path/path1.htm" -Interval 87 -Timeout 87 -UnhealthyThreshold 7
		$poolSetting01 = Get-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting01Name
		$pool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName
		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRuleName2 -Paths "/image" -BackendAddressPool $pool -BackendHttpSettings $poolSetting01
		$appgw = Set-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName -PathRules $imagePathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01

		# Set items that doesn't exist
		Assert-ThrowsLike { Set-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name "fakeName" -CertificateFile $certFilePath2 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name "fakeName" -BackendIPAddresses 10.11.12.14 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus405 -CustomErrorPageUrl $customError403Url02 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name "fakeName" -Port 8081 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name "fakeName" -Match $match1 -Protocol Http -HostName "probeset.com" -Path "/path/path1.htm" -Interval 87 -Timeout 87 -UnhealthyThreshold 7 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name "fakeName" -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name "fakeName" -SubnetId $gwSubnet.Id -PrivateIpAddress 10.0.0.7 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name "fakeName" -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name "fakeName" -RedirectType Permanent -TargetListener $listener01 -IncludePath $true } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name "fakeName" -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name "fakeName" -CertificateFile $sslCert01Path -Password $pw01 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name "fakeName" -PathRules $imagePathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayIPConfiguration -ApplicationGateway $appgw -Name "fakeName" -Subnet $gwSubnet } "*does not exist*"

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		# Remove all possible
		Remove-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2
		Remove-AzApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName
		Remove-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2
		Remove-AzApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403
		Remove-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name
		Remove-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name
		Remove-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName
		Remove-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName
		Remove-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Remove-AzApplicationGatewaySslPolicy -ApplicationGateway $appgw -Force

		Assert-ThrowsLike { Remove-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $appgw -Force } "*doesn't have*"
		Assert-ThrowsLike { Remove-AzApplicationGatewaySslPolicy -ApplicationGateway $appgw -Force } "*doesn't have*"

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-Null $appgw.AuthenticationCertificates
		Assert-NotNull $appgw.BackendAddressPools
		Assert-NotNull $appgw.BackendAddressPools.Count 1
		Assert-NotNull $appgw.FrontendIpConfigurations
		Assert-AreEqual $appgw.FrontendIpConfigurations.Count 1
		Assert-Null $appgw.CustomErrorConfigurations
		Assert-Null $appgw.SslCertificates
		Assert-NotNull $appgw.FrontendPorts
		Assert-AreEqual $appgw.FrontendPorts.Count 1
		Assert-Null $appgw.Probes
		Assert-Null $appgw.RedirectConfigurations
		Assert-Null $appgw.UrlPathMaps
		Assert-Null $appgw.SslPolicy

		# Switch GatewayIpConfiguration, cannotjust add one more to test Add (Gateway must be created with one IP)
		# Need to stop gateway for this switching
		Stop-AzApplicationGateway -ApplicationGateway $appgw;
		Add-AzApplicationGatewayIPConfiguration -Name $gipconfigname2 -Subnet $gwSubnet2 -ApplicationGateway $appgw
		Assert-ThrowsLike { Add-AzApplicationGatewayIPConfiguration -Name $gipconfigname2 -Subnet $gwSubnet2 -ApplicationGateway $appgw } "*already exists*"
		Remove-AzApplicationGatewayIPConfiguration -Name $gipconfigname -ApplicationGateway $appgw
		Add-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2 -SubnetId $gwSubnet2.Id -PrivateIpAddress 10.0.0.7
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
		$ipConfig = Get-AzApplicationGatewayIPConfiguration -ApplicationGateway $appgw -Name $gipconfigname2
		Start-AzApplicationGateway -ApplicationGateway $appgw;

		# Switch subnet in IpConfigs
		Stop-AzApplicationGateway -ApplicationGateway $appgw;
		Set-AzApplicationGatewayIPConfiguration -Name $gipconfigname2 -Subnet $gwSubnet -ApplicationGateway $appgw
		Set-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName2 -Subnet $gwSubnet -ApplicationGateway $appgw -PrivateIpAddress 10.0.0.7
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		$result = Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force -PassThru

		Assert-ThrowsLike { Stop-AzApplicationGateway -ApplicationGateway $appgw } "*not found*"
		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $appgw } "*not found*"
		Assert-ThrowsLike { Start-AzApplicationGateway -ApplicationGateway $appgw } "*not found*"
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway v2 tests
#>
function Test-ApplicationGatewayCRUDSubItems2
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$vnetName2 = Get-ResourceName
	$gwSubnetName2 = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$frontendPort02Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName
	$listener02Name = Get-ResourceName
	$listener03Name = Get-ResourceName

	$poolName = Get-ResourceName
	$poolName02 = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName
	$poolSetting02Name = Get-ResourceName
	$probeName = Get-ResourceName

	$rule01Name = Get-ResourceName
	$rule02Name = Get-ResourceName

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"
	$customError403Url02 = "http://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"

	$urlPathMapName = Get-ResourceName
	$urlPathMapName2 = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRule01Name = Get-ResourceName
	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -RequireServerNameIndication false

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name WAF_v2 -Tier WAF_v2

		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		Assert-AreEqual $autoscaleConfig.MinCapacity 3

		$redirectConfig = New-AzApplicationGatewayRedirectConfiguration -Name $redirectName -RedirectType Permanent -TargetListener $listener01 -IncludePath $true -IncludeQueryString $true

		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "abc" -HeaderValue "def"
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet
		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRule

		$videoPathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRuleName -Paths "/video" -RedirectConfiguration $redirectConfig -RewriteRuleSet $rewriteRuleSet
		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -RedirectConfigurationId $redirectConfig.Id -RewriteRuleSetId $rewriteRuleSet.Id
		$urlPathMap = New-AzApplicationGatewayUrlPathMapConfig -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01
		$urlPathMap2 = New-AzApplicationGatewayUrlPathMapConfig -Name $urlPathMapName2 -PathRules $videoPathRule,$imagePathRule -DefaultRedirectConfiguration $redirectConfig -DefaultRewriteRuleSet $rewriteRuleSet
		$probe = New-AzApplicationGatewayProbeConfig -Name $probeName -Protocol Http -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -MinServers 1 -PickHostNameFromBackendHttpSettings

		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert01Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert = New-AzApplicationGatewaySslCertificate -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01,$fp02 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -AutoscaleConfiguration $autoscaleConfig -UrlPathMap $urlPathMap,$urlPathMap2 -RedirectConfiguration $redirectConfig -Probe $probe -SslCertificate $sslCert -RewriteRuleSet $rewriteRuleSet

		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$certFilePath2 = $basedir + "/ScenarioTests/Data/TrustedRootCertificate.cer"

		# Add
		$listener01 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		Add-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath
		Add-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01

		# Add to test Remove
		Add-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting02Name -Port 1234 -Protocol Http -CookieBasedAffinity Enabled -RequestTimeout 42 -HostName test -Path /test -AffinityCookieName test
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		$fp02 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name 
		$sslCert = Get-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestHostName -RequireServerNameIndication true -SslCertificate $sslCert
		$listener02 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name
		$fp02 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name 
		$sslCert = Get-AzApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener03Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestName -SslCertificate $sslCert
		$urlPathMap = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType PathBasedRouting -HttpListener $listener02 -UrlPathMap $urlPathMap

		# Add twice
		Assert-ThrowsLike { Add-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01 } "*already exists*"

		# Add unsupported
		Assert-ThrowsLike { Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName02 -BackendIPAddresses www.microsoft.com -BackendFqdns www.bing.com } "*At most one of*can be specified*"

		Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName02 -BackendFqdns www.bing.com,www.microsoft.com

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-NotNull $appgw.HttpListeners[0].CustomErrorConfigurations
		Assert-NotNull $appgw.TrustedRootCertificates
		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 2
		Assert-AreEqual $appgw.HttpListeners.Count 3
		Assert-AreEqual $appgw.RequestRoutingRules.Count 2

		# Get
		$trustedCert = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName
		Assert-NotNull $trustedCert

		# List
		$trustedCerts = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw
		Assert-NotNull $trustedCerts
		Assert-AreEqual $trustedCerts.Count 1

		# Set
		$listener01 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		Set-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $appgw -MinCapacity 2
		Set-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$disabledRuleGroup1 = New-AzApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_41_sql_injection_attacks" -Rules 981318,981320
		$disabledRuleGroup2 = New-AzApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_35_bad_robots"
		$exclusion1 = New-AzApplicationGatewayFirewallExclusionConfig -Variable "RequestHeaderNames" -Operator "StartsWith" -Selector "xyz"
		$exclusion2 = New-AzApplicationGatewayFirewallExclusionConfig -Variable "RequestArgNames" -Operator "Equals" -Selector "a"
		Set-AzApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $appgw -Enabled $true -FirewallMode Prevention -RuleSetType "OWASP" -RuleSetVersion "2.2.9" -DisabledRuleGroups $disabledRuleGroup1,$disabledRuleGroup2 -RequestBodyCheck $true -MaxRequestBodySizeInKb 80 -FileUploadLimitInMb 70 -Exclusion $exclusion1,$exclusion2
		Set-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath2

		# Set non-exiting
		Assert-ThrowsLike { Set-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus408 -CustomErrorPageUrl $customError403Url02 } "*does not exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name "fakeName" -CertificateFile $certFilePath } "*does not exist*"

		# Get Application Gateway backend health with expanded resource
		$job = Get-AzApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname -ExpandResource "backendhealth/applicationgatewayresource" -AsJob
		$job | Wait-Job
		$backendHealth = $job | Receive-Job
		Assert-NotNull $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-AreEqual $appgw.AutoscaleConfiguration.MinCapacity 2
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.Enabled $true
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.FirewallMode "Prevention"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RuleSetType "OWASP"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RuleSetVersion "2.2.9"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count 2
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RequestBodyCheck $true
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.MaxRequestBodySizeInKb 80
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.FileUploadLimitInMb 70
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.Exclusions.Count 2

		# Remove
		Remove-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName
		Remove-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting02Name
		Remove-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		Remove-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-Null $appgw.TrustedRootCertificates
		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 1
		Assert-AreEqual $appgw.RequestRoutingRules.Count 1
		Assert-AreEqual $appgw.HttpListeners.Count 2
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}
