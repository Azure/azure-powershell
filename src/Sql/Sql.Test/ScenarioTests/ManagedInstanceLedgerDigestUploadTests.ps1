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
Tests getting default ledger digest upload configuration
#>
function Test-GetDefaultManagedLedgerDigestUpload
{
	# Setup
	$params = Get-DefaultManagedInstanceParameters
	$managedInstance = Create-ManagedInstanceLedgerTestEnvironment

	$databaseResourceId = "/subscriptions/" + $params.subscriptionId + "/resourceGroups/" + $managedInstance.rgName + "/providers/Microsoft.Sql/managedInstance/" + $managedInstance.serverName + "/databases/" + $managedInstance.databaseName
	$databaseObject = Get-AzSqlInstanceDatabase -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -Name $managedInstance.databaseName

	try 
	{
		# Test
		$ledgerDigestUpload = Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -DatabaseName $managedInstance.databaseName
	
		# Assert
		Assert-AreEqual $ledgerDigestUpload.State "Disabled"

		# Test
		$ledgerDigestUploadByResourceId = Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadByResourceId.State "Disabled"

		# Test
		$ledgerDigestUploadByDatabase = Get-AzSqlInstanceDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadByDatabase.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironmentForMi $managedInstance.rgName
	}
}

<#
.SYNOPSIS
Tests enabling and disabling ledger digest uploading using named parameters
#>
function Test-SetManagedLedgerDigestUploadByName
{
	# Setup
	$params = Get-DefaultManagedInstanceParameters
	$managedInstance = Create-ManagedInstanceLedgerTestEnvironment
	$endpoint = "https://test.confidential-ledger.azure.com"

	try 
	{
		# Test enabling
		$ledgerDigestUploadEnable = Enable-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -DatabaseName $managedInstance.databaseName -Endpoint $endpoint
	
		# Assert
		Assert-AreEqual $ledgerDigestUploadEnable.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnable.Endpoint $endpoint

		# Test get enabled settings
		$ledgerDigestUploadEnabledGet = Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -DatabaseName $managedInstance.databaseName

		# Assert
		Assert-AreEqual $ledgerDigestUploadEnabledGet.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnabledGet.Endpoint $endpoint

		# Test disabling 
		$ledgerDigestUploadDisable = Disable-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -DatabaseName $managedInstance.databaseName

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisable.State "Disabled"

		# Test get disabled settings
		$ledgerDigestUploadDisabledGet = Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -DatabaseName $managedInstance.databaseName

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisabledGet.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironmentForMi $managedInstance.rgName
	}
}

<#
.SYNOPSIS
Tests enabling and disabling ledger digest uploading using the database object
#>
function Test-SetManagedLedgerDigestUploadByDatabaseObject
{
	# Setup
	$params = Get-DefaultManagedInstanceParameters
	$managedInstance = Create-ManagedInstanceLedgerTestEnvironment
	$endpoint = "https://test.confidential-ledger.azure.com"

	$databaseObject = Get-AzSqlInstanceDatabase -ResourceGroupName $managedInstance.rgName -InstanceName $managedInstance.serverName -Name $managedInstance.databaseName

	try 
	{
		# Test enabling
		$ledgerDigestUploadEnable = Enable-AzSqlInstanceDatabaseLedgerDigestUpload -InputObject $databaseObject -Endpoint $endpoint
	
		# Assert
		Assert-AreEqual $ledgerDigestUploadEnable.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnable.Endpoint $endpoint

		# Test get enabled settings
		$ledgerDigestUploadEnabledGet = Get-AzSqlInstanceDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadEnabledGet.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnabledGet.Endpoint $endpoint

		# Test disabling 
		$ledgerDigestUploadDisable = Disable-AzSqlInstanceDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisable.State "Disabled"

		# Test get disabled settings
		$ledgerDigestUploadDisabledGet = Get-AzSqlInstanceDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisabledGet.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironmentForMi $managedInstance.rgName
	}
}

<#
.SYNOPSIS
Tests enabling and disabling ledger digest uploading using the resource ID
#>
function Test-SetManagedLedgerDigestUploadByResourceId
{
	# Setup
	$params = Get-DefaultManagedInstanceParameters
	$managedInstance = Create-ManagedInstanceLedgerTestEnvironment
	$databaseResourceId = "/subscriptions/" + $params.subscriptionId + "/resourceGroups/" + $managedInstance.rgName + "/providers/Microsoft.Sql/managedInstance/" + $managedInstance.serverName + "/databases/" + $managedInstance.databaseName
	$endpoint = "https://test.confidential-ledger.azure.com"

	try
	{
		# Test enabling
		$ledgerDigestUploadEnable = Enable-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceId $databaseResourceId -Endpoint $endpoint
	
		# Assert
		Assert-AreEqual $ledgerDigestUploadEnable.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnable.Endpoint $endpoint

		# Test get enabled settings
		$ledgerDigestUploadEnabledGet = Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadEnabledGet.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnabledGet.Endpoint $endpoint

		# Test disabling 
		$ledgerDigestUploadDisable = Disable-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisable.State "Disabled"

		# Test get disabled settings
		$ledgerDigestUploadDisabledGet = Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisabledGet.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironmentForMi $managedInstance.rgName
	}
}