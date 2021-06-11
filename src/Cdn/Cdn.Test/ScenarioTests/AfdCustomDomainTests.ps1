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

function Test-CreateAfdCustomDomain
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $customDomainName = getAssetName

    $hostName = "$customDomainName.azfdtests.xyz"

    $customDomain = New-AzFrontDoorCdnCustomDomain -ResourceGroupName $resourceGroupName -ProfileName $profileName -CustomDomainName $customDomainName -HostName $hostName

    Assert-AreEqual $customDomain.Name $customDomainName
    Assert-AreEqual $customDomain.HostName $hostName

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-GetAfdCustomDomain
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	# Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $customDomainName = getAssetName

    $hostName = "$customDomainName.azfdtests.xyz"

    New-AzFrontDoorCdnCustomDomain -ResourceGroupName $resourceGroupName -ProfileName $profileName -CustomDomainName $customDomainName -HostName $hostName

    $customDomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $resourceGroupName -ProfileName $profileName -CustomDomainName $customDomainName

    Assert-AreEqual $customDomain.Name $customDomainName
    Assert-AreEqual $customDomain.HostName $hostName
    Assert-AreEqual $customDomain.ProvisioningState "Succeeded"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}
