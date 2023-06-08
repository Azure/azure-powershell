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

function Test-ManagedDatabaseMove
{
	$sourceRg = Create-ResourceGroupForTest
	$targetRg = Create-ResourceGroupForTest
	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedDatabaseName = Get-ManagedDatabaseName
	$collation = "SQL_Latin1_General_CP1_CI_AS"

	try
	{
		$managedInstanceSourceJob = Create-ManagedInstanceForTestAsJob $sourceRg
		$managedInstanceTargetJob = Create-ManagedInstanceForTestAsJob $targetRg
		
		$managedInstanceSourceJob | Wait-Job
		$managedInstanceSource = $managedInstanceSourceJob.Output
		
		$managedInstanceTargetJob | Wait-Job
		$managedInstanceTarget = $managedInstanceTargetJob.Output

		$sourceRGName = $sourceRg.ResourceGroupName
		$targetRGName = $targetRg.ResourceGroupName
		$managedInstance = $managedInstanceSource.ManagedInstanceName
		
		New-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-Collation $collation
		
		# Wait for first backup
		Start-TestSleep -Seconds 300

		Move-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName

		$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-OnlyLatestPerDatabase

		Assert-NotNull $moveOperation
		Assert-AreEqual $moveOperation.TargetManagedInstanceName $managedInstanceTarget.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceManagedInstanceName $managedInstanceSource.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $moveOperation.OperationMode "Move"

		while ($moveOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
				-ResourceGroupName $sourceRGName `
				-InstanceName $managedInstanceSource.ManagedInstanceName `
				-Name $managedDatabaseName `
				-OnlyLatestPerDatabase
		}

		Stop-AzSqlInstanceDatabaseMove `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName

		Wait-ForOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Move-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName

		Wait-ForOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Complete-AzSqlInstanceDatabaseMove `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-Force
				
		Wait-ForOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Assert-Throws { 
			Get-AzSqlInstanceDatabase `
				-ResourceGroupName $sourceRGName `
				-InstanceName $managedInstanceSource.ManagedInstanceName `
				-Name $managedDatabaseName
		}

		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Remove-ResourceGroupForTest $sourceRg
			Remove-ResourceGroupForTest $targetRg
		} catch {
			# Ignore exception on clean up
		}
	}
}

function Test-ManagedDatabaseMovePiping
{
	$sourceRg = Create-ResourceGroupForTest
	$targetRg = Create-ResourceGroupForTest
	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedDatabaseName = Get-ManagedDatabaseName
	$collation = "SQL_Latin1_General_CP1_CI_AS"

	try
	{
		$managedInstanceSourceJob = Create-ManagedInstanceForTestAsJob $sourceRg
		$managedInstanceTargetJob = Create-ManagedInstanceForTestAsJob $targetRg
		
		$managedInstanceSourceJob | Wait-Job
		$managedInstanceSource = $managedInstanceSourceJob.Output
		
		$managedInstanceTargetJob | Wait-Job
		$managedInstanceTarget = $managedInstanceTargetJob.Output

		$sourceRGName = $sourceRg.ResourceGroupName
		$targetRGName = $targetRg.ResourceGroupName
		$managedInstance = $managedInstanceSource.ManagedInstanceName
		
		New-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-Collation $collation
		
		# Wait for first backup
		Start-TestSleep -Seconds 300

		$moveObject = Move-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-PassThru

		$moveOperation = $moveObject | Get-AzSqlInstanceDatabaseMoveOperation -OnlyLatestPerDatabase

		Assert-NotNull $moveOperation
		Assert-AreEqual $moveOperation.TargetManagedInstanceName $managedInstanceTarget.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceManagedInstanceName $managedInstanceSource.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $moveOperation.OperationMode "Move"

		while ($moveOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$moveOperation = $moveObject | Get-AzSqlInstanceDatabaseMoveOperation -OnlyLatestPerDatabase
		}

		$moveObject | Stop-AzSqlInstanceDatabaseMove

		Wait-ForOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$moveObject = Move-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-PassThru

		Wait-ForOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$moveObject = Complete-AzSqlInstanceDatabaseMove -Force
				
		Wait-ForOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Assert-Throws { 
			Get-AzSqlInstanceDatabase `
				-ResourceGroupName $sourceRGName `
				-InstanceName $managedInstanceSource.ManagedInstanceName `
				-Name $managedDatabaseName
		}

		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Remove-ResourceGroupForTest $sourceRg
			Remove-ResourceGroupForTest $targetRg
		} catch {
			# Ignore exception on clean up
		}
	}
}

function Wait-ForOperationToSucceed {
	param
	(
		$rgName,
		$instanceName,
		$databaseName
	)

	$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
		-ResourceGroupName $rgName `
		-InstanceName $instanceName `
		-Name $databaseName `
		-OnlyLatestPerDatabase

	while ($moveOperation.state -ne "Succeeded") {
		Start-TestSleep -Seconds 30

		$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
			-ResourceGroupName $rgName `
			-InstanceName $instanceName `
			-Name $databaseName `
			-OnlyLatestPerDatabase
	}
	return $moveOperation
}
