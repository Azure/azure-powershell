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
Creates a Standard_AzureFrontDoor profile and origin group
#>

function Test-CreateAfdOriginGroup
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    $originGroup = New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    Assert-AreEqual $originGroupName $originGroup.Name 
    Assert-AreEqual $originGroup.Type "Microsoft.Cdn/profiles/origingroups"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-GetAfdOriginGroup
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    $originGroup = Get-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    Assert-AreEqual $originGroupName $originGroup.Name 
    Assert-AreEqual $originGroup.Type "Microsoft.Cdn/profiles/origingroups"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-SetAfdOriginGroup
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    Set-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -SampleSize 6 -SuccessfulSamplesRequired 3

    $originGroup = Get-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName
    
    Assert-AreEqual $originGroup.SampleSize 6
    Assert-AreEqual $originGroup.SuccessfulSamplesRequired 3

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RemoveAfdOriginGroup
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

    # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft CDN Profile
    $profile = New-AzAfdProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $originGroupName = getAssetName 

    $originGroup = New-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    Remove-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName

    Assert-ThrowsContains { Get-AzAfdOriginGroup -ResourceId $originGroup.Id } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}