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
Create a Profile 
#>
function Test-NewProfile
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

		$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl $ttl -TrafficRoutingMethod $trafficRoutingMethod -MonitorProtocol $monitorProtocol -MonitorPort $monitoPort -MonitorPath $monitorPath -ProfileStatus $profileStatus

		Assert-NotNull $createdProfile
		Assert-AreEqual $profileName $createdProfile.Name 
		Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName
		Assert-AreEqual $ttl $createdProfile.Ttl
		Assert-AreEqual $trafficRoutingMethod $createdProfile.TrafficRoutingMethod
		Assert-AreEqual $monitorProtocol $createdProfile.MonitorProtocol
		Assert-AreEqual $monitoPort $createdProfile.MonitorPort
		Assert-AreEqual $monitorPath $createdProfile.MonitorPath
		Assert-AreEqual $profileStatus $createdProfile.ProfileStatus
	}
	finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Create a Profile that already exists
#>
function Test-ProfileNewAlreadyExists
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$profileName = getAssetName

	try
	{
		$createdProfile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName
		$resourceGroupName = $createdProfile.ResourceGroupName

		Assert-NotNull $createdProfile
	
		Assert-Throws { TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName } 

		$createdProfile | Remove-AzureRmTrafficManagerProfile -Force
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}