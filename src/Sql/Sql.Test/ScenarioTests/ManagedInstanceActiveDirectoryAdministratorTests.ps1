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
	$params = Get-DefaultManagedInstanceNameAndRgForAADAdmin

	# If there is a need to re-record this test, these values must be changed to correspond to existing group and user from Azure Active Directory related to current subscription.
	$activeDirectoryGroup = "testSqlAADPowershellGroup"
	$activeDirectoryGroupObjectId = "a461269d-f0e1-4214-a0bd-85b4df11a2c3"
	$activeDirectoryUser = "Test User 1"
	$activeDirectoryUserMail = "testuser_1@microsoft.com"
	$activeDirectoryUserObjectId = "c803e62a-3720-4b88-9bc5-ba910dcf229e"
	$activeDirectoryServicePrincipal = "testSqlAADPowershellServicePrincipal"
	$activeDirectoryServicePrincipalObjectId = "5541c08c-3845-44a9-a485-ea6b7e785a87"

	# Set an Active Directory Administrator Group on Managed Instance
	# This command uses the Graph API to check if there is a user/group for provided DisplayName and ObjectId. Graph authentication blocks test passes, so if you need to record this test again, you must provide real token in 
	# MockTokenAuthenticationFactory constructor and change SetAuthenticationFactory in EnvironmentSetupHelper.
	$activeDirectoryAdmin1 = Set-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name -DisplayName $activeDirectoryGroup -ObjectId $activeDirectoryGroupObjectId

	Assert-NotNull $activeDirectoryAdmin1

	# Verify the correct Active Directory Administrator is set
	Assert-AreEqual $activeDirectoryAdmin1.DisplayName $activeDirectoryGroup
	Assert-AreEqual $activeDirectoryAdmin1.ObjectId $activeDirectoryGroupObjectId

	# Get an Active Directory Administrator
	$activeDirectoryAdmin2 = Get-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name

	Assert-AreEqual $activeDirectoryAdmin2.DisplayName $activeDirectoryGroup
	Assert-AreEqual $activeDirectoryAdmin2.ObjectId $activeDirectoryGroupObjectId

	# Set an Active Directory Administrator User on Managed Instance
	$activeDirectoryAdmin3 = Set-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name -DisplayName $activeDirectoryUser -ObjectId $activeDirectoryUserObjectId

	# We expect that email is returned since the API expects email to be sent as the display name
	Assert-AreEqual $activeDirectoryAdmin3.DisplayName $activeDirectoryUserMail
	Assert-AreEqual $activeDirectoryAdmin3.ObjectId $activeDirectoryUserObjectId

	# Set an Active Directory Administrator Service principal on Managed Instance
	$activeDirectoryAdmin4 = Set-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name -DisplayName $activeDirectoryServicePrincipal -ObjectId $activeDirectoryServicePrincipalObjectId

	Assert-AreEqual $activeDirectoryAdmin4.DisplayName $activeDirectoryServicePrincipal
	Assert-AreEqual $activeDirectoryAdmin4.ObjectId $activeDirectoryServicePrincipalObjectId

	# Set an Active Directory Administrator User (mail) on Managed Instance
	$activeDirectoryAdmin5 = Set-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name -DisplayName $activeDirectoryUserMail -ObjectId $activeDirectoryUserObjectId

	Assert-AreEqual $activeDirectoryAdmin5.DisplayName $activeDirectoryUserMail
	Assert-AreEqual $activeDirectoryAdmin5.ObjectId $activeDirectoryUserObjectId

	# Remove an Active Directory Administrator User from Managed Instance
	Remove-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name -Force

	# Verify that Active Directory Administrator was deleted
	$activeDirectoryAdmin6 = Get-AzSqlInstanceActiveDirectoryAdministrator -ResourceGroupName $params.rg -InstanceName $params.name

	Assert-Null $activeDirectoryAdmin6
}
