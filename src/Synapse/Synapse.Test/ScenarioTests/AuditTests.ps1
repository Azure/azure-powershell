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
Tests that when setting the storage account property's value in a SqlPool's blob auditing policy, that value is later fetched properly
#>
function Test-BlobAuditSqlPoolUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
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
Tests that when setting the storage account property's value in a workspace's blob auditing policy, that value is later fetched properly
#>
function Test-BlobAuditWorkspaceUpdatePolicyWithStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
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
Tests that when asking to disable blob auditing of a SqlPool, later when fetching the policy, it is marked as disabled
#>
function Test-BlobAuditDisableSqlPoolAudit
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"

		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
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
Tests that when asking to disable auditing of a Workspace, later when fetching the policy, it is marked as disabled
#>
function Test-BlobAuditDisableWorkspaceAudit
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId
		Set-AzSynapseSqlAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
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
Tests that after setting the storage account property's value in a SqlPool's auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-BlobAuditSqlPoolUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId
		$policyBefore = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName

		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policyAfter = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
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
Tests that after setting the storage account property's value in a Workspace's blob auditing policy, this value is used on next policy set operations as default. Meaning: if you don't want to change the 
storage account, you don't need to provide it.
#>
function Test-BlobAuditWorkspaceUpdatePolicyKeepPreviousStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId
		$policyBefore = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName

		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName 
		$policyAfter = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
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
Tests that it is impossible to use non existing SqlPool with the cmdlets 
#>
function Test-BlobAuditFailWithBadSqlPoolIndentity
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzSynapseSqlPoolAudit -ResourceGroupName "NONEXISTING-RG" -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName }
		Assert-Throws { Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName "NONEXISTING-Workspace"-SqlPoolName $params.sqlPoolName }
		Assert-Throws { Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName "NONEXISTING-RG"  -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId}
		Assert-Throws { Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName "NONEXISTING-Workspace" -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that it is impossible to use non existing Workspace with the cmdlets 
#>
function Test-BlobAuditFailWithBadWorkspaceIndentity
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Assert
		Assert-Throws { Get-AzSynapseSqlAudit -ResourceGroupName "NONEXISTING-RG" -WorkspaceName $params.workspaceName }
		Assert-Throws { Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName "NONEXISTING-Workspace" }
		Assert-Throws { Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName "NONEXISTING-RG"  -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId}
		Assert-Throws { Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName "NONEXISTING-Workspace" -StorageAccountResourceId $params.storageAccountResourceId}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that storage key rotation process for a policy of a SqlPool is managed properly
#>
function Test-BlobAuditSqlPoolStorageKeyRotation
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName  -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName  -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName  -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName  -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName  -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName  -SqlPoolName $params.sqlPoolName
	
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
Tests that storage key rotation process for a policy of a Sql SqlPool Workspace is managed properly
#>
function Test-BlobAuditWorkspaceStorageKeyRotation
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Primary"}

		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary"
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName 
	
		# Assert
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}

		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Primary"
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName 
	
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
Tests that after setting the retention values to a Workspace auditing policy, this value is used on next policy set operations as default.
#>
function Test-BlobAuditWorkspaceRetentionKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 10;

		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 11;
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11

		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId;
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName

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
Tests that after setting the retention values to a SqlPool auditing policy, this value is used on next policy set operations as default.
#>
function Test-BlobAuditSqlPoolRetentionKeepProperties
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 10;
	
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -RetentionInDays 11;
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName

		# Assert
		Assert-AreEqual $policy.RetentionInDays 11

		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId;
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName

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
Tests that when modifying properties of a SqlPools's blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditOnSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$dbName = $params.sqlPoolName

	try
	{
		# Test - Tests that when setting blob auditing policy on SqlPool without StorageKeyType parameter, it gets the default value - "Primary".
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.AuditAction.Length 0
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-True { $policy.StorageKeyType -eq  "Primary"}
		
		# Test	
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary" -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -AuditAction "UPDATE ON sqlpool::[$($params.sqlPoolName)] BY [public]"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-True { $policy.StorageKeyType -eq  "Secondary"}
		Assert-AreEqual $policy.AuditAction.Length 1
		Assert-AreEqual $policy.AuditAction "UPDATE ON sqlpool::[$($params.sqlPoolName)] BY [public]"
		
		# Test
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Disabled"
		Assert-AreEqual $policy.AuditAction.Length 1
		
		# Test - Providing empty AuditActionGroups and an AuditAction
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -AuditActionGroup @() -AuditAction "UPDATE ON sqlpool::[$($params.sqlPoolName)] BY [public]"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 0
		Assert-AreEqual $policy.AuditAction.Length 1
		Assert-AreEqual $policy.AuditAction[0] "UPDATE ON sqlpool::[$($params.sqlPoolName)] BY [public]"
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying properties of a Workspace's blob auditing policy, these properties are later fetched properly
#>
function Test-BlobAuditOnWorkspace
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Test - Tests that when setting blob auditing policy on Workspace without StorageKeyType parameter, it gets the default value - "Primary".
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-AreEqual $policy.StorageKeyType "Primary"

		# Test	
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -StorageKeyType "Secondary" -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
		# Assert
		Assert-AreEqual $policy.BlobStorageTargetState "Enabled"
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual $policy.RetentionInDays 8
		Assert-AreEqual $policy.StorageKeyType "Secondary"

		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
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
		# Test - when setting new blob auditing policy for SqlPool without audit action groups, the default audit action groups is set.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 3
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::BATCH_COMPLETED_GROUP)}

		# Test - when setting blob auditing policy for SqlPool with audit action groups, the default audit action groups is being replaced by the new audit action groups.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP","DATABASE_OBJECT_PERMISSION_CHANGE_GROUP"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::APPLICATION_ROLE_CHANGE_PASSWORD_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_OBJECT_PERMISSION_CHANGE_GROUP)} 

		# Test - tests that audit action groups can be changed
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "DATABASE_OPERATION_GROUP","DATABASE_LOGOUT_GROUP"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when updating blob auditing policy for existing one without audit action groups, the action groups won't change.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}DATABASE_OBJECT_CH

		# Test - when setting new blob auditing policy for Workspace without audit action groups, the default audit action groups is set.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 3
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::BATCH_COMPLETED_GROUP)}

		# Test
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP","DATABASE_OBJECT_PERMISSION_CHANGE_GROUP"
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::APPLICATION_ROLE_CHANGE_PASSWORD_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_OBJECT_PERMISSION_CHANGE_GROUP)}

		# Test - tests that audit action groups can be changed
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "DATABASE_OPERATION_GROUP","DATABASE_LOGOUT_GROUP"
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}

		# Test - when updating blob auditing policy for existing one without audit action groups, the action groups won't change.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	
		# Assert
		Assert-AreEqual $policy.AuditActionGroup.Length 2
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_OPERATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::DATABASE_LOGOUT_GROUP)}
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for extended auditing and auditing on a SqlPool
#>
function Test-ExtendedAuditOnSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Enable auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Enable Extended auditing policy, speficying a predicate expression, and verify it.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression "statement <> 'select 1'"
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable auditing policy and verify it.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName 
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Remove Extended auditing policy, and enable auditing policy
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression ""
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Disable auditing policy.
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName 
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for extended auditing and auditing on a Workspace
#>
function Test-ExtendedAuditOnWorkspace
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try
	{
		# Enable auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Enable Extended auditing policy, speficying a predicate expression, and verify it.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression "statement <> 'select 1'"
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Disable auditing policy and verify it.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState

		# Enable Extended auditing policy, without speficying a predicate expression, and verify it.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "statement <> 'select 1'" $policy.PredicateExpression

		# Remove Extended auditing policy, and enable auditing policy
		Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8 -PredicateExpression ""
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 8 $policy.RetentionInDays
		Assert-AreEqual "Primary" $policy.StorageKeyType
		Assert-AreEqual "" $policy.PredicateExpression

		# Disable auditing policy.
		Set-AzSynapseSqlAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Test for all auditing settings on a SqlPool
#>
function Test-AuditOnSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName + "/sqlPools/" + $params.sqlPoolName

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is Disabled.
		$policy = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlPoolAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
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
		Set-AzSynapseSqlPoolAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Disable event hub auditing policy and verify it
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
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
Test for all auditing settings on a Workspace
#>
function Test-AuditOnWorkspace
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is disabled.
		$policy = Get-AzSynapseWorkspace -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName | Get-AzSynapseSqlAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSynapseWorkspace -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName | Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlAudit -BlobStorageTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
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
		Set-AzSynapseSqlAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify Diagnostic Settings exist.
		Assert-AreEqual 1 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Disable event hub auditing policy and verify it
		Set-AzSynapseSqlAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify storage auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify log analytics auditing policy is disabled.
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
function Test-NewSqlPoolAuditDiagnosticsAreCreatedOnNeed
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName + "/sqlPools/" + $params.sqlPoolName

	try
	{
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Enable event hub auditing policy and verify it.
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SqlRequests
		
		# Enable log analytics auditing policy and verify it
		Set-AzSynapseSqlPoolAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SqlRequests
		
		# Verify log analytics auditing policy is enabled.
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SqlRequests
		
		# Verify event hub auditing settings is enabled.
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SqlRequests
		
		# Disable log analytics auditing policy and verify it
		Set-AzSynapseSqlPoolAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
function Test-NewWorkspaceAuditDiagnosticsAreCreatedOnNeed
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName

	try
	{
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Enable event hub auditing policy and verify it.
		Set-AzSynapseSqlAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category BuiltinSqlReqsEnded

		# Enable log analytics auditing policy and verify it
		Set-AzSynapseSqlAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category BuiltinSqlReqsEnded
		
		# Verify log analytics auditing policy is enabled.
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Enable event hub auditing policy and verify it.
		Set-AzSynapseSqlAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category BuiltinSqlReqsEnded
		# Verify event hub auditing settings is enabled.
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Disable event hub auditing policy and verify it.
		Set-AzSynapseSqlAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual $workspaceResourceId $policy.WorkspaceResourceId
		
		# Enable event hub auditing policy and verify it.
		Set-AzSynapseSqlAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category BuiltinSqlReqsEnded
		
		# Disable log analytics auditing policy and verify it
		Set-AzSynapseSqlAudit -LogAnalyticsTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-Null $policy.WorkspaceResourceId
		
		# Verify event hub auditing policy is enabled.
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual $eventHubAuthorizationRuleResourceId $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Disable event hub auditing policy and verify it.
		Set-AzSynapseSqlAudit -EventHubTargetState Disabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
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

<#
.SYNOPSIS
Test removal of all auditing settings on a Workspace
#>
function Test-RemoveAuditOnWorkspace
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is disabled.
		$policy = Get-AzSynapseWorkspace -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName | Get-AzSynapseSqlAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSynapseWorkspace -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName | Set-AzSynapseSqlAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Remove-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
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
Test removal of all auditing settings on a SqlPool
#>
function Test-RemoveAuditOnSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName + "/sqlPools/" + $params.sqlPoolName

	try
	{
		# Verify Diagnostic Settings do not exist.
		Assert-AreEqual 0 (Get-AzDiagnosticSetting -ResourceId $resourceId).count

		# Verify storage auditing policy is Disabled.
		$policy = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolAudit
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
		Assert-Null $policy.RetentionInDays
		
		# Verify event hub auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable storage auditing policy and verify it.
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Set-AzSynapseSqlPoolAudit -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId -AuditActionGroup "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", "FAILED_DATABASE_AUTHENTICATION_GROUP" -RetentionInDays 8
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Set-AzSynapseSqlPoolAudit -LogAnalyticsTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -WorkspaceResourceId $workspaceResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Enabled" $policy.LogAnalyticsTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
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
		Remove-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.BlobStorageTargetState
		Assert-AreEqual 2 $policy.AuditActionGroup.Length
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP)}
		Assert-True {$policy.AuditActionGroup.Contains([Microsoft.Azure.Commands.Synapse.Models.Auditing.AuditActionGroups]::FAILED_DATABASE_AUTHENTICATION_GROUP)}
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.StorageAccountResourceId
		Assert-AreEqual "None" $policy.StorageKeyType
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
Tests that auditing settings are removed when multiple diagnostic settings which enable audit category exist
#>
function Test-RemoveSqlPoolAuditingSettingsMultipleDiagnosticSettings
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName + "/sqlPools/" + $params.sqlPoolName

	try
	{
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace

		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId

		# Enable event hub auditing policy and verify it.
		Set-AzSynapseSqlPoolAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category SqlRequests
		
		# Create new Diagnostic Settings and enable auditing category
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Category SQLSecurityAuditEvents -WorkspaceId $workspaceResourceId

		# Verify Diagnostic Settings count.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Remove auditing settings.
		Remove-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSynapseSqlPoolAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual 0 $policy.AuditAction.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		 
		# Verify only one Diagnostic Settings was removed.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count
		
		# Verify audit category is disabled in remaining Diagnostic Settings.
		$foundAuditCategory = $False
		Foreach ($log in $diagnostics[0].Logs)
		{
			if ($log.Category -eq "SQLSecurityAuditEvents")
			{
				$foundAuditCategory = $True
				Assert-AreEqual $False $log.Enabled
				break
			}
		}
		
		Assert-AreEqual $True $foundAuditCategory
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that auditing settings are removed when multiple diagnostic settings which enable audit category exist
#>
function Test-RemoveWorkspaceAuditingSettingsMultipleDiagnosticSettings
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	$subscriptionId = (Get-AzContext).Subscription.Id
	$workspaceResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.operationalinsights/workspaces/" + $params.logworkspaceName
	$eventHubAuthorizationRuleResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $params.rgname + "/providers/microsoft.EventHub/namespaces/" + $params.eventHubNamespace + "/authorizationrules/RootManageSharedAccessKey"
	$resourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $params.rgname + "/providers/Microsoft.Synapse/workspaces/" + $params.workspaceName

	try
	{
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 0 $policy.AuditActionGroup.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		
		# Enable event hub auditing policy and verify it.
		Set-AzSynapseSqlAudit -EventHubTargetState Enabled -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -EventHubAuthorizationRuleResourceId $eventHubAuthorizationRuleResourceId -BlobStorageTargetState Enabled -StorageAccountResourceId $params.storageAccountResourceId
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Enabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
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
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Name $settingsName -Category IntegrationPipelineRuns
		
		# Create new Diagnostic Settings and enable auditing category
		Set-AzDiagnosticSetting -ResourceId $resourceId -Enabled $True -Category SQLSecurityAuditEvents -WorkspaceId $workspaceResourceId
		
		# Verify Diagnostic Settings count.
		Assert-AreEqual 2 (Get-AzDiagnosticSetting -ResourceId $resourceId).count
		
		# Remove auditing settings.
		Remove-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		
		# Verify event hub auditing policy is disabled.
		$policy = Get-AzSynapseSqlAudit -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
		Assert-AreEqual "Disabled" $policy.EventHubTargetState
		Assert-AreEqual 3 $policy.AuditActionGroup.Length
		Assert-AreEqual "" $policy.PredicateExpression
		Assert-Null $policy.EventHubAuthorizationRuleResourceId
		Assert-Null $policy.EventHubNamespace
		
		# Verify log analytics auditing policy is Disabled.
		Assert-AreEqual "Disabled" $policy.LogAnalyticsTargetState
		Assert-Null $policy.WorkspaceResourceId
		 
		# Verify only one Diagnostic Settings was removed.
		$diagnostics = Get-AzDiagnosticSetting -ResourceId $resourceId
		Assert-AreEqual 1 ($diagnostics).count
		
		# Verify audit category is disabled in remaining Diagnostic Settings.
		$foundAuditCategory = $False
		Foreach ($log in $diagnostics[0].Logs)
		{
			if ($log.Category -eq "SQLSecurityAuditEvents")
			{
				$foundAuditCategory = $True
				Assert-AreEqual $False $log.Enabled
				break
			}
		}
		
		Assert-AreEqual $True $foundAuditCategory
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}