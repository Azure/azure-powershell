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
Creates a Standard_AzureFrontDoor profile
#>

function Test-CreateStandardAfdProfile
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

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Creates a Premium_AzureFrontDoor profile
#>

function Test-CreatePremiumAfdProfile 
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Premium_AzureFrontDoor"
    $profileTags = @{"ps-test-tag-name"="ps-test-tag-value"}

    # Create a Microsoft CDN Profile
    $createdProfile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku -Tag $profileTags

    Assert-AreEqual $profileName $createdProfile.Name
    Assert-AreEqual $profileSku $createdProfile.Sku
    Assert-AreEqual $createdProfile.Location "Global"
    Assert-AreEqual $profileTags["ps-test-tag-name"] $createdProfile.Tags["ps-test-tag-name"]

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Creates a Standard_AzureFrontDoor profile and Gets the profile after creating
#>

function Test-GetStandardAfdProfile
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $profile = Get-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName

    Assert-AreEqual $profileName $profile.Name
    Assert-AreEqual $profileSku $profile.Sku
    Assert-AreEqual $profile.Location "Global"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Creates a Premium_AzureFrontDoor profile and removes the profile after creating
#>

function Test-RemovePremiumAfdProfile 
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Premium_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $isDeleted = Remove-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -PassThru

    Assert-AreEqual $isDeleted true

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}
