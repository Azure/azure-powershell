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
Tests for getting restore points from SQL pools
#>
function Test-SqlPoolRestorePoint
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolBackupTestEnvironment $testSuffix
	$params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix

	try
	{
        # Get restore points
        $restorePoints = Get-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName

        # Create a new restore point
        $restorePointLabelToSet = 'ContosoRestorePoint'
        New-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName -RestorePointLabel $restorePointLabelToSet

        # Get restore points and compare with what we sent
        $restorePoints = Get-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName

        Assert-AreEqual 1 $restorePoints.Count
        Assert-AreEqual $restorePointLabelToSet $restorePoints[0].RestorePointLabel
        Assert-AreEqual 'DISCRETE' $restorePoints[0].RestorePointType
        Assert-Null $restorePoints[0].EarliestRestoreDate
        Assert-NotNull $restorePoints[0].RestorePointCreationDate

        # Remove restore point
        Remove-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName `
            -RestorePointCreationDate $restorePoints[0].RestorePointCreationDate -Force

        # Get restore points
        $restorePoints = Get-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName

        # Check the SQL pool doesn't have any restore point
        Assert-AreEqual 0 $restorePoints.Count

        # Remove the system restore point
        $restorePointCannotBeDeletedErrorMessage = "Cannot delete system restore point"
        Assert-ThrowsContains -script { Remove-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName `
            -RestorePointCreationDate $restorePoints[0].RestorePointCreationDate -Force } -message $restorePointCannotBeDeletedErrorMessage

        # piping scenario
        $pool = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName

        # Create a restore point
        $pool | New-AzSynapseSqlPoolRestorePoint -RestorePointLabel $restorePointLabelToSet

        # Get restore points and compare with what we sent
        $restorePoints = $pool | Get-AzSynapseSqlPoolRestorePoint
        Assert-AreEqual 1 $restorePoints.Count
        Assert-AreEqual $restorePointLabelToSet $restorePoints[0].RestorePointLabel
        Assert-AreEqual 'DISCRETE' $restorePoints[0].RestorePointType
        Assert-Null $restorePoints[0].EarliestRestoreDate
        Assert-NotNull $restorePoints[0].RestorePointCreationDate

        # Remove restore point
        $pool | Remove-AzSynapseSqlPoolRestorePoint -RestorePointCreationDate $restorePoints[0].RestorePointCreationDate -Force

        # Get restore points
        $restorePoints = $pool | Get-AzSynapseSqlPoolRestorePoint

        # Check the SQL pool only has one system restore point
        Assert-AreEqual 0 $restorePoints.Count

        # Create a restore point
        $pool | New-AzSynapseSqlPoolRestorePoint -RestorePointLabel $restorePointLabelToSet

        # Get restore points and compare with what we sent
        $restorePoints = $pool | Get-AzSynapseSqlPoolRestorePoint
        Assert-AreEqual 1 $restorePoints.Count
        Assert-AreEqual $restorePointLabelToSet $restorePoints[0].RestorePointLabel
        Assert-AreEqual 'DISCRETE' $restorePoints[0].RestorePointType
        Assert-Null $restorePoints[0].EarliestRestoreDate
        Assert-NotNull $restorePoints[0].RestorePointCreationDate

        $restorePoints[0] | Remove-AzSynapseSqlPoolRestorePoint -Force

        # Get restore points
        $restorePoints = $pool | Get-AzSynapseSqlPoolRestorePoint

        # Check the SQL pool only has one system restore point
        Assert-AreEqual 0 $restorePoints.Count
	}
	finally
	{
		# Cleanup
		Remove-SqlPoolBackupTestEnvironment $testSuffix
	}
}

function Test-SqlPoolGeoBackup
{
	# Setup
	$testSuffix = 'ps2502'
	$params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix

	try
	{	
	    $SqlPoolGeoBackupGet =Get-AzSynapseSqlPoolGeoBackup -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
        Assert-AreEqual $params.sqlPoolName $SqlPoolGeoBackupGet[0].Name
        Assert-Null $SqlPoolGeoBackupGet[0].ElasticPoolName
        Assert-NotNull $SqlPoolGeoBackupGet[0].Edition
        Assert-NotNull $SqlPoolGeoBackupGet[0].LastAvailableBackupDate

        $SqlPoolGeoBackupGetByPool =Get-AzSynapseSqlPoolGeoBackup -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName
        Assert-AreEqual $params.sqlPoolName $SqlPoolGeoBackupGetByPool.Name
        Assert-Null $SqlPoolGeoBackupGetByPool.ElasticPoolName
        Assert-NotNull $SqlPoolGeoBackupGetByPool.Edition
        Assert-NotNull $SqlPoolGeoBackupGetByPool.LastAvailableBackupDate
    }
	finally
	{
		# Cleanup
		Remove-SqlPoolBackupTestEnvironment $testSuffix
	}
}

