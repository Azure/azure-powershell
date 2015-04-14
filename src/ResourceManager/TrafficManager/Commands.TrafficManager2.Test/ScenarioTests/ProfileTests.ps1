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
	$profileName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	$createdProfile = New-AzureTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	Assert-NotNull $createdProfile
	Assert-AreEqual $profileName $createdProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName 
	Assert-AreEqual "Performance" $createdProfile.TrafficRoutingMethod

	$retrievedProfile = Get-AzureTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual $profileName $retrievedProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedProfile.ResourceGroupName

	$createdProfile.TrafficRoutingMethod = "Priority"

	$updatedProfile = Set-AzureTrafficManagerProfile -Profile $createdProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual $profileName $updatedProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $updatedProfile.ResourceGroupName
	Assert-AreEqual "Priority" $updatedProfile.TrafficRoutingMethod

	Remove-AzureTrafficManagerProfile -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force

	Assert-Throws { Get-AzureTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "ResourceNotFound: Resource not found."
}

<#
.SYNOPSIS
Delete a profile using the object instead of the parameters
#>
function Test-CreateDeleteUsingProfile
{
	$profileName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	$createdProfile = New-AzureTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	Assert-NotNull $createdProfile
	Assert-AreEqual $profileName $createdProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName 
	Assert-AreEqual "Performance" $createdProfile.TrafficRoutingMethod

	Remove-AzureTrafficManagerProfile -Profile $createdProfile -Force

	Assert-Throws { Get-AzureTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "ResourceNotFound: Resource not found."
}

<#
.SYNOPSIS
Create a Profile that already exists
#>
function Test-ProfileNewAlreadyExists
{
	$zoneName = getAssetname
    $createdZone = TestSetup-CreateResourceGroup | New-AzureDnsZone -Name $zoneName
	$resourceGroupName = $createdZone.ResourceGroupName
	Assert-NotNull $createdZone
	
	Assert-Throws { New-AzureDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } "PreconditionFailed: The condition '*' in the If-None-Match header was not satisfied."

	$createdZone | Remove-AzureDnsZone -PassThru -Force
}

<#
.SYNOPSIS
Set a Profile that does not exist
#>
function Test-ProfileSetNotFound
{
	$zoneName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	
	Assert-Throws { Set-AzureDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } "PreconditionFailed: The condition '*' in the If-Match header was not satisfied."
}

<#
.SYNOPSIS
Remove a Profile that does not exist
#>
function Test-ProfileRemoveNonExisting
{
	$zoneName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	
	$removed = Remove-AzureDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force -PassThru
	Assert-True { $removed }
}