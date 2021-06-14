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

function Test-CreateAfdRoute
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $endpointName = getAssetName 

    $createdEndpoint = New-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName
    
    $originGroupName = getAssetName 

    $originGroup = New-AzFrontDoorCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -SampleSize 3

    $customDomainName = getAssetName

    $hostName = "$customDomainName.azfdtests.xyz"

    $customDomain = New-AzFrontDoorCdnCustomDomain -ResourceGroupName $resourceGroupName -ProfileName $profileName -CustomDomainName $customDomainName -HostName $hostName

    $routeName = getAssetName

    $route = New-AzFrontDoorCdnRoute -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -RouteName $routeName -OriginGroupId $originGroup.Id -DomainId $customDomain.Id

    Assert-AreEqual $routeName $route.Name
    Assert-AreEqual $originGroup.Id $route.OriginGroupId

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-GetAfdRoute 
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    $profile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $endpointName = getAssetName

    $endpoint = New-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName 

    $routeName = getAssetName

    Assert-ThrowsContains { Get-AzFrontDoorCdnRoute -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -RouteName $routeName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}