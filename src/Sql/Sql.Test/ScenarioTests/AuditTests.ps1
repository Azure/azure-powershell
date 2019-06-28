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
Tests that when setting the storage account property's value in a database's blob auditing policy, that value is later fetched properly
#>
function Test-BlobAuditDatabaseUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountResourceId $params.storageAccountResourceId
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"  
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the flow in which re-setting the policy with storage account that has the same name as before, but it is now on a different region
#>
function Test-BlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountResourceId $params.storageAccountResourceId
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"  

		$newResourceGroupName =  "test-rg2-for-sql-cmdlets-" + $testSuffix
		New-AzureRmResourceGroup -Location "West Europe" -ResourceGroupName $newResourceGroupName
		New-AzureRmStorageAccount -StorageAccountName $params.storageAccount  -ResourceGroupName $newResourceGroupName -Location "West Europe" -Type Standard_GRS

		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountResourceId $params.storageAccountResourceId
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"  
	}
	finally
	{
		# Cleanup
		Remove-AzureRmResourceGroup -Name $newResourceGroupName -Force
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when setting the storage account property's value in a server's blob auditing policy, that value is later fetched properly
#>
function Test-BlobAuditServerUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountResourceId $params.storageAccountResourceId
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled" 
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the storage account property's value in a database's auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-BlobAuditDatabaseUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		$policyBefore = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policyAfter = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policyBefore.StorageAccountResourceId $policyAfter.StorageAccountResourceId
		Assert-AreEqual $policyAfter.StorageAccountResourceId $params.storageAccountResourceId 

	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the storage account property's value in a server's blob auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-BlobAuditServerUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId
		$policyBefore = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName

		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policyAfter = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policyBefore.StorageAccountResourceId $policyAfter.StorageAccountResourceId
		Assert-AreEqual $policyAfter.StorageAccountResourceId $params.storageAccountResourceId 

	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when asking to disable blob auditing of a database, later when fetching the policy, it is marked as disabled
#>
function Test-BlobAuditDisableDatabaseAudit
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"

		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when asking to disable auditing of a server, later when fetching the policy, it is marked as disabled
#>
function Test-BlobAuditDisableServerAudit
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId
		Set-AzSqlServerAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to set a policy to a database, and that database does not have a policy as well as the policy does not have a storage account  
#>
function Test-BlobAuditFailedDatabaseUpdatePolicyWithNoStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy -DatabaseName $params.databaseWithoutPolicy }
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to set a policy to a server, and that policy does not have a storage account  
#>
function Test-BlobAuditFailedServerUpdatePolicyWithNoStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing database with the cmdlets 
#>
function Test-BlobAuditFailWithBadDatabaseIndentity
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzSqlDatabaseAudit -ResourceGroupName "NONEXISTING-RG" -ServerName $params.serverName -DatabaseName $params.databaseName }
		Assert-Throws { Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER"-DatabaseName $params.databaseName }
		Assert-Throws { Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName "NONEXISTING-RG"  -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId}
		Assert-Throws { Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing server with the cmdlets 
#>
function Test-BlobAuditFailWithBadServerIndentity
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzSqlServerAudit -ResourceGroupName "NONEXISTING-RG" -ServerName $params.serverName }
		Assert-Throws { Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" }
		Assert-Throws { Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName "NONEXISTING-RG"  -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId}
		Assert-Throws { Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" -StorageAccountResourceId $params.storageAccountResourceId}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotation process for a policy of a Sql database server is managed properly
#>
function Test-BlobAuditServerStorageKeyRotation
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary"
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotation process for a policy of a Sql database is managed properly
#>
function Test-BlobAuditDatabaseStorageKeyRotation
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the retention values to a server auditing policy, this value is used on next policy set operations as default.
#>
function Test-BlobAuditServerRetentionKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 10;

		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 11;
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11

		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId;
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the retention values to a database auditing policy, this value is used on next policy set operations as default.
#>
function Test-BlobAuditDatabaseRetentionKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 10;
	
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 11;
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11

		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId;
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying properties of a databases's blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditOnDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$dbName = $params.databaseName

	try
	{
		# Test - Tests that when setting blob auditing policy on database without StorageKeyType parameter, it gets the default value - "Primary".
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 0
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
		
		# Test	
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary" -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -AuditAction "UPDATE ON database::[$($params.databaseName)] BY [public]"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}
		Assert-AreEqual $policy.AuditAction.Length 1
		Assert-AreEqual $policy.AuditAction "UPDATE ON database::[$($params.databaseName)] BY [public]"
		
		# Test
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Disabled"
		Assert-AreEqual $policy.AuditAction.Length 1
		
		# Test - Providing empty AuditActionGroups and an AuditAction
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -AuditActionGroup @() -AuditAction "UPDATE ON database::[$($params.databaseName)] BY [public]"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 0
		Assert-AreEqual $policy.AuditAction.Length 1
		Assert-AreEqual $policy.AuditAction[0] "UPDATE ON database::[$($params.databaseName)] BY [public]"
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying properties of a server's blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditOnServer
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test - Tests that when setting blob auditing policy on server without StorageKeyType parameter, it gets the default value - "Primary".
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-AreEqual $policy.StorageKeyType "Primary"

		# Test	
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary" -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-AreEqual $policy.StorageKeyType "Secondary"

		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the auditActionGroup property of a blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditWithAuditActionGroups
{
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test - when setting new blob auditing policy for database without audit action groups, the default audit action groups is set.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 3
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::BATCH_COMPLETED_GROUP)}

		# Test - when setting blob auditing policy for database with audit action groups, the default audit action groups is being replaced by the new audit action groups.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP","DATABASE_OBJECT_PERMISSION_CHANGE_GROUP"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::APPLICATION_ROLE_CHANGE_PASSWORD_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OBJECT_PERMISSION_CHANGE_GROUP)} 

		# Test - tests that audit action groups can be changed
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "DATABASE_OPERATION_GROUP","DATABASE_LOGOUT_GROUP"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when updating blob auditing policy for existing one without audit action groups, the action groups won't change.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when setting new blob auditing policy for server without audit action groups, the default audit action groups is set.
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 3
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::BATCH_COMPLETED_GROUP)}

		# Test
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP","DATABASE_OBJECT_PERMISSION_CHANGE_GROUP"
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::APPLICATION_ROLE_CHANGE_PASSWORD_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OBJECT_PERMISSION_CHANGE_GROUP)}

		# Test - tests that audit action groups can be changed
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "DATABASE_OPERATION_GROUP","DATABASE_LOGOUT_GROUP"
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when updating blob auditing policy for existing one without audit action groups, the action groups won't change.
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for extended auditing and auditing on a server
#>
function Test-ExtendedAuditOnServer
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Enable auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Enable Extended auditing policy, speficying a predicate expression, and verify it.
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression "statement <> 'select 1'"
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable auditing policy and verify it.
		Set-AzSqlServerAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Remove Extended auditing policy, and enable auditing policy
		Set-AzSqlServerAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression ""
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Disable auditing policy.
		Set-AzSqlServerAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
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
function Test-ExtendedAuditOnDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Enable auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Enable Extended auditing policy, speficying a predicate expression, and verify it.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression "statement <> 'select 1'"
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable auditing policy and verify it.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Remove Extended auditing policy, and enable auditing policy
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression ""
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Disable auditing policy.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for all auditing settings on a database
#>
function Test-AuditOnDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.workspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/" + $params.databaseName

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is Disabled.
		$policy = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-Null $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Enable event hub auditing policy and verify it
		Set-AzSqlDatabaseAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Enable log analytics auditing policy and verify it
		Set-AzSqlDatabaseAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable storage auditing policy and verify it.
		Set-AzSqlDatabaseAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable log analytics auditing policy and verify it
		Set-AzSqlDatabaseAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Disable event hub auditing policy and verify it
		Set-AzSqlDatabaseAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test removal of all auditing settings on a database
