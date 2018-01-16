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
		$basedir = ".\" 
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

		$authCertFilePath = $basedir + "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
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

		$listener01 = New-AzureRmApplicationGatewayHttpListener -Name $listener01Name -Protocol Http -FrontendIPConfiguration $fipconfig01 -FrontendPort $fp01
		$listener02 = New-AzureRmApplicationGatewayHttpListener -Name $listener02Name -Protocol Http -FrontendIPConfiguration $fipconfig02 -FrontendPort $fp02

		$rule01 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule01Name -RuleType basic -BackendHttpSettings $poolSetting01 -HttpListener $listener01 -BackendAddressPool $pool
		$rule02 = New-AzureRmApplicationGatewayRequestRoutingRule -Name $rule02Name -RuleType basic -BackendHttpSettings $poolSetting02 -HttpListener $listener02 -BackendAddressPool $pool

		$sku = New-AzureRmApplicationGatewaySku -Name WAF_Medium -Tier WAF -Capacity 2

		$sslPolicy = New-AzureRmApplicationGatewaySslPolicy -DisabledSslProtocols TLSv1_0, TLSv1_1

		$disabledRuleGroup1 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_41_sql_injection_attacks" -Rules 981318,981320
		$disabledRuleGroup2 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_35_bad_robots"
		$firewallConfig = New-AzureRmApplicationGatewayWebApplicationFirewallConfiguration -Enabled $true -FirewallMode Prevention -RuleSetType "OWASP" -RuleSetVersion "2.2.9" -DisabledRuleGroups $disabledRuleGroup1,$disabledRuleGroup2

		# Create Application Gateway
		$job = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probe01, $probe02 -BackendAddressPools $pool, $nicPool -BackendHttpSettingsCollection $poolSetting01,$poolSetting02 -FrontendIpConfigurations $fipconfig01, $fipconfig02  -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RequestRoutingRules $rule01, $rule02 -Sku $sku -SslPolicy $sslPolicy -AuthenticationCertificates $authcert01 -WebApplicationFirewallConfiguration $firewallConfig -AsJob
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
		Assert-AreEqual 0 $getgw.Probes[1].Match.StatusCodes.Count

		# Get Application Gateway backend health with expanded resource
		$job = Get-AzureRmApplicationGatewayBackendHealth -Name $appgwName -ResourceGroupName $rgname -ExpandResource "backendhealth/applicationgatewayresource" -AsJob
		$job | Wait-Job
		$backendHealth = $job | Receive-Job
		Assert-NotNull $backendHealth.BackendAddressPools[0].BackendAddressPool.Name

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
		$basedir = ".\" 
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
		$pw01 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert01Path = $basedir + "\ScenarioTests\Data\ApplicationGatewaySslCert1.pfx"
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
		$appgw = New-AzureRmApplicationGateway -Name $appgwName -ResourceGroupName $rgname -Location $location -Probes $probeHttp -BackendAddressPools $pool -BackendHttpSettingsCollection $poolSetting01 -FrontendIpConfigurations $fipconfig -GatewayIpConfigurations $gipconfig -FrontendPorts $fp01, $fp02 -HttpListeners $listener01, $listener02 -RedirectConfiguration $redirect01 -RequestRoutingRules $rule01, $rule02 -Sku $sku -SslPolicy $sslPolicy -SslCertificates $sslCert01

		# Check get/set/remove for RedirectConfiguration
		$redirect02 = Get-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirect01Name
		Assert-AreEqual $redirect01.TargetListenerId $redirect02.TargetListenerId
		$getgw = Set-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirect01Name -RedirectType Permanent -TargetUrl "https://www.bing.com"

		$getgw = Add-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $getgw -Name $redirect03Name -RedirectType Permanent -TargetListener $listener01 -IncludePath $true
		$getgw = Remove-AzureRmApplicationGatewayRedirectConfiguration -ApplicationGateway $getgw -Name $redirect03Name

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

		$pw02 = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
		$sslCert02Path = $basedir + "\ScenarioTests\Data\ApplicationGatewaySslCert2.pfx"
		$getgw = Add-AzureRmApplicationGatewaySslCertificate -ApplicationGateway $getgw -Name $sslCert02Name -CertificateFile $sslCert02Path -Password $pw02

		# Modify existing application gateway with new configuration
		$getgw = Set-AzureRmApplicationGateway -ApplicationGateway $getgw

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