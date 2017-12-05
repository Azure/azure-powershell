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
Tests that when setting the storage account property's value in a database's auditing policy, that value is later fetched properly
#>
function Test-AuditingDatabaseUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled"  
		Assert-AreEqual $policy.UseServerDefault "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the flow in which re-setting the policy with storage account that has the same name as before, but it is now on a different region
#>
function Test-AuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled"  
		Assert-AreEqual $policy.UseServerDefault "Disabled"

		$newResourceGroupName =  "test-rg2-for-sql-cmdlets-" + $testSuffix
		New-AzureRmResourceGroup -Location "japanwest" -ResourceGroupName $newResourceGroupName
		New-AzureRmStorageAccount -StorageAccountName $params.storageAccount  -ResourceGroupName $newResourceGroupName -Location "West Europe" -Type Standard_GRS 

		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled"  
		Assert-AreEqual $policy.UseServerDefault "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AzureRmResourceGroup -Name $newResourceGroupName -Force
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when setting the storage account property's value in a server's auditing policy, that value is later fetched properly
#>
function Test-AuditingServerUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled" 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the storage account property's value in a database's auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-AuditingDatabaseUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policyBefore = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policyAfter = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policyBefore.StorageAccountName $policyAfter.StorageAccountName
		Assert-AreEqual $policyAfter.StorageAccountName $params.storageAccount 

	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the storage account property's value in a server's auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-AuditingServerUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policyBefore = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName

		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policyAfter = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policyBefore.StorageAccountName $policyAfter.StorageAccountName
		Assert-AreEqual $policyAfter.StorageAccountName $params.storageAccount 

	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the eventType property of a databases's auditing policy (including the All and None values), these properties are later fetched properly
