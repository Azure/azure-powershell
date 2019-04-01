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
Full Link CRUD cycle
#>
function Test-LinkCrud
{
	$createdLink = Create-VirtualNetworkLink $false

	Assert-NotNull $createdLink
	Assert-NotNull $createdLink.Etag
	Assert-NotNull $createdLink.Name
	Assert-NotNull $createdLink.ZoneName
	Assert-NotNull $createdLink.ResourceGroupName
	Assert-AreEqual 1 $createdLink.Tags.Count
	Assert-AreEqual $false $createdLink.RegistrationEnabled
	Assert-AreNotEqual $createdLink.VirtualNetworkId $createdZone.VirtualNetworkId
	Assert-AreEqual $createdLink.ProvisioningState "Succeeded"
	Assert-Null $createdLink.Type

	$retrievedLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name

	Assert-NotNull $retrievedLink
	Assert-NotNull $retrievedLink.Etag
	Assert-AreEqual $createdLink.Name $retrievedLink.Name
	Assert-AreEqual $createdLink.ResourceGroupName $retrievedLink.ResourceGroupName
	Assert-AreEqual $retrievedLink.Etag $createdLink.Etag
	Assert-AreEqual 1 $retrievedLink.Tags.Count
	Assert-AreEqual $createdLink.VirtualNetworkId $retrievedLink.VirtualNetworkId
	Assert-AreEqual $createdLink.ZoneName $retrievedLink.ZoneName
	Assert-AreEqual $createdLink.RegistrationEnabled $retrievedLink.RegistrationEnabled
	Assert-AreEqual $retrievedLink.ProvisioningState "Succeeded"
	Assert-Null $retrievedLink.Type

	$updatedLink = Set-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name -Tag @{tag1="value1";tag2="value2"}

	Assert-NotNull $updatedLink
	Assert-NotNull $updatedLink.Etag
	Assert-AreEqual $createdLink.Name $updatedLink.Name
	Assert-AreEqual $createdLink.ResourceGroupName $updatedLink.ResourceGroupName
	Assert-AreNotEqual $updatedLink.Etag $createdLink.Etag
	Assert-AreEqual 2 $updatedLink.Tags.Count
	Assert-AreEqual $updatedLink.ProvisioningState "Succeeded"
	Assert-Null $updatedLink.Type

	$retrievedLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name

	Assert-NotNull $retrievedLink
	Assert-NotNull $retrievedLink.Etag
	Assert-AreEqual $createdLink.Name $retrievedLink.Name
	Assert-AreEqual $createdLink.ResourceGroupName $retrievedLink.ResourceGroupName
	Assert-AreEqual $retrievedLink.Etag $updatedLink.Etag
	Assert-AreEqual 2 $retrievedLink.Tags.Count
	Assert-AreEqual $retrievedLink.ProvisioningState "Succeeded"
	Assert-Null $retrievedLink.Type

	$removed = Remove-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-Throws { Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name }
	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force	
}

<#
.SYNOPSIS
Full Link CRUD cycle with piping
#>
function Test-LinkCrudWithPiping
{
	$createdLink = Create-VirtualNetworkLink $false

	Assert-NotNull $createdLink
	Assert-NotNull $createdLink.Etag
	Assert-NotNull $createdLink.Name
	Assert-NotNull $createdLink.ZoneName
	Assert-NotNull $createdLink.ResourceGroupName
	Assert-AreEqual 1 $createdLink.Tags.Count
	Assert-AreEqual $false $createdLink.RegistrationEnabled
	Assert-AreNotEqual $createdLink.VirtualNetworkId $createdZone.VirtualNetworkId
	Assert-AreEqual $createdLink.ProvisioningState "Succeeded"
	Assert-Null $createdLink.Type

	$retrievedLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name

	Assert-NotNull $retrievedLink
	Assert-NotNull $retrievedLink.Etag
	Assert-AreEqual $createdLink.Name $retrievedLink.Name
	Assert-AreEqual $createdLink.ResourceGroupName $retrievedLink.ResourceGroupName
	Assert-AreEqual $retrievedLink.Etag $createdLink.Etag
	Assert-AreEqual 1 $retrievedLink.Tags.Count
	Assert-AreEqual $createdLink.VirtualNetworkId $retrievedLink.VirtualNetworkId
	Assert-AreEqual $createdLink.ZoneName $retrievedLink.ZoneName
	Assert-AreEqual $createdLink.RegistrationEnabled $retrievedLink.RegistrationEnabled
	Assert-AreEqual $retrievedLink.ProvisioningState "Succeeded"
	Assert-Null $retrievedLink.Type

	$updatedLink = $createdLink | Set-AzPrivateDnsVirtualNetworkLink -Tag @{tag1="value1";tag2="value2"}

	Assert-NotNull $updatedLink
	Assert-NotNull $updatedLink.Etag
	Assert-AreEqual $createdLink.Name $updatedLink.Name
	Assert-AreEqual $createdLink.ResourceGroupName $updatedLink.ResourceGroupName
	Assert-AreNotEqual $updatedLink.Etag $createdLink.Etag
	Assert-AreEqual 2 $updatedLink.Tags.Count
	Assert-AreEqual $updatedLink.ProvisioningState "Succeeded"
	Assert-Null $updatedLink.Type

	$retrievedLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name

	Assert-NotNull $retrievedLink
	Assert-NotNull $retrievedLink.Etag
	Assert-AreEqual $createdLink.Name $retrievedLink.Name
	Assert-AreEqual $createdLink.ResourceGroupName $retrievedLink.ResourceGroupName
	Assert-AreEqual $retrievedLink.Etag $updatedLink.Etag
	Assert-AreEqual 2 $retrievedLink.Tags.Count
	Assert-AreEqual $retrievedLink.ProvisioningState "Succeeded"
	Assert-Null $retrievedLink.Type

	$removed = $retrievedLink | Remove-AzPrivateDnsVirtualNetworkLink -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-Throws { Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name }
	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force	
}

