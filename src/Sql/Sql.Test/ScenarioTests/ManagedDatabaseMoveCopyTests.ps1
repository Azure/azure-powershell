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
		Start-TestSleep -Seconds 60

		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Clear-LiveTestResources $sourceRGName
			Clear-LiveTestResources $targetRGName
		} catch {
			# Ignore exception on clean up
		}
	}
}

function Test-CrossSubscriptionManagedDatabaseMove
{
	try
	{
		$sourceRG = Create-ResourceGroupForTest -location "westeurope"
		$sourceInstance = Create-ManagedInstanceForTest -resourceGroup $sourceRG -isV3 $true
		$targetRG = Create-ResourceGroupForTest -location "westeurope"
		$targetInstance = Create-ManagedInstanceForTest -resourceGroup $targetRG -isV3 $true
		$managedDatabaseName = "managedDb01"

		New-AzSqlInstanceDatabase -ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName

		Move-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName

		$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-OnlyLatestPerDatabase

		Assert-NotNull $moveOperation
		Assert-AreEqual $moveOperation.TargetManagedInstanceName $targetInstance.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceManagedInstanceName $sourceInstance.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $moveOperation.OperationMode "Move"

		while ($moveOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
				-ResourceGroupName $sourceRG.ResourceGroupName `
				-InstanceName $sourceInstance.ManagedInstanceName `
				-Name $managedDatabaseName `
				-OnlyLatestPerDatabase
		}

		Stop-AzSqlInstanceDatabaseMove `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName

		Wait-ForOperationToSucceed `
			-rgName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Move-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName

		Wait-ForOperationToSucceed `
			-rgName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Complete-AzSqlInstanceDatabaseMove `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName `
			-Force
				
		Wait-ForOperationToSucceed `
			-rgName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Assert-Throws { 
			Get-AzSqlInstanceDatabase `
				-ResourceGroupName $sourceRG.ResourceGroupName `
				-InstanceName $sourceInstance.ManagedInstanceName `
				-Name $managedDatabaseName
		}
	}
	finally
	{
		Remove-AzSqlInstance -ResourceGroupName $sourceRG.ResourceGroupName -Name $sourceInstance.ManagedInstanceName -Force
		Remove-AzSqlInstance -ResourceGroupName $targetRG.ResourceGroupName -Name $targetInstance.ManagedInstanceName -Force
		Remove-ResourceGroupForTest $sourceRG
		Remove-ResourceGroupForTest $targetRG
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

		$moveObject | Complete-AzSqlInstanceDatabaseMove -Force
				
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
		
		Start-TestSleep -Seconds 60

		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Clear-LiveTestResources $sourceRGName
			Clear-LiveTestResources $targetRGName
		} catch {
			# Ignore exception on clean up
		}
	}
}

function Test-ManagedDatabaseMoveUsingOperationObject
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

		$moveOperation | Stop-AzSqlInstanceDatabaseMove

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

		$moveOperation = $moveObject | Get-AzSqlInstanceDatabaseMoveOperation -OnlyLatestPerDatabase
		$moveOperation | Complete-AzSqlInstanceDatabaseMove -Force
				
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

		Start-TestSleep -Seconds 60

		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Clear-LiveTestResources $sourceRGName
			Clear-LiveTestResources $targetRGName
		} catch {
			# Ignore exception on clean up
		}
	}
}

### COPY TESTS ###
##################

function Test-ManagedDatabaseCopy
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

		Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName

		$CopyOperation = Get-AzSqlInstanceDatabaseCopyOperation `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-OnlyLatestPerDatabase

		Assert-NotNull $CopyOperation
		Assert-AreEqual $CopyOperation.TargetManagedInstanceName $managedInstanceTarget.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceManagedInstanceName $managedInstanceSource.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $CopyOperation.OperationMode "Copy"

		while ($CopyOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$CopyOperation = Get-AzSqlInstanceDatabaseCopyOperation `
				-ResourceGroupName $sourceRGName `
				-InstanceName $managedInstanceSource.ManagedInstanceName `
				-Name $managedDatabaseName `
				-OnlyLatestPerDatabase
		}

		Stop-AzSqlInstanceDatabaseCopy `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Complete-AzSqlInstanceDatabaseCopy `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName
				
		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$dbOnSource = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName

		Start-TestSleep -Seconds 60
		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnSource
		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Clear-LiveTestResources $sourceRGName
			Clear-LiveTestResources $targetRGName
		} catch {
			# Ignore exception on clean up
		}
	}
}

function Test-CrossSubscriptionManagedDatabaseCopy
{
	try
	{
		$sourceRG = Create-ResourceGroupForTest -location "westeurope"
		$sourceInstance = Create-ManagedInstanceForTest -resourceGroup $sourceRG -isV3 $true
		$targetRG = Create-ResourceGroupForTest -location "westeurope"
		$targetInstance = Create-ManagedInstanceForTest -resourceGroup $targetRG -isV3 $true
		$managedDatabaseName = "managedDb01"

		New-AzSqlInstanceDatabase -ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName

		Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName

		$CopyOperation = Get-AzSqlInstanceDatabaseCopyOperation `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-OnlyLatestPerDatabase

		Assert-NotNull $CopyOperation
		Assert-AreEqual $CopyOperation.TargetManagedInstanceName $targetInstance.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceManagedInstanceName $sourceInstance.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $CopyOperation.OperationMode "Copy"

		while ($CopyOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$CopyOperation = Get-AzSqlInstanceDatabaseCopyOperation `
				-ResourceGroupName $sourceRG.ResourceGroupName `
				-InstanceName $sourceInstance.ManagedInstanceName `
				-Name $managedDatabaseName `
				-OnlyLatestPerDatabase
		}

		Stop-AzSqlInstanceDatabaseCopy `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRG.ResourceGroupName `
			-instanceName $sourceInstance.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRG.ResourceGroupName `
			-instanceName $sourceInstance.ManagedInstanceName `
			-databaseName $managedDatabaseName

		Complete-AzSqlInstanceDatabaseCopy `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $targetInstance.ManagedInstanceName `
			-TargetResourceGroupName $targetRG.ResourceGroupName
				
		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRG.ResourceGroupName `
			-instanceName $sourceInstance.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$dbOnSource = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRG.ResourceGroupName `
			-InstanceName $sourceInstance.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnSource

	}
	finally
	{
		Remove-AzSqlInstance -ResourceGroupName $sourceRG.ResourceGroupName -Name $sourceInstance.ManagedInstanceName -Force
		Remove-AzSqlInstance -ResourceGroupName $targetRG.ResourceGroupName -Name $targetInstance.ManagedInstanceName -Force
		Remove-ResourceGroupForTest $sourceRG
		Remove-ResourceGroupForTest $targetRG

	}
}

