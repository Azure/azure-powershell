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
function Test-GetDefaultLedgerDigestUpload
{
	# Setup
	$testSuffix = getAssetName
	$params = Get-LedgerTestEnvironmentParameters $testSuffix
	Create-LedgerTestEnvironment $params

	$databaseResourceId = "/subscriptions/" + $params.subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/" + $params.databaseName 
	$databaseObject = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

	try 
	{
		# Test
		$ledgerDigestUpload = Get-AzSqlDatabaseLedgerDigestUpload -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $ledgerDigestUpload.State "Disabled"

		# Test
		$ledgerDigestUploadByResourceId = Get-AzSqlDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadByResourceId.State "Disabled"

		# Test
		$ledgerDigestUploadByDatabase = Get-AzSqlDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadByDatabase.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests enabling and disabling ledger digest uploading using named parameters
#>
function Test-SetLedgerDigestUploadByName
{
	# Setup
	$testSuffix = getAssetName
	$params = Get-LedgerTestEnvironmentParameters $testSuffix
	Create-LedgerTestEnvironment $params
	$endpoint = "https://test.confidential-ledger.azure.com"

	try 
	{
		# Test enabling
		$ledgerDigestUploadEnable = Enable-AzSqlDatabaseLedgerDigestUpload -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -Endpoint $endpoint
	
		# Assert
		Assert-AreEqual $ledgerDigestUploadEnable.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnable.Endpoint $endpoint

		# Test get enabled settings
		$ledgerDigestUploadEnabledGet = Get-AzSqlDatabaseLedgerDigestUpload -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $ledgerDigestUploadEnabledGet.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnabledGet.Endpoint $endpoint

		# Test disabling 
		$ledgerDigestUploadDisable = Disable-AzSqlDatabaseLedgerDigestUpload -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisable.State "Disabled"

		# Test get disabled settings
		$ledgerDigestUploadDisabledGet = Get-AzSqlDatabaseLedgerDigestUpload -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisabledGet.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests enabling and disabling ledger digest uploading using the database object
#>
function Test-SetLedgerDigestUploadByDatabaseObject
{
	# Setup
	$testSuffix = getAssetName
	$params = Get-LedgerTestEnvironmentParameters $testSuffix
	Create-LedgerTestEnvironment $params
	$endpoint = "https://test.confidential-ledger.azure.com"
	$databaseObject = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

	try 
	{
		# Test enabling
		$ledgerDigestUploadEnable = Enable-AzSqlDatabaseLedgerDigestUpload -InputObject $databaseObject -Endpoint $endpoint
	
		# Assert
		Assert-AreEqual $ledgerDigestUploadEnable.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnable.Endpoint $endpoint

		# Test get enabled settings
		$ledgerDigestUploadEnabledGet = Get-AzSqlDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadEnabledGet.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnabledGet.Endpoint $endpoint

		# Test disabling 
		$ledgerDigestUploadDisable = Disable-AzSqlDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisable.State "Disabled"

		# Test get disabled settings
		$ledgerDigestUploadDisabledGet = Get-AzSqlDatabaseLedgerDigestUpload -InputObject $databaseObject

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisabledGet.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests enabling and disabling ledger digest uploading using the resource ID
#>
function Test-SetLedgerDigestUploadByResourceId
{
	# Setup
	$testSuffix = getAssetName
	$params = Get-LedgerTestEnvironmentParameters $testSuffix
	Create-LedgerTestEnvironment $params
	$endpoint = "https://test.confidential-ledger.azure.com"
	$databaseResourceId = "/subscriptions/" + $params.subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/" + $params.databaseName 

	try 
	{
		# Test enabling
		$ledgerDigestUploadEnable = Enable-AzSqlDatabaseLedgerDigestUpload -ResourceId $databaseResourceId -Endpoint $endpoint
	
		# Assert
		Assert-AreEqual $ledgerDigestUploadEnable.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnable.Endpoint $endpoint

		# Test get enabled settings
		$ledgerDigestUploadEnabledGet = Get-AzSqlDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadEnabledGet.State "Enabled"
		Assert-AreEqual $ledgerDigestUploadEnabledGet.Endpoint $endpoint

		# Test disabling 
		$ledgerDigestUploadDisable = Disable-AzSqlDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisable.State "Disabled"

		# Test get disabled settings
		$ledgerDigestUploadDisabledGet = Get-AzSqlDatabaseLedgerDigestUpload -ResourceId $databaseResourceId

		# Assert
		Assert-AreEqual $ledgerDigestUploadDisabledGet.State "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-LedgerTestEnvironment $testSuffix
	}
}