<#
.SYNOPSIS
Test registration link creation
#>
function Test-RegistrationLinkCreate
{
	
	$createdLink = Create-VirtualNetworkLink $true

	Assert-NotNull $createdLink
	Assert-AreEqual $true $createdLink.RegistrationEnabled
	Assert-AreEqual $createdLink.ProvisioningState "Succeeded"

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link creation when link already exists
#>
function Test-LinkAlreadyExistsCreateThrow
{
	$createdLink1 = Create-VirtualNetworkLink $false

	$message = "*exists already and hence cannot be created again*"
	Assert-ThrowsLike { New-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink1.zoneName -ResourceGroupName $createdLink1.ResourceGroupName -Name $createdLink1.Name -Tag @{tag1="value2"} -VirtualNetworkId $createdLink1.VirtualNetworkId } $message

	Remove-AzResourceGroup -Name $createdLink1.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link creation with virtual network object
#>
function Test-CreateLinkWithVirtualNetworkObject
{
	$zoneName = Get-RandomZoneName
	$linkName = Get-RandomLinkName
    $resourceGroup = TestSetup-CreateResourceGroup

	$createdZone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tag @{tag1="value1"}
	$createdVirtualNetwork = TestSetup-CreateVirtualNetwork $resourceGroup
	$createdLink = New-AzPrivateDnsVirtualNetworkLink -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Name $linkName -Tag @{tag1="value1"} -VirtualNetwork $createdVirtualNetwork -EnableRegistration

	Assert-NotNull $createdLink
	Assert-NotNull $createdLink.Etag
	Assert-NotNull $createdLink.Name
	Assert-NotNull $createdLink.ZoneName
	Assert-NotNull $createdLink.ResourceGroupName
	Assert-AreEqual 1 $createdLink.Tags.Count
	Assert-AreEqual $true $createdLink.RegistrationEnabled
	Assert-AreEqual $createdLink.VirtualNetworkId $createdVirtualNetwork.Id
	Assert-AreEqual $createdLink.ProvisioningState "Succeeded"
	Assert-Null $createdLink.Type

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force

}

<#
.SYNOPSIS
Test link update
#>
function Test-UpdateLinkRegistrationStatusWithPiping
{
	$createdLink = Create-VirtualNetworkLink $false
	
	$createdLink.RegistrationEnabled = $true
	$updatedLink = $createdLink | Set-AzPrivateDnsVirtualNetworkLink	
	Assert-AreEqual $updatedLink.RegistrationEnabled $true

	$updatedLink.RegistrationEnabled = $false
	$reUpdatedLink = $updatedLink | Set-AzPrivateDnsVirtualNetworkLink
	Assert-AreEqual $updatedLink.RegistrationEnabled $false

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link update with resource Id
#>
function Test-UpdateLinkRegistrationStatusWithResourceId
{
	$createdLink = Create-VirtualNetworkLink $false
	$updatedLink = Set-AzPrivateDnsVirtualNetworkLink -ResourceId $createdLink.ResourceId -IsRegistrationEnabled $true -Tag @{}
	
	Assert-AreEqual $updatedLink.RegistrationEnabled $true
	Assert-AreEqual 0 $updatedLink.Tags.Count

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link delete with resource Id
#>
function Test-DeleteLinkWithResourceId
{
	$createdLink = Create-VirtualNetworkLink $false
	$deletedLink = Remove-AzPrivateDnsVirtualNetworkLink -ResourceId $createdLink.ResourceId -PassThru
	
	Assert-True { $deletedLink }
	Assert-Throws { Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name }

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}


<#
.SYNOPSIS
Test link update with etag mismatch throws error 
#>
function Test-UpdateLinkWithEtagMismatchThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	$createdLink.RegistrationEnabled = $true
	$createdLink.Etag = "gibberish"
	
	Assert-ThrowsLike { $createdLink | Set-AzPrivateDnsVirtualNetworkLink } "*(etag mismatch)*"

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link update with etag mismatch with overwrite.
#>
function Test-UpdateLinkWithEtagMismatchOverwrite
{
	$createdLink = Create-VirtualNetworkLink $false
	Assert-AreEqual $createdLink.RegistrationEnabled $false

	$createdLink.RegistrationEnabled = $true
	$createdLink.Etag = "gibberish"
	
	$updatedLink = $createdLink | Set-AzPrivateDnsVirtualNetworkLink -Overwrite
	Assert-AreEqual $updatedLink.RegistrationEnabled $true
	Assert-AreEqual $updatedLink.ProvisioningState "Succeeded"

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link update with non existing zone
#>
function Test-UpdateLinkZoneNotExistsThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	
	$message = "*The resource * under resource group * was not found*"
	Assert-ThrowsLike { Set-AzPrivateDnsVirtualNetworkLink -ZoneName "nonexistingzone.com" -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name -Tag @{tag1="value1";tag2="value2"} } $message

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link update with non existing link
#>
function Test-UpdateLinkLinkNotExistsThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	
	$message = "*The resource * under resource group * was not found*"
	Assert-ThrowsLike { Set-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name "nonexistinglink" -Tag @{tag1="value1";tag2="value2"} } $message

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link update with no changes to link
#>
function Test-UpdateLinkWithNoChangesShouldNotThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	
	$updatedLink = $createdLink | Set-AzPrivateDnsVirtualNetworkLink
	Assert-AreEqual $updatedLink.ProvisioningState "Succeeded"

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link get with non existing zone.
#>
function Test-GetLinkZoneNotExistsThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	
	$message = "*The resource * under resource group * was not found*"
	Assert-ThrowsLike { Get-AzPrivateDnsVirtualNetworkLink -ZoneName "nonexistingzone.com" -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name } $message

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link get with non existing link
#>
function Test-GetLinkLinkNotExistsThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	
	$message = "*The resource * under resource group * was not found*"
	Assert-ThrowsLike { Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name "nonexistinglink" } $message

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}
<#
.SYNOPSIS
Test link remove with non existing zone.
#>
function Test-RemoveLinkZoneNotExistsShouldNotThrow
{
	$createdLink = Create-VirtualNetworkLink $false
	
	Remove-AzPrivateDnsVirtualNetworkLink -ZoneName "nonexistingzone.com" -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name

	$getLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name
	Assert-NotNull $getLink
	Assert-AreEqual $getLink.RegistrationEnabled $false

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test link remove with non existing link
#>
function Test-RemoveLinkLinkNotExistsShouldNotThrow
{
	$createdLink = Create-VirtualNetworkLink $false

	Remove-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name "nonexistinglink"

	$getLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $createdLink.ZoneName -ResourceGroupName $createdLink.ResourceGroupName -Name $createdLink.Name
	Assert-NotNull $getLink
	Assert-AreEqual $getLink.RegistrationEnabled $false

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

<#
.SYNOPSIS
List all links in a resource group
#>
function Test-ListLinks
{
	$linkName1 = Get-RandomLinkName
	$linkName2 = Get-RandomLinkName
	$zoneName = Get-RandomZoneName
    $resourceGroup = TestSetup-CreateResourceGroup

	$createdZone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tag @{tag1="value1"}
	
	$createdVirtualNetwork1 = TestSetup-CreateVirtualNetwork $resourceGroup
	$createdVirtualNetwork2 = TestSetup-CreateVirtualNetwork $resourceGroup
	
	$createdLink1 = New-AzPrivateDnsVirtualNetworkLink -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Name $linkName1 -Tag @{tag1="value1"} -VirtualNetworkId $createdVirtualNetwork1.Id
	$createdLink2 = New-AzPrivateDnsVirtualNetworkLink -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Name $linkName2 -Tag @{tag1="value1"} -VirtualNetworkId $createdVirtualNetwork2.Id

	$getLink = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $zoneName -ResourceGroupName $createdLink1.ResourceGroupName
	
	Assert-NotNull $getLink
	Assert-AreEqual 2 $getLink.Count

	Remove-AzResourceGroup -Name $createdLink.ResourceGroupName -Force
}