#>
function Test-AuditingDatabaseUpdatePolicyWithEventTypes
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 10

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success","ParameterizedSQL_Success","ParameterizedSQL_Failure"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 3
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::PlainSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Failure)}

		# Test - when updating table auditing policy for existing one without event type, the audit event types won't change.
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 3
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::PlainSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Failure)}

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the eventType property of a server's auditing policy (including the All and None values), these properties are later fetched properly
#>
function Test-AuditingServerUpdatePolicyWithEventTypes
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 10

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success","ParameterizedSQL_Success","ParameterizedSQL_Failure"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 3
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::PlainSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Failure)}

	   # Test - when updating table auditing policy for existing one without event type, the audit event types won't change.
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 3
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::PlainSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Success)}
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Failure)}

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the modification of a database's auditing policy event types with the 'All' or 'None' shortcuts 
#>
function Test-AuditingDatabaseUpdatePolicyWithEventTypeShortcuts
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 10

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 10


		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All", "None"}
		Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None", "All"}
		Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success", "All"}
		Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success", "None"}
			
		#Test - If the event types includes new events and deprecated events we throw error
		Assert-Throws {Set-AzureRmSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success", "DataAccess"}

	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the modification of a server's auditing policy event types with the 'All' or 'None' shortcuts 
#>
function Test-AuditingServerUpdatePolicyWithEventTypeShortcuts
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 10

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 10


		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Assert-Throws {Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All", "None"}
		Assert-Throws {Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None", "All"}
		Assert-Throws {Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success", "All"}
		Assert-Throws {Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success", "None"}

		#Test - If the event types includes new events and deprecated events we throw error
		Assert-Throws {Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "PlainSQL_Success", "DataAccess"}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when asking to disable auditing of a database, later when fetching the policy, it is marked as disabled
#>
function Test-AuditingDisableDatabaseAuditing
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.UseServerDefault "Enabled"

		# Test
		Remove-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.UseServerDefault "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when asking to disable auditing of a server, later when fetching the policy, it is marked as disabled
#>
function Test-AuditingDisableServerAuditing
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Remove-AzureRmSqlServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when disabling an already existing auditing policy on a database and then re-enabling it, the properties of the policy are kept
#>
function Test-AuditingDatabaseDisableEnableKeepProperties
{
	# Setup
		$testSuffix = getAssetName
		Create-AuditingTestEnvironment $testSuffix
		$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "Login_Failure"
		Remove-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.UseServerDefault "Disabled"
		Assert-AreEqual $policy.EventType.Length 1
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::Login_Failure)}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when disabling an already existing auditing policy on a server and then re-enabling it, the properties of the policy are kept
#>
function Test-AuditingServerDisableEnableKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	
	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "TransactionManagement_Success"
		Remove-AzureRmSqlServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.EventType.Length 1
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::TransactionManagement_Success)}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after marking a database as using its server's policy, when fetching the database's policy, it is marked as using the server's policy  
#>
function Test-AuditingUseServerDefault
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.UseServerDefault "Enabled"
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to set a policy to a database, and that database does not have a policy as well as the policy does not have a storage account  
#>
function Test-AuditingFailedDatabaseUpdatePolicyWithNoStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy -DatabaseName $params.databaseWithoutPolicy }
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to set a policy to a server, and that policy does not have a storage account  
#>
function Test-AuditingFailedServerUpdatePolicyWithNoStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to make a database use its server's auditing policy when the server's policy does not have a storage account  
#>
function Test-AuditingFailedUseServerDefault
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy -DatabaseName $params.databaseWithoutPolicy }
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing database with the cmdlets 
#>
function Test-AuditingFailWithBadDatabaseIndentity
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName "NONEXISTING-RG" -ServerName $params.serverName -DatabaseName $params.databaseName }
		Assert-Throws { Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER"-DatabaseName $params.databaseName }
		Assert-Throws { Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName "NONEXISTING-RG"  -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount}
		Assert-Throws { Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing server with the cmdlets 
#>
function Test-AuditingFailWithBadServerIndentity
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName "NONEXISTING-RG" -ServerName $params.serverName }
		Assert-Throws { Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" }
		Assert-Throws { Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName "NONEXISTING-RG"  -ServerName $params.serverName -StorageAccountName $params.storageAccount}
		Assert-Throws { Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" -StorageAccountName $params.storageAccount}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotation process for a policy of a Sql database server is managed properly
#>
function Test-AuditingServerStorageKeyRotation
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Secondary"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotation process for a policy of a Sql database is managed properly
#>
function Test-AuditingDatabaseStorageKeyRotation
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Secondary"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when setting the retention values of server policy, that values is later fetched properly.
#>
function Test-AuditingServerUpdatePolicyWithRetention
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		$retentionTableIdentifier = "retentionTableIdentifier" + $testSuffix;
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -RetentionInDays 10 -TableIdentifier $retentionTableIdentifier;
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.RetentionInDays 10
		Assert-AreEqual $policy.TableIdentifier $retentionTableIdentifier 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when setting the retention values of database policy, that values is later fetched properly.
#>
function Test-AuditingDatabaseUpdatePolicyWithRetention
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		$retentionTableIdentifier = "retentionTableIdentifier" + $testSuffix;
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -RetentionInDays 10 -TableIdentifier $retentionTableIdentifier;
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.RetentionInDays 10
		Assert-AreEqual $policy.TableIdentifier $retentionTableIdentifier 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the retention values to a server auditing policy, this value is used on next policy set operations as default.
#>
function Test-AuditingServerRetentionKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		$retentionTableIdentifier = "retentionTableIdentifier" + $testSuffix;
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -RetentionInDays 10 -TableIdentifier $retentionTableIdentifier;

		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -RetentionInDays 11;
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11
		Assert-AreEqual $policy.TableIdentifier $retentionTableIdentifier 

		# Test
		$retentionTableIdentifier = "retentionTableIdentifier1" + $testSuffix;
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -TableIdentifier $retentionTableIdentifier;
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11
		Assert-AreEqual $policy.TableIdentifier $retentionTableIdentifier 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the retention values to a database auditing policy, this value is used on next policy set operations as default.
#>
function Test-AuditingDatabaseRetentionKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		$retentionTableIdentifier = "retentionTableIdentifier" + $testSuffix;
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -RetentionInDays 10 -TableIdentifier $retentionTableIdentifier;
	
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -RetentionInDays 11;
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11
		Assert-AreEqual $policy.TableIdentifier $retentionTableIdentifier 

		# Test
		$retentionTableIdentifier = "retentionTableIdentifier1" + $testSuffix;
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -TableIdentifier $retentionTableIdentifier;
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11
		Assert-AreEqual $policy.TableIdentifier $retentionTableIdentifier 
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying properties of a databases's blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditingOnDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	$dbName = $params.databaseName

	try
	{
		# Test - Tests that when setting blob auditing policy on database without StorageKeyType parameter, it gets the default value - "Primary".
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 0
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
		
		# Test	
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Secondary" -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -AuditAction "UPDATE ON database::[$($params.databaseName)] BY [public]"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}
		Assert-AreEqual $policy.AuditAction.Length 1
		Assert-AreEqual $policy.AuditAction "UPDATE ON database::[$($params.databaseName)] BY [public]"

		# Test
		Remove-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.AuditAction.Length 0
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying properties of a server's blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditingOnServer
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test - Tests that when setting blob auditing policy on server without StorageKeyType parameter, it gets the default value - "Primary".
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 0
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-AreEqual $policy.StorageKeyType "Primary"

		# Test	
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Secondary" -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 0
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-AreEqual $policy.StorageKeyType "Secondary"

		# Test
		Remove-AzureRmSqlServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.AuditAction.Length 0
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after migrating between database audit types the returned policy is of the migrated-to audit type
#>
function Test-DatatabaseAuditingTypeMigration
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	$dbName = $params.databaseName

	try
	{		
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType PlainSQL_Success
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 1
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::PlainSQL_Success)}

		# Test
		$selectAuditAction = "SELECT ON database::[$dbName] BY [public]"
		$UpdateAuditAction = "UPDATE ON database::[$dbName] BY [public]"
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup FAILED_DATABASE_AUTHENTICATION_GROUP -RetentionInDays 4 -AuditAction $selectAuditAction, $updateAuditAction
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Blob)
		Assert-AreEqual $policy.AuditActionGroup.Length 1
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 2
		Assert-AreEqual $policy.RetentionInDays 4

		 # Test - Tests that when updating blob auditing policy on database without AuditType parameter, the policy type isn't changed.
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "DATABASE_OPERATION_GROUP"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		#Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Blob)
		Assert-AreEqual $policy.AuditActionGroup.Length 1
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 2
		Assert-AreEqual $policy.RetentionInDays 4

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Table -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType ParameterizedSQL_Failure
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)
		Assert-AreEqual $policy.EventType.Length 1
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Failure)}

		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)

		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)

		# Test
		Remove-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.UseServerDefault "Disabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after migrating between server audit types the returned policy is of the migrated-to audit type
