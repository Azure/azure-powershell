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
	Tests for managing Active Directory Administrator on managed instance
#>
function Test-ManagedInstanceActiveDirectoryAdministrator
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId
        
	# If there is a need to re-record this test, these values must be changed to correspond to existing group and user from Azure Active Directory related to current subscription.
	$activeDirectoryGroup1 = "aadadmin"
	$activeDirectoryGroup1ObjectId = "52b6d571-5ff9-4b8f-92de-4a5b1bcdbbef"
	$activeDirectoryUser1 = "CL AAD Test User"
	$activeDirectoryUser1ObjectId = "034bb7d9-ca26-4c6f-abe0-4aff74fdca50"

	try
	{
		# Verify there is no Active Directory Administrator set
		$activeDirectoryAdmin = Get-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName

		Assert-Null $activeDirectoryAdmin

		# Set an Active Directory Administrator Group on Managed Instance
		# This command uses the Graph API to check if there is a user/group for provided DisplayName and ObjectId. Graph authentication blocks test passes, so if you need to record this test again, you must provide real token in 
		# MockTokenAuthenticationFactory constructor and change SetAuthenticationFactory in EnvironmentSetupHelper.
		$activeDirectoryAdmin1 = Set-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DisplayName $activeDirectoryGroup1 -ObjectId $activeDirectoryGroup1ObjectId

		Assert-NotNull $activeDirectoryAdmin1

		# Verify the correct Active Directory Administrator is set
		Assert-AreEqual $activeDirectoryAdmin1.DisplayName $activeDirectoryGroup1
		Assert-AreEqual $activeDirectoryAdmin1.ObjectId $activeDirectoryGroup1ObjectId

		# Get an Active Directory Administrator
		$activeDirectoryAdmin2 = Get-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName

		Assert-AreEqual $activeDirectoryAdmin2.DisplayName $activeDirectoryGroup1
		Assert-AreEqual $activeDirectoryAdmin2.ObjectId $activeDirectoryGroup1ObjectId

		# Set an Active Directory Administrator User on Managed Instance
		$activeDirectoryAdmin3 = Set-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DisplayName $activeDirectoryUser1 -ObjectId $activeDirectoryUser1ObjectId

		Assert-AreEqual $activeDirectoryAdmin3.DisplayName $activeDirectoryUser1
		Assert-AreEqual $activeDirectoryAdmin3.ObjectId $activeDirectoryUser1ObjectId

		# Remove an Active Directory Administrator User from Managed Instance
		$activeDirectoryAdmin4 = Remove-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Force

		# Verify that Active Directory Administrator was deleted
		$activeDirectoryAdmin5 = Get-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName

		Assert-Null $activeDirectoryAdmin5
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
