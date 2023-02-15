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
ResourceManagementPrivateLinksTests
#>

function Test-RemoveResourceManagementPrivateLink
{
    $getresponse1 = Get-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL
    $getresponse1 | Remove-AzResourceManagementPrivateLink -Force
    try
    {
      $getresponse2 = Get-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL
    }
    catch
    {
	   Assert-Null $getresponse2
    }

    $expectedType =  "Microsoft.Authorization/resourceManagementPrivateLinks"
    $expectedName = "NewPL"
    $expectedLocation = "centralus"
    $expectedId = "/subscriptions/e3a1f070-4fbe-428f-90cb-50dadce68bfb/resourceGroups/PrivateLinkTestRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/NewPL"
    
    Assert-NotNull $getresponse1
    
    Assert-AreEqual $getresponse1.Type $expectedType
    Assert-AreEqual $getresponse1.Id $expectedId
    Assert-AreEqual $getresponse1.Name $expectedName
    Assert-AreEqual $getresponse1.Location $expectedLocation

	Assert-Null $getresponse2
}

function Test-GetResourceManagementPrivateLink
{
    $getresponse = Get-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL
    
    $expectedType =  "Microsoft.Authorization/resourceManagementPrivateLinks"
    $expectedName = "NewPL"
    $expectedLocation = "centralus"
    $expectedId = "/subscriptions/e3a1f070-4fbe-428f-90cb-50dadce68bfb/resourceGroups/PrivateLinkTestRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/NewPL"
    
    Assert-NotNull $getresponse
    
    Assert-AreEqual $getresponse.Type $expectedType
    Assert-AreEqual $getresponse.Id $expectedId
    Assert-AreEqual $getresponse.Name $expectedName
    Assert-AreEqual $getresponse.Location $expectedLocation
}

function Test-GetResourceManagementPrivateLinks
{
    $getresponse = Get-AzResourceManagementPrivateLink

    $expectedType =  "Microsoft.Authorization/resourceManagementPrivateLinks"
    $expectedName1 = "NewPL"
    $expectedName2 = "NewPL2"
    $expectedLocation = "centralus"

    Assert-NotNull $getresponse
    Assert-AreEqual @($getresponse).Count 2
    Assert-AreEqual @($getresponse)[0].Type $expectedType
    Assert-AreEqual @($getresponse)[1].Type $expectedType
    Assert-AreEqual @($getresponse)[0].Location $expectedLocation
    Assert-AreEqual @($getresponse)[1].Location $expectedLocation
    Assert-AreEqual @($getresponse)[0].Name $expectedName1
    Assert-AreEqual @($getresponse)[1].Name $expectedName2

    $getresponse = Get-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG

    Assert-NotNull $getresponse
    Assert-AreEqual @($getresponse).Count 2
    Assert-AreEqual @($getresponse)[0].Type $expectedType
    Assert-AreEqual @($getresponse)[1].Type $expectedType
    Assert-AreEqual @($getresponse)[0].Location $expectedLocation
    Assert-AreEqual @($getresponse)[1].Location $expectedLocation
    Assert-AreEqual @($getresponse)[0].Name $expectedName1
    Assert-AreEqual @($getresponse)[1].Name $expectedName2
}

function Test-RemoveResourceManagementPrivateLinkAssociation
{
    $privateLinkAssociationId = "1d7942d1-288b-48de-8d0f-2d2aa8e03ad4"
    $getresponse = Get-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a
    Remove-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a -Name $privateLinkAssociationId -Force
    $getresponse1 = Get-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a

    $expectedPublicNetworkAccess = "Enabled"
    $expectedPrivateLinkResourceId = "/subscriptions/6dbb5850-64b4-49c0-ba85-d38f089c6fa4/resourceGroups/ARMPrivateLinkRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL"
    $expectedPrivateLinkAssociationId = "1d7942d1-288b-48de-8d0f-2d2aa8e03ad4"
    $expectedType = "Microsoft.Authorization/privateLinkAssociations"
    
    Assert-NotNull $getresponse
    Assert-AreEqual @($getresponse).Count 1

    $properties = @($getresponse)[0].Properties | ConvertFrom-Json

    Assert-AreEqual @($getresponse)[0].Type $expectedType
    Assert-AreEqual @($getresponse)[0].Name $expectedPrivateLinkAssociationId
    Assert-AreEqual $properties.PublicNetworkAccess $expectedPublicNetworkAccess
    Assert-AreEqual $properties.PrivateLink $expectedPrivateLinkResourceId

    Assert-NotNull $getresponse1
    Assert-AreEqual @($getresponse1).Count 0
}

