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

	$result = Get-AzApplicationGatewaySslPredefinedPolicy -Name AppGwSslPolicy*
	Assert-NotNull $result
	Assert-True { $result.Count -gt 0 }
	Assert-NotNull $result[0].MinProtocolVersion
	Assert-True { $result[0].CipherSuites -gt 0 }
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

function Test-WafDynamicManifest
{
	$location = "westus";
	$result = Get-AzApplicationGatewayWafDynamicManifest -Location $location
	# need to add the correct path - alon
	Assert-NotNull $result
	Assert-NotNull $result.defaultRuleSetType
	Assert-NotNull $result.defaultRuleSetVersion
	Assert-NotNull $result.availableRuleSets[0].RuleSetType
	Assert-NotNull $result.availableRuleSets[0].RuleSetVersion
	Assert-NotNull $result.availableRuleSets[0].tiers[0]
	Assert-NotNull $result.availableRuleSets[0].RuleGroups
	Assert-True { $result.availableRuleSets[0].RuleGroups.Count -gt 0 }
	Assert-NotNull $result.availableRuleSets[0].RuleGroups[0].RuleGroupName
	Assert-NotNull $result.availableRuleSets[0].RuleGroups[0].Rules
	Assert-True { $result.availableRuleSets[0].RuleGroups[0].Rules.Count -gt 0 }
	Assert-NotNull $result.availableRuleSets[0].RuleGroups[0].Rules[0].RuleId
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
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
	$customError403Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"
	$customError502Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/502-another.htm"
	$customError502Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/502.htm"

	try 
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"} 
      
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$nicSubnet = New-AzVirtualNetworkSubnetConfig  -Name $nicSubnetName -AddressPrefix 10.0.2.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $nicSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
 		$nicSubnet = Get-AzVirtualNetworkSubnetConfig -Name $nicSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -sku Basic

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

		<#
		Tested on Azure Portal CloudShell against a V2 gateway and got the same error that this test gets when listing gateways...
		Get-AzApplicationGateway: Resource provider 'Microsoft.Network' failed to return collection response for type 'applicationGateways'.

		# List ApplicationGateway
		$getgw = Get-AzApplicationGateway -Name $appgwName

		Assert-AreEqual "Running" $getgw[0].OperationalState
		Compare-ConnectionDraining $poolSetting01 $getgw[0].BackendHttpSettingsCollection[0]
		Compare-ConnectionDraining $poolSetting02 $getgw[0].BackendHttpSettingsCollection[1]
		Compare-WebApplicationFirewallConfiguration $firewallConfig $getgw[0].WebApplicationFirewallConfiguration

		$getgw = Get-AzApplicationGateway -Name ($appgwName + "*")

		Assert-AreEqual "Running" $getgw.OperationalState
		Compare-ConnectionDraining $poolSetting01 $getgw.BackendHttpSettingsCollection[0]
		Compare-ConnectionDraining $poolSetting02 $getgw.BackendHttpSettingsCollection[1]
		Compare-WebApplicationFirewallConfiguration $firewallConfig $getgw.WebApplicationFirewallConfiguration
		
		#>

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
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $nicSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
 		$nicSubnet = Get-AzVirtualNetworkSubnetConfig -Name $nicSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -sku Basic

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
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

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
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -Zone 1,2 -location $location -AllocationMethod Static -sku Standard

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
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -port 1234
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#Rewrite Rule Set
		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "abc" -HeaderValue "def"
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet
		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRule
		
		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool -RewriteRuleSet $rewriteRuleSet

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
		$getgw = Set-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2 -ApplicationGateway $getgw

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
		Assert-AreEqual $sku01.Capacity 2
		Assert-AreEqual $sku01.Name Standard_v2
		Assert-AreEqual $sku01.Tier Standard_v2

		# check probe
		$probe01 = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw01
		Assert-NotNull $probe01
		Assert-AreEqual $probe01.Port 1234
		Assert-AreEqual $probe01.Host "probe.com"
		Assert-AreEqual $probe01.Path "/path/path.htm"
		Assert-AreEqual $probe01.Interval 89
		Assert-AreEqual $probe01.Timeout 88
		Assert-AreEqual $probe01.UnhealthyThreshold 8

		Assert-ThrowsLike { Set-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw01 -Name "fakeName" -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -port 1234} "*does not exist*"
		Assert-ThrowsLike { Add-AzApplicationGatewayProbeConfig -ApplicationGateway $getgw01 -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -port 1234} "*already exists*"

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

function Test-ApplicationGatewayCRUDRewriteRuleSetWithConditions
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard -Zone 1,2

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = Join-Path $basedir "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#Rewrite Rule Set
		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "abc" -HeaderValue "def"
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$condition = New-AzApplicationGatewayRewriteRuleCondition -Variable "var_request_uri" -Pattern "http" -IgnoreCase
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet -RuleSequence 102 -Condition $condition
		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRule
		
		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool -RewriteRuleSet $rewriteRuleSet

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
		Assert-NotNull $rewriteRuleSet.RewriteRules[0].Conditions

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
		$getgw = Set-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2 -ApplicationGateway $getgw

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
		$condition = New-AzApplicationGatewayRewriteRuleCondition -Variable "var_http_method" -Pattern "get" -IgnoreCase
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$rewriteRule2 = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet -RuleSequence 101 -Condition $condition

        Assert-ThrowsLike { Set-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw -Name "fakeName" -RewriteRule $rewriteRule2 } "*does not exist*"
        $rewriteRuleSet = Set-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw -Name $rewriteRuleSetName -RewriteRule $rewriteRule2
        $getgw = Set-AzApplicationGateway -ApplicationGateway $getgw01
        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $getgw -Name $rewriteRuleSetName
        Assert-AreEqual $rewriteRuleSet.RewriteRules[0].Name $rewriteRule2.Name

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw01
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 2
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

function Test-ApplicationGatewayCRUDRewriteRuleSetWithUrlConfiguration
{
    param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"
	$customError403Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"

	$urlPathMapName = Get-ResourceName
	$urlPathMapName2 = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRule01Name = Get-ResourceName
	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 81

		# Create a firewall policy for http listener
		$listenerPolicyName = "listenerhttpPolicy"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 300 
		New-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$httpPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $httpPolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $httpPolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $httpPolicy.PolicySettings.State  $policySetting.State

		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -RequireServerNameIndication false -FirewallPolicy $httpPolicy

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		# sku
		$sku = New-AzApplicationGatewaySku -Name WAF_v2 -Tier WAF_v2

		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		Assert-AreEqual $autoscaleConfig.MinCapacity 3

		$headerConfiguration1 = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "abc" -HeaderValue "def"
		#url configuration with modified path only
		$urlConfiguration1 = New-AzApplicationGatewayRewriteRuleUrlConfiguration -ModifiedPath "/abc"
		$actionSet1 = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration1 -UrlConfiguration $urlConfiguration1
		$rewriteRule1 = New-AzApplicationGatewayRewriteRule -Name "rewriterule1" -ActionSet $actionSet1

		#url configuration with modified path and query string
		$urlConfiguration2 = New-AzApplicationGatewayRewriteRuleUrlConfiguration -ModifiedPath "/def" -ModifiedQueryString "a=b&c=d%20f"
		$actionSet2 = New-AzApplicationGatewayRewriteRuleActionSet -UrlConfiguration $urlConfiguration2
		$rewriteRule2 = New-AzApplicationGatewayRewriteRule -Name "rewriterule2" -ActionSet $actionSet2

	    #url configuration with query string only
		$urlConfiguration3 = New-AzApplicationGatewayRewriteRuleUrlConfiguration -ModifiedQueryString "a=b&c=d%20f1"
		$actionSet3 = New-AzApplicationGatewayRewriteRuleActionSet -UrlConfiguration $urlConfiguration3
		$rewriteRule3 = New-AzApplicationGatewayRewriteRule -Name "rewriterule3" -ActionSet $actionSet3

	    #url configuration with query string, path and reroute
		$urlConfiguration4 = New-AzApplicationGatewayRewriteRuleUrlConfiguration -ModifiedPath "/def2" -ModifiedQueryString "a=b&c=d%20f12" -Reroute
		$actionSet4 = New-AzApplicationGatewayRewriteRuleActionSet -UrlConfiguration $urlConfiguration4
		$rewriteRule4 = New-AzApplicationGatewayRewriteRule -Name "rewriterule4" -ActionSet $actionSet4

		$rewriteRules = New-Object System.Collections.ArrayList

		$rewriteRules.Add($rewriteRule1);
		$rewriteRules.Add($rewriteRule2);
		$rewriteRules.Add($rewriteRule3);
		$rewriteRules.Add($rewriteRule4);

		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRules

		$videoPathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRuleName -Paths "/video" -RewriteRuleSet $rewriteRuleSet -BackendAddressPool $pool -BackendHttpSettings $poolSetting01
		Assert-AreEqual $videoPathRule.RewriteRuleSet.Id $rewriteRuleSet.Id

		$urlPathMap = New-AzApplicationGatewayUrlPathMapConfig -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01

		$probe = New-AzApplicationGatewayProbeConfig -Name $probeName -Protocol Http -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -MinServers 1 -PickHostNameFromBackendHttpSettings

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule  -Name $rule01Name -RuleType PathBasedRouting -Priority 101 -HttpListener $listener01 -UrlPathMap $urlPathMap

		#Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01,$fp02 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -AutoscaleConfiguration $autoscaleConfig -UrlPathMap $urlPathMap -RedirectConfiguration $redirectConfig -Probe $probe -RewriteRuleSet $rewriteRuleSet

		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 1
		Assert-AreEqual $appgw.HttpListeners.Count 1
		Assert-AreEqual $appgw.RequestRoutingRules.Count 1

		Assert-NotNull $appgw.RewriteRuleSets
		Assert-AreEqual 1 $appgw.RewriteRuleSets.Count
		Assert-AreEqual 4 $appgw.RewriteRuleSets.RewriteRules.Count

		Assert-AreEqual "rewriterule1" $appgw.RewriteRuleSets.RewriteRules[0].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[0].ActionSet
		Assert-AreEqual "/abc" $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedPath
		Assert-Null $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.Reroute

		Assert-AreEqual "rewriterule2" $appgw.RewriteRuleSets.RewriteRules[1].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[1].ActionSet
		Assert-AreEqual "/def" $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f" $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.Reroute

	    Assert-AreEqual "rewriterule3" $appgw.RewriteRuleSets.RewriteRules[2].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[2].ActionSet
		Assert-Null $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f1" $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.Reroute

		Assert-AreEqual "rewriterule4" $appgw.RewriteRuleSets.RewriteRules[3].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[3].ActionSet
		Assert-AreEqual "/def2" $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f12" $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $true $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.Reroute

		# Get Application Gateway
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

        Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 1
		Assert-AreEqual $appgw.HttpListeners.Count 1
		Assert-AreEqual $appgw.RequestRoutingRules.Count 1

		Assert-NotNull $appgw.RewriteRuleSets
		Assert-AreEqual 1 $appgw.RewriteRuleSets.Count
		Assert-AreEqual 4 $appgw.RewriteRuleSets.RewriteRules.Count

		Assert-AreEqual "rewriterule1" $appgw.RewriteRuleSets.RewriteRules[0].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[0].ActionSet
		Assert-AreEqual "/abc" $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedPath
		Assert-Null $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.Reroute

		Assert-AreEqual "rewriterule2" $appgw.RewriteRuleSets.RewriteRules[1].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[1].ActionSet
		Assert-AreEqual "/def" $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f" $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.Reroute

	    Assert-AreEqual "rewriterule3" $appgw.RewriteRuleSets.RewriteRules[2].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[2].ActionSet
		Assert-Null $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f1" $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.Reroute

		Assert-AreEqual "rewriterule4" $appgw.RewriteRuleSets.RewriteRules[3].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[3].ActionSet
		Assert-AreEqual "/def2" $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f12" $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $true $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.Reroute

		# Updating Url Configuration
		$appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedPath = "/abc1"
		$appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedQueryString = "a=b&c=d"

		$appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.Reroute = $false

		# Adding listener and request routing rule to start slow path update
		$listener02 = New-AzApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -RequireServerNameIndication false
		$appgw.HttpListeners.Add($listener02)
		$rule02 = New-AzApplicationGatewayRequestRoutingRule  -Name $rule02Name -RuleType PathBasedRouting -Priority 102 -HttpListener $listener02 -UrlPathMap $urlPathMap
		$appgw.RequestRoutingRules.Add($rule02)

		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 1
		Assert-AreEqual $appgw.HttpListeners.Count 2
		Assert-AreEqual $appgw.RequestRoutingRules.Count 2

		Assert-NotNull $appgw.RewriteRuleSets
		Assert-AreEqual 1 $appgw.RewriteRuleSets.Count
		Assert-AreEqual 4 $appgw.RewriteRuleSets.RewriteRules.Count

		Assert-AreEqual "rewriterule1" $appgw.RewriteRuleSets.RewriteRules[0].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[0].ActionSet
		Assert-AreEqual "/abc1" $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d" $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[0].ActionSet.UrlConfiguration.Reroute

		Assert-AreEqual "rewriterule2" $appgw.RewriteRuleSets.RewriteRules[1].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[1].ActionSet
		Assert-AreEqual "/def" $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f" $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[1].ActionSet.UrlConfiguration.Reroute

	    Assert-AreEqual "rewriterule3" $appgw.RewriteRuleSets.RewriteRules[2].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[2].ActionSet
		Assert-Null $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f1" $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[2].ActionSet.UrlConfiguration.Reroute

		Assert-AreEqual "rewriterule4" $appgw.RewriteRuleSets.RewriteRules[3].Name
		Assert-NotNull $appgw.RewriteRuleSets.RewriteRules[3].ActionSet
		Assert-AreEqual "/def2" $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.ModifiedPath
		Assert-AreEqual "a=b&c=d%20f12" $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.ModifiedQueryString
		Assert-AreEqual $false $appgw.RewriteRuleSets.RewriteRules[3].ActionSet.UrlConfiguration.Reroute

		# Stop Application Gateway
		$getgw1 = Stop-AzApplicationGateway -ApplicationGateway $appgw

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
Application gateway global configuration (request/response buffering) tests
#>
function Test-ApplicationGatewayGlobalConfig
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# check trusted root
		$trustedRoot02 = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $getgw -Name $trustedRootCertName
		Assert-NotNull $trustedRoot02
		Assert-AreEqual $getgw.BackendHttpSettingsCollection[0].TrustedRootCertificates.Count 1

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 2
		Assert-AreEqual $sku01.Name Standard_v2
		Assert-AreEqual $sku01.Tier Standard_v2

		# Assert by default request and response buffering are set to true
		Assert-AreEqual $true $getgw.EnableRequestBuffering
		Assert-AreEqual $true $getgw.EnableResponseBuffering

		# Set only EnableRequestBuffering to false and assert that EnableResponseBuffering is still true
		$getgw.EnableRequestBuffering = $false
		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw

		Assert-AreEqual $false $getgw.EnableRequestBuffering
		Assert-AreEqual $true $getgw.EnableResponseBuffering

		# Now set EnableRequestBuffering and EnableResponseBuffering to true
		$getgw.EnableRequestBuffering = $true
		$getgw.EnableResponseBuffering = $true

		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Assert-AreEqual $true $getgw.EnableRequestBuffering
		Assert-AreEqual $true $getgw.EnableResponseBuffering

		# Stop Application Gateway
		$getgwStopped = Stop-AzApplicationGateway -ApplicationGateway $getgw

		Assert-AreEqual "Stopped" $getgwStopped.OperationalState

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force

		# Create Application Gateway with request and response buffering set and assert that the values are set properly
		$getgw2 = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01 -EnableRequestBuffering $false -EnableResponseBuffering $true

		$getgw3 = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Assert-AreEqual "Running" $getgw3.OperationalState

		Assert-AreEqual $false $getgw3.EnableRequestBuffering
		Assert-AreEqual $true $getgw3.EnableResponseBuffering

		# Assert that the values for request and response buffering remain after other powershell commands are executed (ensure bug is fixed)
		$getgw3 = Set-AzApplicationGatewayBackendAddressPool -ApplicationGateway $getgw3 -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com, www.amazon.com
		Set-AzApplicationGateway -ApplicationGateway $getgw3
		$getgw3 = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		Assert-AreEqual $false $getgw3.EnableRequestBuffering
		Assert-AreEqual $true $getgw3.EnableResponseBuffering

		# Stop Application Gateway
		$getgw2Stopped = Stop-AzApplicationGateway -ApplicationGateway $getgw3

		Assert-AreEqual "Stopped" $getgw2Stopped.OperationalState

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
Application gateway Basic SKU tests
#>
function Test-ApplicationGatewayBasicSkuCRUD
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Basic -Tier Basic -Capacity 2

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# check trusted root
		$trustedRoot02 = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $getgw -Name $trustedRootCertName
		Assert-NotNull $trustedRoot02
		Assert-AreEqual $getgw.BackendHttpSettingsCollection[0].TrustedRootCertificates.Count 1

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 2
		Assert-AreEqual $sku01.Name Basic
		Assert-AreEqual $sku01.Tier Basic

		Set-AzApplicationGatewaySku -Name Basic -Tier Basic -Capacity 1 -ApplicationGateway $getgw 

		$sku02 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw
		Assert-NotNull $sku02
		Assert-AreEqual $sku02.Capacity 1
		Assert-AreEqual $sku02.Name Basic
		Assert-AreEqual $sku02.Tier Basic

		# Set Application Gateway
		$getgw02 = Set-AzApplicationGateway -ApplicationGateway $getgw
		Assert-Null $(Get-AzApplicationGatewayIdentity -ApplicationGateway $getgw)

		# Stop Application Gateway
		$getgw03 = Stop-AzApplicationGateway -ApplicationGateway $getgw02

		Assert-AreEqual "Stopped" $getgw03.OperationalState

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
Application gateway Basic SKU tests
#>
function Test-ApplicationGatewayBasicSkuLimitsAndUnsupportedFeatures
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$identityName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = "powershellBasicSkuTestPort80"
	$frontendPort02Name = "powershellBasicSkuTestPort81"
	$frontendPort03Name = "powershellBasicSkuTestPort82"
	$frontendPort04Name = "powershellBasicSkuTestPort83"
	$frontendPort05Name = "powershellBasicSkuTestPort84"
	$frontendPort06Name = "powershellBasicSkuTestPort85"

	$fipconfigName = Get-ResourceName
	$listener01Name = "powershellBasicSkuTestListener1"
	$listener02Name = "powershellBasicSkuTestListener2"
	$listener03Name = "powershellBasicSkuTestListener3"
	$listener04Name = "powershellBasicSkuTestListener4"
	$listener05Name = "powershellBasicSkuTestListener5"
	$listener06Name = "powershellBasicSkuTestListener6"

	$pool01Name = "powershellBasicSkuTestBackendPool1"
	$pool02Name = "powershellBasicSkuTestBackendPool2"
	$pool03Name = "powershellBasicSkuTestBackendPool3"
	$pool04Name = "powershellBasicSkuTestBackendPool4"
	$pool05Name = "powershellBasicSkuTestBackendPool5"
	$pool06Name = "powershellBasicSkuTestBackendPool6"

	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName

	$backendSetting01Name = "powershellBasicSkuTestBackendSettings1"
	$backendSetting02Name = "powershellBasicSkuTestBackendSettings2"
	$backendSetting03Name = "powershellBasicSkuTestBackendSettings3"
	$backendSetting04Name = "powershellBasicSkuTestBackendSettings4"
	$backendSetting05Name = "powershellBasicSkuTestBackendSettings5"
	$backendSetting06Name = "powershellBasicSkuTestBackendSettings6"

	$rule01Name = "powershellBasicSkuTestRoutingRule1"
	$probeHttpName = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $pool01Name -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Basic -Tier Basic -Capacity 2

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01

		# Get Application Gateway
		$createdAppGw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $createdAppGw.OperationalState

		$createdAppGw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort02Name -Port 81
		$createdAppGw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort03Name -Port 82
		$createdAppGw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort04Name -Port 83
		$createdAppGw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort05Name -Port 84
		$createdAppGw = Add-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort06Name -Port 85

		$fp02 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort02Name
		$fp03 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort03Name
		$fp04 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort04Name
		$fp05 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort05Name
		$fp06 = Get-AzApplicationGatewayFrontendPort -ApplicationGateway $createdAppGw -Name $frontendPort06Name

		$createdAppGw = Add-AzApplicationGatewayHttpListener -ApplicationGateway $createdAppGw -Name $listener02Name -Protocol Http -FrontendIpConfiguration $fipconfig -FrontendPort $fp02
		$createdAppGw = Add-AzApplicationGatewayHttpListener -ApplicationGateway $createdAppGw -Name $listener03Name -Protocol Http -FrontendIpConfiguration $fipconfig -FrontendPort $fp03
		$createdAppGw = Add-AzApplicationGatewayHttpListener -ApplicationGateway $createdAppGw -Name $listener04Name -Protocol Http -FrontendIpConfiguration $fipconfig -FrontendPort $fp04
		$createdAppGw = Add-AzApplicationGatewayHttpListener -ApplicationGateway $createdAppGw -Name $listener05Name -Protocol Http -FrontendIpConfiguration $fipconfig -FrontendPort $fp05
		$createdAppGw = Add-AzApplicationGatewayHttpListener -ApplicationGateway $createdAppGw -Name $listener06Name -Protocol Http -FrontendIpConfiguration $fipconfig -FrontendPort $fp06

		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*The number of HttpListeners exceeds the maximum allowed value. The number of HttpListeners is 6 and the maximum allowed is 5."
		
		$createdAppGw = Remove-AzApplicationGatewayHttpListener -ApplicationGateway $createdAppGw -Name $listener06Name
		$createdAppGw = Set-AzApplicationGateway -ApplicationGateway $createdAppGw

		$createdAppGw = Add-AzApplicationGatewayBackendSetting -ApplicationGateway $createdAppGw -Name $backendSetting01Name -Port 88 -Protocol TCP
		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*For specified sku-tier Basic, property BackendSettingsCollection or Listeners or RoutingRules is not supported."

		$createdAppGw = Remove-AzApplicationGatewayBackendSetting -ApplicationGateway $createdAppGw -Name $backendSetting01Name
		$createdAppGw = Set-AzApplicationGateway -ApplicationGateway $createdAppGw

		$createdAppGw = Add-AzApplicationGatewayListener -ApplicationGateway $createdAppGw -Name $listener06Name -Protocol "TCP" -FrontendIpConfiguration $fipconfig -FrontendPort $fp06
		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*For specified sku-tier Basic, property BackendSettingsCollection or Listeners or RoutingRules is not supported."

		$createdAppGw = Remove-AzApplicationGatewayListener -ApplicationGateway $createdAppGw -Name $listener06Name
		$createdAppGw = Set-AzApplicationGateway -ApplicationGateway $createdAppGw

		$createdAppGw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool02Name -BackendFqdns "contoso1.com", "contoso2.com", "contoso3.com", "contoso4.com", "contoso5.com", "contoso6.com"
		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*The number of BackendServersPerPool exceeds the maximum allowed value. The number of BackendServersPerPool is 6 and the maximum allowed is 5."

		$createdAppGw = Remove-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool02Name
		$createdAppGw = Set-AzApplicationGateway -ApplicationGateway $createdAppGw

		$createdAppGw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool02Name -BackendFqdns "contoso1.com"
		$createdAppGw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool03Name -BackendFqdns "contoso1.com"
		$createdAppGw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool04Name -BackendFqdns "contoso1.com"
		$createdAppGw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool05Name -BackendFqdns "contoso1.com"
		$createdAppGw = Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool06Name -BackendFqdns "contoso1.com"

		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*The number of BackendAddressPools exceeds the maximum allowed value. The number of BackendAddressPools is 6 and the maximum allowed is 5."
		$createdAppGw = Remove-AzApplicationGatewayBackendAddressPool -ApplicationGateway $createdAppGw -Name $pool06Name

		$urlConfiguration = New-AzApplicationGatewayRewriteRuleUrlConfiguration -ModifiedPath "/abc" -ModifiedQueryString "x=y&a=b"
		$hc = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName abc -HeaderValue def
		$action = New-AzApplicationGatewayRewriteRuleActionSet -ResponseHeaderConfiguration $hc -UrlConfiguration $urlConfiguration
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name "rewriteRule" -ActionSet $action

		$createdAppGw = Add-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $createdAppGw -Name "ruleset1" -RewriteRule $rewriteRule

		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*does not support URL Rewrite for the selected SKU tier Basic. Supported SKU tiers are Standard_v2,WAF_v2."
	
		$createdAppGw = Remove-AzApplicationGatewayRewriteRuleSet -ApplicationGateway $createdAppGw -Name "ruleset1"
		$createdAppGw = Set-AzApplicationGateway -ApplicationGateway $createdAppGw

		Set-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $createdAppGw -MaxCapacity 5 -MinCapacity 4
		Assert-ThrowsLike { Set-AzApplicationGateway -ApplicationGateway $createdAppGw } "*does not support Autoscaling for the selected SKU tier Basic. Supported SKU tiers are Standard_v2,WAF_v2."
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway Basic SKU tests
#>
function Test-ApplicationGatewayBasicSkuMigration
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Basic -Tier Basic -Capacity 2

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# Check that migration to Standard_v2 was successful
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 2
		Assert-AreEqual $sku01.Name Basic
		Assert-AreEqual $sku01.Tier Basic

		# Migrate to Standard_v2
		$getgw = Set-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2 -ApplicationGateway $getgw

		$getgw01 = Set-AzApplicationGateway -ApplicationGateway $getgw

		# Check that migration to Standard_v2 was successful
		$sku02 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw01
		Assert-NotNull $sku02
		Assert-AreEqual $sku02.Capacity 2
		Assert-AreEqual $sku02.Name Standard_v2
		Assert-AreEqual $sku02.Tier Standard_v2
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
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

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
		$getgw = Set-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2 -ApplicationGateway $getgw

		# Set
		$getgw01 = Set-AzApplicationGateway -ApplicationGateway $getgw

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw01
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 2
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
Application gateway v2 tests for key vault
#>
function Test-KeyVaultIntegrationTest
{
	param
	(
		[string]$basedir = "./",
		[string]$spn
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
	$poolSetting01Name = Get-ResourceName

	$rule01Name = Get-ResourceName

	$keyVaultName = Get-ResourceName
	$sslCert01Name = Get-ResourceName
	$sslCert02Name = Get-ResourceName

	try
	{
		# resource group
		New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# managed identity
		$identity = New-AzUserAssignedIdentity -Name $identityName -Location $location -ResourceGroup $rgname

		# keyvault
		if ((Get-NetworkTestMode) -ne 'Playback')
        {
			New-AzKeyVault -Name $keyVaultName -ResourceGroupName $rgname -Location $location -EnableSoftDelete
			Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ServicePrincipalName $spn -PermissionsToSecrets get -PermissionsToCertificates get,list,delete,create,import,update,managecontacts,getissuers,listissuers,setissuers,deleteissuers,manageissuers,recover,purge,backup,restore
			Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ObjectId $identity.PrincipalId -PermissionsToSecrets get -BypassObjectIdValidation

			$policy = New-AzKeyVaultCertificatePolicy -ValidityInMonths 12 `
			-SubjectName "CN=www.app.com" -IssuerName self `
			-RenewAtNumberOfDaysBeforeExpiry 30

			$certificate01 = Add-AzKeyVaultCertificate -VaultName $keyVaultName -Name $sslCert01Name -CertificatePolicy $policy
			$certificate02 = Add-AzKeyVaultCertificate -VaultName $keyVaultName -Name $sslCert02Name -CertificatePolicy $policy

			Start-TestSleep -Seconds 30

			$certificate01 = Get-AzKeyVaultCertificate -VaultName $keyVaultName -Name $sslCert01Name
			$secretId01 = $certificate01.SecretId.Replace($certificate01.Version, "")

			$certificate02 = Get-AzKeyVaultCertificate -VaultName $keyVaultName -Name $sslCert02Name
			$secretId02 = $certificate02.SecretId.Replace($certificate02.Version, "")
		}
		else
		{
			$secretId01 = "https://$keyVaultName.vault.azure.net:443/secrets/$sslCert01Name/"
			$secretId02 = "https://$keyVaultName.vault.azure.net:443/secrets/$sslCert02Name/"
		}

		# virtual network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses 10.0.0.1
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		# rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2

		# appgw identity
		$appgwIdentity = New-AzApplicationGatewayIdentity -UserAssignedIdentity $identity.Id

		# ssl cert
		$sslCert01 = New-AzApplicationGatewaySslCertificate -Name $sslCert01Name -KeyVaultSecretId $secretId01

		# create
		$appgw = New-AzApplicationGateway -Sku $sku -Identity $appgwIdentity -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location `
		-BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 `
		-FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 `
		-SslCertificates $sslCert01 `
		-RequestRoutingRules $rule01

		Assert-AreEqual $appgw.SslCertificates.Count 1
		Assert-AreEqual $appgw.SslCertificates[0].KeyVaultSecretId $secretId01

		# modify the certificate
		$appgw = Set-AzApplicationGatewaySslCertificate -Name $sslCert01Name -KeyVaultSecretId $secretId02 -ApplicationGateway $appgw
		$result = Set-AzApplicationGateway -ApplicationGateway $appgw
		
		Assert-AreEqual $result.SslCertificates[0].KeyVaultSecretId $secretId02

		$result = Remove-AzApplicationGatewaySslCertificate -Name $sslCert01Name -ApplicationGateway $result

		Assert-AreEqual $result.SslCertificates.Count 0

		# delete
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
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
	$customError403Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403-another2.htm"

	$redirectName = Get-ResourceName
	$urlPathMapName = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRuleName2 = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 10.0.0.0/24
		$vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
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
		Assert-ThrowsLike { Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool } "*already exists*"
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

		# Tested on Azure Portal CloudShell against a V2 gateway and got the same error that this test gets when listing gateways...
		# Get-AzApplicationGateway: Resource provider 'Microsoft.Network' failed to return collection response for type 'applicationGateways'.
		# $appgwsAll = Get-AzApplicationGateway

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
		Assert-ThrowsLike { Set-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name "fakeName" -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool } "*does not exist*"
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
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"
	$customError403Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"

	$urlPathMapName = Get-ResourceName
	$urlPathMapName2 = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRule01Name = Get-ResourceName
	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443

		$listenerPolicyName = "listenerhttpPolicy"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 300 
		New-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$httpPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $httpPolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $httpPolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $httpPolicy.PolicySettings.State  $policySetting.State

		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -RequireServerNameIndication false -FirewallPolicy $httpPolicy

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

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
		Assert-AreEqual $videoPathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -RedirectConfigurationId $redirectConfig.Id -RewriteRuleSetId $rewriteRuleSet.Id
		Assert-AreEqual $imagePathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
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
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestHostName -RequireServerNameIndication true -SslCertificate $sslCert
		$listener02 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener03Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestName -SslCertificate $sslCert
		$urlPathMap = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType PathBasedRouting -Priority 101 -HttpListener $listener02 -UrlPathMap $urlPathMap

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
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		# WAF Policy and Custom Rule
        # Disabled until Firewall Policy cmdlets are updated
		<#$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block

		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy#>

        # Get Application Gateway
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

        # Disabled until Firewall Policy cmdlets are updated
		#$appgw.FirewallPolicy = $policy
		#$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		#$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# First Check firewall configuraiton
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.Enabled $true
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.FirewallMode "Prevention"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RuleSetType "OWASP"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RuleSetVersion "2.2.9"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count 2
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RequestBodyCheck $true
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.MaxRequestBodySizeInKb 80
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.FileUploadLimitInMb 70
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.Exclusions.Count 2
        
        # Disabled until Firewall Policy cmdlets are updated
		# Second check firewll policy
		<#Assert-AreEqual $policy.Id $appgw.FirewallPolicy.Id
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector#>

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

function Test-AvailableServerVariableAndHeader
{
	#Get server variables, request headers and response headers
	$result = Get-AzApplicationGatewayAvailableServerVariableAndHeader

	Assert-NotNull $result
	Assert-True { $result.AvailableServerVariable.Count -gt 0 }
	Assert-True { $result.AvailableRequestHeader.Count -gt 0 }
	Assert-True { $result.AvailableResponseHeader.Count -gt 0 }

	#Get server variables, request headers and response headers
	$result = Get-AzApplicationGatewayAvailableServerVariableAndHeader -ServerVariable -RequestHeader -ResponseHeader

	Assert-NotNull $result
	Assert-True { $result.AvailableServerVariable.Count -gt 0 }
	Assert-True { $result.AvailableRequestHeader.Count -gt 0 }
	Assert-True { $result.AvailableResponseHeader.Count -gt 0 }

	#Get server variables only
	$result = Get-AzApplicationGatewayAvailableServerVariableAndHeader -ServerVariable

	Assert-NotNull $result
	Assert-True { $result.AvailableServerVariable.Count -gt 0 }

	#Get request headers only
	$result = Get-AzApplicationGatewayAvailableServerVariableAndHeader -RequestHeader

	Assert-NotNull $result
	Assert-True { $result.AvailableRequestHeader.Count -gt 0 }

	#Get response headers only
	$result = Get-AzApplicationGatewayAvailableServerVariableAndHeader -ResponseHeader

	Assert-NotNull $result
	Assert-True { $result.AvailableResponseHeader.Count -gt 0 }
}

<#
.SYNOPSIS
Application gateway v2 top level waf tests
#>
function Test-ApplicationGatewayTopLevelFirewallPolicy
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"
	$customError403Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"

	$urlPathMapName = Get-ResourceName
	$urlPathMapName2 = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRule01Name = Get-ResourceName
	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443

		$listenerPolicyName = "listenerhttpPolicy"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 300 
		New-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$httpPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $httpPolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $httpPolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $httpPolicy.PolicySettings.State  $policySetting.State

		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -RequireServerNameIndication false -FirewallPolicy $httpPolicy
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

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
		Assert-AreEqual $videoPathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -RedirectConfigurationId $redirectConfig.Id -RewriteRuleSetId $rewriteRuleSet.Id
		Assert-AreEqual $imagePathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
		$urlPathMap = New-AzApplicationGatewayUrlPathMapConfig -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01
		$urlPathMap2 = New-AzApplicationGatewayUrlPathMapConfig -Name $urlPathMapName2 -PathRules $videoPathRule,$imagePathRule -DefaultRedirectConfiguration $redirectConfig -DefaultRewriteRuleSet $rewriteRuleSet
		$probe = New-AzApplicationGatewayProbeConfig -Name $probeName -Protocol Http -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -MinServers 1 -PickHostNameFromBackendHttpSettings

		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert01Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert = New-AzApplicationGatewaySslCertificate -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01,$fp02 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -AutoscaleConfiguration $autoscaleConfig -UrlPathMap $urlPathMap,$urlPathMap2 -RedirectConfiguration $redirectConfig -Probe $probe -SslCertificate $sslCert -RewriteRuleSet $rewriteRuleSet -ForceFirewallPolicyAssociation

		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$certFilePath2 = $basedir + "/ScenarioTests/Data/TrustedRootCertificate.cer"

		# Add
		$listener01 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		Add-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath
		Add-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01

		# Add to test Remove
		Add-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting02Name -Port 1234 -Protocol Http -CookieBasedAffinity Enabled -RequestTimeout 42 -HostName test -Path /test -AffinityCookieName test
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestHostName -RequireServerNameIndication true -SslCertificate $sslCert
		$listener02 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener03Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestName -SslCertificate $sslCert
		$urlPathMap = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType PathBasedRouting -Priority 101 -HttpListener $listener02 -UrlPathMap $urlPathMap

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
		Set-AzApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $appgw -Enabled $true -FirewallMode Prevention -RuleSetType "OWASP" -RuleSetVersion "3.0" -RequestBodyCheck $true -MaxRequestBodySizeInKb 70 -FileUploadLimitInMb 70
		Set-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath2
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.0"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		$wafPolicyName = "wafPolicy1"
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings
	
		# Get Application Gateway
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		$appgw.FirewallPolicy = $policy
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $policy.Id $appgw.FirewallPolicy.Id
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		#Add Exclusions and disabled rules to the firewall policy
		$exclusionEntry = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestArgNames -SelectorMatchOperator Contains -Selector Bingo
		$ruleOverrideEntry1 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 942100
		$ruleOverrideEntry2 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 942110
		$sqlRuleGroupOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride -RuleGroupName REQUEST-942-APPLICATION-ATTACK-SQLI -Rule $ruleOverrideEntry1,$ruleOverrideEntry2
		
		$ruleOverrideEntry3 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 941100
		$xssRuleGroupOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride -RuleGroupName REQUEST-941-APPLICATION-ATTACK-XSS -Rule $ruleOverrideEntry3
		
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.0" -RuleGroupOverride $sqlRuleGroupOverrideEntry,$xssRuleGroupOverrideEntry
		$managedRules = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet -Exclusion $exclusionEntry
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 750 -MaxRequestBodySizeInKb 128
		$policy.managedRules = $managedRules
		$policy.PolicySettings = $policySettings
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		# Get firewall policy
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets.Count 1
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides.Count 2
		Assert-AreEqual $policy.ManagedRules.Exclusions.Count 1
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway SKU Family tests
#>
function Test-ApplicationGatewaySkuFamilyGet
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 2

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# check trusted root
		$trustedRoot02 = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $getgw -Name $trustedRootCertName
		Assert-NotNull $trustedRoot02
		Assert-AreEqual $getgw.BackendHttpSettingsCollection[0].TrustedRootCertificates.Count 1

		# check sku
		$sku01 = Get-AzApplicationGatewaySku -ApplicationGateway $getgw
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 2
		Assert-AreEqual $sku01.Name Standard_v2
		Assert-AreEqual $sku01.Tier Standard_v2
		Assert-AreEqual $sku01.Family Generation_1

		# Set Application Gateway
		$getgw01 = Set-AzApplicationGateway -ApplicationGateway $getgw
		Assert-Null $(Get-AzApplicationGatewayIdentity -ApplicationGateway $getgw)

		# Stop Application Gateway
		$getgw02 = Stop-AzApplicationGateway -ApplicationGateway $getgw01

		Assert-AreEqual "Stopped" $getgw02.OperationalState

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
This case tests the per-site and per-listener firewall policies. At the end we try to add a global firewall polcy and test the whole thing.
#>
function Test-ApplicationGatewayWithFirewallPolicy
{
	param
	(
		$basedir = "./"
	)

	# Setup
	# $location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "South Central US"

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
		# The Per-Site firewall policy can only be enabled in regions which have the dynamic setting set to true.
		# Currently Central US EUAP region has it enabled so hardcoding it to this region, This can be removed once it is enabled on regions in production.
		$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443
		
		# Create a firewall policy for http listener
		$listenerPolicyName = "listenerhttpPolicy"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 300 
		New-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$httpPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $httpPolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $httpPolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $httpPolicy.PolicySettings.State  $policySetting.State
		
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -RequireServerNameIndication false -FirewallPolicy $httpPolicy
		Assert-AreEqual $listener01.FirewallPolicy.Id $httpPolicy.Id

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name WAF_v2 -Tier WAF_v2

		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		Assert-AreEqual $autoscaleConfig.MinCapacity 3

		$redirectConfig = New-AzApplicationGatewayRedirectConfiguration -Name $redirectName -RedirectType Permanent -TargetListener $listener01 -IncludePath $true -IncludeQueryString $true
		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "abc" -HeaderValue "def"
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -RequestHeaderConfiguration $headerConfiguration
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet
		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRule
		
		# Create two polices for path rules /video and /image
		$videoPolicyName = "videoPolicyName"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 150 
		New-AzApplicationGatewayFirewallPolicy -Name $videoPolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$videoPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $videoPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $videoPolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $videoPolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $videoPolicy.PolicySettings.State  $policySetting.State

		$imagePolicyName = "imagePolicyName"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 50 
		New-AzApplicationGatewayFirewallPolicy -Name $imagePolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$imagePolicy = Get-AzApplicationGatewayFirewallPolicy -Name $imagePolicyName -ResourceGroupName $rgname
		Assert-AreEqual $imagePolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $imagePolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $imagePolicy.PolicySettings.State  $policySetting.State
		
		# Create path rule
		$videoPathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRuleName -Paths "/video" -RedirectConfiguration $redirectConfig -RewriteRuleSet $rewriteRuleSet -FirewallPolicy $videoPolicy
		Assert-AreEqual $videoPathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
		Assert-AreEqual $videoPathRule.FirewallPolicy.Id $videoPolicy.Id

		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -RedirectConfigurationId $redirectConfig.Id -RewriteRuleSetId $rewriteRuleSet.Id -FirewallPolicyId $imagePolicy.Id
		Assert-AreEqual $imagePathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
		Assert-AreEqual $imagePathRule.FirewallPolicy.Id $imagePolicy.Id
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
		$certFilePath2 = $basedir + "/Scenario/Data/TrustedRootCertificate.cer"

		# Add
		$listener01 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		Add-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath
		Add-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01

		# Add to test Remove
		Add-AzApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting02Name -Port 1234 -Protocol Http -CookieBasedAffinity Enabled -RequestTimeout 42 -HostName test -Path /test -AffinityCookieName test
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestHostName -RequireServerNameIndication true -SslCertificate $sslCert
		$listener02 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener03Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestName -SslCertificate $sslCert
		$urlPathMap = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType PathBasedRouting -Priority 101 -HttpListener $listener02 -UrlPathMap $urlPathMap

		# Add twice
		Assert-ThrowsLike { Add-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath } "*already exists*"
		Assert-ThrowsLike { Add-AzApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01 } "*already exists*"

		Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName02 -BackendFqdns www.bing.com,www.microsoft.com
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-NotNull $appgw.HttpListeners[0].CustomErrorConfigurations
		Assert-NotNull $appgw.TrustedRootCertificates
		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 2
		Assert-AreEqual $appgw.HttpListeners.Count 3
		Assert-AreEqual $appgw.RequestRoutingRules.Count 2
		Assert-AreEqual $appgw.HttpListeners[0].FirewallPolicy.Id $httpPolicy.Id
		Assert-AreEqual $appgw.UrlPathMaps[1].PathRules[0].FirewallPolicy.Id $videoPolicy.Id
		Assert-AreEqual $appgw.UrlPathMaps[1].PathRules[1].FirewallPolicy.Id $imagePolicy.Id

		# Get
		$trustedCert = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName
		Assert-NotNull $trustedCert

		# List
		$trustedCerts = Get-AzApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw
		Assert-NotNull $trustedCerts
		Assert-AreEqual $trustedCerts.Count 1
		
		# Add a basic global firewall policy
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.0"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		$wafPolicyName = "wafPolicy1"
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings
	
		# Get Application Gateway
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$globalPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		$appgw.FirewallPolicy = $globalPolicy
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
	
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$globalPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $globalPolicy.Id $appgw.FirewallPolicy.Id
		Assert-AreEqual $globalPolicy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $globalPolicy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $globalPolicy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $globalPolicy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $globalPolicy.PolicySettings.State $policySettings.State

		# Create a new policy and switch the appgw to the new policy
		$globalPolicyName2 = "globalpolicy2"
		New-AzApplicationGatewayFirewallPolicy -Name $globalPolicyName2 -ResourceGroupName $rgname -Location $location
		$globalPolicy =  Get-AzApplicationGatewayFirewallPolicy -Name $globalPolicyName2 -ResourceGroupName $rgname
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$appgw.FirewallPolicy = $globalPolicy
		Set-AzApplicationGateway -ApplicationGateway $appgw

		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$globalPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $globalPolicyName2 -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $globalPolicy.Id $appgw.FirewallPolicy.Id
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
This case tests the cmdlets related to TCP Listeners, BackendSettings, RoutingRules and Probes.
#>
function Test-ApplicationGatewayWithTCPResources
{
	param
	(
		$basedir = "./"
	)

	# Setup
	# $location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "South Central US"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$frontendPort02Name = Get-ResourceName
	$frontendPort03Name = Get-ResourceName
	$frontendPort04Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName
	$listener02Name = Get-ResourceName
	$listener03Name = Get-ResourceName

	$poolName = Get-ResourceName
	$poolName02 = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName
	$poolSetting02Name = Get-ResourceName
	$poolSetting03Name = Get-ResourceName
	$probeName = Get-ResourceName
	$probeName02 = Get-ResourceName
	$rule01Name = Get-ResourceName
	$rule02Name = Get-ResourceName

	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	try
	{
		# The Routing Rule Priortity field will be enabled in upcoming SDK release and  is enabled for selected locations in NRP
		# Currently West US 3 region does not have priority filed enabled so hardcoding it to this region, This can be removed once it is enabled on all regions in productions and SDK is released.
		$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443
		$fp03 = New-AzApplicationGatewayFrontendPort -Name $frontendPort03Name -Port 444
		$fp04 = New-AzApplicationGatewayFrontendPort -Name $frontendPort04Name -Port 404

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		Assert-AreEqual $autoscaleConfig.MinCapacity 3
		
		##New commands
		
		#New Listener command
		$listener01 = New-AzApplicationGatewayListener -Name $listener01Name -Protocol TCP -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 
		Assert-AreEqual $listener01.Name  $listener01Name
		Assert-AreEqual $listener01.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener01.FrontendPort.Id   $fp01.Id
		Assert-AreEqual $listener01.Protocol   "TCP"

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		
		#New BackendSetting Command
		$poolSetting01 = New-AzApplicationGatewayBackendSetting -Name $poolSetting01Name -Port 443 -Protocol TCP -Timeout 20
		Assert-AreEqual $poolSetting01.Name    $poolSetting01Name
		Assert-AreEqual $poolSetting01.Port    443
		Assert-AreEqual $poolSetting01.Protocol   "TCP"
		Assert-AreEqual $poolSetting01.Timeout    20

		#New Routing rule  command
		$rule01 = New-AzApplicationGatewayRoutingRule -Name $rule01Name -RuleType basic -Priority 100  -BackendSettings  $poolSetting01 -Listener  $listener01 -BackendAddressPool  $pool
		Assert-AreEqual $rule01.BackendSettings.Id   $poolSetting01.Id
		Assert-AreEqual $rule01.Listener.Id    $listener01.Id
		Assert-AreEqual $rule01.BackendAddressPool.Id    $pool.Id
		
		#new  Health Probe command
		$probe = New-AzApplicationGatewayProbeConfig -Name $probeName -Protocol TCP  -Interval 89 -Timeout 88 -UnhealthyThreshold 8 
		Assert-AreEqual $probe.Name   $probeName
		Assert-AreEqual $probe.Protocol   "TCP"
		Assert-AreEqual $probe.Interval   89
		Assert-AreEqual $probe.Timeout   88
		Assert-AreEqual $probe.UnhealthyThreshold   8
		

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01,$fp02,$fp03,$fp04 -Listeners $listener01 -RoutingRules $rule01 -Sku $sku -AutoscaleConfiguration $autoscaleConfig  -Probe $probe  
		
		
		##Get Commands

		# Get Listener
		$listener01 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener01Name
		Assert-AreEqual $listener01.Name  $listener01Name
		
		#Get Backend setting
		$backendSettingGet = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting01Name
		Assert-AreEqual $backendSettingGet.Name  $poolSetting01Name
		#Get Routing Rule 
		$routingRuleGet = Get-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule01Name
		Assert-AreEqual $routingRuleGet.Name  $rule01Name
		#Get Health Probe
		$healthProbeGet = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName
		Assert-AreEqual $healthProbeGet.Name  $probeName
		
		
		
		##Add  to test Remove
		
		# Add Backend Setting
		Add-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name -Port 1234 -Protocol TCP  -Timeout 42
		$poolSetting02 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		Assert-AreEqual $poolSetting02.Name    $poolSetting02Name
		Assert-AreEqual $poolSetting02.Port    1234
		Assert-AreEqual $poolSetting02.Protocol   "TCP"
		Assert-AreEqual $poolSetting02.Timeout    42
		
		#Add backend Setting
		Add-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting03Name -Port 4321 -Protocol TCP  -Timeout 24
		$poolSetting03= Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting03Name
		Assert-AreEqual $poolSetting03.Name    $poolSetting03Name
		Assert-AreEqual $poolSetting03.Port    4321
		Assert-AreEqual $poolSetting03.Protocol   "TCP"
		Assert-AreEqual $poolSetting03.Timeout    24
		
		
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		
		# Add Listener
		Add-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name -Protocol TCP -FrontendIPConfiguration $fipconfig -FrontendPort $fp02
		$listener02 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name
		Assert-AreEqual $listener02.Name  $listener02Name
		Assert-AreEqual $listener02.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener02.FrontendPort.Id   $fp02.Id
		Assert-AreEqual $listener02.Protocol   "TCP"
		
		
		#Add Listener 3
		Add-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener03Name -Protocol TCP -FrontendIPConfiguration $fipconfig -FrontendPort $fp03
		$listener03 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener03Name
		Assert-AreEqual $listener03.Name  $listener03Name
		Assert-AreEqual $listener03.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener03.FrontendPort.Id   $fp03.Id
		Assert-AreEqual $listener03.Protocol   "TCP"
		


		#Add Routing Rule
		$poolSetting02 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		$listener02 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name 
	    Add-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType Basic -Priority 99  -BackendSettings  $poolSetting02 -Listener  $listener02 -BackendAddressPool  $pool
		$rule02 =Get-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		Assert-AreEqual $rule02.BackendSettings.Id   $poolSetting02.Id
		Assert-AreEqual $rule02.Listener.Id    $listener02.Id
		Assert-AreEqual $rule02.BackendAddressPool.Id    $pool.Id

		#Add Probe
		Add-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02 -Protocol TCP  -Interval 79 -Timeout 78 -UnhealthyThreshold 7 
		$probe02 = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02
		Assert-AreEqual $probe02.Name   $probeName02
		Assert-AreEqual $probe02.Protocol   "TCP"
		Assert-AreEqual $probe02.Interval   79
		Assert-AreEqual $probe02.Timeout   78
		Assert-AreEqual $probe02.UnhealthyThreshold   7
		
		#Add backend Pool
		Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName02 -BackendFqdns www.bing.com,www.microsoft.com
		
		## Set Application Gateway
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-AreEqual $appgw.BackendSettingsCollection.Count 3
		Assert-AreEqual $appgw.Listeners.Count 3
		Assert-AreEqual $appgw.RoutingRules.Count 2
		Assert-AreEqual $appgw.Probes.Count 2
		
		
		##Set Commands
		
		
		# Set Backend Setting
		Set-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name -Port 123 -Protocol TCP  -Timeout 40
		$poolSetting02 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		Assert-AreEqual $poolSetting02.Port    123
		Assert-AreEqual $poolSetting02.Timeout    40
		
		
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		
		# Set Listener
		Set-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name -Protocol TCP -FrontendIPConfiguration $fipconfig -FrontendPort $fp04
		$listener02 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name
		Assert-AreEqual $listener02.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener02.FrontendPort.Id   $fp04.Id
		
		
		#Set Routing Rule
		$poolSetting03 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting03Name
		$listener03 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener03Name 
	    Set-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType Basic -Priority 98  -BackendSettings  $poolSetting03 -Listener  $listener03 -BackendAddressPool  $pool
		$rule02 =Get-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		Assert-AreEqual $rule02.BackendSettings.Id   $poolSetting03.Id
		Assert-AreEqual $rule02.Listener.Id    $listener03.Id
		Assert-AreEqual $rule02.BackendAddressPool.Id    $pool.Id

		#Set Probe
		Set-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02 -Protocol TCP  -Interval 24 -Timeout 15 -UnhealthyThreshold 6 
		$probe02 = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02
		Assert-AreEqual $probe02.Name   $probeName02
		Assert-AreEqual $probe02.Protocol   "TCP"
		Assert-AreEqual $probe02.Interval   24
		Assert-AreEqual $probe02.Timeout   15
		Assert-AreEqual $probe02.UnhealthyThreshold   6
		
		
		## Set Application Gateway
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
		
		
		
		
		##Remove
		Remove-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name
		
		Remove-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		
		Remove-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		
		Remove-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02
		
		
		## Set Application Gateway
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
		
		Assert-AreEqual $appgw.BackendSettingsCollection.Count 2
		Assert-AreEqual $appgw.Listeners.Count 2
		Assert-AreEqual $appgw.RoutingRules.Count 1
		Assert-AreEqual $appgw.Probes.Count 1
		
		
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}




<#
.SYNOPSIS
This case tests the cmdlets related to TLS Listeners, BackendSettings, RoutingRules and Probes.
#>
function Test-ApplicationGatewayWithTLSResources
{
	param
	(
		$basedir = "./"
	)

	# Setup
	# $location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "South Central US"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPort01Name = Get-ResourceName
	$frontendPort02Name = Get-ResourceName
	$frontendPort03Name = Get-ResourceName
	$frontendPort04Name = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName
	$listener02Name = Get-ResourceName
	$listener03Name = Get-ResourceName

	$poolName = Get-ResourceName
	$poolName02 = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName
	$poolSetting02Name = Get-ResourceName
	$poolSetting03Name = Get-ResourceName
	$probeName = Get-ResourceName
	$probeName02 = Get-ResourceName
	$rule01Name = Get-ResourceName
	$rule02Name = Get-ResourceName

	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	$trustedClientCert01Name = Get-ResourceName
	$trustedClientCert02Name = Get-ResourceName
	$sslProfile01Name = Get-ResourceName
	$sslProfile02Name = Get-ResourceName

	try
	{
		# The Routing Rule Priortity field will be enabled in upcoming SDK release and  is enabled for selected locations in NRP
		# Currently West US 3 region does not have priority filed enabled so hardcoding it to this region, This can be removed once it is enabled on all regions in productions and SDK is released.
		$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443
		$fp03 = New-AzApplicationGatewayFrontendPort -Name $frontendPort03Name -Port 444
		$fp04 = New-AzApplicationGatewayFrontendPort -Name $frontendPort04Name -Port 404


		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert01Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert = New-AzApplicationGatewaySslCertificate -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01
		
		#New  TLS Listener
		$listener01 = New-AzApplicationGatewayListener -Name $listener01Name -Protocol TLS -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -SslCertificate $sslCert #-SslProfile  $sslProfile01
		Assert-AreEqual $listener01.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener01.FrontendPort.Id   $fp01.Id
		Assert-AreEqual $listener01.Protocol   "TLS"
		Assert-AreEqual $listener01.SslCertificate.Id    $sslCert.Id
		Assert-AreEqual $listener01.SslProfile.Id     $sslProfile01.Id
		
		
		$certFilePath2 = $basedir + "/ScenarioTests/Data/TrustedRootCertificate.cer"
		
		$trustedRootCert = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath2
		
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		
		
		#add for port also
		$probe = New-AzApplicationGatewayProbeConfig -Name $probeName -Protocol TLS  -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -Port 777
		Assert-AreEqual $probe.Interval   89
		Assert-AreEqual $probe.Timeout   88
		Assert-AreEqual $probe.UnhealthyThreshold   8
		
		
		#New TLS BackendSettings
		$poolSetting01 = New-AzApplicationGatewayBackendSetting -Name $poolSetting01Name -Port 443 -Protocol TLS -Timeout 20 -HostName www.google.com -TrustedRootCertificate $trustedRootCert -Probe $probe
		
		Assert-AreEqual $poolSetting01.Protocol  TLS
		Assert-AreEqual $poolSetting01.Timeout   20
		Assert-AreEqual $poolSetting01.Port   443
		Assert-AreEqual $poolSetting01.Probe.Id    $probe.Id
		Assert-AreEqual $poolSetting01.HostName  "www.google.com"

		#New Routing rule
		$rule01 = New-AzApplicationGatewayRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendSettings  $poolSetting01 -Listener  $listener01 -BackendAddressPool  $pool
		Assert-AreEqual $rule01.BackendSettings.Id   $poolSetting01.Id
		Assert-AreEqual $rule01.Listener.Id    $listener01.Id
		Assert-AreEqual $rule01.BackendAddressPool.Id    $pool.Id



		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		Assert-AreEqual $autoscaleConfig.MinCapacity 3
		
        # Create Application Gateway	
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location   -BackendAddressPools $pool -BackendSettingsCollection  $poolSetting01     -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01,$fp02,$fp03,$fp04 -Listeners $listener01 -RoutingRules $rule01 -Sku $sku -AutoscaleConfiguration $autoscaleConfig  -Probe $probe -SslCertificate $sslCert -TrustedRootCertificate $trustedRootCert 
		

		
		##Get Commands

		# Get Listener
		$listener01 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener01Name
		Assert-AreEqual $listener01.Name  $listener01Name
		#Get Backend setting
		$backendSettingGet = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting01Name
		Assert-AreEqual $backendSettingGet.Name  $poolSetting01Name
		#Get Routing Rule 
		$routingRuleGet = Get-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule01Name
		Assert-AreEqual $routingRuleGet.Name  $rule01Name
		#Get Health Probe
		$healthProbeGet = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName
		Assert-AreEqual $healthProbeGet.Name  $probeName
		
		
		## Add to test Remove		
		#Add Probe
		Add-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02 -Protocol TLS -Timeout 10 -Interval 10 -UnhealthyThreshold 10
		$probe02 =Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02
		Assert-AreEqual $probe02.Name   $probeName02
		Assert-AreEqual $probe02.Protocol   "TLS"
		Assert-AreEqual $probe02.Interval   10
		Assert-AreEqual $probe02.Timeout   10
		Assert-AreEqual $probe02.UnhealthyThreshold   10

		# Add Backend Setting
		Add-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name -Port 1234 -Protocol TLS  -Timeout 42 -HostName test -TrustedRootCertificate $trustedRootCert -Probe $probe02
		$poolSetting02 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		Assert-AreEqual $poolSetting02.Name    $poolSetting02Name
		Assert-AreEqual $poolSetting02.Port    1234
		Assert-AreEqual $poolSetting02.Protocol   "TLS"
		Assert-AreEqual $poolSetting02.Timeout    42
		Assert-AreEqual $poolSetting02.HostName    "test"
		Assert-AreEqual $poolSetting02.Probe.Id    $probe02.Id

		#Add backend Setting
		Add-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting03Name -Port 4321 -Protocol TCP  -Timeout 24
		$poolSetting03= Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting03Name
		Assert-AreEqual $poolSetting03.Name    $poolSetting03Name
		Assert-AreEqual $poolSetting03.Port    4321
		Assert-AreEqual $poolSetting03.Protocol   "TCP"
		Assert-AreEqual $poolSetting03.Timeout    24
		
		
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		$appgw = Set-AzApplicationGatewaySslPolicy -ApplicationGateway $appgw -PolicyType Custom -MinProtocolVersion TLSv1_0 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_0 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"
		Add-AzApplicationGatewaySslProfile   -ApplicationGateway $appgw   -Name $sslProfile01Name   -SslPolicy $sslPolicy
	    $sslProfile01 = Get-AzApplicationGatewaySslProfile   -ApplicationGateway $appgw   -Name $sslProfile01Name
		
		# Add Listener
		Add-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name -Protocol TLS -FrontendIPConfiguration $fipconfig -FrontendPort $fp02   -SslCertificate $sslCert -SslProfile  $sslProfile01
		$listener02 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name
		Assert-AreEqual $listener02.Name  $listener02Name
		Assert-AreEqual $listener02.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener02.FrontendPort.Id   $fp02.Id
		Assert-AreEqual $listener02.Protocol   "TLS"
		Assert-AreEqual $listener02.SslCertificate.Id $sslCert.Id   
		Assert-AreEqual $listener02.SslProfile.Id $sslProfile01.Id   
		
		
		#Add Listener 3
		Add-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener03Name -Protocol TCP -FrontendIPConfiguration $fipconfig -FrontendPort $fp03
		$listener03 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener03Name
		Assert-AreEqual $listener03.Name  $listener03Name
		Assert-AreEqual $listener03.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener03.FrontendPort.Id   $fp03.Id
		Assert-AreEqual $listener03.Protocol   "TCP"
		


		#Add Routing Rule
		$poolSetting02 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		$listener02 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name 
	    Add-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType Basic -Priority 99 -BackendSettings  $poolSetting02 -Listener  $listener02 -BackendAddressPool  $pool
		$rule02 =Get-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		Assert-AreEqual $rule02.BackendSettings.Id   $poolSetting02.Id
		Assert-AreEqual $rule02.Listener.Id    $listener02.Id
		Assert-AreEqual $rule02.BackendAddressPool.Id    $pool.Id

		
		#Add backend Pool
		Add-AzApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName02 -BackendFqdns www.bing.com,www.microsoft.com
		
		## Set Application Gateway
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

		Assert-AreEqual $appgw.BackendSettingsCollection.Count 3
		Assert-AreEqual $appgw.Listeners.Count 3
		Assert-AreEqual $appgw.RoutingRules.Count 2
		Assert-AreEqual $appgw.Probes.Count 2
		
		
		##Set Commands
		
		
		# Set Backend Setting
		Set-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name -Port 123 -Protocol TCP  -Timeout 40
		$poolSetting02 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		Assert-AreEqual $poolSetting02.Port    123
		Assert-AreEqual $poolSetting02.Timeout    40
		
		
		$fipconfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		
		# Set Listener
		Set-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name -Protocol TCP -FrontendIPConfiguration $fipconfig -FrontendPort $fp04
		$listener02 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name
		Assert-AreEqual $listener02.FrontendIPConfiguration.Id  $fipconfig.Id
		Assert-AreEqual $listener02.FrontendPort.Id   $fp04.Id
		
		
		#Set Routing Rule
		$poolSetting03 = Get-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting03Name
		$listener03 = Get-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener03Name 
	    Set-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType Basic -Priority 98 -BackendSettings  $poolSetting03 -Listener  $listener03 -BackendAddressPool  $pool
		$rule02 =Get-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		Assert-AreEqual $rule02.BackendSettings.Id   $poolSetting03.Id
		Assert-AreEqual $rule02.Listener.Id    $listener03.Id
		Assert-AreEqual $rule02.BackendAddressPool.Id    $pool.Id

		#Set Probe
		Set-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02 -Protocol TCP  -Interval 24 -Timeout 15 -UnhealthyThreshold 6 
		$probe02 = Get-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02
		Assert-AreEqual $probe02.Name   $probeName02
		Assert-AreEqual $probe02.Protocol   "TCP"
		Assert-AreEqual $probe02.Interval   24
		Assert-AreEqual $probe02.Timeout   15
		Assert-AreEqual $probe02.UnhealthyThreshold   6
		
		
		## Set Application Gateway
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
		
		
		
		
		## Now remove
		#Remove Listener
		Remove-AzApplicationGatewayListener -ApplicationGateway $appgw -Name $listener02Name
		
		Remove-AzApplicationGatewayBackendSetting -ApplicationGateway $appgw -Name $poolSetting02Name
		
		Remove-AzApplicationGatewayRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		
		Remove-AzApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName02
		
		
		## Set Application Gateway
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw
		
		Assert-AreEqual $appgw.BackendSettingsCollection.Count 2
		Assert-AreEqual $appgw.Listeners.Count 2
		Assert-AreEqual $appgw.RoutingRules.Count 1
		Assert-AreEqual $appgw.Probes.Count 1
		
		
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}



<#
.SYNOPSIS
Application gateway v2 top level waf tests
#>
function Test-ApplicationGatewayFirewallPolicyExclusions
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		# Add Exclusions and disabled rules to the firewall policy
		$exclusionEntry1 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestArgNames -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry2 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestArgValues -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry3 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestArgKeys -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry4 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestHeaderNames -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry5 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestHeaderValues -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry6 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestHeaderKeys -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry7 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestCookieNames -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry8 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestCookieValues -SelectorMatchOperator Contains -Selector Bingo
		$exclusionEntry9 = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestCookieKeys -SelectorMatchOperator Contains -Selector Bingo

		$ruleOverrideEntry1 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 942100
		$ruleOverrideEntry2 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 942110
		$ruleOverrideEntry3 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 942160  -State Enabled -Action Log
		$sqlRuleGroupOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride -RuleGroupName REQUEST-942-APPLICATION-ATTACK-SQLI -Rule $ruleOverrideEntry1,$ruleOverrideEntry2, $ruleOverrideEntry3

		$ruleOverrideEntry4 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 941100
		$xssRuleGroupOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride -RuleGroupName REQUEST-941-APPLICATION-ATTACK-XSS -Rule $ruleOverrideEntry4

		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2" -RuleGroupOverride $sqlRuleGroupOverrideEntry,$xssRuleGroupOverrideEntry
		$managedRules = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet -Exclusion $exclusionEntry1,$exclusionEntry2,$exclusionEntry3,$exclusionEntry4,$exclusionEntry5,$exclusionEntry6,$exclusionEntry7,$exclusionEntry8,$exclusionEntry9
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 750 -MaxRequestBodySizeInKb 128
		$policy.managedRules = $managedRules
		$policy.PolicySettings = $policySettings
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		# Get firewall policy
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets.Count 1
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides.Count 2
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides[0].Rules[2].Action Log
		Assert-AreEqual $policy.ManagedRules.Exclusions.Count 9
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway v2 top level waf tests with empty rule in ManagedRuleGroupOverride
#>
function Test-ApplicationGatewayFirewallPolicyManagedRuleGroupOverrideEmptyRule

{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		# Add disabled rules to the firewall policy

		$emptyRuleGroupOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride -RuleGroupName REQUEST-942-APPLICATION-ATTACK-SQLI 

		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2" -RuleGroupOverride $emptyRuleGroupOverrideEntry
		$managedRules = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 750 -MaxRequestBodySizeInKb 128
		$policy.managedRules = $managedRules
		$policy.PolicySettings = $policySettings
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		# Get firewall policy
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets.Count 1
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides.Count 1
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides[0].Rules.Count 0
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway v2 top level waf tests in ManagedRuleGroupOverride with sensitivity
#>
function Test-ApplicationGatewayFirewallPolicyManagedRuleGroupOverrideWithSensitivity

{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "uksouth"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$ruleOverrideEntry1 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 500100 -State Enabled -Action Block -Sensitivity High
		$ruleOverrideEntry2 = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId 500110 -State Enabled -Action Block -Sensitivity High
		$ruleGroupOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride -RuleGroupName ExcessiveRequests -Rule $ruleOverrideEntry1,$ruleOverrideEntry2
		$primarymanagedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$ddosmanagedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "Microsoft_HTTPDDoSRuleSet" -RuleSetVersion "1.0" -RuleGroupOverride $ruleGroupOverrideEntry
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $primarymanagedRuleSet,$ddosmanagedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleSetType "Microsoft_HTTPDDoSRuleSet"
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleSetVersion "1.0"
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleGroupOverrides[0].RuleGroupName $ruleGroupOverrideEntry.RuleGroupName
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleGroupOverrides[0].Rules[0].Sensitivity $ruleOverrideEntry1.Sensitivity
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleGroupOverrides[0].Rules[0].Action $ruleOverrideEntry1.Action
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleGroupOverrides[0].Rules[1].Sensitivity $ruleOverrideEntry2.Sensitivity
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets[1].RuleGroupOverrides[0].Rules[1].Action $ruleOverrideEntry2.Action
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway v2 waf policy default managed rule set
#>
function Test-ApplicationGatewayFirewallPolicyDefaultRuleSet

{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -PolicySetting $policySettings

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets.RuleSetType "Microsoft_DefaultRuleSet"
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets.RuleSetVersion "2.1"

	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}


<#
.SYNOPSIS
Application gateway v2 waf policy with per rule exclusions
#>
function Test-ApplicationGatewayFirewallPolicyWithPerRuleExclusions
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicyName = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		
		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check firewall policy
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		# Add Per Rule Exclusions to the firewall policy
		$ruleEntry1 = New-AzApplicationGatewayFirewallPolicyExclusionManagedRule -RuleId 942100
		$ruleEntry2 = New-AzApplicationGatewayFirewallPolicyExclusionManagedRule -RuleId 942110
		$sqlRuleGroupEntry = New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup -Name REQUEST-942-APPLICATION-ATTACK-SQLI -Rule $ruleEntry1,$ruleEntry2

		$ruleEntry3 = New-AzApplicationGatewayFirewallPolicyExclusionManagedRule -RuleId 941100
		$xssRuleGroupEntry = New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup -Name REQUEST-941-APPLICATION-ATTACK-XSS -Rule $ruleEntry3

		$exclusionRuleSetEntry = New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet -Type "OWASP" -Version "3.2" -RuleGroup $sqlRuleGroupEntry,$xssRuleGroupEntry

		$exclusionEntry = New-AzApplicationGatewayFirewallPolicyExclusion -MatchVariable RequestArgNames -SelectorMatchOperator Contains -Selector Bingo -ExclusionManagedRuleSet $exclusionRuleSetEntry
				
		$managedRules = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet -Exclusion $exclusionEntry
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 750 -MaxRequestBodySizeInKb 128
		$policy.managedRules = $managedRules
		$policy.PolicySettings = $policySettings
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		# Second check firewall policy
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $policy.ManagedRules.ManagedRuleSets.Count 1
		Assert-AreEqual $policy.ManagedRules.Exclusions.Count 1
		Assert-AreEqual $policy.ManagedRules.Exclusions[0].ExclusionManagedRuleSets.Count 1
		Assert-AreEqual $policy.ManagedRules.Exclusions[0].ExclusionManagedRuleSets[0].RuleGroups.Count 2
		Assert-AreEqual $policy.ManagedRules.Exclusions[0].ExclusionManagedRuleSets[0].RuleGroups[0].Rules.Count 2
		Assert-AreEqual $policy.ManagedRules.Exclusions[0].ExclusionManagedRuleSets[0].RuleGroups[1].Rules.Count 1
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Application gateway v2 waf policy with log scrubbing
#>
function Test-ApplicationGatewayFirewallPolicyWithLogScrubbing
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicyName = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		
		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Lowercase -NegationCondition $False
		$logScrubbingRule1 = New-AzApplicationGatewayFirewallPolicyLogScrubbingRule -State Enabled -MatchVariable RequestArgNames -SelectorMatchOperator Equals -Selector test
		$logScrubbingRule2 = New-AzApplicationGatewayFirewallPolicyLogScrubbingRule -State Enabled -MatchVariable RequestIPAddress -SelectorMatchOperator EqualsAny
		$logScrubbingRuleConfig = New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration -State Enabled -ScrubbingRule $logScrubbingRule1, $logScrubbingRule2
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 4000 -MaxRequestBodySizeInKb 2000 -LogScrubbing $logScrubbingRuleConfig
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check firewall policy
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
		Assert-AreEqual $policy.PolicySettings.LogScrubbing.ScrubbingRules.Count 2
		Assert-AreEqual $policy.PolicySettings.LogScrubbing.ScrubbingRules[0].State $policySettings.LogScrubbing.ScrubbingRules[0].State
		Assert-AreEqual $policy.PolicySettings.LogScrubbing.ScrubbingRules[0].MatchVariable $policySettings.LogScrubbing.ScrubbingRules[0].MatchVariable
		Assert-AreEqual $policy.PolicySettings.LogScrubbing.ScrubbingRules[0].SelectorMatchOperator $policySettings.LogScrubbing.ScrubbingRules[0].SelectorMatchOperator
		Assert-AreEqual $policy.PolicySettings.LogScrubbing.ScrubbingRules[0].Selector $policySettings.LogScrubbing.ScrubbingRules[0].Selector

	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
This case tests the per-listener HostNames feature.
#>
function Test-ApplicationGatewayWithListenerHostNames
{
		param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

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

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"
	$customError403Url02 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403.htm"

	$urlPathMapName = Get-ResourceName
	$urlPathMapName2 = Get-ResourceName
	$PathRuleName = Get-ResourceName
	$PathRule01Name = Get-ResourceName
	$redirectName = Get-ResourceName
	$sslCert01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName

	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name -Port 80
		$fp02 = New-AzApplicationGatewayFrontendPort -Name $frontendPort02Name -Port 443

		$listenerPolicyName = "listenerhttpPolicy"
		$policySetting = New-AzApplicationGatewayFirewallPolicySetting -Mode "Prevention" -State Enabled -MaxFileUploadInMb 300 
		New-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname -Location $location -PolicySetting $policySetting
		$httpPolicy = Get-AzApplicationGatewayFirewallPolicy -Name $listenerPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $httpPolicy.PolicySettings.FileUploadLimitInMb  $policySetting.FileUploadLimitInMb
		Assert-AreEqual $httpPolicy.PolicySettings.Mode  $policySetting.Mode
		Assert-AreEqual $httpPolicy.PolicySettings.State  $policySetting.State


		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -RequireServerNameIndication false -FirewallPolicy $httpPolicy

		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

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
		Assert-AreEqual $videoPathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
		$imagePathRule = New-AzApplicationGatewayPathRuleConfig -Name $PathRule01Name -Paths "/image" -RedirectConfigurationId $redirectConfig.Id -RewriteRuleSetId $rewriteRuleSet.Id
		Assert-AreEqual $imagePathRule.RewriteRuleSet.Id $rewriteRuleSet.Id
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
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostNames "TestHostName" -SslCertificate $sslCert
		$listener02 = Get-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name
		Add-AzApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener03Name -Protocol Https -FrontendIPConfiguration $fipconfig -FrontendPort $fp02 -HostName TestName -SslCertificate $sslCert
		$urlPathMap = Get-AzApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Add-AzApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType PathBasedRouting -Priority 101 -HttpListener $listener02 -UrlPathMap $urlPathMap

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
		$appgw = Set-AzApplicationGateway -ApplicationGateway $appgw

        # Get Application Gateway
		$appgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# First Check firewall configuraiton
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.Enabled $true
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.FirewallMode "Prevention"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RuleSetType "OWASP"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RuleSetVersion "2.2.9"
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count 2
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.RequestBodyCheck $true
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.MaxRequestBodySizeInKb 80
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.FileUploadLimitInMb 70
		Assert-AreEqual $appgw.WebApplicationFirewallConfiguration.Exclusions.Count 2
        
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

function Test-ApplicationGatewayWithPrivateLinkConfiguration
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$plsSubnetName = Get-ResourceName
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

	$privateLinkIpConfigName1 = Get-ResourceName
	$privateLinkIpConfigName2 = Get-ResourceName
	$privateLinkIpConfigName3 = Get-ResourceName

	$privateLinkConfigName = Get-ResourceName
	$privateLinkConfigName2 = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24  -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
		$plsSubnet = New-AzVirtualNetworkSubnetConfig -Name $plsSubnetName -AddressPrefix 10.0.1.0/24  -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $plsSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
		$plsSubnet = Get-AzVirtualNetworkSubnetConfig -Name $plsSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -Zone 1,2 -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		# private link configuration
		$privateLinkIpConfiguration1 =  New-AzApplicationGatewayPrivateLinkIpConfiguration -Name $privateLinkIpConfigName1 -Subnet $plsSubnet -Primary
		$privateLinkIpConfiguration2 =  New-AzApplicationGatewayPrivateLinkIpConfiguration -Name $privateLinkIpConfigName2 -Subnet $plsSubnet
		$privateLinkConfiguration = New-AzApplicationGatewayPrivateLinkConfiguration -Name $privateLinkConfigName -IpConfiguration $privateLinkIpConfiguration1, $privateLinkIpConfiguration2

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip -PrivateLinkConfiguration $privateLinkConfiguration
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -port 1234
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSetting -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01
		
		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2

		# autoscale configuration
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01 -AutoscaleConfiguration $autoscaleConfig -PrivateLinkConfiguration $privateLinkConfiguration

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# Verify PrivateLink Configuration
		Assert-NotNull $getgw.PrivateLinkConfigurations
		Assert-AreEqual 1 $getgw.PrivateLinkConfigurations.Count
		$getPrivateLinkConfig = Get-AzApplicationGatewayPrivateLinkConfiguration -Name $privateLinkConfigName -ApplicationGateway $getgw
        Assert-NotNull $getPrivateLinkConfig
		Assert-AreEqual $getPrivateLinkConfig.IpConfigurations.Count 2
		
		# Verify Frontend Ip has PrivateLink Configuration
		$getFipConfig = Get-AzApplicationGatewayFrontendIPConfig -ApplicationGateway $getgw -Name $fipconfigName
		Assert-NotNull $getFipconfig
		Assert-NotNull $getFipconfig.PrivateLinkConfiguration
		Assert-AreEqual $getPrivateLinkConfig.Id $getFipconfig.PrivateLinkConfiguration.Id

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		# Set AppGw
		$getgw01 = Set-AzApplicationGateway -ApplicationGateway $getgw

		# Cannot add same PrivateLinkConfiguration
		Assert-ThrowsLike { Add-AzApplicationGatewayPrivateLinkConfiguration -ApplicationGateway $getgw01 -Name $privateLinkConfigName -IpConfiguration $privateLinkIpConfiguration1 } "*already exists*"

		# add another private link configuration and change the ip configuration
		$getgw01 = Add-AzApplicationGatewayPrivateLinkConfiguration -ApplicationGateway $getgw01 -Name $privateLinkConfigName2 -IpConfiguration $privateLinkIpConfiguration1
		$privateLinkIpConfiguration3 =  New-AzApplicationGatewayPrivateLinkIpConfiguration -Name $privateLinkIpConfigName3 -Subnet $plsSubnet -Primary
		$getgw01 = Set-AzApplicationGatewayPrivateLinkConfiguration -ApplicationGateway $getgw01 -Name $privateLinkConfigName2 -IpConfiguration $privateLinkIpConfiguration3
		$getPrivateLinkConfig = Get-AzApplicationGatewayPrivateLinkConfiguration -Name $privateLinkConfigName2 -ApplicationGateway $getgw01
        Assert-NotNull $getPrivateLinkConfig
		Assert-AreEqual $getPrivateLinkConfig.IpConfigurations.Count 1
		Assert-AreEqual $getPrivateLinkConfig.IpConfigurations.Name $privateLinkIpConfigName3

		# add / remove privateLinkConfiguration
        $getgw = Set-AzApplicationGateway -ApplicationGateway $getgw01
        $privateLinkConfigurations = Get-AzApplicationGatewayPrivateLinkConfiguration -ApplicationGateway $getgw
        Assert-NotNull $privateLinkConfigurations
        Assert-AreEqual $privateLinkConfigurations.Count 2

        $getgw01 = Remove-AzApplicationGatewayPrivateLinkConfiguration -ApplicationGateway $getgw01 -Name $privateLinkConfigName2
        $getgw = Set-AzApplicationGateway -ApplicationGateway $getgw01

        $privateLinkConfigurations = Get-AzApplicationGatewayPrivateLinkConfiguration -ApplicationGateway $getgw
        Assert-NotNull $privateLinkConfigurations
        Assert-AreEqual $privateLinkConfigurations.Count 1

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayPrivateEndpointWorkFlows
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
	$plsSubnetName = Get-ResourceName
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

	$privateLinkIpConfigName = Get-ResourceName
	$privateLinkConfigName = Get-ResourceName

	$peRgName = Get-ResourceGroupName
	$peVnetName = Get-ResourceName
	$peSubnetName = Get-ResourceName
	$peName = Get-ResourceName
	$peConnName = Get-ResourceName

	try
	{
		# Create the appgw resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24  -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
		$plsSubnet = New-AzVirtualNetworkSubnetConfig -Name $plsSubnetName -AddressPrefix 10.0.1.0/24  -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $plsSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
		$plsSubnet = Get-AzVirtualNetworkSubnetConfig -Name $plsSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		# private link configuration
		$privateLinkIpConfiguration = New-AzApplicationGatewayPrivateLinkIpConfiguration -Name $privateLinkIpConfigName -Subnet $plsSubnet -Primary
		$privateLinkConfiguration = New-AzApplicationGatewayPrivateLinkConfiguration -Name $privateLinkConfigName -IpConfiguration $privateLinkIpConfiguration

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip -PrivateLinkConfiguration $privateLinkConfiguration
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -port 1234
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSetting -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01
		
		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2

		# autoscale configuration
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -TrustedRootCertificate $trustedRoot01 -AutoscaleConfiguration $autoscaleConfig -PrivateLinkConfiguration $privateLinkConfiguration

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# Verify PrivateLink Configuration
		Assert-NotNull $getgw.PrivateLinkConfigurations
		Assert-AreEqual 1 $getgw.PrivateLinkConfigurations.Count
		$getPrivateLinkConfig = Get-AzApplicationGatewayPrivateLinkConfiguration -Name $privateLinkConfigName -ApplicationGateway $getgw
        Assert-NotNull $getPrivateLinkConfig
		Assert-AreEqual $getPrivateLinkConfig.IpConfigurations.Count 1
		
		# Get Private Link Resource
		$privateLinkResource = Get-AzPrivateLinkResource -PrivateLinkResourceId $getgw.Id
		Assert-AreEqual $privateLinkResource.Name $fipconfigName
		Assert-AreEqual $privateLinkResource.GroupId $fipconfigName

		# Create the private endpoint resource group, vnet and subnet
		$peRg = New-AzResourceGroup -Name $peRgName -Location $location -Tags @{ testtag = "APPGw PrivateEndpoint tag"}
		$peSubnet = New-AzVirtualNetworkSubnetConfig -Name $peSubnetName -AddressPrefix 20.0.1.0/24  -PrivateEndpointNetworkPolicies "Disabled"
		$peVnet = New-AzVirtualNetwork -Name $peVnetName -ResourceGroupName $peRgName -Location $location -AddressPrefix 20.0.0.0/16 -Subnet $peSubnet
		$peVnet = Get-AzVirtualNetwork -Name $peVnetName -ResourceGroupName $peRgName
		$peSubnet = Get-AzVirtualNetworkSubnetConfig -Name $peSubnetName -VirtualNetwork $peVnet

		# Set Private Endpoint Connection in memory
		$connection = New-AzPrivateLinkServiceConnection -Name $peConnName -PrivateLinkServiceId $getgw.Id -GroupId $privateLinkResource.GroupId
		$privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $peRgName -Name $peName -Location $location -Subnet $peSubnet -PrivateLinkServiceConnection $connection -ByManualRequest

		# Get Private Endpoint and verify
		$privateEndpoint = Get-AzPrivateEndpoint -ResourceGroupName $peRgName -Name $peName
		Assert-AreEqual "Succeeded" $privateEndpoint.ProvisioningState

		# Verify PrivateEndpointConnections using appgw Id
		$connection = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $getgw.Id
		Assert-AreEqual 1 $connection.Count
		Assert-NotNull $connection.PrivateEndpoint
		Assert-NotNull $connection.PrivateLinkServiceConnectionState
		Assert-AreEqual $privateEndpoint.Id $connection.PrivateEndpoint.Id
		Assert-AreEqual "Pending" $connection.PrivateLinkServiceConnectionState.Status

		# Verify PrivateEndpointConnections using connection Id
		$connection = Get-AzPrivateEndpointConnection -ResourceId $connection.Id
		Assert-NotNull $connection.PrivateEndpoint
		Assert-NotNull $connection.PrivateLinkServiceConnectionState
		Assert-AreEqual $privateEndpoint.Id $connection.PrivateEndpoint.Id
		Assert-AreEqual "Pending" $connection.PrivateLinkServiceConnectionState.Status
		
		# Verify PrivateEndpointConnections on Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Assert-AreEqual 1 $getgw.PrivateEndpointConnections.Count
		$connection = $getgw.PrivateEndpointConnections

		# Approve Connection
		$approve = Approve-AzPrivateEndpointConnection -ResourceId $connection.Id
		Assert-NotNull $approve;
        Assert-AreEqual "Approved" $approve.PrivateLinkServiceConnectionState.Status
		Start-TestSleep -Seconds 30

		# Deny Connection
		$deny = Deny-AzPrivateEndpointConnection -ResourceId $connection.Id
		Assert-NotNull $deny;
        Assert-AreEqual "Rejected" $deny.PrivateLinkServiceConnectionState.Status
		Start-TestSleep -Seconds 30

		# Remove Connection
		$remove = Remove-AzPrivateEndpointConnection -ResourceId $connection.Id -Force
		Start-TestSleep -Seconds 30

		# Verify PrivateEndpointConnections on Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Assert-AreEqual 0 $getgw.PrivateEndpointConnections.Count

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $peRgName

		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayCRUDWithMutualAuthentication
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "East US"

	$rgname = Get-ResourceGroupName
	$appgwName = Get-ResourceName
	$vnetName = Get-ResourceName
	$gwSubnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$gipconfigname = Get-ResourceName

	$frontendPortName = Get-ResourceName
	$fipconfigName = Get-ResourceName
	$listenerName = Get-ResourceName

	$poolName = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSettingName = Get-ResourceName

	$sslCertName = Get-ResourceName
	$trustedClientCert01Name = Get-ResourceName
	$trustedClientCert02Name = Get-ResourceName
	$sslProfile01Name = Get-ResourceName
	$sslProfile02Name = Get-ResourceName
    
	$ruleName = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -Zone 1,2 -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		# Frontend part
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$password = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCertPath = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert = New-AzApplicationGatewaySslCertificate -Name $sslCertName -CertificateFile $sslCertPath -Password $password

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$port = New-AzApplicationGatewayFrontendPort -Name $frontendPortName  -Port 443

		$clientCertFilePath = $basedir + "/ScenarioTests/Data/TrustedClientCertificate.cer"
		$trustedClient01 = New-AzApplicationGatewayTrustedClientCertificate -Name $trustedClientCert01Name -CertificateFile $clientCertFilePath
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_0 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		$clientAuthConfig = New-AzApplicationGatewayClientAuthConfiguration -VerifyClientCertIssuerDN -VerifyClientRevocation OCSP
		Assert-AreEqual $True $clientAuthConfig.VerifyClientCertIssuerDN
		Assert-AreEqual "OCSP" $clientAuthConfig.VerifyClientRevocation

		$sslProfile01 = New-AzApplicationGatewaySslProfile -Name $sslProfile01Name -SslPolicy $sslPolicy -ClientAuthConfiguration $clientAuthConfig -TrustedClientCertificates $trustedClient01
		Assert-AreEqual "OCSP" $sslProfile01.ClientAuthConfiguration.VerifyClientRevocation

		$listener = New-AzApplicationGatewayHttpListener -Name $listenerName -Protocol Https -SslCertificate $sslCert -FrontendIPConfiguration $fipconfig -FrontendPort $port -SslProfile $sslProfile01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot = New-AzApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting = New-AzApplicationGatewayBackendHttpSettings -Name $poolSettingName -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot
		
		# rule
		$rule = New-AzApplicationGatewayRequestRoutingRule -Name $ruleName -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting -HttpListener $listener -BackendAddressPool $pool
		
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		$sslPolicyGlobal = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $port -HttpListeners $listener -RequestRoutingRules $rule -Sku $sku -SslPolicy $sslPolicyGlobal -TrustedRootCertificate $trustedRoot -AutoscaleConfiguration $autoscaleConfig -TrustedClientCertificates $trustedClient01 -SslProfiles $sslProfile01 -SslCertificates $sslCert

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		$sslProfile01 = Get-AzApplicationGatewaySslProfile -Name $sslProfile01Name -ApplicationGateway $getgw 
		$sslProfiles = Get-AzApplicationGatewaySslProfile -ApplicationGateway $getgw
		Assert-AreEqual $sslProfiles.Count 1
		Assert-AreEqual $sslProfiles[0].Id $sslProfile01.Id
		Assert-AreEqual $sslProfile01.TrustedClientCertificates.Count 1
		Assert-AreEqual $sslProfiles.TrustedClientCertificates[0].Id $trustedClient01.Id

		$trustedClients = Get-AzApplicationGatewayTrustedClientCertificate -ApplicationGateway $getgw
		Assert-AreEqual $trustedClients.Count 1
		Assert-AreEqual $trustedClients[0].Id $trustedClient01.Id

		$clientAuthConfig = Get-AzApplicationGatewayClientAuthConfiguration -SslProfile $sslProfile01
		Assert-NotNull $clientAuthConfig
		Assert-AreEqual $True $clientAuthConfig.VerifyClientCertIssuerDN
		Assert-AreEqual "OCSP" $clientAuthConfig.VerifyClientRevocation

		$getpolicy = Get-AzApplicationGatewaySslProfilePolicy -SslProfile $sslProfile01
		Assert-AreEqual $sslPolicy.MinProtocolVersion $getpolicy.MinProtocolVersion

		$getgpolicy = Get-AzApplicationGatewaySslPolicy -ApplicationGateway $getgw
		Assert-AreEqual $sslPolicyGlobal.MinProtocolVersion $getgpolicy.MinProtocolVersion
		
		$listener = Get-AzApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listenerName
		Assert-AreEqual $listener.SslProfile.Id $sslProfile01.Id

		# Add and Set operations.
		$getgw = Add-AzApplicationGatewayTrustedClientCertificate -Name $trustedClientCert02Name -ApplicationGateway $getgw -CertificateFile $clientCertFilePath
		$trustedClient02 =  Get-AzApplicationGatewayTrustedClientCertificate -Name $trustedClientCert02Name -ApplicationGateway $getgw
		$getgw = Add-AzApplicationGatewaySslProfile -Name $sslProfile02Name -ApplicationGateway $getgw -TrustedClientCertificates $trustedClient01,$trustedClient02
		$sslProfile01 = Set-AzApplicationGatewayClientAuthConfiguration -SslProfile $sslProfile01
		Assert-AreEqual "None" $sslProfile01.ClientAuthConfiguration.VerifyClientRevocation

		$sslProfile01 = Set-AzApplicationGatewaySslProfilePolicy -SslProfile $sslProfile01 -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"
		$sslPolicy02 = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"
		$getgw = Set-AzApplicationGatewaySslProfile -Name $sslProfile02Name -ApplicationGateway $getgw -SslPolicy $sslPolicy02 -TrustedClientCertificates $trustedClient01,$trustedClient02 -ClientAuthConfiguration $clientAuthConfig 

		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw

		$sslProfile01 = Get-AzApplicationGatewaySslProfile -Name $sslProfile01Name -ApplicationGateway $getgw
		$sslProfile02 = Get-AzApplicationGatewaySslProfile -Name $sslProfile02Name -ApplicationGateway $getgw 
		$sslProfiles = Get-AzApplicationGatewaySslProfile -ApplicationGateway $getgw
		Assert-AreEqual $sslProfiles.Count 2
        Assert-AreEqual $sslProfile02.TrustedClientCertificates.Count 2
        Assert-AreEqual $sslProfile02.TrustedClientCertificates[0].Id $trustedClient01.Id
		Assert-AreEqual $sslProfile02.TrustedClientCertificates[1].Id $trustedClient02.Id

		$getpolicy = Get-AzApplicationGatewaySslProfilePolicy -SslProfile $sslProfile01
		Assert-AreEqual $getpolicy.MinProtocolVersion $sslPolicyGlobal.MinProtocolVersion

        $trustedClient02 = Get-AzApplicationGatewayTrustedClientCertificate -Name $trustedClientCert02Name -ApplicationGateway $getgw 
		$trustedClients = Get-AzApplicationGatewayTrustedClientCertificate -ApplicationGateway $getgw
		Assert-AreEqual $trustedClients.Count 2
		Assert-AreEqual $trustedClients[0].Id $trustedClient01.Id
		Assert-AreEqual $trustedClients[1].Id $trustedClient02.Id

		$clientAuthConfig = Get-AzApplicationGatewayClientAuthConfiguration -SslProfile $getgw.SslProfiles[0]
		Assert-AreEqual $False $clientAuthConfig.VerifyClientCertIssuerDN
		Assert-AreEqual "None" $clientAuthConfig.VerifyClientRevocation

		# Remove operations.
		$sslProfile02 = Remove-AzApplicationGatewaySslProfilePolicy -SslProfile $sslProfile02
		$getpolicy = Get-AzApplicationGatewaySslProfilePolicy -SslProfile $sslProfile02
		Assert-Null $getpolicy
		$sslProfile02 = Remove-AzApplicationGatewayClientAuthConfiguration -SslProfile $sslProfile02
		$clientAuthConfig = Get-AzApplicationGatewayClientAuthConfiguration -SslProfile $sslProfile02
		Assert-Null $clientAuthConfig
		$getgw = Remove-AzApplicationGatewaySslProfile -Name $sslProfile02Name -ApplicationGateway $getgw
		$getgw = Remove-AzApplicationGatewayTrustedClientCertificate -Name $trustedClientCert02Name -ApplicationGateway $getgw
		$getgw = Set-AzApplicationGateway -ApplicationGateway $getgw
		$sslProfiles = Get-AzApplicationGatewaySslProfile -ApplicationGateway $getgw
		Assert-AreEqual $sslProfiles.Count 1
		$trustedClients = Get-AzApplicationGatewayTrustedClientCertificate -ApplicationGateway $getgw
		Assert-AreEqual $trustedClients.Count 1

		# Negative tests.
		Assert-ThrowsLike { Add-AzApplicationGatewaySslProfile -Name $sslProfile01Name -ApplicationGateway $getgw -TrustedClientCertificates $trustedClient01 } "*already exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewaySslProfile -Name "fakeName" -ApplicationGateway $getgw -TrustedClientCertificates $trustedClient01 } "*does not exist*"
		Assert-ThrowsLike { Add-AzApplicationGatewayTrustedClientCertificate -Name $trustedClientCert01Name -ApplicationGateway $getgw -CertificateFile $clientCertFilePath } "*already exist*"
		Assert-ThrowsLike { Set-AzApplicationGatewayTrustedClientCertificate -Name "fakeName" -ApplicationGateway $getgw -CertificateFile $clientCertFilePath } "*does not exist*"

		# Delete Application Gateway
		Remove-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithCustomRules
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"
	$rgname = Get-ResourceGroupName
	$wafPolicyName = "wafPolicy1"

	try {
		
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy with custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Malicious-Header
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator Any -NegationCondition $False
		$customRule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block

		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings -CustomRule $customRule

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check WAF policy
		Assert-AreEqual $policy.CustomRules[0].Name $customRule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $customRule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $customRule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $customRule.Priority
		Assert-AreEqual $policy.CustomRules[0].State "Enabled"
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $customRule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $customRule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $customRule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $customRule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		$policy.CustomRules[0].State = "Disabled"
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy
		$policy1 = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $policy1.CustomRules[0].State "Disabled"
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithRateLimitRule
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"
	$rgname = Get-ResourceGroupName
	$wafPolicyName = "wafPolicy1"

	try {
		
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy with rate limiting rule custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Malicious-Header
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator Any -NegationCondition $False
		$groupbyVar = New-AzApplicationGatewayFirewallCustomRuleGroupByVariable -VariableName ClientAddr 
		$groupbyUserSes = New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession -GroupByVariable $groupbyVar
		$customRule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RateLimitDuration OneMin -RateLimitThreshold 10 -RuleType RateLimitRule -MatchCondition $condition -GroupByUserSession $groupbyUserSes -Action Block

		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings -CustomRule $customRule

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check WAF policy
		Assert-AreEqual $policy.CustomRules[0].Name $customRule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $customRule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $customRule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $customRule.Priority
		Assert-AreEqual $policy.CustomRules[0].RateLimitDuration $customRule.RateLimitDuration
		Assert-AreEqual $policy.CustomRules[0].RateLimitThreshold $customRule.RateLimitThreshold
		Assert-AreEqual $policy.CustomRules[0].State "Enabled"
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $customRule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $customRule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $customRule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $customRule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.CustomRules[0].GroupByUserSession[0].GroupByVariables[0].VariableName $customRule.GroupByUserSession[0].GroupByVariables[0].VariableName
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		$policy.CustomRules[0].State = "Disabled"
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy
		$policy1 = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $policy1.CustomRules[0].State "Disabled"
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithRateLimitRuleGeoLocation
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"
	$rgname = Get-ResourceGroupName
	$wafPolicyName = "wafPolicy1"

	try {
		
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy with rate limiting rule custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Malicious-Header
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator Any -NegationCondition $False
		$groupbyVar = New-AzApplicationGatewayFirewallCustomRuleGroupByVariable -VariableName GeoLocation 
		$groupbyUserSes = New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession -GroupByVariable $groupbyVar
		$customRule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RateLimitDuration OneMin -RateLimitThreshold 10 -RuleType RateLimitRule -MatchCondition $condition -GroupByUserSession $groupbyUserSes -Action Block

		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings -CustomRule $customRule

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check WAF policy
		Assert-AreEqual $policy.CustomRules[0].Name $customRule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $customRule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $customRule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $customRule.Priority
		Assert-AreEqual $policy.CustomRules[0].RateLimitDuration $customRule.RateLimitDuration
		Assert-AreEqual $policy.CustomRules[0].RateLimitThreshold $customRule.RateLimitThreshold
		Assert-AreEqual $policy.CustomRules[0].State "Enabled"
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $customRule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $customRule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $customRule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $customRule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.CustomRules[0].GroupByUserSession[0].GroupByVariables[0].VariableName $customRule.GroupByUserSession[0].GroupByVariables[0].VariableName
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		$policy.CustomRules[0].State = "Disabled"
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy
		$policy1 = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $policy1.CustomRules[0].State "Disabled"
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithUppercaseTransform
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Uppercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Second check firewll policy
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithInspectionLimit
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy and Custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Content-Length
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator GreaterThan -MatchValue 1000 -Transform Uppercase -NegationCondition $False
		$rule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -DisableRequestBodyEnforcement $True -RequestBodyInspectLimitInKB 2000 -MaxFileUploadInMb 70 -DisableFileUploadEnforcement $True -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname
		$policy.CustomRules = $rule
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Check firewall policy
		Assert-AreEqual $policy.CustomRules[0].Name $rule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $rule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $rule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $rule.Priority
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $rule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].Transforms[0] $rule.MatchConditions[0].Transforms[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $rule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchValues[0] $rule.MatchConditions[0].MatchValues[0]
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $rule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $rule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
		Assert-AreEqual $False $policySettings.RequestBodyEnforcement
		Assert-AreEqual $policy.PolicySettings.RequestBodyInspectLimitInKB $policySettings.RequestBodyInspectLimitInKB
		Assert-AreEqual $False $policySettings.FileUploadEnforcement
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithJSChallenge
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"
	$rgname = Get-ResourceGroupName
	$wafPolicyName = "wafPolicy1"

	try {
		
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy with custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Malicious-Header
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator Any -NegationCondition $False
		$customRule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Block

		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70 -JSChallengeCookieExpirationInMins 100
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings -CustomRule $customRule

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check WAF policy
		Assert-AreEqual $policy.CustomRules[0].Name $customRule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $customRule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $customRule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $customRule.Priority
		Assert-AreEqual $policy.CustomRules[0].State "Enabled"
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $customRule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $customRule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $customRule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $customRule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State
		Assert-AreEqual $policy.PolicySettings.JSChallengeCookieExpirationInMins $policySettings.JSChallengeCookieExpirationInMins
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyCustomRuleRemoval
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"
	$rgname = Get-ResourceGroupName
	$wafPolicyName = "wafPolicy1"

	try {
		
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# WAF Policy with rate limiting rule custom Rule
		$variable = New-AzApplicationGatewayFirewallMatchVariable -VariableName RequestHeaders -Selector Malicious-Header
		$condition =  New-AzApplicationGatewayFirewallCondition -MatchVariable $variable -Operator Any -NegationCondition $False
		$groupbyVar = New-AzApplicationGatewayFirewallCustomRuleGroupByVariable -VariableName GeoLocation 
		$groupbyUserSes = New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession -GroupByVariable $groupbyVar
		$customRule = New-AzApplicationGatewayFirewallCustomRule -Name example -Priority 2 -RateLimitDuration OneMin -RateLimitThreshold 10 -RuleType RateLimitRule -MatchCondition $condition -GroupByUserSession $groupbyUserSes -Action Block

		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet 
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings -CustomRule $customRule

		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname

		# Check WAF policy
		Assert-AreEqual $policy.CustomRules[0].Name $customRule.Name
		Assert-AreEqual $policy.CustomRules[0].RuleType $customRule.RuleType
		Assert-AreEqual $policy.CustomRules[0].Action $customRule.Action
		Assert-AreEqual $policy.CustomRules[0].Priority $customRule.Priority
		Assert-AreEqual $policy.CustomRules[0].RateLimitDuration $customRule.RateLimitDuration
		Assert-AreEqual $policy.CustomRules[0].RateLimitThreshold $customRule.RateLimitThreshold
		Assert-AreEqual $policy.CustomRules[0].State "Enabled"
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].OperatorProperty $customRule.MatchConditions[0].OperatorProperty
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].NegationConditon $customRule.MatchConditions[0].NegationConditon
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].VariableName $customRule.MatchConditions[0].MatchVariables[0].VariableName
		Assert-AreEqual $policy.CustomRules[0].MatchConditions[0].MatchVariables[0].Selector $customRule.MatchConditions[0].MatchVariables[0].Selector
		Assert-AreEqual $policy.CustomRules[0].GroupByUserSession[0].GroupByVariables[0].VariableName $customRule.GroupByUserSession[0].GroupByVariables[0].VariableName
		Assert-AreEqual $policy.PolicySettings.FileUploadLimitInMb $policySettings.FileUploadLimitInMb
		Assert-AreEqual $policy.PolicySettings.MaxRequestBodySizeInKb $policySettings.MaxRequestBodySizeInKb
		Assert-AreEqual $policy.PolicySettings.RequestBodyCheck $policySettings.RequestBodyCheck
		Assert-AreEqual $policy.PolicySettings.Mode $policySettings.Mode
		Assert-AreEqual $policy.PolicySettings.State $policySettings.State

		$policy.CustomRules[0].State = "Disabled"
		Set-AzApplicationGatewayFirewallPolicy -InputObject $policy
		$policy1 = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-AreEqual $policy1.CustomRules[0].State "Disabled"

		#Remove Custom Rule
		Remove-AzApplicationGatewayFirewallCustomRule -Name $customRule.Name -ResourceGroupName $rgname -PolicyName $wafPolicyName
		$policynew = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicyName -ResourceGroupName $rgname
		Assert-Null $policynew.CustomRules[0]
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayFirewallPolicyWithCustomBlockResponse
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US 2"

	$rgname = Get-ResourceGroupName
	$wafPolicy = Get-ResourceName

	try
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}

		# Test both status and body are present
		$customBlockResponseBody = "Sorry! Forbidden"
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70 -CustomBlockResponseStatusCode 405 -CustomBlockResponseBody $customBlockResponseBody
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		New-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -Location $location -ManagedRule $managedRule -PolicySetting $policySettings
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		Assert-AreEqual $policySettings.FileUploadLimitInMb $policy.PolicySettings.FileUploadLimitInMb 
		Assert-AreEqual $policySettings.MaxRequestBodySizeInKb $policy.PolicySettings.MaxRequestBodySizeInKb 
		Assert-AreEqual $policySettings.RequestBodyCheck $policy.PolicySettings.RequestBodyCheck 
		Assert-AreEqual $policySettings.Mode $policy.PolicySettings.Mode 
		Assert-AreEqual $policySettings.State $policy.PolicySettings.State 
		Assert-AreEqual $policySettings.CustomBlockResponseStatusCode $policy.CustomBlockResponseStatusCode
		Assert-AreEqual $customBlockResponseBody $policy.CustomBlockResponseBody

		# test status code alone present
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70 -CustomBlockResponseStatusCode 405
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		Set-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -ManagedRule $managedRule -PolicySetting $policySettings
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Check firewall policy
		Assert-AreEqual $policySettings.FileUploadLimitInMb $policy.PolicySettings.FileUploadLimitInMb 
		Assert-AreEqual $policySettings.MaxRequestBodySizeInKb $policy.PolicySettings.MaxRequestBodySizeInKb 
		Assert-AreEqual $policySettings.RequestBodyCheck $policy.PolicySettings.RequestBodyCheck 
		Assert-AreEqual $policySettings.Mode $policy.PolicySettings.Mode 
		Assert-AreEqual $policySettings.State $policy.PolicySettings.State 
		Assert-AreEqual $policySettings.CustomBlockResponseStatusCode $policy.CustomBlockResponseStatusCode
		Assert-Null 	$policy.CustomBlockResponseBody

		# test body alone present 
		$customBlockResponseBody = "Sorry! Forbidden. You can't access"
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70 -CustomBlockResponseBody $customBlockResponseBody
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		Set-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -ManagedRule $managedRule -PolicySetting $policySettings
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Check firewall policy
		Assert-AreEqual $policySettings.FileUploadLimitInMb $policy.PolicySettings.FileUploadLimitInMb 
		Assert-AreEqual $policySettings.MaxRequestBodySizeInKb $policy.PolicySettings.MaxRequestBodySizeInKb 
		Assert-AreEqual $policySettings.RequestBodyCheck $policy.PolicySettings.RequestBodyCheck 
		Assert-AreEqual $policySettings.Mode $policy.PolicySettings.Mode 
		Assert-AreEqual $policySettings.State $policy.PolicySettings.State 
		Assert-Null 	$policy.CustomBlockResponseStatusCode
		Assert-AreEqual $customBlockResponseBody $policy.CustomBlockResponseBody 

		# test both are not present
		$policySettings = New-AzApplicationGatewayFirewallPolicySetting -Mode Prevention -State Enabled -MaxFileUploadInMb 70 -MaxRequestBodySizeInKb 70
		$managedRuleSet = New-AzApplicationGatewayFirewallPolicyManagedRuleSet -RuleSetType "OWASP" -RuleSetVersion "3.2"
		$managedRule = New-AzApplicationGatewayFirewallPolicyManagedRule -ManagedRuleSet $managedRuleSet
		Set-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname -ManagedRule $managedRule -PolicySetting $policySettings
	
		$policy = Get-AzApplicationGatewayFirewallPolicy -Name $wafPolicy -ResourceGroupName $rgname

		# Check firewall policy
		Assert-AreEqual $policySettings.FileUploadLimitInMb $policy.PolicySettings.FileUploadLimitInMb 
		Assert-AreEqual $policySettings.MaxRequestBodySizeInKb $policy.PolicySettings.MaxRequestBodySizeInKb 
		Assert-AreEqual $policySettings.RequestBodyCheck $policy.PolicySettings.RequestBodyCheck 
		Assert-AreEqual $policySettings.Mode $policy.PolicySettings.Mode 
		Assert-AreEqual $policySettings.State $policy.PolicySettings.State 
		Assert-Null 	$policy.CustomBlockResponseStatusCode
		Assert-Null 	$policy.CustomBlockResponseBody
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

function Test-ApplicationGatewayHeaderValueMatcher
{
	param
	(
		$basedir = "./"
	)

	# Setup
	$location = Get-ProviderLocation "Microsoft.Network/applicationGateways" "West US"

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
	$poolSetting01Name = Get-ResourceName

	$rewriteRuleName = Get-ResourceName
	$rewriteRuleSetName = Get-ResourceName
    $rewriteRuleSetName2 = Get-ResourceName
	$rule01Name = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		$pool = New-AzApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.httpbin.org
		$poolSetting01 = New-AzApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -CookieBasedAffinity Enabled
		$hvm = New-AzApplicationGatewayHeaderValueMatcher -Pattern ".*" -IgnoreCase -Negate

		#Rewrite Rule Set
		$headerConfiguration = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "Set-Cookie" -HeaderValue "def" -HeaderValueMatcher $hvm
		$actionSet = New-AzApplicationGatewayRewriteRuleActionSet -ResponseHeaderConfiguration $headerConfiguration
		$rewriteRule = New-AzApplicationGatewayRewriteRule -Name $rewriteRuleName -ActionSet $actionSet
		$rewriteRuleSet = New-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -RewriteRule $rewriteRule
		
		#rule
		$rule01 = New-AzApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -Priority 100 -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool -RewriteRuleSet $rewriteRuleSet

		# sku
		$sku = New-AzApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2

		# autoscale configuration
		$autoscaleConfig = New-AzApplicationGatewayAutoscaleConfiguration -MinCapacity 3

		# security part
		$sslPolicy = New-AzApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# Create Application Gateway
		$appgw = New-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -SslPolicy $sslPolicy -TrustedRootCertificate $trustedRoot01 -AutoscaleConfiguration $autoscaleConfig -RewriteRuleSet $rewriteRuleSet

		# Get Application Gateway
		$getgw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $rgname

        $rewriteRuleSet = Get-AzApplicationGatewayRewriteRuleSet -Name $rewriteRuleSetName -ApplicationGateway $getgw
        Assert-NotNull $rewriteRuleSet
        Assert-AreEqual $rewriteRuleSet.RewriteRules.Count 1
        Assert-NotNull $rewriteRuleSet.RewriteRules[0].ActionSet
		Assert-NotNull $rewriteRuleSet.RewriteRules[0].ActionSet[0].ResponseHeaderConfigurations.HeaderValueMatcher
		Assert-AreEqual $rewriteRuleSet.RewriteRules[0].ActionSet[0].ResponseHeaderConfigurations.HeaderValueMatcher.Pattern ".*"
		Assert-AreEqual $rewriteRuleSet.RewriteRules[0].ActionSet[0].ResponseHeaderConfigurations.HeaderValueMatcher.IgnoreCase $true
		Assert-AreEqual $rewriteRuleSet.RewriteRules[0].ActionSet[0].ResponseHeaderConfigurations.HeaderValueMatcher.Negate $true
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}