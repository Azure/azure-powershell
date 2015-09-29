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
	Tests creating a database
#>
function Test-ServerActiveDirectoryAdministrator ($location = "North Europe")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "12.0" $location
	
	try
	{
		$activeDirectoryGroup1 = "testAADaccount"
		$activeDirectoryGroup1ObjectId = "41732a4a-e09e-4b18-9624-38e252d68bbf"
		$activeDirectoryUser1 = "Test User 2"
		$activeDirectoryUser1ObjectId = "e87332b2-e3ed-480a-9723-e9b3611268f8"

		# Verify there is no Active Directory Administrator set
		$activeDirectoryAdmin = Get-AzureRmSqlServerActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName

		Assert-Null $activeDirectoryAdmin

			# Set an Azure SQL Server Active Directory Administrator Group
		$activeDirectoryAdmin1 = Set-AzureRmSqlServerActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		-DisplayName $activeDirectoryGroup1

		Assert-NotNull $activeDirectoryAdmin1

		# Verify the correct Active Directory Administrator is set
		Assert-AreEqual $activeDirectoryAdmin1.DisplayName $activeDirectoryGroup1
		Assert-AreEqual $activeDirectoryAdmin1.ObjectId $activeDirectoryGroup1ObjectId

		# Get an Azure SQL Server Active Directory Administrator
		$activeDirectoryAdmin2 = Get-AzureRmSqlServerActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName

		Assert-AreEqual $activeDirectoryAdmin2.DisplayName $activeDirectoryGroup1
		Assert-AreEqual $activeDirectoryAdmin2.ObjectId $activeDirectoryGroup1ObjectId

		# Set an Azure SQL Server Active Directory Administrator User
		$activeDirectoryAdmin3 = Set-AzureRmSqlServerActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		-DisplayName $activeDirectoryUser1

		Assert-AreEqual $activeDirectoryAdmin3.DisplayName $activeDirectoryUser1
		Assert-AreEqual $activeDirectoryAdmin3.ObjectId $activeDirectoryUser1ObjectId

		# Set an Azure SQL Server Active Directory Administrator User
		$activeDirectoryAdmin4 = Remove-AzureRmSqlServerActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Force

		# Verify that Azure SQL Server Active Directory Administrator was deleted
		$activeDirectoryAdmin5 = Get-AzureRmSqlServerActiveDirectoryAdministrator -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName

		Assert-Null $activeDirectoryAdmin5
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

