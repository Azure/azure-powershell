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
	$result = Get-AzureRmApplicationGatewayAvailableSslOptions
	Assert-NotNull $result
	Assert-NotNull $result.DefaultPolicy

	$result = Get-AzureRmApplicationGatewaySslPredefinedPolicy
	Assert-NotNull $result
	Assert-True { $result.Count -gt 0 }
	Assert-NotNull $result[0].MinProtocolVersion
	Assert-True { $result[0].CipherSuites -gt 0 }

	$result = Get-AzureRmApplicationGatewaySslPredefinedPolicy -Name AppGwSslPolicy20170401
	Assert-NotNull $result
	Assert-NotNull $result.MinProtocolVersion
	Assert-True { $result.CipherSuites -gt 0 }
}

function Test-AvailableWafRuleSets
{
	$result = Get-AzureRmApplicationGatewayAvailableWafRuleSets

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
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"} 
      
		# Create the Virtual Network
		$gwSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$nicSubnet = New-AzureRmVirtualNetworkSubnetConfig  -Name $nicSubnetName -AddressPrefix 10.0.2.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $nicSubnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
 		$nicSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $nicSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

		# create 2 nics to add to backend
		$nic01 = New-AzureRmNetworkInterface -Name $nic01Name -ResourceGroupName $rgname -Location $location -Subnet $nicSubnet
		$nic02 = New-AzureRmNetworkInterface -Name $nic02Name -ResourceGroupName $rgname -Location $location -Subnet $nicSubnet

		# Create application gateway configuration
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig01 = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfig01Name -PublicIPAddress $publicip
		$fipconfig02 = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfig02Name  -Subnet $gwSubnet

		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses 1.1.1.1, 2.2.2.2, 3.3.3.3
		# Add an empty backend address pool
		$nicPool = New-AzureRmApplicationGatewayBackendAddressPool -Name $nicPoolName

		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$fp02 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort02Name  -Port 8080

		$authCertFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$authcert01 = New-AzureRmApplicationGatewayAuthenticationCertificate -Name $authCertName -CertificateFile $authCertFilePath
		
		# Create match with undefined statuscode list
		$match1 = New-AzureRmApplicationGatewayProbeHealthResponseMatch -Body "helloworld"
		Assert-Null $match1.StatusCodes
		
		$probe01 = New-AzureRmApplicationGatewayProbeConfig -Name $probe01Name -Match $match1 -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		
		$connectionDraining01 = New-AzureRmApplicationGatewayConnectionDraining -Enabled $True -DrainTimeoutInSec 42
		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -Probe $probe01 -CookieBasedAffinity Disabled -ConnectionDraining $connectionDraining01
		Assert-NotNull $poolSetting01.connectionDraining
		Assert-AreEqual $True $poolSetting01.connectionDraining.Enabled
		Assert-AreEqual 42 $poolSetting01.connectionDraining.DrainTimeoutInSec
		Assert-NotNull $poolSetting01.Probe
		
		# Create match with empty statuscode list
		$match2 = New-AzureRmApplicationGatewayProbeHealthResponseMatch -Body "helloworld" -StatusCode "200"
		Assert-NotNull $match2.StatusCodes
		$match2.StatusCodes.RemoveAt(0)
		Assert-AreEqual 0 $match2.StatusCodes.Count

		$probe02 = New-AzureRmApplicationGatewayProbeConfig -Name $probe02Name -Match $match2 -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8

		$poolSetting02 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting02Name -Probe $probe02 -Port 443 -Protocol Https -CookieBasedAffinity Enabled -AuthenticationCertificates $authcert01
		Assert-Null $poolSetting02.connectionDraining
		Assert-NotNull $poolSetting02.Probe
		
		# Test setting and removing connectiondraining
		Set-AzureRmApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02 -Enabled $False -DrainTimeoutInSec 3600
		$connectionDraining02 = Get-AzureRmApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02
		Assert-NotNull $connectionDraining02
		Assert-AreEqual $False $connectionDraining02.Enabled
		Assert-AreEqual 3600 $connectionDraining02.DrainTimeoutInSec
		Remove-AzureRmApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02
		Assert-Null $poolSetting02.connectionDraining

		$ce01_listener = New-AzureRmApplicationGatewayCustomError -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01
		$ce02_listener = New-AzureRmApplicationGatewayCustomError -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url01

		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig01 -FrontendPort $fp01
		$listener02 = New-AzureRmApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig02 -FrontendPort $fp02 -CustomErrorConfiguration $ce01_listener,$ce02_listener

		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -BackendHttpSettings $poolSetting02 -HttpListener $listener02 -BackendAddressPool $pool

		$sku = New-AzureRmApplicationGatewaySku -Name WAF_Medium -Tier WAF -Capacity 2

		$sslPolicy = New-AzureRmApplicationGatewaySslPolicy -DisabledSslProtocols TLSv1_0, TLSv1_1

		$disabledRuleGroup1 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_41_sql_injection_attacks" -Rules 981318,981320
		$disabledRuleGroup2 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_35_bad_robots"
		$exclusion1 = New-AzureRmApplicationGatewayFirewallExclusionConfig -Variable "RequestHeaderNames" -Operator "StartsWith" -Selector "xyz"
		$exclusion2 = New-AzureRmApplicationGatewayFirewallExclusionConfig -Variable "RequestArgNames" -Operator "Equals" -Selector "a"
		$firewallConfig = New-AzureRmApplicationGatewayWebApplicationFirewallConfiguration -Enabled $true -FirewallMode Prevention -RuleSetType "OWASP" -RuleSetVersion "2.2.9" -DisabledRuleGroups $disabledRuleGroup1,$disabledRuleGroup2 -RequestBodyCheck $true -MaxRequestBodySizeInKb 80 -FileUploadLimitInMb 70 -Exclusion $exclusion1,$exclusion2

		$ce01_appgw = New-AzureRmApplicationGatewayCustomError -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$ce02_appgw = New-AzureRmApplicationGatewayCustomError -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url02

		# Create Application Gateway
		$job = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probe01, $probe02 -BackendAddressPools $pool, $nicPool -BackendHttpSettingsCollection $poolSetting01,$poolSetting02 -FrontendIpConfigurations $fipconfig01, $fipconfig02 -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RequestRoutingRules $rule01, $rule02 -Sku $sku -SslPolicy $sslPolicy -AuthenticationCertificates $authcert01 -WebApplicationFirewallConfiguration $firewallConfig -AsJob -CustomErrorConfiguration $ce01_appgw,$ce02_appgw
		$job | Wait-Job
		$appgw = $job | Receive-Job

		# Get Application Gateway
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname

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
		# $job = Get-AzureRmApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname -ExpandResource "backendhealth/applicationgatewayresource" -AsJob
		# $job | Wait-Job
		# $backendHealth = $job | Receive-Job
		# Assert-NotNull $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

		# Get Application Gateway backend health without expanded resource
		$backendHealth = Get-AzureRmApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname
		Assert-Null $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

		# add nics to application gateway backend address pool
		$nicPool = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $getgw -Name $nicPoolName
        $nic01.IpConfigurations[0].ApplicationGatewayBackendAddressPools.Add($nicPool);
        $nic02.IpConfigurations[0].ApplicationGatewayBackendAddressPools.Add($nicPool);

		 # set the nics
        $nic01 = $nic01 | Set-AzureRmNetworkInterface
        $nic02 = $nic02 | Set-AzureRmNetworkInterface

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
		$job = Set-AzureRmApplicationGateway -ApplicationGateway $getgw -AsJob
		$job | Wait-Job

		# Modify WAF config and verify that it can be retrieved
		$getgw = Set-AzureRmApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $getgw -Enabled $true -FirewallMode Detection
		$firewallConfig2 = Get-AzureRmApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $getgw		

		# Verify that default values got set
		Assert-AreEqual "OWASP"  $firewallConfig2.RuleSetType
		Assert-AreEqual "3.0"  $firewallConfig2.RuleSetVersion
		Assert-AreEqual $null  $firewallConfig2.DisabledRuleGroups
		Assert-AreEqual $True  $firewallConfig2.RequestBodyCheck
		Assert-AreEqual 128  $firewallConfig2.MaxRequestBodySizeInKb
		Assert-AreEqual 100  $firewallConfig2.FileUploadLimitInMb
		Assert-AreEqual $null  $firewallConfig2.Exclusions

		$getgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw

		Compare-WebApplicationFirewallConfiguration $firewallConfig2 $getgw.WebApplicationFirewallConfiguration

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

		# Get Custom Error from listener and appgw
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		$ce = Get-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url01 $ce.CustomErrorPageUrl

		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$ce = Get-AzureRmApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url02 $ce.CustomErrorPageUrl

		#Set Custom Error on listener and appgw
		#(403 error page on listener change from $customError403Url01 to $customError403Url02)
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		Set-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$updatedgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw
		$updatedlistener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $updatedgw -Name $listener02Name
		$ce = Get-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $updatedlistener -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url02 $ce.CustomErrorPageUrl

		#(403 error page on appgw change from $customError403Url02 to $customError403Url01)
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		Set-AzureRmApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01
		$updatedgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw
		$ce = Get-AzureRmApplicationGatewayCustomError -ApplicationGateway $updatedgw -StatusCode HttpStatus403
		Assert-AreEqual $customError403Url01 $ce.CustomErrorPageUrl

		#Remove Custom Error from listener and appgw
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		Remove-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus502
		$updatedgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw
		$updatedlistener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $updatedgw -Name $listener02Name
		$ceConfigs = Get-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $updatedlistener
		Assert-AreEqual 1 $ceConfigs.count
		Assert-AreEqual HttpStatus403 $ceConfigs[0].StatusCode

		Remove-AzureRmApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus502
		$updatedgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw
		$ceConfigs = Get-AzureRmApplicationGatewayCustomError -ApplicationGateway $updatedgw
		Assert-AreEqual 1 $ceConfigs.count
		Assert-AreEqual HttpStatus403 $ceConfigs[0].StatusCode

		#Add Custom Error on listener and appgw
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname
		$listener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $getgw -Name $listener02Name
		Add-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url01
		$updatedgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw
		$updatedlistener = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $updatedgw -Name $listener02Name
		$ceConfigs = Get-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $updatedlistener
		Assert-AreEqual 2 $ceConfigs.count

		Add-AzureRmApplicationGatewayCustomError -ApplicationGateway $getgw -StatusCode HttpStatus502 -CustomErrorPageUrl $customError502Url02
		$updatedgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw
		$ceConfigs = Get-AzureRmApplicationGatewayCustomError -ApplicationGateway $updatedgw
		Assert-AreEqual 2 $ceConfigs.count

		# Modify existing application gateway with new configuration
		$getgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw

		Assert-AreEqual "Running" $getgw.OperationalState

		# Stop Application Gateway
		$job = Stop-AzureRmApplicationGateway -ApplicationGateway $getgw -AsJob
		$job | Wait-Job
		$getgw = $job | Receive-Job

		Assert-AreEqual "Stopped" $getgw.OperationalState

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
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"} 
      
		# Create the Virtual Network
		$gwSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$nicSubnet = New-AzureRmVirtualNetworkSubnetConfig  -Name $nicSubnetName -AddressPrefix 10.0.2.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet, $nicSubnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet
 		$nicSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $nicSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

		# Create ip configuration
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		# frontend part
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert01Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert1.pfx"
		$sslCert01 = New-AzureRmApplicationGatewaySslCertificate -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01

		$fipconfig = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 443
		$fp02 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort02Name  -Port 80
		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Https -SslCertificate $sslCert01 -FrontendIPConfiguration $fipconfig -FrontendPort $fp01
		$listener02 = New-AzureRmApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp02

		# backend part
		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$match = New-AzureRmApplicationGatewayProbeHealthResponseMatch -Body "helloworld" -StatusCode "200-300","404"
		$probeHttp = New-AzureRmApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 -Match $match
		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 80 -Protocol Http -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		# rule part
		$redirect01 = New-AzureRmApplicationGatewayRedirectConfiguration -Name $redirect01Name -RedirectType Permanent -TargetListener $listener01

		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -HttpListener $listener02 -RedirectConfiguration $redirect01

		$sku = New-AzureRmApplicationGatewaySku -Name Standard_Medium -Tier Standard -Capacity 2

		# security part
		$sslPolicy = New-AzureRmApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# Create Application Gateway
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RedirectConfiguration $redirect01 -RequestRoutingRules $rule01, $rule02 -Sku $sku -SslPolicy $sslPolicy -SslCertificates $sslCert01 -EnableHttp2

		# Check get/set/remove for RedirectConfiguration
		$redirect02 = Get-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirect01Name
		Assert-AreEqual $redirect01.TargetListenerId $redirect02.TargetListenerId
		$getgw = Set-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirect01Name -RedirectType Permanent -TargetUrl "https://www.bing.com"

		$getgw = Add-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $getgw -Name $redirect03Name -RedirectType Permanent -TargetListener $listener01 -IncludePath $true
		$getgw = Remove-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $getgw -Name $redirect03Name

		# Check EnableHttp2 flag is true
		Assert-AreEqual $getgw.EnableHttp2 $true

		# Get for SslPolicy
		$sslPolicy01 = Get-AzureRmApplicationGatewaySslPolicy -ApplicationGateway $getgw
		Assert-AreEqual $sslPolicy.MinProtocolVersion $sslPolicy01.MinProtocolVersion

		# Set for sslPolicy
		$getgw = Set-AzureRmApplicationGatewaySslPolicy -ApplicationGateway $getgw -PolicyType Predefined -PolicyName AppGwSslPolicy20170401

		# Get Match
		$probeHttp01 = Get-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $getgw -Name $probeHttpName
		Assert-AreEqual $probeHttp.Match.Body $probeHttp01.Match.Body

		# Get Application Gateway
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Check SSLCertificates
		Assert-NotNull $getgw.SslCertificates[0]
		Assert-Null $getgw.SslCertificates[0].Password

		# Use Set/Add Certificate
		$getgw = Set-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $getgw -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01
		Assert-NotNull $getgw.SslCertificates[0].Password

		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$pw02 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert02Path = $basedir + "/ScenarioTests/Data/ApplicationGatewaySslCert2.pfx"
		$getgw = Add-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $getgw -Name $sslCert02Name -CertificateFile $sslCert02Path -Password $pw02

		# Modify existing application gateway with new configuration
		$getgw.EnableHttp2 = $false
		$getgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw

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
		$getgw = Stop-AzureRmApplicationGateway -ApplicationGateway $getgw

		Assert-AreEqual "Stopped" $getgw.OperationalState
 
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
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		# backend part
		# trusted root cert part
		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$trustedRoot01 = New-AzureRmApplicationGatewayTrustedRootCertificate -Name $trustedRootCertName -CertificateFile $certFilePath
		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$probeHttp = New-AzureRmApplicationGatewayProbeConfig -Name $probeHttpName -Protocol Https -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -Probe $probeHttp -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress -TrustedRootCertificate $trustedRoot01

		#rule
		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzureRmApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2

		# autoscale configuration
		$autoscaleConfig = New-AzureRmApplicationGatewayAutoscaleConfiguration -MinCapacity 3

		# security part
		$sslPolicy = New-AzureRmApplicationGatewaySslPolicy -PolicyType Custom -MinProtocolVersion TLSv1_1 -CipherSuite "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_GCM_SHA256"

		# Create Application Gateway
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Zone 1,2 -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -SslPolicy $sslPolicy -TrustedRootCertificate $trustedRoot01 -AutoscaleConfiguration $autoscaleConfig

		# Get Application Gateway
		$getgw = Get-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname

		# Operational State
		Assert-AreEqual "Running" $getgw.OperationalState

		# check trusted root
		$trustedRoot02 = Get-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $getgw -Name $trustedRootCertName
		Assert-NotNull $trustedRoot02
		Assert-AreEqual $getgw.BackendHttpSettingsCollection[0].TrustedRootCertificates.Count 1

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzureRmApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		# Get for zones
		Assert-AreEqual $getgw.Zones.Count 2

		# Get for SslPolicy
		$sslPolicy01 = Get-AzureRmApplicationGatewaySslPolicy -ApplicationGateway $getgw
		Assert-AreEqual $sslPolicy.MinProtocolVersion $sslPolicy01.MinProtocolVersion

		# check autoscale configuration
		$autoscaleConfig01 = Get-AzureRmApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw
		Assert-NotNull $autoscaleConfig01
		Assert-AreEqual $autoscaleConfig01.MinCapacity 3

		# Next setup preparation

		# remove autoscale config
		$getgw = Remove-AzureRmApplicationGatewayAutoscaleConfiguration -ApplicationGateway $getgw -Force
		$getgw = Set-AzureRmApplicationGatewaySku -Name Standard_v2 -Tier Standard_v2 -Capacity 3 -ApplicationGateway $getgw

		# Set
		$getgw01 = Set-AzureRmApplicationGateway -ApplicationGateway $getgw

		# check sku
		$sku01 = Get-AzureRmApplicationGatewaySku -ApplicationGateway $getgw01
		Assert-NotNull $sku01
		Assert-AreEqual $sku01.Capacity 3
		Assert-AreEqual $sku01.Name Standard_v2
		Assert-AreEqual $sku01.Tier Standard_v2

		# Stop Application Gateway
		$getgw1 = Stop-AzureRmApplicationGateway -ApplicationGateway $getgw01

		Assert-AreEqual "Stopped" $getgw1.OperationalState

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
Compare connectionDraining of backendhttpsettings
#>
function Compare-ConnectionDraining($expected, $actual)
{
	$expectedConnectionDraining = Get-AzureRmApplicationGatewayConnectionDraining -BackendHttpSettings $expected
	$actualConnectionDraining = Get-AzureRmApplicationGatewayConnectionDraining -BackendHttpSettings $actual

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
function Compare-AzureRmApplicationGateway($expected, $actual)
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
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 10.0.0.0/24
		$vnet2 = New-AzureRmvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzureRmvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -sku Basic

		# Create ip configuration
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		$sslPolicy = New-AzureRmApplicationGatewaySslPolicy -DisabledSslProtocols TLSv1_0, TLSv1_1

		#rule
		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzureRmApplicationGatewaySku -Name Standard_Medium -Tier Standard -Capacity 2

		$match1 = New-AzureRmApplicationGatewayProbeHealthResponseMatch -Body "helloworld"

		# Create Application Gateway
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -SslPolicy $sslPolicy -EnableFIPS

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
		$appgw = Add-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName -CertificateFile $certFilePath
		$appgw = Add-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2 -BackendIPAddresses 10.11.12.13
		$appgw = Add-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2 -SubnetId $gwSubnet.Id -PrivateIpAddress 10.0.0.7
		$appgw = Add-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01
		$appgw = Add-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01
		$appgw = Add-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name -Port 8080
		$appgw = Add-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName -Match $match1 -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8
		$listener01 = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		$appgw = Add-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName -RedirectType Permanent -TargetListener $listener01 -IncludePath $true
		$poolSetting01 = Get-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting01Name
		$pool = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName
		$videoPathRule = New-AzureRmApplicationGatewayPathRuleConfig -Name $PathRuleName -Paths "/video" -BackendAddressPool $pool -BackendHttpSettings $poolSetting01
		$appgw = Add-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01

		# Call Add on already existing items
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName -CertificateFile $certFilePath } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2 -BackendIPAddresses 10.11.12.13 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2 -SubnetId $gwSubnet.Id -PrivateIpAddress 10.0.0.7 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name -CertificateFile $sslCert01Path -Password $pw01 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name -Port 8080 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName -Match $match1 -Protocol Http -HostName "probe.com" -Path "/path/path.htm" -Interval 89 -Timeout 88 -UnhealthyThreshold 8 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName -RedirectType Permanent -TargetListener $listener01 -IncludePath $true } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress } "*already exists*"

		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

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
		$gipconfig = Get-AzureRmApplicationGatewayIPConfiguration -ApplicationGateway $appgw -Name $gipconfigname
		$authCert = Get-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName
		$aPool = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2
		$feip = Get-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2
		$customError = Get-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403
		$sslCert = Get-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name
		$fPort = Get-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name
		$probe = Get-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName
		$rule = Get-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule01Name

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
		$gipconfigs = Get-AzureRmApplicationGatewayIPConfiguration -ApplicationGateway $appgw
		$authCerts = Get-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw
		$aPools = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw
		$feips = Get-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw
		$customErrors = Get-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw
		$sslCerts = Get-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $appgw
		$fPorts = Get-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw
		$probes = Get-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw
		$poolSettings = Get-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw
		$listeners = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw
		$redirects = Get-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw
		$rules = Get-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw
		$maps = Get-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw

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

		$appgwsRG = Get-AzureRmApplicationGateway -ResourceGroupName $rgname
		$appgwsAll = Get-AzureRmApplicationGateway

		# Set all possible
		$appgw = Set-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName -CertificateFile $certFilePath2
		$appgw = Set-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2 -BackendIPAddresses 10.11.12.14
		$appgw = Set-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$appgw = Set-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name -Port 8081
		$appgw = Set-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName -Match $match1 -Protocol Http -HostName "probeset.com" -Path "/path/path1.htm" -Interval 87 -Timeout 87 -UnhealthyThreshold 7
		$poolSetting01 = Get-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting01Name
		$pool = Get-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName
		$imagePathRule = New-AzureRmApplicationGatewayPathRuleConfig -Name $PathRuleName2 -Paths "/image" -BackendAddressPool $pool -BackendHttpSettings $poolSetting01
		$appgw = Set-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName -PathRules $imagePathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01

		# Set items that doesn't exist
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name "fakeName" -CertificateFile $certFilePath2 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name "fakeName" -BackendIPAddresses 10.11.12.14 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus405 -CustomErrorPageUrl $customError403Url02 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name "fakeName" -Port 8081 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name "fakeName" -Match $match1 -Protocol Http -HostName "probeset.com" -Path "/path/path1.htm" -Interval 87 -Timeout 87 -UnhealthyThreshold 7 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name "fakeName" -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name "fakeName" -SubnetId $gwSubnet.Id -PrivateIpAddress 10.0.0.7 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name "fakeName" -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name "fakeName" -RedirectType Permanent -TargetListener $listener01 -IncludePath $true } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name "fakeName" -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name "fakeName" -CertificateFile $sslCert01Path -Password $pw01 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name "fakeName" -PathRules $imagePathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayIPConfiguration -ApplicationGateway $appgw -Name "fakeName" -Subnet $gwSubnet } "*does not exist*"

		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

		# Remove all possible
		Remove-AzureRmApplicationGatewayBackendAddressPool -ApplicationGateway $appgw -Name $poolName2
		Remove-AzureRmApplicationGatewayAuthenticationCertificate -ApplicationGateway $appgw -Name $authCertName
		Remove-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2
		Remove-AzureRmApplicationGatewayCustomError -ApplicationGateway $appgw -StatusCode HttpStatus403
		Remove-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $appgw -Name $sslCert01Name
		Remove-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort02Name
		Remove-AzureRmApplicationGatewayProbeConfig -ApplicationGateway $appgw -Name $probeName
		Remove-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName
		Remove-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Remove-AzureRMApplicationGatewaySslPolicy -ApplicationGateway $appgw -Force

		Assert-ThrowsLike { Remove-AzureRmApplicationGatewayAutoscaleConfiguration -ApplicationGateway $appgw -Force } "*doesn't have*"
		Assert-ThrowsLike { Remove-AzureRMApplicationGatewaySslPolicy -ApplicationGateway $appgw -Force } "*doesn't have*"

		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

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
		Stop-AzureRmApplicationGateway -ApplicationGateway $appgw;
		Add-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname2 -Subnet $gwSubnet2 -ApplicationGateway $appgw
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname2 -Subnet $gwSubnet2 -ApplicationGateway $appgw } "*already exists*"
		Remove-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -ApplicationGateway $appgw
		Add-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName2 -SubnetId $gwSubnet2.Id -PrivateIpAddress 10.0.0.7
		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw
		$ipConfig = Get-AzureRmApplicationGatewayIPConfiguration -ApplicationGateway $appgw -Name $gipconfigname2
		Start-AzureRmApplicationGateway -ApplicationGateway $appgw;

		# Switch subnet in IpConfigs
		Stop-AzureRmApplicationGateway -ApplicationGateway $appgw;
		Set-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname2 -Subnet $gwSubnet -ApplicationGateway $appgw
		Set-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfigName2 -Subnet $gwSubnet -ApplicationGateway $appgw -PrivateIpAddress 10.0.0.7
		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

		$result = Remove-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Force -PassThru

		Assert-ThrowsLike { Stop-AzureRmApplicationGateway -ApplicationGateway $appgw } "*not found*"
		Assert-ThrowsLike { Set-AzureRmApplicationGateway -ApplicationGateway $appgw } "*not found*"
		Assert-ThrowsLike { Start-AzureRmApplicationGateway -ApplicationGateway $appgw } "*not found*"
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
	$fipconfigName = Get-ResourceName
	$listener01Name = Get-ResourceName
	$listener02Name = Get-ResourceName

	$poolName = Get-ResourceName
	$trustedRootCertName = Get-ResourceName
	$poolSetting01Name = Get-ResourceName
	$poolSetting02Name = Get-ResourceName

	$rule01Name = Get-ResourceName
	$rule02Name = Get-ResourceName

	$customError403Url01 = "https://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"
	$customError403Url02 = "http://mycustomerrorpages.blob.core.windows.net/errorpages/403-another.htm"

	$urlPathMapName = Get-ResourceName
	$PathRuleName = Get-ResourceName

	try
	{
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "APPGw tag"}
		# Create the Virtual Network
		$gwSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -AddressPrefix 10.0.0.0/24
		$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $gwSubnet
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$gwSubnet = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName -VirtualNetwork $vnet

		$gwSubnet2 = New-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName2 -AddressPrefix 11.0.1.0/24
		$vnet2 = New-AzureRmvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 11.0.0.0/8 -Subnet $gwSubnet2
		$vnet2 = Get-AzureRmvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
		$gwSubnet2 = Get-AzureRmVirtualNetworkSubnetConfig -Name $gwSubnetName2 -VirtualNetwork $vnet2

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

		# Create ip configuration
		# Re-create AppGw with another SKU to test more
		$gipconfig = New-AzureRmApplicationGatewayIPConfiguration -Name $gipconfigname -Subnet $gwSubnet

		$fipconfig = New-AzureRmApplicationGatewayFrontendIPConfig -Name $fipconfigName -PublicIPAddress $publicip
		$fp01 = New-AzureRmApplicationGatewayFrontendPort -Name $frontendPort01Name  -Port 80
		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01

		$pool = New-AzureRmApplicationGatewayBackendAddressPool -Name $poolName -BackendIPAddresses www.microsoft.com, www.bing.com
		$poolSetting01 = New-AzureRmApplicationGatewayBackendHttpSettings -Name $poolSetting01Name -Port 443 -Protocol Https -CookieBasedAffinity Enabled -PickHostNameFromBackendAddress

		#rule
		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool

		# sku
		$sku = New-AzureRmApplicationGatewaySku -Name WAF_v2 -Tier WAF_v2

		$autoscaleConfig = New-AzureRmApplicationGatewayAutoscaleConfiguration -MinCapacity 3
		Assert-AreEqual $autoscaleConfig.MinCapacity 3

		$videoPathRule = New-AzureRmApplicationGatewayPathRuleConfig -Name $PathRuleName -Paths "/video" -BackendAddressPool $pool -BackendHttpSettings $poolSetting01
		$urlPathMap = New-AzureRmApplicationGatewayUrlPathMapConfig -Name $urlPathMapName -PathRules $videoPathRule -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $poolSetting01

		# Create Application Gateway
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01 -HttpListeners $listener01 -RequestRoutingRules $rule01 -Sku $sku -AutoscaleConfiguration $autoscaleConfig -UrlPathMap $urlPathMap

		$certFilePath = $basedir + "/ScenarioTests/Data/ApplicationGatewayAuthCert.cer"
		$certFilePath2 = $basedir + "/ScenarioTests/Data/TrustedRootCertificate.cer"

		# Add
		$listener01 = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		Add-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath
		Add-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01

		# Add to test Remove
		Add-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting02Name -Port 1234 -Protocol Http -CookieBasedAffinity Enabled -RequestTimeout 42 -HostName test -Path /test -AffinityCookieName test
		$fipconfig = Get-AzureRmApplicationGatewayFrontendIPConfig -ApplicationGateway $appgw -Name $fipconfigName
		$fp01 = Get-AzureRmApplicationGatewayFrontendPort -ApplicationGateway $appgw -Name $frontendPort01Name 
		Add-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig -FrontendPort $fp01 -HostName TestHostName
		$listener02 = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name
		$urlPathMap = Get-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $appgw -Name $urlPathMapName
		Add-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name -RuleType PathBasedRouting -HttpListener $listener02 -UrlPathMap $urlPathMap

		# Add twice
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath } "*already exists*"
		Assert-ThrowsLike { Add-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url01 } "*already exists*"

		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

		Assert-NotNull $appgw.HttpListeners[0].CustomErrorConfigurations
		Assert-NotNull $appgw.TrustedRootCertificates
		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 2
		Assert-AreEqual $appgw.HttpListeners.Count 2
		Assert-AreEqual $appgw.RequestRoutingRules.Count 2

		# Get
		$trustedCert = Get-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName
		Assert-NotNull $trustedCert

		# List
		$trustedCerts = Get-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw
		Assert-NotNull $trustedCerts
		Assert-AreEqual $trustedCerts.Count 1

		# Set
		$listener01 = Get-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener01Name
		Set-AzureRmApplicationGatewayAutoscaleConfiguration -ApplicationGateway $appgw -MinCapacity 2
		Set-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus403 -CustomErrorPageUrl $customError403Url02
		$disabledRuleGroup1 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_41_sql_injection_attacks" -Rules 981318,981320
		$disabledRuleGroup2 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_35_bad_robots"
		$exclusion1 = New-AzureRmApplicationGatewayFirewallExclusionConfig -Variable "RequestHeaderNames" -Operator "StartsWith" -Selector "xyz"
		$exclusion2 = New-AzureRmApplicationGatewayFirewallExclusionConfig -Variable "RequestArgNames" -Operator "Equals" -Selector "a"
		Set-AzureRmApplicationGatewayWebApplicationFirewallConfiguration -ApplicationGateway $appgw -Enabled $true -FirewallMode Prevention -RuleSetType "OWASP" -RuleSetVersion "2.2.9" -DisabledRuleGroups $disabledRuleGroup1,$disabledRuleGroup2 -RequestBodyCheck $true -MaxRequestBodySizeInKb 80 -FileUploadLimitInMb 70 -Exclusion $exclusion1,$exclusion2
		Set-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName -CertificateFile $certFilePath2

		# Set non-exiting
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayHttpListenerCustomError -HttpListener $listener01 -StatusCode HttpStatus408 -CustomErrorPageUrl $customError403Url02 } "*does not exist*"
		Assert-ThrowsLike { Set-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name "fakeName" -CertificateFile $certFilePath } "*does not exist*"

		# Get Application Gateway backend health with expanded resource
		$job = Get-AzureRmApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname -ExpandResource "backendhealth/applicationgatewayresource" -AsJob
		$job | Wait-Job
		$backendHealth = $job | Receive-Job
		Assert-NotNull $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

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
		Remove-AzureRmApplicationGatewayTrustedRootCertificate -ApplicationGateway $appgw -Name $trustedRootCertName
		Remove-AzureRmApplicationGatewayBackendHttpSettings -ApplicationGateway $appgw -Name $poolSetting02Name
		Remove-AzureRmApplicationGatewayRequestRoutingRule -ApplicationGateway $appgw -Name $rule02Name
		Remove-AzureRmApplicationGatewayHttpListener -ApplicationGateway $appgw -Name $listener02Name

		$appgw = Set-AzureRmApplicationGateway -ApplicationGateway $appgw

		Assert-Null $appgw.TrustedRootCertificates
		Assert-AreEqual $appgw.BackendHttpSettingsCollection.Count 1
		Assert-AreEqual $appgw.RequestRoutingRules.Count 1
		Assert-AreEqual $appgw.HttpListeners.Count 1
	}
	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}
