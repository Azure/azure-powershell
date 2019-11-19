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
Full Front Door CRUD cycle
#>
function Test-FrontDoorCrud
{
	## Create Azure Front Door
    $Name = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$Name.azurefd.net"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
	New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags

    $retrievedFrontDoor = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName
    Assert-NotNull $retrievedFrontDoor
    Assert-AreEqual $Name $retrievedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $retrievedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $retrievedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $backendpool1.Name $retrievedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $retrievedFrontDoor.FrontendEndpoints[0].Name
    Assert-AreEqual $retrievedFrontDoor.RoutingRules[0].RouteConfiguration.GetType().Name "PSForwardingConfiguration"
    Assert-Tags $tags $retrievedFrontDoor.Tags

	# Verify HealthProbeSettings
	Assert-AreEqual $healthProbeSetting1.Name $retrievedFrontDoor.HealthProbeSettings[0].Name
	Assert-AreEqual $healthProbeSetting1.HealthProbeMethod $retrievedFrontDoor.HealthProbeSettings[0].HealthProbeMethod
	Assert-AreEqual $healthProbeSetting1.EnabledState $retrievedFrontDoor.HealthProbeSettings[0].EnabledState

	# Verify backendPoolsSetting 
	Assert-AreEqual $backendPoolsSetting1.SendRecvTimeoutInSeconds $retrievedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $retrievedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $retrievedFrontDoor.EnforceCertificateNameCheck

	## Update Azure Front Door
    $newTags = @{"tag1" = "value3"; "tag2" = "value4"}
	$healthProbeSetting1.HealthProbeMethod = "Get"
	$healthProbeSetting1.EnabledState = "Enabled"
	$backendPoolsSetting1.SendRecvTimeoutInSeconds = 20
    $updatedFrontDoor = Set-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -Tag $newTags -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1

    Assert-NotNull $updatedFrontDoor
    Assert-AreEqual $Name $updatedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $updatedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $updatedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $backendpool1.Name $updatedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $updatedFrontDoor.FrontendEndpoints[0].Name
    Assert-Tags $newTags $updatedFrontDoor.Tags

	# Verify HealthProbeSettings
	Assert-AreEqual $healthProbeSetting1.Name $updatedFrontDoor.HealthProbeSettings[0].Name
	Assert-AreEqual $healthProbeSetting1.HealthProbeMethod $updatedFrontDoor.HealthProbeSettings[0].HealthProbeMethod
	Assert-AreEqual $healthProbeSetting1.EnabledState $updatedFrontDoor.HealthProbeSettings[0].EnabledState

	# Verify backendPoolsSetting 
	Assert-AreEqual $backendPoolsSetting1.SendRecvTimeoutInSeconds $updatedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $updatedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $updatedFrontDoor.EnforceCertificateNameCheck

	## Delete Azure Front Door
    $removed = Remove-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -PassThru
    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName } "does not exist"

    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Front Door CRUD to validate default values.
#>
function Test-FrontDoorCrudDefaults
{
	## Create Azure Front Door
    $Name = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$Name.azurefd.net"

    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject
	New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags

    $retrievedFrontDoor = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName
    Assert-NotNull $retrievedFrontDoor
    Assert-AreEqual $Name $retrievedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $retrievedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $retrievedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $backendpool1.Name $retrievedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $retrievedFrontDoor.FrontendEndpoints[0].Name
    Assert-AreEqual $retrievedFrontDoor.RoutingRules[0].RouteConfiguration.GetType().Name "PSForwardingConfiguration"
    Assert-Tags $tags $retrievedFrontDoor.Tags

	# Verify Default HealthProbeSettings
	Assert-AreEqual $retrievedFrontDoor.HealthProbeSettings[0].Name $healthProbeSetting1.Name
	Assert-AreEqual $retrievedFrontDoor.HealthProbeSettings[0].HealthProbeMethod "Head"
	Assert-AreEqual $retrievedFrontDoor.HealthProbeSettings[0].EnabledState "Enabled"
	Assert-AreEqual $retrievedFrontDoor.HealthProbeSettings[0].IntervalInSeconds 30

	# Verify Default backendPoolsSetting 
	Assert-AreEqual $retrievedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds 30
	Assert-AreEqual $retrievedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck "Enabled"
	Assert-AreEqual $retrievedFrontDoor.EnforceCertificateNameCheck "Enabled"

	## Delete Azure Front Door
    $removed = Remove-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -PassThru
    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName } "does not exist"

    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Front Door CRUD cycle with traffic redirection