function Test-DroppedSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolBackupTestEnvironment $testSuffix
    $params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix

	try
	{	
        Remove-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName -Force

        Wait-Seconds 300

	    $DroppedSqlPoolGet =Get-AzSynapseDroppedSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName
        Assert-AreEqual $params.sqlPoolName $DroppedSqlPoolGet[0].DatabaseName
        Assert-Null $DroppedSqlPoolGet[0].ElasticPoolName
        Assert-NotNull $DroppedSqlPoolGet[0].Edition
        Assert-NotNull $DroppedSqlPoolGet[0].MaxSizeBytes
        Assert-NotNull $DroppedSqlPoolGet[0].ServiceLevelObjective
        Assert-NotNull $DroppedSqlPoolGet[0].CreationDate
        Assert-NotNull $DroppedSqlPoolGet[0].DeletionDate
        Assert-NotNull $DroppedSqlPoolGet[0].EarliestRestoreDate
        
        $DroppedSqlPoolGetByPool= Get-AzSynapseDroppedSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName
        Assert-AreEqual $params.sqlPoolName $DroppedSqlPoolGetByPool[0].DatabaseName
        Assert-Null $DroppedSqlPoolGetByPool[0].ElasticPoolName
        Assert-NotNull $DroppedSqlPoolGetByPool[0].Edition
        Assert-NotNull $DroppedSqlPoolGetByPool[0].MaxSizeBytes
        Assert-NotNull $DroppedSqlPoolGetByPool[0].ServiceLevelObjective
        Assert-NotNull $DroppedSqlPoolGetByPool[0].CreationDate
        Assert-NotNull $DroppedSqlPoolGetByPool[0].DeletionDate
        Assert-NotNull $DroppedSqlPoolGetByPool[0].EarliestRestoreDate
    }
	finally
	{
		# Cleanup
		Remove-SqlPoolBackupTestEnvironment $testSuffix
	}
}
<#
.SYNOPSIS
Tests for restoring from restore point
#>
function Test-RestoreFromRestorePoint
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolBackupTestEnvironment $testSuffix
	$params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix

	try
	{
        # Create a new restore point
        $restorePointLabelToSet = 'ContosoRestorePoint'
        $restorePoint = New-AzSynapseSqlPoolRestorePoint -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName -RestorePointLabel $restorePointLabelToSet

        # Transform Synapse SQL pool resource ID to SQL database ID because 
        # currently the command only accepts the SQL databse ID
        $pool = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName
        $databaseId = $pool.Id -replace "Microsoft.Synapse", "Microsoft.Sql" `
            -replace "workspaces", "servers" `
            -replace "sqlPools", "databases"

        # Restore to same workspace with source SQL database
        $restoredPool = Restore-AzSynapseSqlPool -FromRestorePoint -RestorePoint $restorePoint.RestorePointCreationDate -TargetSqlPoolName $params.restoredSqlPoolName -ResourceGroupName $params.rgname `
            -WorkspaceName $params.workspaceName -ResourceId $databaseId -PerformanceLevel $params.perfLevel

        Assert-AreEqual $params.rgname $restoredPool.ResourceGroupName
        Assert-AreEqual $params.workspaceName $restoredPool.WorkspaceName
        Assert-AreEqual $params.restoredSqlPoolName $restoredPool.SqlPoolName
	}
	finally
	{
		# Cleanup
		Remove-SqlPoolBackupTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests for restoring from backup
#>
function Test-RestoreFromBackup
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolBackupTestEnvironment $testSuffix
	$params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix

	try
	{
        # Transform Synapse SQL pool resource ID to SQL database ID because 
        # currently the command only accepts the SQL databse ID
        $pool = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -Name $params.sqlPoolName
        $databaseId = $pool.Id -replace "Microsoft.Synapse", "Microsoft.Sql" `
            -replace "workspaces", "servers" `
            -replace "sqlPools", "databases"

        # Restore to same workspace with source SQL database
        $restoredPool = Restore-AzSynapseSqlPool -FromBackup -TargetSqlPoolName $params.restoredSqlPoolName -ResourceGroupName $params.rgname `
            -WorkspaceName $params.workspaceName -ResourceId $databaseId

        Assert-AreEqual $params.rgname $restoredPool.ResourceGroupName
        Assert-AreEqual $params.workspaceName $restoredPool.WorkspaceName
        Assert-AreEqual $params.restoredSqlPoolName $restoredPool.SqlPoolName
	}
	finally
	{
		# Cleanup
		Remove-SqlPoolBackupTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-SqlPoolBackupTestEnvironment ($testSuffix)
{
	$params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-SqlPoolBackupTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-bk-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "sqlbkws" +$testSuffix;
			  sqlPoolName = "sqlbkpool" + $testSuffix;
			  storageAccountName = "sqlbkstorage" + $testSuffix;
			  fileSystemName = "sqlbkcmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
			  perfLevel = 'DW200c';
              location = "northeurope";
              restoredSqlPoolName = "dwrestore" + $testSuffix;
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-SqlPoolBackupTestEnvironment ($testSuffix)
{
	$params = Get-SqlPoolBackupTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}