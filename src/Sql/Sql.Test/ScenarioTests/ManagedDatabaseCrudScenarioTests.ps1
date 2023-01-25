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
	Tests creating a managed database
#>
function Test-CreateManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Create with all values
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		$job1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Collation $collation -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate

		# Create new by using ManagedInstance as input
		$managedDatabaseName = Get-ManagedDatabaseName
		$db = New-AzSqlInstanceDatabase -InstanceObject $managedInstance -Name $managedDatabaseName
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate

		# Create with default values via piping
		$managedDatabaseName = Get-ManagedDatabaseName
		$db = $managedInstance | New-AzSqlInstanceDatabase -Name $managedDatabaseName
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a managed database
#>
function Test-GetManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg
	
	# Create with default values
	$managedDatabaseName = Get-ManagedDatabaseName
	$db1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName
	Assert-AreEqual $db1.Name $managedDatabaseName

	$managedDatabaseName = Get-ManagedDatabaseName
	$db2 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName
	Assert-AreEqual $db2.Name $managedDatabaseName

	try
	{
		# Test Get using all parameters
		$gdb1 = Get-AzSqlInstanceDatabase -ResourceGroupName $managedInstance.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $db1.Name
		Assert-NotNull $gdb1
		Assert-AreEqual $db1.Name $gdb1.Name
		Assert-AreEqual $db1.Collation $gdb1.Collation

		# Test Get using ResourceGroupName and InstanceName
		$all = Get-AzSqlInstanceDatabase -ResourceGroupName $managedInstance.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name *
		Assert-NotNull $all
		Assert-AreEqual $all.Count 2

		# Test Get using ResourceId
		$gdb2 = Get-AzSqlInstanceDatabase -InstanceResourceId $managedInstance.Id -Name $db1.Name
		Assert-NotNull $gdb2
		Assert-AreEqual $db1.Name $gdb2.Name
		Assert-AreEqual $db1.Collation $gdb2.Collation

		# Test Get from piping
		$all = $managedInstance | Get-AzSqlInstanceDatabase
		Assert-AreEqual $all.Count 2
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Deleting a managed database
#>
function Test-RemoveManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg
	
	# Create with default values
	$managedDatabaseName = Get-ManagedDatabaseName
	$db1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName
	Assert-AreEqual $db1.Name $managedDatabaseName

	$managedDatabaseName = Get-ManagedDatabaseName
	$db2 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName
	Assert-AreEqual $db2.Name $managedDatabaseName

	$managedDatabaseName = Get-ManagedDatabaseName
	$db3 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName
	Assert-AreEqual $db3.Name $managedDatabaseName

	$managedDatabaseName = Get-ManagedDatabaseName
	$db4 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName
	Assert-AreEqual $db4.Name $managedDatabaseName

	$all = $managedInstance | Get-AzSqlInstanceDatabase
	Assert-AreEqual $all.Count 4

	try
	{
		# Test remove using all parameters
		Remove-AzSqlInstanceDatabase -ResourceGroupName $managedInstance.ResourceGroupname -InstanceName $managedInstance.ManagedInstanceName -Name $db1.Name -Force
		
		$all = $managedInstance | Get-AzSqlInstanceDatabase
		Assert-AreEqual $all.Count 3

		# Test remove using piping
		$db2 | Remove-AzSqlInstanceDatabase -Force

		$all = $managedInstance | Get-AzSqlInstanceDatabase
		Assert-AreEqual $all.Count 2

		# Test remove using input object
		Remove-AzSqlInstanceDatabase -InputObject $db3 -Force
		
		$all = $managedInstance | Get-AzSqlInstanceDatabase
		Assert-AreEqual $all.Count 1

		# Test remove using database resourceId
		Remove-AzSqlInstanceDatabase -ResourceId $db4.Id -Force
		
		$all = $managedInstance | Get-AzSqlInstanceDatabase
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests restoring a managed database
#>
function Test-RestoreManagedDatabase
{
	# Setup
	$sub = (Get-AzContext).Subscription.Id
	$rg = Create-ResourceGroupForTest
	$rg2 = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg
	$managedInstance2 = Create-ManagedInstanceForTest $rg2

	try
	{
		# Create with all values
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		$job1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Collation $collation -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName

		$targetManagedDatabaseName = Get-ManagedDatabaseName
		$pointInTime = (Get-date).AddMinutes(5)

		# Once database is created, backup service will automaticly take log backups every 5 minutes. We are waiting 450s to ensure backups are taken to which we can restore.
		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Wait-Seconds 450
		}

		# restore managed database to the same instance
		$restoredDb = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -PointInTime $pointInTime -TargetInstanceDatabaseName $targetManagedDatabaseName
		Assert-NotNull $restoredDb
		Assert-AreEqual $restoredDb.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $restoredDb.ManagedInstanceName $managedInstance.ManagedInstanceName

		# restore managed database to the another instance, different resource group and managed instance
		$restoredDb2 = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -SubscriptionId $sub -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -PointInTime $pointInTime -TargetInstanceDatabaseName $targetManagedDatabaseName -TargetInstanceName $managedInstance2.ManagedInstanceName -TargetResourceGroupName $rg2.ResourceGroupName
		Assert-NotNull $restoredDb2
		Assert-AreEqual $restoredDb2.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb2.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb2.ManagedInstanceName $managedInstance2.ManagedInstanceName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rg2
	}
}

<#
	.SYNOPSIS
	Tests restoring a managed database
#>
function Test-RestoreDeletedManagedDatabase
{
	# Setup
	$sub = (Get-AzContext).Subscription.Id
	$rg = Create-ResourceGroupForTest
	$rg2 = Create-ResourceGroupForTest
	
	Wait-Seconds 60
	try
	{
		$managedInstance = Create-ManagedInstanceForTest $rg
		$managedInstance2 = Create-ManagedInstanceForTest $rg2

		# Create with all values
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		$job1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Collation $collation -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName

		$targetManagedDatabaseName1 = Get-ManagedDatabaseName
		$targetManagedDatabaseName2 = Get-ManagedDatabaseName
		$targetManagedDatabaseName3 = Get-ManagedDatabaseName
		$targetManagedDatabaseName4 = Get-ManagedDatabaseName
		$targetManagedDatabaseName5 = Get-ManagedDatabaseName

		# Once database is created, backup service will automatically take log backups every 5 minutes. We are waiting 600s to ensure backups are taken to which we can restore.
		Wait-Seconds 600

		# Test remove using all parameters
		Remove-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Force
		
		# Wait to stabilaze
		Wait-Seconds 60

		# Get deleted database
		$deletedDatabases = Get-AzSqlDeletedInstanceDatabaseBackup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName 

		# restore managed database to the same instance
		$restoredDb1 = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -DeletionDate $deletedDatabases[0].DeletionDate -PointInTime $deletedDatabases[0].EarliestRestorePoint -TargetInstanceDatabaseName $targetManagedDatabaseName1
		Assert-NotNull $restoredDb1
		Assert-AreEqual $restoredDb1.Name $targetManagedDatabaseName1
		Assert-AreEqual $restoredDb1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $restoredDb1.ManagedInstanceName $managedInstance.ManagedInstanceName

		# restore managed database to the another instance, different resource group and managed instance
		$restoredDb2 = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -SubscriptionId $sub -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -DeletionDate $deletedDatabases[0].DeletionDate -PointInTime $deletedDatabases[0].EarliestRestorePoint -TargetInstanceDatabaseName $targetManagedDatabaseName2 -TargetInstanceName $managedInstance2.ManagedInstanceName -TargetResourceGroupName $rg2.ResourceGroupName
		Assert-NotNull $restoredDb2
		Assert-AreEqual $restoredDb2.Name $targetManagedDatabaseName2
		Assert-AreEqual $restoredDb2.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb2.ManagedInstanceName $managedInstance2.ManagedInstanceName

		# restore managed database to the same instance using InputObject
		$restoredDb3 = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -InputObject $deletedDatabases[0] -PointInTime $deletedDatabases[0].EarliestRestorePoint -TargetInstanceDatabaseName $targetManagedDatabaseName3
		Assert-NotNull $restoredDb3
		Assert-AreEqual $restoredDb3.Name $targetManagedDatabaseName3
		Assert-AreEqual $restoredDb3.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $restoredDb3.ManagedInstanceName $managedInstance.ManagedInstanceName

		# restore managed database to the same instance using ResourceId
		$restoredDb4 = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -ResourceId $deletedDatabases[0].Id -PointInTime $deletedDatabases[0].EarliestRestorePoint -TargetInstanceDatabaseName $targetManagedDatabaseName4
		Assert-NotNull $restoredDb4
		Assert-AreEqual $restoredDb4.Name $targetManagedDatabaseName4
		Assert-AreEqual $restoredDb4.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $restoredDb4.ManagedInstanceName $managedInstance.ManagedInstanceName.

		# restore managed database to the same instance using Piping
		$restoredDb5 = $deletedDatabases[0] | Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -PointInTime $deletedDatabases[0].EarliestRestorePoint -TargetInstanceDatabaseName $targetManagedDatabaseName5
		Assert-NotNull $restoredDb5
		Assert-AreEqual $restoredDb5.Name $targetManagedDatabaseName5
		Assert-AreEqual $restoredDb5.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $restoredDb5.ManagedInstanceName $managedInstance.ManagedInstanceName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rg2
	}
}

<#
.SYNOPSIS
	Tests Getting a managed database geo-redundant backups
#>
function Test-GetManagedDatabaseGeoBackup
{
	# Due to long creation of geo backups, use existing MI
	$default = Get-DefaultManagedInstanceParameters

	# Test Get using all parameters
	$gdb1 = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName $default.rg -InstanceName $default.defaultMI -Name $default.defaultMIDB
	Assert-NotNull $gdb1
	Assert-AreEqual $default.defaultMIDB $gdb1.Name

	# Test Get using ResourceGroupName and InstanceName
	$all = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName $default.rg -InstanceName $default.defaultMI -Name *

	Assert-NotNull $all
	if($all.Count -le 1)
	{
        throw "Should get more than 1 backup geo-redundant backups"
    }
}

<#
	.SYNOPSIS
	Tests geo-restoring a managed database
#>
function Test-GeoRestoreManagedDatabase
{
	# Due to long creation of geo backups, use existing MI
	$default = Get-DefaultManagedInstanceParameters

	$rg2 = Create-ResourceGroupForTest

	try
	{
		$managedInstance2 = Create-ManagedInstanceForTest $rg2
	
		$sourceDbGeoBackup = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName $default.rg -InstanceName $default.defaultMI -Name $default.defaultMIDB

		Assert-NotNull $sourceDbGeoBackup

		$targetManagedDatabaseName1 = Get-ManagedDatabaseName
		$targetManagedDatabaseName2 = Get-ManagedDatabaseName
		$targetManagedDatabaseName3 = Get-ManagedDatabaseName
		$targetManagedDatabaseName4 = Get-ManagedDatabaseName

		# geo-restore managed database using resourceID
		$restoredDb1 = Restore-AzSqlInstanceDatabase -FromGeoBackup `
			-ResourceId $sourceDbGeoBackup.RecoverableDatabaseId `
			-TargetInstanceDatabaseName $targetManagedDatabaseName1 `
			-TargetInstanceName $managedInstance2.ManagedInstanceName `
			-TargetResourceGroupName $rg2.ResourceGroupName

		Assert-NotNull $restoredDb1
		Assert-AreEqual $restoredDb1.Name $targetManagedDatabaseName1
		Assert-AreEqual $restoredDb1.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb1.ManagedInstanceName $managedInstance2.ManagedInstanceName

		# geo-restore managed database using name, instance and resource group name 
		$restoredDb2 = Restore-AzSqlInstanceDatabase -FromGeoBackup `
			-ResourceGroupName $default.rg `
			-InstanceName $default.defaultMI `
			-Name $default.defaultMIDB `
			-TargetInstanceDatabaseName $targetManagedDatabaseName2 `
			-TargetInstanceName $managedInstance2.ManagedInstanceName `
			-TargetResourceGroupName $rg2.ResourceGroupName

		Assert-NotNull $restoredDb2
		Assert-AreEqual $restoredDb2.Name $targetManagedDatabaseName2
		Assert-AreEqual $restoredDb2.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb2.ManagedInstanceName $managedInstance2.ManagedInstanceName
		
		# geo-restore managed database using GeoBackupObject
		$restoredDb3 = Restore-AzSqlInstanceDatabase -FromGeoBackup `
			-GeoBackupObject $sourceDbGeoBackup `
			-TargetInstanceDatabaseName $targetManagedDatabaseName3 `
			-TargetInstanceName $managedInstance2.ManagedInstanceName `
			-TargetResourceGroupName $rg2.ResourceGroupName

		Assert-NotNull $restoredDb3
		Assert-AreEqual $restoredDb3.Name $targetManagedDatabaseName3
		Assert-AreEqual $restoredDb3.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb3.ManagedInstanceName $managedInstance2.ManagedInstanceName

		# geo-restore managed database using piping
		$restoredDb4 = $sourceDbGeoBackup | Restore-AzSqlInstanceDatabase -FromGeoBackup -TargetInstanceDatabaseName $targetManagedDatabaseName4 -TargetInstanceName $managedInstance2.ManagedInstanceName -TargetResourceGroupName $rg2.ResourceGroupName
		Assert-NotNull $restoredDb4
		Assert-AreEqual $restoredDb4.Name $targetManagedDatabaseName4
		Assert-AreEqual $restoredDb4.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb4.ManagedInstanceName $managedInstance2.ManagedInstanceName	
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rg2
	}
}

<#
	.SYNOPSIS
	Tests creating a managed database
#>
function Test-SetManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$managedInstance = Create-ManagedInstanceForTest $rg
	
	try
	{
		# Create with all values
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		$job1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Collation $collation -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-Null $db.Tags

		$tags = @{tag1= "value1"}

		$db = Set-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Tags $tags
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag1")

		$tags = @{managedDatabaseTag= "valueInputObject"}
		# Set by using ManagedDatabase as input
		$db = Set-AzSqlInstanceDatabase -InputObject $db -Tags $tags
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("managedDatabaseTag")

		$tags = @{managedInstanceTag= "managedInstanceInputObject"}
		# Set by using ManagedInstance as input
		$db = Set-AzSqlInstanceDatabase -InstanceObject $managedInstance -Name $db.Name -Tags $tags
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("managedInstanceTag")
		
		# Set tags via piping
		$tags = @{piping= "valuePiping"}
		$db = $db | Set-AzSqlInstanceDatabase -Tags $tags
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("piping")

		# Set tags via resourceId
		$tags = @{resourceIdTag= "resourceIdTagValue"}
		$db = Set-AzSqlInstanceDatabase -ResourceId $db.Id -Tags $tags
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("resourceIdTag")

		# Expect exception when setting on db that doesn't exists
		Assert-Throws { Set-AzSqlInstanceDatabase -Name "nonexisting_db" -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Tags $tags }

	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests restoring a managed database
#>
function Test-CrossSubscriptionRestoreManagedDatabase
{

	try
	{
		# Setup
		$targetSub = (Get-AzContext).Subscription.Id
		$targetRg = Create-ResourceGroupForTest
		$targetManagedInstance = Create-ManagedInstanceForTest $targetRg
		$targetManagedDatabaseName = Get-ManagedDatabaseName

		# Wait for mi to stabilize
		Wait-Seconds 60

		# Creating managed instance on different subscription would take more then 6 hours, so using existing one for sake of testing.
		$sourceSub = "62e48210-5e43-423e-889b-c277f3e08c39"
		$sourceRg = "gen4-testing-RG"
		$soruceManagedInstance = "filiptanic-gen4-on-gen7-different-subnet"
		$sourceManagedDatabaseName = "cross-sub-restored"
		$sourceDbId = "/subscriptions/62e48210-5e43-423e-889b-c277f3e08c39/resourceGroups/gen4-testing-RG/providers/Microsoft.Sql/managedInstances/filiptanic-gen4-on-gen7-different-subnet/databases/cross-sub-restored"

		$pointInTime = (Get-date).AddMinutes(-10)

		# restore managed database from another instance in different subscription using all parameters
		$restoredDb = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup `
			-SubscriptionId $sourceSub `
			-ResourceGroupName $sourceRg `
			-InstanceName $soruceManagedInstance `
			-Name $sourceManagedDatabaseName `
			-PointInTime $pointInTime `
			-TargetInstanceDatabaseName $targetManagedDatabaseName `
			-TargetInstanceName $targetManagedInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRg.ResourceGroupName `
			-TargetSubscriptionId $targetSub
		Assert-NotNull $restoredDb
		Assert-AreEqual $restoredDb.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb.ResourceGroupName $targetRg.ResourceGroupName
		Assert-AreEqual $restoredDb.ManagedInstanceName $targetManagedInstance.ManagedInstanceName
		
		$targetManagedDatabaseName = Get-ManagedDatabaseName
		# restore managed database from another sub in different subscription using resourceid
		$restoredDb = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup `
			-ResourceId $sourceDbId `
			-PointInTime $pointInTime `
			-TargetInstanceDatabaseName $targetManagedDatabaseName `
			-TargetInstanceName $targetManagedInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRg.ResourceGroupName `
			-TargetSubscriptionId $targetSub
		Assert-NotNull $restoredDb
		Assert-AreEqual $restoredDb.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb.ResourceGroupName $targetRg.ResourceGroupName
		Assert-AreEqual $restoredDb.ManagedInstanceName $targetManagedInstance.ManagedInstanceName
	}
	finally
	{
		Remove-ResourceGroupForTest $targetRg
	}
}


<#
	.SYNOPSIS
	Tests restoring a managed database
#>
function Test-CrossSubscriptionRestoreDeletedManagedDatabase
{

	try
	{
		# Creating managed instance on different subscription would take more then 6 hours, so using existing one for sake of testing.
		$sourceSub = "62e48210-5e43-423e-889b-c277f3e08c39"
		$sourceRg = "gen4-testing-RG"
		$soruceManagedInstance = "filiptanic-gen4-on-gen7-different-subnet"
		$sourceManagedDatabaseName = "cross-sub-pipe-restored"

		#> $deletedDatabase = Get-AzSqlDeletedInstanceDatabaseBackup -ResourceGroupName "gen4-testing-RG" -InstanceName "filiptanic-gen4-on-gen7-different-subnet" -DatabaseName "cross-sub-pipe-restored"
		#> $deletedDatabase.DeletionDate
		# execute script above to get deletion date
		$deletionDate = "01/23/2023 14:46:01";

		$pointInTime = ([DateTime]$deletionDate).AddMinutes(-10)
		
		$targetSub = (Get-AzContext).Subscription.Id
		$targetRg = Create-ResourceGroupForTest
		$targetManagedInstance = Create-ManagedInstanceForTest $targetRg
		$targetManagedDatabaseName = Get-ManagedDatabaseName

		# Wait for mi to stabilize
		Wait-Seconds 60

		# restore managed database from another instance in different subscription using all parameters
		$restoredDb = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup `
			-SubscriptionId $sourceSub `
			-ResourceGroupName $sourceRg `
			-InstanceName $soruceManagedInstance `
			-Name $sourceManagedDatabaseName `
			-PointInTime $pointInTime `
			-DeletionDate $deletionDate `
			-TargetInstanceDatabaseName $targetManagedDatabaseName `
			-TargetInstanceName $targetManagedInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRg.ResourceGroupName `
			-TargetSubscriptionId $targetSub
		Assert-NotNull $restoredDb
		Assert-AreEqual $restoredDb.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb.ResourceGroupName $targetRg.ResourceGroupName
		Assert-AreEqual $restoredDb.ManagedInstanceName $targetManagedInstance.ManagedInstanceName
	}
	finally
	{
		Remove-ResourceGroupForTest $targetRg
	}
}
