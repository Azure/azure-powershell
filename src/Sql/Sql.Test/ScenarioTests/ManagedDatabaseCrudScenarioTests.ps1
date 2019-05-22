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
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

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
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId
	
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
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId
	
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
	$rg = Create-ResourceGroupForTest
	$rg2 = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId
	$managedInstance2 = Create-ManagedInstanceForTest $rg2 $subnetId

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

		# Wait for 450 seconds for restore to be ready
		Wait-Seconds 450

		# restore managed database to the same instance
		$restoredDb = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -PointInTime $pointInTime -TargetInstanceDatabaseName $targetManagedDatabaseName
		Assert-NotNull $restoredDb
		Assert-AreEqual $restoredDb.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $restoredDb.ManagedInstanceName $managedInstance.ManagedInstanceName

		# restore managed database to the another instance, different resource group and managed instance
		$restoredDb2 = Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -PointInTime $pointInTime -TargetInstanceDatabaseName $targetManagedDatabaseName -TargetInstanceName $managedInstance2.ManagedInstanceName -TargetResourceGroupName $rg2.ResourceGroupName
		Assert-NotNull $restoredDb2
		Assert-AreEqual $restoredDb2.Name $targetManagedDatabaseName
		Assert-AreEqual $restoredDb2.ResourceGroupName $rg2.ResourceGroupName
		Assert-AreEqual $restoredDb2.ManagedInstanceName $managedInstance2.ManagedInstanceName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
	Tests Getting a managed database geo-redundant backups
#>
function Test-GetManagedDatabaseGeoBackup
{
	# Setup
	$rgName = "restore-rg"	
	$managedInstanceName = "testbrinstance"
	$managedDatabaseName = "sourcedb"

	# Test Get using all parameters
	$gdb1 = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $managedDatabaseName
	Assert-NotNull $gdb1
	Assert-AreEqual $managedDatabaseName $gdb1.Name

	# Test Get using ResourceGroupName and InstanceName
	$all = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name *

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
	# Setup
    $rgName = "restore-rg"	
	$managedInstanceName = "testbrinstance"
	$managedDatabaseName = "sourcedb"

	$targetRgName = "restore-rg"
	$targetInstanceName = "testbrinstance"
	try
	{
		$sourceDbGeoBackup = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $managedDatabaseName

		Assert-NotNull $sourceDbGeoBackup

	   $targetManagedDatabaseName1 = Get-ManagedDatabaseName		
		$targetManagedDatabaseName2 = Get-ManagedDatabaseName
		$targetManagedDatabaseName3 = Get-ManagedDatabaseName
		$targetManagedDatabaseName4 = Get-ManagedDatabaseName

		# geo-restore managed database using resourceID
		$restoredDb1 = Restore-AzSqlInstanceDatabase -FromGeoBackup -ResourceId $sourceDbGeoBackup.RecoverableDatabaseId -TargetInstanceDatabaseName $targetManagedDatabaseName1 -TargetInstanceName $targetInstanceName -TargetResourceGroupName $targetRgName
		Assert-NotNull $restoredDb1
		Assert-AreEqual $restoredDb1.Name $targetManagedDatabaseName1
		Assert-AreEqual $restoredDb1.ResourceGroupName $targetRgName
		Assert-AreEqual $restoredDb1.ManagedInstanceName $targetInstanceName

		# geo-restore managed database using name, instance and resource group name 
		$restoredDb2 = Restore-AzSqlInstanceDatabase -FromGeoBackup -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $managedDatabaseName -TargetInstanceDatabaseName $targetManagedDatabaseName2 -TargetInstanceName $targetInstanceName -TargetResourceGroupName $targetRgName
		Assert-NotNull $restoredDb2
		Assert-AreEqual $restoredDb2.Name $targetManagedDatabaseName2
		Assert-AreEqual $restoredDb2.ResourceGroupName $targetRgName
		Assert-AreEqual $restoredDb2.ManagedInstanceName $targetInstanceName
		
		# geo-restore managed database using GeoBackupObject
		$restoredDb3 = Restore-AzSqlInstanceDatabase -FromGeoBackup -GeoBackupObject $sourceDbGeoBackup -TargetInstanceDatabaseName $targetManagedDatabaseName3 -TargetInstanceName $targetInstanceName -TargetResourceGroupName $targetRgName
		Assert-NotNull $restoredDb3
		Assert-AreEqual $restoredDb3.Name $targetManagedDatabaseName3
		Assert-AreEqual $restoredDb3.ResourceGroupName $targetRgName
		Assert-AreEqual $restoredDb3.ManagedInstanceName $targetInstanceName

		# geo-restore managed database using piping
		$restoredDb4 = $sourceDbGeoBackup | Restore-AzSqlInstanceDatabase -FromGeoBackup -TargetInstanceDatabaseName $targetManagedDatabaseName4 -TargetInstanceName $targetInstanceName -TargetResourceGroupName $targetRgName
		Assert-NotNull $restoredDb4
		Assert-AreEqual $restoredDb4.Name $targetManagedDatabaseName4
		Assert-AreEqual $restoredDb4.ResourceGroupName $targetRgName
	   Assert-AreEqual $restoredDb4.ManagedInstanceName $targetInstanceName	

	}
	finally
	{
     	$restoredDb1 | Remove-AzSqlInstanceDatabase -Force
		$restoredDb2 | Remove-AzSqlInstanceDatabase -Force
		$restoredDb3 | Remove-AzSqlInstanceDatabase -Force
		$restoredDb4 | Remove-AzSqlInstanceDatabase -Force
	}
}