function Test-ManagedDatabaseCopyPiping
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

		$CopyObject = Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-PassThru

		$CopyOperation = $CopyObject | Get-AzSqlInstanceDatabaseCopyOperation -OnlyLatestPerDatabase

		Assert-NotNull $CopyOperation
		Assert-AreEqual $CopyOperation.TargetManagedInstanceName $managedInstanceTarget.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceManagedInstanceName $managedInstanceSource.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $CopyOperation.OperationMode "Copy"

		while ($CopyOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$CopyOperation = $CopyObject | Get-AzSqlInstanceDatabaseCopyOperation -OnlyLatestPerDatabase
		}

		$CopyObject | Stop-AzSqlInstanceDatabaseCopy

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$CopyObject = Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-PassThru

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$CopyObject | Complete-AzSqlInstanceDatabaseCopy
				
		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$dbOnSource = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName

		Start-TestSleep -Seconds 60
		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnSource
		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Clear-LiveTestResources $sourceRGName
			Clear-LiveTestResources $targetRGName
		} catch {
			# Ignore exception on clean up
		}
	}
}

function Test-ManagedDatabaseCopyUsingOperationObject
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

		$CopyObject = Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-PassThru

		$CopyOperation = $CopyObject | Get-AzSqlInstanceDatabaseCopyOperation -OnlyLatestPerDatabase

		Assert-NotNull $CopyOperation
		Assert-AreEqual $CopyOperation.TargetManagedInstanceName $managedInstanceTarget.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceManagedInstanceName $managedInstanceSource.ManagedInstanceName
		Assert-AreEqual $CopyOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $CopyOperation.OperationMode "Copy"

		while ($CopyOperation.isCancellable -eq $false) {
			Start-TestSleep -Seconds 30

			$CopyOperation = $CopyObject | Get-AzSqlInstanceDatabaseCopyOperation -OnlyLatestPerDatabase
		}

		$CopyOperation | Stop-AzSqlInstanceDatabaseCopy

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$CopyObject = Copy-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName `
			-TargetResourceGroupName $targetRGName `
			-PassThru

		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName
		
		$CopyOperation = $CopyObject | Get-AzSqlInstanceDatabaseCopyOperation -OnlyLatestPerDatabase
		$CopyOperation | Complete-AzSqlInstanceDatabaseCopy
				
		Wait-ForCopyOperationToSucceed `
			-rgName $sourceRGName `
			-instanceName $managedInstanceSource.ManagedInstanceName `
			-databaseName $managedDatabaseName

		$dbOnSource = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $sourceRGName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName

		Start-TestSleep -Seconds 60
		$dbOnTheTarget = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $targetRGName `
			-InstanceName $managedInstanceTarget.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $dbOnSource
		Assert-NotNull $dbOnTheTarget
	}
	finally
	{
		try {
			Clear-LiveTestResources $sourceRGName
			Clear-LiveTestResources $targetRGName
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

	while ($moveOperation.state -ne "Succeeded" -and $moveOperation.state -ne "Cancelled") {
		Start-TestSleep -Seconds 30

		$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
			-ResourceGroupName $rgName `
			-InstanceName $instanceName `
			-Name $databaseName `
			-OnlyLatestPerDatabase
	}
	return $moveOperation
}

function Wait-ForCopyOperationToSucceed {
	param
	(
		$rgName,
		$instanceName,
		$databaseName
	)

	$moveOperation = Get-AzSqlInstanceDatabaseCopyOperation `
		-ResourceGroupName $rgName `
		-InstanceName $instanceName `
		-Name $databaseName `
		-OnlyLatestPerDatabase

	while ($moveOperation.state -ne "Succeeded" -and $moveOperation.state -ne "Cancelled") {
		Start-TestSleep -Seconds 30

		$moveOperation = Get-AzSqlInstanceDatabaseCopyOperation `
			-ResourceGroupName $rgName `
			-InstanceName $instanceName `
			-Name $databaseName `
			-OnlyLatestPerDatabase
	}
	return $moveOperation
}