#>
function Test-ServerAuditingTypeMigration
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	$dbName = $params.databaseName

	try
	{		
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType PlainSQL_Success
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 1
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::PlainSQL_Success)}

		# Test
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup FAILED_DATABASE_AUTHENTICATION_GROUP -RetentionInDays 4
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Blob)
		Assert-AreEqual $policy.AuditActionGroup.Length 1
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 4

		#Test - Tests that when updating blob auditing policy on server without AuditType parameter, the policy type isn't changed.
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup DATABASE_OPERATION_GROUP
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName

		#Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Blob)
		Assert-AreEqual $policy.AuditActionGroup.Length 1
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 4

		# Test
		Set-AzureRmSqlServerAuditingPolicy -AuditType Table -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType ParameterizedSQL_Failure
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.EventType.Length 1
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)
		Assert-True {$policy.EventType.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditEventType]::ParameterizedSQL_Failure)}

		# Test
		Remove-AzureRmSqlServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.AuditType ([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditType]::Table)
		Assert-AreEqual $policy.AuditAction.Length 0
		Assert-AreEqual $policy.RetentionInDays 0
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that Get Server and Database Auditing on UK passes
#>
function Test-GetServerAndDatabaseAuditingInUkRegion
{
	# Setup
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix "UK South"

	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix 

	try
	{                              
		# Test
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
								
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.RetentionInDays 0
								
		# Test
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
								
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.RetentionInDays 0

	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the auditActionGroup property of a blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditingWithAuditActionGroups
{
	$testSuffix = getAssetName
	Create-AuditingTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test - when setting new blob auditing policy for database without audit action groups, the default audit action groups is set.
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 3
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::BATCH_COMPLETED_GROUP)}

		# Test - when setting blob auditing policy for database with audit action groups, the default audit action groups is being replaced by the new audit action groups.
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP","DATABASE_OBJECT_PERMISSION_CHANGE_GROUP"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::APPLICATION_ROLE_CHANGE_PASSWORD_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OBJECT_PERMISSION_CHANGE_GROUP)} 

		# Test - tests that audit action groups can be changed
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -AuditActionGroup "DATABASE_OPERATION_GROUP","DATABASE_LOGOUT_GROUP"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when updating blob auditing policy for existing one without audit action groups, the action groups won't change.
		Set-AzureRmSqlDatabaseAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when setting new blob auditing policy for server without audit action groups, the default audit action groups is set.
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 3
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::BATCH_COMPLETED_GROUP)}

		# Test
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP","DATABASE_OBJECT_PERMISSION_CHANGE_GROUP"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::APPLICATION_ROLE_CHANGE_PASSWORD_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OBJECT_PERMISSION_CHANGE_GROUP)}

		# Test - tests that audit action groups can be changed
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -AuditActionGroup "DATABASE_OPERATION_GROUP","DATABASE_LOGOUT_GROUP"
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when updating blob auditing policy for existing one without audit action groups, the action groups won't change.
		Set-AzureRmSqlServerAuditingPolicy -AuditType Blob -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}
	}
	finally
	{
		# Cleanup
		Remove-AuditingTestEnvironment $testSuffix
	}
}