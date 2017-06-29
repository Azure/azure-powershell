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
Get profile 
#>
function Test-GetProfile
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName

	try
	{
		$ttl = 50
		$trafficRoutingMethod = "Weighted"
		$monitorProtocol = "HTTP"
		$monitoPort = 80
		$monitorPath = "/testpath.asp"
		$profileStatus = "Enabled"

		New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl $ttl -TrafficRoutingMethod $trafficRoutingMethod -MonitorProtocol $monitorProtocol -MonitorPort $monitoPort -MonitorPath $monitorPath -ProfileStatus $profileStatus

		$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-NotNull $retrievedProfile
		Assert-AreEqual $profileName $retrievedProfile.Name 
		Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedProfile.ResourceGroupName
		Assert-AreEqual $ttl $retrievedProfile.Ttl
		Assert-AreEqual $trafficRoutingMethod $retrievedProfile.TrafficRoutingMethod
		Assert-AreEqual $monitorProtocol $retrievedProfile.MonitorProtocol
		Assert-AreEqual $monitoPort $retrievedProfile.MonitorPort
		Assert-AreEqual $monitorPath $retrievedProfile.MonitorPath
		Assert-AreEqual $profileStatus $retrievedProfile.ProfileStatus
	}
	finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Get non existing profile
#>
function Test-GetMissingProfile
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		Assert-Throws { Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }
	}
	finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
List profiles in resource group
#>
function Test-ListProfilesInResourceGroup
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
		$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

		$profiles = Get-AzureRmTrafficManagerProfile -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-AreEqual 1 $profiles.Count
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
List profiles in subscription
#>
function Test-ListProfilesInSubscription
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
		$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

		$profiles = Get-AzureRmTrafficManagerProfile

		Assert-NotNull $profiles
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
List profiles in resource group and pipe results to where-object. VSO#942574
Also assert on the return type to prevent silent change
#>
function Test-ListProfilesWhereObject
{
	$resourceGroup = TestSetup-CreateResourceGroup

	$profileName1 = getAssetName
	$relativeName1 = getAssetName
	$profileName2 = getAssetName
	$relativeName2 = getAssetName
	
	try
	{
		$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName1 -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName1 -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
		$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName2 -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName2 -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

		$profiles = Get-AzureRmTrafficManagerProfile -ResourceGroupName $resourceGroup.ResourceGroupName
		Assert-AreEqual Microsoft.Azure.Commands.TrafficManager.Models.TrafficManagerProfile[] $profiles.GetType()

		$profile2 = $profiles | where-object {$_.Name -eq $profileName2}

		Assert-AreEqual $profileName2 $profile2.Name
		Assert-AreEqual $relativeName2 $profile2.RelativeDnsName
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}