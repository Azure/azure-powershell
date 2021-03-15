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

function Test-CreateAfdOrigin
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    $originName = getAssetName

    $hostName = "contoso.com"

    $origin = New-AzAfdOrigin -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -OriginName $originName -HostName $hostName

    Assert-AreEqual $hostName $origin.HostName
    Assert-AreEqual $originGroupName $origin.OriginGroupName

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-GetAfdOrigin
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    $originName = getAssetName

    $hostName = "example.org"

    $newOrigin = New-AzAfdOrigin -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -OriginName $originName -HostName $hostName 

    $getOrigin = Get-AzAfdOrigin -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -OriginName $originName

    Assert-AreEqual $newOrigin.HostName $getOrigin.HostName
    Assert-AreEqual $newOrigin.ProfileName $getOrigin.ProfileName

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-SetAfdOrigin
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    $originName = getAssetName

    $hostName = "example.org"

    New-AzAfdOrigin -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -OriginName $originName -HostName $hostName 

    Set-AzAfdOrigin -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -OriginName $originName -Priority 5 -Weight 10

    $origin = Get-AzAfdOrigin -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -OriginName $originName

    Assert-AreEqual $origin.Priority 5
    Assert-AreEqual $origin.Weight 10

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}
