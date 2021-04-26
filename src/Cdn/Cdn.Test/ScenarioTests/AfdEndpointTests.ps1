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
Creates a Standard_AzureFrontDoor profile and endpoint
#>

function Test-CreateAfdEndpoint 
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    $createdProfile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    Assert-AreEqual $profileName $createdProfile.Name
    Assert-AreEqual $profileSku $createdProfile.Sku
    Assert-AreEqual $createdProfile.Location "Global"

    $endpointName = getAssetName

    $createdEndpoint = New-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName

    Assert-AreEqual $endpointName $createdEndpoint.Name

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Creates a Standard_AzureFrontDoor profile and endpoint, then gets the endpoint
#>

function Test-GetAfdEndpoint
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    $createdProfile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $endpointName = getAssetName

    New-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName

    $endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName

    Assert-AreEqual $endpointName $endpoint.Name
    Assert-AreEqual "Global" $endpoint.Location

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Creates a Standard_AzureFrontDoor profile and endpoint, then removes the endpoint
#>

function Test-RemoveAfdEndpoint
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    $createdProfile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $endpointName = getAssetName

    $createdEndpoint = New-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName

    $isDeleted = Remove-AzFrontDoorCdnEndpoint -Endpoint $createdEndpoint -PassThru

    Assert-AreEqual $isDeleted true

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Creates a Standard_AzureFrontDoor profile and endpoint, then updates the endpoint
#>

function Test-SetAfdEndpoint
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    $createdProfile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $endpointName = getAssetName

    New-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName

    $endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName

    $endpoint.Tags = @{"endpoint"="afd-standard"}

    $updatedEndpoint = Set-AzFrontDoorCdnEndpoint -Endpoint $endpoint

    Assert-AreEqual $endpoint.Tags["endpoint"] $updatedEndpoint.Tags["endpoint"]

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}