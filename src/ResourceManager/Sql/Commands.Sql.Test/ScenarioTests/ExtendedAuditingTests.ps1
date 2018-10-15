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
Test for extended auditing and auditing on a server
#>
function Test-ExtendedAuditingOnServer
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Enable blob auditing policy and verify it.
		Set-AzureRmSqlServerAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType 

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzureRmSqlServerExtendedAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlServerExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.PredicateExpression

		# Enable Extended auditing policy, speficying a predicate expression, and verify it.
		Set-AzureRmSqlServerExtendedAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression "statement <> 'select 1'"
		$policy = Get-AzureRmSqlServerExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable extended auditing policy and verify it.
		Set-AzureRmSqlServerExtendedAuditing -State Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureRmSqlServerExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.AuditState

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzureRmSqlServerExtendedAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlServerExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable extended auditing policy and verify it.
		Set-AzureRmSqlServerExtendedAuditing -State Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for extended auditing and auditing on a database
#>
function Test-ExtendedAuditingOnDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Enable blob auditing policy and verify it.
		Set-AzureRmSqlDatabaseAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzureRmSqlDatabaseExtendedAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlDatabaseExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.PredicateExpression

		# Enable Extended auditing policy, speficying a predicate expression, and verify it.
		Set-AzureRmSqlDatabaseExtendedAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression "statement <> 'select 1'"
		$policy = Get-AzureRmSqlDatabaseExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable extended auditing policy and verify it.
		Set-AzureRmSqlDatabaseExtendedAuditing -State Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
		$policy = Get-AzureRmSqlDatabaseExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.AuditState

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzureRmSqlDatabaseExtendedAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlDatabaseExtendedAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.AuditState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable extended auditing policy and verify it.
		Set-AzureRmSqlDatabaseExtendedAuditing -State Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}