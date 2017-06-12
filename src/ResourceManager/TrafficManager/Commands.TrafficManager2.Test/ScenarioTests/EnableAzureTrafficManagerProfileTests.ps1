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
Enable existing disabled profile
#>
function Test-ProfileEnable
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
		$disabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
		Assert-AreEqual "Disabled" $disabledProfile.ProfileStatus

		Assert-True { Enable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }

		$updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-AreEqual "Enabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable existing disabled profile using pipeline
#>
function Test-ProfileEnablePipeline
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
		$disabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
		Assert-AreEqual "Disabled" $disabledProfile.ProfileStatus

		Assert-True { Enable-AzureRmTrafficManagerProfile -TrafficManagerProfile $disabledProfile }

		$updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-AreEqual "Enabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable non existing profile
#>
function Test-ProfileEnableNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    
	try
	{
		Assert-Throws { Enable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}