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
Full Profile CRUD cycle
#>
function Test-ProfileCrud
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $profileLocation = "EastUS"
    $profileSku = "StandardVerizon"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $profileLocation -Sku $profileSku -Tags $tags

    Assert-NotNull $createdProfile
    Assert-AreEqual $profileName $createdProfile.Name 
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName
    Assert-AreEqual $profileSku $createdProfile.Sku.Name
    Assert-Tags $tags $createdProfile.Tags

    $retrievedProfile = Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-NotNull $retrievedProfile
    Assert-AreEqual $profileName $retrievedProfile.Name 
    Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedProfile.ResourceGroupName
    Assert-Tags $tags $createdProfile.Tags

    $newTags = @{"tag1" = "value3"; "tag2" = "value4"}
    $retrievedProfile.Tags = $newTags

    $updatedProfile = Set-AzureRmCdnProfile -CdnProfile $retrievedProfile

    Assert-NotNull $updatedProfile
    Assert-AreEqual $profileName $updatedProfile.Name 
    Assert-AreEqual $resourceGroup.ResourceGroupName $updatedProfile.ResourceGroupName
    Assert-Tags $newTags $updatedProfile.Tags

    $sso = Get-AzureRmCdnProfileSsoUrl -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-NotNull $sso.SsoUriValue

    $removed = Remove-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru

    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Profile CRUD cycle
#>
function Test-ProfileDeleteWithEndpoints
{
    $profileName = getAssetName
    $endpointName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $profileLocation = "EastUS"
    $profileSku = "StandardVerizon"
    
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $profileLocation -Sku $profileSku 

    New-AzureRmCdnEndpoint -CdnProfile $createdProfile -OriginName "contoso" -OriginHostName "www.contoso.com" -EndpointName $endpointName

    $removed = Remove-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force -PassThru

    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Profile cycle with piping
#>
function Test-ProfileDeleteAndSsoWithPiping
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $profileLocation = "EastUS"
    $profileSku = "StandardVerizon"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $profileLocation -Sku $profileSku -Tags $tags

    Assert-NotNull $createdProfile

    $sso = Get-AzureRmCdnProfileSsoUrl -CdnProfile $createdProfile
    Assert-NotNull $sso.SsoUriValue

    $removed = Remove-AzureRmCdnProfile -CdnProfile $createdProfile -PassThru

    Assert-True { $removed }
    Assert-ThrowsContains { Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Profile cycle with piping multiple profiles down the pipeline
#>
function Test-ProfilePipeline
{
    $profileName1 = getAssetName
    $profileName2 = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $profileLocation = "EastUS"
    $profileSku = "StandardVerizon"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile1 = New-AzureRmCdnProfile -ProfileName $profileName1 -ResourceGroupName $resourceGroup.ResourceGroupName -Location $profileLocation -Sku $profileSku -Tags $tags

    Assert-NotNull $createdProfile1

    $createdProfile2 = New-AzureRmCdnProfile -ProfileName $profileName2 -ResourceGroupName $resourceGroup.ResourceGroupName -Location $profileLocation -Sku $profileSku -Tags $tags

    Assert-NotNull $createdProfile2

    $profiles = Get-AzureRmCdnProfile | where {($_.Name -eq $profileName1) -or ($_.Name -eq $profileName2)}

    Assert-True { $profiles.Count -eq 2 }

    Get-AzureRmCdnProfile | where {($_.Name -eq $profileName1) -or ($_.Name -eq $profileName2)} | Remove-AzureRmCdnProfile -Force

    $deletedProfiles = Get-AzureRmCdnProfile | where {($_.Name -eq $profileName1) -or ($_.Name -eq $profileName2)}

    Assert-True { $deletedProfiles.Count -eq 0 }

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}