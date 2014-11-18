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
function Test-DatabaseUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = 101
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True { $policy.IsEnabled } 
		Assert-False { $policy.UseServerDefault }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when setting the storage account property's value in a server's auditing policy, that value is later fetched properly
#>
function Test-ServerUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = 201
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True { $policy.IsEnabled } 
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the storage account property's value in a database's auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-DatabaseUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = 301
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policyBefore = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policyAfter = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policyBefore.StorageAccountName $policyAfter.StorageAccountName
		Assert-AreEqual $policyAfter.StorageAccountName $params.storageAccount 

	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after setting the storage account property's value in a server's auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-ServerUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = 401
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policyBefore = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName

		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policyAfter = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policyBefore.StorageAccountName $policyAfter.StorageAccountName
		Assert-AreEqual $policyAfter.StorageAccountName $params.storageAccount 

	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the eventType property of a databases's auditing policy (including the All and None values), these properties are later fetched properly
#>
function Test-DatabaseUpdatePolicyWithEventTypes
{
	# Setup
	$testSuffix = 501
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 5

		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "DataAccess","DataChanges","RevokePermissions"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 3
		Assert-True {$policy.EventType.Contains("DataAccess")}
		Assert-True {$policy.EventType.Contains("DataChanges")}
		Assert-True {$policy.EventType.Contains("RevokePermissions")}

		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the eventType property of a server's auditing policy (including the All and None values), these properties are later fetched properly
#>
function Test-ServerUpdatePolicyWithEventTypes
{
	# Setup
	$testSuffix = 601
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 5

		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "DataAccess","DataChanges","RevokePermissions"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 3
		Assert-True {$policy.EventType.Contains("DataAccess")}
		Assert-True {$policy.EventType.Contains("DataChanges")}
		Assert-True {$policy.EventType.Contains("RevokePermissions")}

		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the modification of a database's auting policy event types with the 'All' or 'None' shortcuts 
#>
function Test-DatabaseUpdatePolicyWithEventTypeShortcuts
{
	# Setup
	$testSuffix = 701
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 5

		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All", "All"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 5


		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None", "None"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Assert-Throws {Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "All", "None"}
		Assert-Throws {Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "None", "All"}
		Assert-Throws {Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "DataChanges", "All"}
		Assert-Throws {Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "DataChanges", "None"}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the modification of a server's auditing policy event types with the 'All' or 'None' shortcuts 
#>
function Test-ServerUpdatePolicyWithEventTypeShortcuts
{
	# Setup
	$testSuffix = 801
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 5

		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All", "All"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 5


		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None", "None"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-AreEqual $policy.EventType.Length 0 

		# Test
		Assert-Throws {Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "All", "None"}
		Assert-Throws {Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "None", "All"}
		Assert-Throws {Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "DataChanges", "All"}
		Assert-Throws {Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "DataChanges", "None"}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when asking to disable auditing of a database, later when fetching the policy, it is marked as disabled
#>
function Test-DisableDatabaseAuditing
{
	# Setup
	$testSuffix = 901
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		Remove-AzureSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-False { $policy.IsEnabled }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when asking to disable auditing of a server, later when fetching the policy, it is marked as disabled
#>
function Test-DisableServerAuditing
{
	# Setup
	$testSuffix = 111
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Remove-AzureSqlDatabaseServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-False { $policy.IsEnabled }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when disabling an already existing auditing policy on a database and then re-enabling it, the properties of the policy are kept
#>
function Test-DatabaseDisableEnableKeepProperties
{
	# Setup
	$testSuffix = 121
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EventType "SecurityExceptions"
		Remove-AzureSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True { $policy.IsEnabled } 
		Assert-False { $policy.UseServerDefault }
		Assert-AreEqual $policy.EventType.Length 1
		Assert-True {$policy.EventType.Contains("SecurityExceptions")}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when disabling an already existing auditing policy on a server and then re-enabling it, the properties of the policy are kept
#>
function Test-ServerDisableEnableKeepProperties
{
	# Setup
	$testSuffix = 131
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	
	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -EventType "RevokePermissions"
		Remove-AzureSqlDatabaseServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True { $policy.IsEnabled } 
		Assert-False { $policy.UseServerDefault }
		Assert-AreEqual $policy.EventType.Length 1
		Assert-True {$policy.EventType.Contains("RevokePermissions")}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that after marking a database as using its server's policy, when fetching the database's policy, it is marked as using the server's policy  
#>
function Test-UseServerDefault
{
    # Setup
	$testSuffix = 141
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Use-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-True {$policy.UseServerDefault}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to set a policy to a database, and that database does not have a polic as well as the policy does not have a storage account  
#>
function Test-FailedDatabaseUpdatePolicyWithNoStorage
{
	# Setup
	$testSuffix = 151
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy -DatabaseName $params.databaseWithoutPolicy }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to set a policy to a server, and that policy does not have a storage account  
#>
function Test-FailedServerUpdatePolicyWithNoStorage
{
	# Setup
	$testSuffix = 161
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that a failure occurs when trying to make a database use its server's auditing policy when the server's policy does not have a storage account  
#>
function Test-FailedUseServerDefault
{
	# Setup
	$testSuffix = 171
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Assert
		Assert-Throws { Use-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverWithoutPolicy -DatabaseName $params.databaseWithoutPolicy }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing database with the cmdlets 
#>
function Test-FailWithBadDatabaseIndentity
{
	# Setup
	$testSuffix = 181
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName "NONEXISTING-RG" -ServerName $params.serverName -DatabaseName $params.databaseName }
		Assert-Throws { Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER"-DatabaseName $params.databaseName }
		Assert-Throws { Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName "NONEXISTING-RG"  -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount}
		Assert-Throws { Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing server with the cmdlets 
#>
function Test-FailWithBadServerIndentity
{
	# Setup
	$testSuffix = 191
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName "NONEXISTING-RG" -ServerName $params.serverName }
		Assert-Throws { Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" }
		Assert-Throws { Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName "NONEXISTING-RG"  -ServerName $params.serverName -StorageAccountName $params.storageAccount}
		Assert-Throws { Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName "NONEXISTING-SERVER" -StorageAccountName $params.storageAccount}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that the direct access property is getting updated correctly for a sql database
#>
function Test-DatabaseDirectAccess
{
	# Setup
	$testSuffix = 551
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount 
		Enable-AzureSqlDatabaseDirectAccess -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.DirectAccessEnabled }

		# Test
		Disable-AzureSqlDatabaseDirectAccess -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-False { $policy.DirectAccessEnabled }

		# Test
		Enable-AzureSqlDatabaseDirectAccess -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.DirectAccessEnabled }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that the direct access property is getting updated correctly for a sql database server
#>
function Test-ServerDirectAccess
{
	# Setup
	$testSuffix = 650
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Enable-AzureSqlDatabaseServerDirectAccess -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.DirectAccessEnabled }

		# Test
		Disable-AzureSqlDatabaseServerDirectAccess -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-False { $policy.DirectAccessEnabled }

		# Test
		Enable-AzureSqlDatabaseServerDirectAccess -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.DirectAccessEnabled }
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotatation process for a policy of a Sql database server is managed properly
#>
function Test-ServerStorageKeyRotation
{
	# Setup
	$testSuffix = 680
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Secondary"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureSqlDatabaseServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotatation process for a policy of a Sql database is managed properly
#>
function Test-DatabaseStorageKeyRotation
{
	# Setup
	$testSuffix = 680
	Create-TestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Secondary"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -StorageKeyType "Primary"
		$policy = Get-AzureSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
	}
	finally
	{
		# Cleanup
		Remove-TestEnvironment $testSuffix
	}
}