#>
function Test-RemoveAuditOnDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.workspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/" + $params.databaseName

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is Disabled.
		$policy = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-Null $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Set-AzSqlDatabaseAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Enable event hub auditing policy and verify it
		Set-AzSqlDatabaseAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Enable log analytics auditing policy and verify it
		Set-AzSqlDatabaseAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable auditing policy and verify it.
		Remove-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for all auditing settings on a server
#>
function Test-AuditOnServer
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.workspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/master"

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is disabled.
		$policy = Get-AzSqlServer -ResourceGroupName $params.rgname -ServerName $params.serverName | Get-AzSqlServerAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSqlServer -ResourceGroupName $params.rgname -ServerName $params.serverName | Set-AzSqlServerAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Enable event hub auditing policy and verify it
		Set-AzSqlServerAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Enable log analytics auditing policy and verify it
		Set-AzSqlServerAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable storage auditing policy and verify it.
		Set-AzSqlServerAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable log analytics auditing policy and verify it
		Set-AzSqlServerAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable event hub auditing policy and verify it
		Set-AzSqlServerAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
	}	
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test removal of all auditing settings on a server
#>
function Test-RemoveAuditOnServer
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.workspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/master"

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is disabled.
		$policy = Get-AzSqlServer -ResourceGroupName $params.rgname -ServerName $params.serverName | Get-AzSqlServerAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSqlServer -ResourceGroupName $params.rgname -ServerName $params.serverName | Set-AzSqlServerAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Enable event hub auditing policy and verify it
		Set-AzSqlServerAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Enable log analytics auditing policy and verify it
		Set-AzSqlServerAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual $params.storageAccountResourceId $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual 8 $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable audit policy and verify it.
		Remove-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}
