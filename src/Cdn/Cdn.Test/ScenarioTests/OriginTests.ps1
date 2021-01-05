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
Gets or sets origin with the running endpoint
#>
function Test-OriginGetSetWithRunningEndpoint
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $httpPort = 80

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort

    $createdOrigin = $createdEndpoint | Get-AzCdnOrigin -OriginName $originName 
    Assert-AreEqual $originName $createdOrigin.Name
    Assert-AreEqual $originHostName $createdOrigin.HostName
    Assert-AreEqual $httpPort $createdOrigin.HttpPort
    Assert-Null $createdOrigin.HttpsPort

    $createdOrigin.HttpPort = 789
    $createdOrigin.HttpsPort = 456
    $createdOrigin.HostName = "www.azure.com"

    $updatedOrigin = $createdOrigin | Set-AzCdnOrigin

    Assert-AreEqual $originName $updatedOrigin.Name
    Assert-AreEqual "www.azure.com" $updatedOrigin.HostName
    Assert-AreEqual 456 $updatedOrigin.HttpsPort
    Assert-AreEqual 789 $updatedOrigin.HttpPort

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Gets or sets origin with stopped endpoint
#>
function Test-OriginGetSetWithStoppedEndpoint
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $httpPort = 80

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort
    Stop-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false

    $createdOrigin = Get-AzCdnOrigin -OriginName $originName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $originName $createdOrigin.Name
    Assert-AreEqual $originHostName $createdOrigin.HostName
    Assert-AreEqual $httpPort $createdOrigin.HttpPort
    Assert-Null $createdOrigin.HttpsPort

    $createdOrigin.HttpPort = 789
    $createdOrigin.HttpsPort = 456
    $createdOrigin.HostName = "www.azure.com"

    $updatedOrigin = Set-AzCdnOrigin -CdnOrigin $createdOrigin

    Assert-AreEqual $originName $updatedOrigin.Name
    Assert-AreEqual "www.azure.com" $updatedOrigin.HostName
    Assert-AreEqual 456 $updatedOrigin.HttpsPort
    Assert-AreEqual 789 $updatedOrigin.HttpPort

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Gets or sets the origin that does not exist.
#>
function Test-OriginGetSetWhenEndpointDoesnotExist
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $httpPort = 80

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort

    $createdOrigin = Get-AzCdnOrigin -OriginName $originName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $createdOrigin.Id = "/subscriptions/d33030b5-85cf-4f96-be7d-b99b5dd0325d/resourcegroups/notarg/providers/Microsoft.Cdn/profiles/notaprofile/endpoints/notanendpoint/origins/notanorigin"

    Assert-ThrowsContains { Get-AzCdnOrigin -OriginName "thisisnotanoriginname" -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"
    Assert-ThrowsContains { Set-AzCdnOrigin -CdnOrigin $createdOrigin } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-SetOriginProperties
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
    $originName = getAssetName 
    $originHostName = "www.microsoft.com"

    # Create CDN endpoint
    $createdEndpoint = New-AzCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName 

    # Generate the origin resource id
    $originResourceId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$profileName/endpoints/$endpointName/origins/$originName"

    # Origin specific properties
    $origin = Get-AzCdnOrigin -ResourceId $originResourceId
    $origin.Priority = 5
    $origin.Weight = 500
    $origin.HttpPort = 80
    $origin.HttpsPort = 443
    $origin.HostName = "contoso.com"

    # Set the origin
    $updatedOrigin = Set-AzCdnOrigin -CdnOrigin $origin

    # Test origin properties were set correctly
    Assert-AreEqual 5 $updatedOrigin.Priority
    Assert-AreEqual 500 $updatedOrigin.Weight
    Assert-AreEqual 80 $updatedOrigin.HttpPort
    Assert-AreEqual 443 $updatedOrigin.HttpsPort
    Assert-AreEqual "contoso.com" $updatedOrigin.HostName

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}