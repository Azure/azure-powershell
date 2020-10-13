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
Creats an origin group and set the default origin group on a running endpoint
#>
function Test-CreateOriginGroup
{
    # Set up required fields
    $subId = (Get-AzContext).Subscription.id
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $resourceLocation = "Global"
    $profileSku = "Standard_Microsoft"
   
    # Create a Microsoft CDN Profile
    $createdProfile = New-AzCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Location $resourceLocation -Sku $profileSku

    # Endpoint specific properties
    $endpointName = getAssetName
    $originGroupName = getAssetName
    $originName = getAssetName 
    $originHostName = "www.microsoft.com"
    $originGroupResourceId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origingroups/$originGroupName"
    $defaultOriginGroup = $originGroupResourceId
    
    # 1st origin group properties 
    $probeInterval = 240
    $probePath = "/health.aspx"
    $probeProtocol = "Https"
    $probeRequestType = "GET"
    $originId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origins/$originName"
  
    # Create CDN endpoint, 1st origin group, and establish the default origin group
    $createdEndpoint = New-AzCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -OriginGroupName $originGroupName -DefaultOriginGroup $defaultOriginGroup -OriginGroupProbeIntervalInSeconds $probeInterval -OriginGroupProbePath $probePath -OriginGroupProbeProtocol $probeProtocol -OriginGroupProbeRequestType $probeRequestType -OriginId $originId
    
    # 2nd origin group properties
    $originGroupName2 = getAssetName
    $probeInterval2 = 120
    $probePath2 = "/check-health.aspx"
    $probeProtocol2 = "Http"
    $probeRequestType2 = "HEAD"

    # create 2nd origin group 
    $createdOriginGroup = New-AzCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -OriginGroupName $originGroupName2 -OriginId $originId -ProbeIntervalInSeconds $probeInterval2 -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2

    # Test the default origin group on the endpoint
    Assert-AreEqual $defaultOriginGroup $createdEndpoint.DefaultOriginGroup.Id

    # Test the properties on the 2nd origin group
    Assert-AreEqual $originGroupName2 $createdOriginGroup.Name
    Assert-AreEqual $probeInterval2 $createdOriginGroup.ProbeIntervalInSeconds
    Assert-AreEqual $probePath2 $createdOriginGroup.ProbePath
    Assert-AreEqual $probeProtocol2 $createdOriginGroup.ProbeProtocol
    Assert-AreEqual $probeRequestType2 $createdOriginGroup.ProbeRequestType
    Assert-AreEqual $originId $createdOriginGroup.Origins[0].Id

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Gets and sets an origin group with a running endpoint
#>
function Test-GetSetOriginGroup 
{
    # Set up required fields
    $subId = (Get-AzContext).Subscription.id
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $resourceLocation = "Global"
    $profileSku = "Standard_Microsoft"
   
    # Create a Microsoft CDN Profile
    $createdProfile = New-AzCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Location $resourceLocation -Sku $profileSku

    # Endpoint specific properties
    $endpointName = getAssetName
    $originGroupName = getAssetName
    $originName = getAssetName 
    $originHostName = "www.microsoft.com"
    $originGroupResourceId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origingroups/$originGroupName"
    $defaultOriginGroup = $originGroupResourceId

    # Origin id for the origin group
    $originId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origins/$originName"

    # Create CDN endpoint, origin group, and establish the default origin group
    $createdEndpoint = New-AzCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -OriginGroupName $originGroupName -DefaultOriginGroup $defaultOriginGroup -OriginId $originId

    # Get the origin group
    $originGroup = Get-AzCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -OriginGroupName $originGroupName

    # Test the unmodified origin group
    Assert-AreEqual $originGroupResourceId $originGroup.Id
    Assert-AreEqual 0 $originGroup.ProbeIntervalInSeconds
    Assert-Null $originGroup.ProbePath
    Assert-Null $originGroup.ProbeProtocol
    Assert-Null $originGroup.ProbeRequestType

    # Set new values on the origin group
    $probeInterval = 120
    $probePath = "/health-status.aspx"
    $probeProtocol = "Https"
    $probeRequestType = "GET"

    # Update properties on origin group
    $updatedOriginGroup = Set-AzCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -OriginGroupName $originGroupName -OriginId $originId -ProbeIntervalInSeconds $probeInterval -ProbePath $probePath -ProbeProtocol $probeProtocol -ProbeRequestType $probeRequestType

    # Test modified origin group
    Assert-AreEqual $probeInterval $updatedOriginGroup.ProbeIntervalInSeconds
    Assert-AreEqual $probePath $updatedOriginGroup.ProbePath
    Assert-AreEqual $probeProtocol $updatedOriginGroup.ProbeProtocol
    Assert-AreEqual $probeRequestType $updatedOriginGroup.ProbeRequestType

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Creates and removes an origin group with a running endpoint
#>
function Test-RemoveOriginGroup
{
    # Set up required fields
    $subId = (Get-AzContext).Subscription.id
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $resourceLocation = "Global"
    $profileSku = "Standard_Microsoft"
   
    # Create a Microsoft CDN Profile
    $createdProfile = New-AzCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Location $resourceLocation -Sku $profileSku

    # Endpoint specific properties
    $endpointName = getAssetName
    $originGroupName = getAssetName
    $originName = getAssetName 
    $originHostName = "www.microsoft.com"
    $originGroupResourceId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origingroups/$originGroupName"
    $defaultOriginGroup = $originGroupResourceId

    # Origin id for the origin group
    $originId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origins/$originName"

    # Create CDN endpoint, origin group, and establish the default origin group
    $createdEndpoint = New-AzCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -OriginGroupName $originGroupName -DefaultOriginGroup $defaultOriginGroup -OriginId $originId
   
    # 2nd origin group properties
    $originGroupName2 = getAssetName
    $probeInterval2 = 120
    $probePath2 = "/check-health.aspx"
    $probeProtocol2 = "Http"
    $probeRequestType2 = "HEAD"
    $originGroupResourceId2 = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origingroups/$originGroupName2"

    # create 2nd origin group 
    $createdOriginGroup = New-AzCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -OriginGroupName $originGroupName2 -OriginId $originId -ProbeIntervalInSeconds $probeInterval2 -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2
    
    # Remove the 2nd origin group
    Remove-AzCdnOriginGroup -ResourceId $originGroupResourceId2

    # Update a property on the already deleted origin group
    $probeIntervalUpdate = 60 

    # Test origin group was removed correctly 
    Assert-ThrowsContains { Get-AzCdnOriginGroup -ResourceId $originGroupResourceId2 } "NotFound"
    Assert-ThrowsContains { Set-AzCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -OriginGroupName $originGroupName2 -OriginId $originId -ProbeIntervalInSeconds $probeIntervalUpdate } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}