<#
.SYNOPSIS
Tests that new diagnostic settings are created when needed while enabling or disabling policy.
#>
function Test-NewDatabaseAuditDiagnosticsAreCreatedOnNeed
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.workspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/" + $params.databaseName

	try
	{
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-Null $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Enable event hub auditing policy and verify it.
		Set-AzSqlDatabaseAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Verify only one diagnostic settings exists.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count

		# Enable a new category in existing Diagnostic Settings.
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		
		# Enable log analytics auditing policy and verify it
		Set-AzSqlDatabaseAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId

		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Remove old Diagnostics.
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		# Verify only one diagnostic settings exists.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count

		# Enable a new category in Diagnostic Settings.
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		
		# Verify log analytics auditing policy is enabled.
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Enable event hub auditing policy and verify it.
		Set-AzSqlDatabaseAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Remove old Diagnostics.
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		# Verify only one diagnostic settings exist.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count
		
		# Enable a new category in Diagnostic Settings
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		
		# Verify event hub auditing settings is enabled.
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId

		# Disable event hub auditing policy and verify it.
		Set-AzSqlDatabaseAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Remove old Diagnostics
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		# Verify only one diagnostic settings exist.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count

		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Enable event hub auditing policy and verify it.
		Set-AzSqlDatabaseAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Enable a new category in Diagnostic Settings.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		
		# Disable log analytics auditing policy and verify it
		Set-AzSqlDatabaseAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Remove old Diagnostics
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		# Verify log analytics auditing policy is Disabled.
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Disable event hub auditing policy and verify it.
		Set-AzSqlDatabaseAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAudit -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that new diagnostic settings are created when needed while enabling or disabling policy.
#>
function Test-NewServerAuditDiagnosticsAreCreatedOnNeed
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.workspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Sql/servers/" + $params.serverName + "/databases/master"

	try
	{
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Enable event hub auditing policy and verify it.
		Set-AzSqlServerAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Verify only one diagnostic settings exists.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count (($diagnostics).count + "1")

		# Enable a new category in existing Diagnostic Settings.
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights

		# Enable log analytics auditing policy and verify it
		Set-AzSqlServerAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId

		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count "2"
		
		# Remove old Diagnostics.
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		
		# Verify only one diagnostic settings exists.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count "3"
		
		# Enable a new category in Diagnostic Settings.
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		
		# Verify log analytics auditing policy is enabled.
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Enable event hub auditing policy and verify it.
		Set-AzSqlServerAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count "4"
		
		# Remove old Diagnostics.
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		
		# Verify only one diagnostic settings exist.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count "5"
		
		# Enable a new category in Diagnostic Settings
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		# Verify event hub auditing settings is enabled.
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Disable event hub auditing policy and verify it.
		Set-AzSqlServerAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count "6"
		
		# Remove old Diagnostics
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		# Verify only one diagnostic settings exist.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count "7"
		
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Enable event hub auditing policy and verify it.
		Set-AzSqlServerAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Enable a new category in Diagnostic Settings.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count "8"
		$settingsName = ($diagnostics)[0].Name
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SQLInsights
		
		# Disable log analytics auditing policy and verify it
		Set-AzSqlServerAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings were splitted.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count "9"
		
		# Remove old Diagnostics
		Remove-AzDiagnosticSetting -ResourceId $resourceId -Name $settingsName
		# Verify log analytics auditing policy is Disabled.
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Disable event hub auditing policy and verify it.
		Set-AzSqlServerAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAudit -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}