#>
function Test-FrontDoorCrudRedirect
{
    $Name = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$Name.azurefd.net"
    $customHost = "contoso2"
    $customPath = "/test"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -CustomHost $customHost
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" 
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
	New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    
    $retrievedFrontDoor = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName
    Assert-NotNull $retrievedFrontDoor
    Assert-AreEqual $Name $retrievedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $retrievedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $retrievedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $healthProbeSetting1.Name $retrievedFrontDoor.HealthProbeSettings[0].Name
    Assert-AreEqual $backendpool1.Name $retrievedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $retrievedFrontDoor.FrontendEndpoints[0].Name
    Assert-Tags $tags $retrievedFrontDoor.Tags
    Assert-AreEqual $retrievedFrontDoor.RoutingRules[0].RouteConfiguration.GetType().Name "PSRedirectConfiguration"
    Assert-AreEqual $retrievedFrontDoor.RoutingRules[0].RouteConfiguration.CustomHost $customHost
	Assert-AreEqual $backendPoolsSetting1.SendRecvTimeoutInSeconds $retrievedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $retrievedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck

    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -CustomHost $customHost -CustomPath $customPath
    $updatedFrontDoor = Set-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1
    Assert-NotNull $updatedFrontDoor
    Assert-AreEqual $Name $updatedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $updatedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $updatedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $healthProbeSetting1.Name $updatedFrontDoor.HealthProbeSettings[0].Name
    Assert-AreEqual $backendpool1.Name $updatedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $updatedFrontDoor.FrontendEndpoints[0].Name
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.GetType().Name "PSRedirectConfiguration"
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.CustomHost $customHost
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.CustomPath $customPath
	Assert-AreEqual $backendPoolsSetting1.SendRecvTimeoutInSeconds $updatedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds
	Assert-AreEqual $updatedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck "Enabled"

    $updatedFrontDoor = Set-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -DisableCertificateNameCheck
    Assert-NotNull $updatedFrontDoor
    Assert-AreEqual $Name $updatedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $updatedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $updatedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $healthProbeSetting1.Name $updatedFrontDoor.HealthProbeSettings[0].Name
    Assert-AreEqual $backendpool1.Name $updatedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $updatedFrontDoor.FrontendEndpoints[0].Name
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.GetType().Name "PSRedirectConfiguration"
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.CustomHost $customHost
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.CustomPath $customPath
    Assert-AreEqual $updatedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck "Disabled"

    $removed = Remove-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -PassThru
    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName } "does not exist"

    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Front Door cycle with input piping
#>
function Test-FrontDoorCrudWithPiping
{
    $Name = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$Name.azurefd.net"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
	New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    
    $newTags = @{"tag1" = "value3"; "tag2" = "value4"}
    $updatedFrontDoor = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName | Set-AzFrontDoor -Tag $newTags
    Assert-NotNull $updatedFrontDoor
    Assert-AreEqual $Name $updatedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $updatedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $updatedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $healthProbeSetting1.Name $updatedFrontDoor.HealthProbeSettings[0].Name
    Assert-AreEqual $backendpool1.Name $updatedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $updatedFrontDoor.FrontendEndpoints[0].Name
    Assert-Tags $newTags $updatedFrontDoor.Tags
    Assert-AreEqual $updatedFrontDoor.RoutingRules[0].RouteConfiguration.GetType().Name "PSForwardingConfiguration"

	# Verify HealthProbeSettings
	Assert-AreEqual $healthProbeSetting1.Name $updatedFrontDoor.HealthProbeSettings[0].Name
	Assert-AreEqual $healthProbeSetting1.HealthProbeMethod $updatedFrontDoor.HealthProbeSettings[0].HealthProbeMethod
	Assert-AreEqual $healthProbeSetting1.EnabledState $updatedFrontDoor.HealthProbeSettings[0].EnabledState

	# Verify backendPoolsSetting 
	Assert-AreEqual $backendPoolsSetting1.SendRecvTimeoutInSeconds $updatedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $updatedFrontDoor.BackendPoolsSetting[0].EnforceCertificateNameCheck
	Assert-AreEqual $backendPoolsSetting1.EnforceCertificateNameCheck $updatedFrontDoor.EnforceCertificateNameCheck

    $removed = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName | Remove-AzFrontDoor  -PassThru
    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName } "does not exist"
}

<#
.SYNOPSIS
Set custom domain configuration for FrontDoor endpoint.
#>
function Test-FrontDoorEndpointCustomDomainHTTPS-FrontDoor
{
    $Name = "test-powershell-030620190342"
	$resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$Name.azurefd.net"
    $randomName = getRandomItemName "test"
    $customDomainHostName = "$randomName.powershell-custom.azfdtest.xyz"
    $customFrontendEndpointName = "frontendendpoint2"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" 
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $frontendEndpoint2 = New-AzFrontDoorFrontendEndpointObject -Name $customFrontendEndpointName -HostName $customDomainHostName
    $frontendEndpoints = $frontendEndpoint1, $frontendEndpoint2
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoints -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    
    $retrievedFrontDoor = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName
    Assert-NotNull $retrievedFrontDoor

    $customDomain = Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName $ResourceGroupName -FrontDoorName $Name -FrontendEndpointName $customFrontendEndpointName -MinimumTlsVersion "1.2"
    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabling"
    [int]$counter = 0
    do 
    {
       Wait-Seconds 600
       $customDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $ResourceGroupName -FrontDoorName $Name -Name $customFrontendEndpointName
    } while ($customDomain.CustomHttpsProvisioningState -ne "Enabled" -and $counter++ -lt 50)
    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabled"
	Assert-AreEqual $customDomain.MinimumTlsVersion "1.2"

    $customDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $ResourceGroupName -FrontDoorName $Name -Name $customFrontendEndpointName
    $disabledCustomDomain = $customDomain | Disable-AzFrontDoorCustomDomainHttps
    Assert-AreEqual $disabledCustomDomain.CustomHttpsProvisioningState "Disabling"
    [int]$counter = 0
    do 
    {
       Wait-Seconds 600
       $disabledCustomDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $ResourceGroupName -FrontDoorName $Name -Name $customFrontendEndpointName
    } while ($disabledCustomDomain.CustomHttpsProvisioningState -ne "Disabled" -and $counter++ -lt 50)
    Assert-AreEqual $disabledCustomDomain.CustomHttpsProvisioningState "Disabled"
    $disabledCustomDomain = Get-AzFrontDoorFrontendEndpoint -ResourceId $disabledCustomDomain.Id
}