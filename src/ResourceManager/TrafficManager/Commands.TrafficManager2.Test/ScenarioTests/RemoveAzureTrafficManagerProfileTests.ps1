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
Remove a Profile
#>
function Test-RemoveProfile
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName
	
		$removed = Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force 
		Assert-True { $removed }
	}
	finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Remove a Profile that does not exist
#>
function Test-ProfileRemoveNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
		$removed = Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force 
		Assert-False { $removed }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Delete a profile using the object instead of the parameters
#>
function Test-RemoveProfileParameterSetObject
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName

	try
	{
		$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

		$removed = Remove-AzureRmTrafficManagerProfile -TrafficManagerProfile $createdProfile -Force 
		Assert-True { $removed }
	}
	finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}