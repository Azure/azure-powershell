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
    New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    
    $retrievedFrontDoor = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName
    Assert-NotNull $retrievedFrontDoor
    Assert-AreEqual $Name $retrievedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $retrievedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $retrievedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $healthProbeSetting1.Name $retrievedFrontDoor.HealthProbeSettings[0].Name
    Assert-AreEqual $backendpool1.Name $retrievedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $retrievedFrontDoor.FrontendEndpoints[0].Name
    Assert-Tags $tags $retrievedFrontDoor.Tags

    $newTags = @{"tag1" = "value3"; "tag2" = "value4"}
    $updatedFrontDoor = Set-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -Tag $newTags
    Assert-NotNull $updatedFrontDoor
    Assert-AreEqual $Name $updatedFrontDoor.Name
    Assert-AreEqual $routingrule1.Name $updatedFrontDoor.RoutingRules[0].Name
    Assert-AreEqual $loadBalancingSetting1.Name $updatedFrontDoor.LoadBalancingSettings[0].Name
    Assert-AreEqual $healthProbeSetting1.Name $updatedFrontDoor.HealthProbeSettings[0].Name
    Assert-AreEqual $backendpool1.Name $updatedFrontDoor.BackendPools[0].Name
    Assert-AreEqual $frontendEndpoint1.Name $updatedFrontDoor.FrontendEndpoints[0].Name
    Assert-Tags $newTags $updatedFrontDoor.Tags

    $removed = Remove-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -PassThru
    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName } "does not exist"

    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Front Door cycle with piping
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
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" 
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    
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

    $removed = Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName | Remove-AzFrontDoor  -PassThru
    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName } "does not exist"
}

<#
.SYNOPSIS
Front Door cycle with piping
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

    $customDomain = Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName $ResourceGroupName -FrontDoorName $Name -FrontendEndpointName $customFrontendEndpointName
    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabling"
    [int]$counter = 0
    do 
    {
       Wait-Seconds 600
       $customDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $ResourceGroupName -FrontDoorName $Name -Name $customFrontendEndpointName
    } while ($customDomain.CustomHttpsProvisioningState -ne "Enabled" -and $counter++ -lt 50)
    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabled"

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