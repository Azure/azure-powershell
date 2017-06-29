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
Disable existing disabled profile
#>
function Test-ProfileDisable
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
		$enabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Enabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	
		Assert-AreEqual "Enabled" $enabledProfile.ProfileStatus

		Assert-True { Disable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force }

		$updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-AreEqual "Disabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable existing disabled profile using pipeline
#>
function Test-ProfileDisablePipeline
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
		$enabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Enabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
		Assert-AreEqual "Enabled" $enabledProfile.ProfileStatus

		Assert-True { Disable-AzureRmTrafficManagerProfile -TrafficManagerProfile $enabledProfile -Force }

		$updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-AreEqual "Disabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable non existing profile
#>
function Test-ProfileDisableNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		Assert-Throws { Disable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force } 
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}