function Test-GetResourceManagementPrivateLinkAssociations
{
    $getresponse = Get-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a
    $expectedPublicNetworkAccess = "Enabled"
    $expectedPrivateLinkResourceId = "/subscriptions/6dbb5850-64b4-49c0-ba85-d38f089c6fa4/resourceGroups/ARMPrivateLinkRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL"
    $expectedPrivateLinkAssociationId = "1d7942d1-288b-48de-8d0f-2d2aa8e03ad4"
    $expectedType = "Microsoft.Authorization/privateLinkAssociations"
    
    Assert-NotNull $getresponse
    Assert-AreEqual @($getresponse).Count 1

    $properties = @($getresponse)[0].Properties | ConvertFrom-Json

    Assert-AreEqual @($getresponse)[0].Type $expectedType
    Assert-AreEqual @($getresponse)[0].Name $expectedPrivateLinkAssociationId
    Assert-AreEqual $properties.PublicNetworkAccess $expectedPublicNetworkAccess
    Assert-AreEqual $properties.PrivateLink $expectedPrivateLinkResourceId
}

function Test-GetResourceManagementPrivateLinkAssociation
{
    $getresponse = Get-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a -Name 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4
    $expectedPublicNetworkAccess = "Enabled"
    $expectedPrivateLinkResourceId = "/subscriptions/6dbb5850-64b4-49c0-ba85-d38f089c6fa4/resourceGroups/ARMPrivateLinkRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL"
    $expectedPrivateLinkAssociationId = "1d7942d1-288b-48de-8d0f-2d2aa8e03ad4"
    $expectedType = "Microsoft.Authorization/privateLinkAssociations"

    Assert-NotNull $getresponse
    Assert-AreEqual @($getresponse).Count 1

    $properties = @($getresponse)[0].Properties | ConvertFrom-Json

    Assert-AreEqual @($getresponse)[0].Type $expectedType
    Assert-AreEqual @($getresponse)[0].Name $expectedPrivateLinkAssociationId
    Assert-AreEqual $properties.PublicNetworkAccess $expectedPublicNetworkAccess
    Assert-AreEqual $properties.PrivateLink $expectedPrivateLinkResourceId
}

function Test-NewResourceManagementPrivateLinkAssociation
{
    $privateLinkResourceId = "/subscriptions/6dbb5850-64b4-49c0-ba85-d38f089c6fa4/resourceGroups/ARMPrivateLinkRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL"
    $privateLinkAssociationId = "1d7942d1-288b-48de-8d0f-2d2aa8e03ad4"
    $response = New-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a -Name $privateLinkAssociationId -PrivateLink $privateLinkResourceId -PublicNetworkAccess Enabled

    $properties = $response.Properties | ConvertFrom-Json
    $expectedPublicNetworkAccess = "Enabled"
    Assert-AreEqual $response.PublicNetworkAccess $expectedPublicNetworkAcess
    Assert-AreEqual $properties.PrivateLink $privateLinkResourceId
}

function Test-NewResourceManagementPrivateLink
{
    $response = New-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL -Location centralus

    $expectedType =  "Microsoft.Authorization/resourceManagementPrivateLinks"
    $expectedId = "/subscriptions/e3a1f070-4fbe-428f-90cb-50dadce68bfb/resourceGroups/PrivateLinkTestRG/providers/Microsoft.Authorization/resourceManagementPrivateLinks/NewPL"
    $expectedName = "NewPL"
    $expectedLocation = "centralus"

    Assert-AreEqual $response.Type $expectedType
    Assert-AreEqual $response.Id $expectedId
    Assert-AreEqual $response.Name $expectedName
    Assert-AreEqual $response.Location $expectedLocation
}