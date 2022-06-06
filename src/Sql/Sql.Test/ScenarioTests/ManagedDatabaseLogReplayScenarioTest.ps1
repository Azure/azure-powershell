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

$stoname = "backupscxteam";
$container = "clients";
$testStorageContainerUri = "https://backupscxteam.blob.core.windows.net/clients";
$lastBackupName = "full_0.bak";

<#
.SYNOPSIS
Tests Managed Database Log Replay.
#>
function Test-ManagedDatabaseLogReplay
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$defaultParams = Get-DefaultManagedInstanceParameters

	$testStorageContainerSasToken = Generate-SasToken $defaultParams.rg

	$managedInstance = Create-ManagedInstanceForTest $rg

	$rgName = $rg.ResourceGroupName
	$managedInstance = $managedInstance.ManagedInstanceName
	try
	{
		# Start log replay
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		
		Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rgName -InstanceName $managedInstance `
			-Name $managedDatabaseName -Collation $collation `
			-StorageContainerUri $testStorageContainerUri `
			-StorageContainerSasToken $testStorageContainerSasToken `
			-AutoComplete -LastBackupName $lastBackupName

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
        }

		# Fetch status of the operation
		$status = "InProgress"
        $statusCompleted = "Completed"
		$statusResponse = ""

		while($true){
            $statusResponse = Get-AzSqlInstanceDatabaseLogReplay `
			-ResourceGroupName $rgName `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName

			# Wait until restore state is Completed - this means that all files have been restored from storage container.
            #
            $status = $statusResponse.Status
            if($status -eq $statusCompleted){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 15
            }
        }

		Assert-NotNull $statusResponse
		Assert-AreEqual $status $statusCompleted
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Database Log Replay calling complete API.
#>
function Test-CompleteManagedDatabaseLogReplay
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	$rgName = $rg.ResourceGroupName
	$managedInstance = $managedInstance.ManagedInstanceName
	try
	{
		# Start log replay
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		
		Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rgName -InstanceName $managedInstance `
			-Name $managedDatabaseName -Collation $collation `
			-StorageContainerUri $testStorageContainerUri `
			-StorageContainerSasToken $testStorageContainerSasToken

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
        }

		# Fetch status of the operation
		$status = "InProgress"
        $statusCompleted = "Completed"
		$statusResponse = ""

		while($true){
            $statusResponse = Get-AzSqlInstanceDatabaseLogReplay `
			-ResourceGroupName $rgName `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName

			# Wait until restore state is Restoring - this means restore has began
            #
            $status = $statusResponse.Status
            if($status -eq "Restoring"){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 15
            }
        }

		Complete-AzSqlInstanceDatabaseLogReplay `
			-ResourceGroupName $rgName `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName `
			-LastBackupName $lastBackupName

		while($true){
            $statusResponse = Get-AzSqlInstanceDatabaseLogReplay `
			-ResourceGroupName $rgName `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName

			# Wait until restore state is Complted - this means restore has completed
            #
            $status = $statusResponse.Status
            if($status -eq $statusCompleted){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 15
            }
        }

		Assert-NotNull $statusResponse
		Assert-AreEqual $status $statusCompleted
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Database Log Replay cancel.
#>
function Test-CancelManagedDatabaseLogReplay
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	$rgName = $rg.ResourceGroupName
	$managedInstance = $managedInstance.ManagedInstanceName
	try
	{
		# Start log replay
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		
		Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rgName -InstanceName $managedInstance `
			-Name $managedDatabaseName -Collation $collation `
			-StorageContainerUri $testStorageContainerUri `
			-StorageContainerSasToken $testStorageContainerSasToken

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
        }

		# Fetch status of the operation
		$status = "InProgress"

		while($true){
            $statusResponse = Get-AzSqlInstanceDatabaseLogReplay `
			-ResourceGroupName $rgName `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName

			# Wait until restore state is Restoring - this means restore has began
            #
            $status = $statusResponse.Status
            if($status -eq "Restoring"){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 15
            }
        }

		Stop-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rgName -InstanceName $managedInstance -Name $managedDatabaseName -Force
		
		try {
			$db = Get-AzSqlInstanceDatabase `
				-ResourceGroupName $rgName `
				-InstanceName $managedInstance `
				-Name $managedDatabaseName
        }
		catch {
			# This is what we want
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("not found")
		}

		Assert-Null $db
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
.SYNOPSIS
Tests Managed Database Log Replay piping.
#>
function Test-ManagedDatabaseLogReplayPiping
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	$rgName = $rg.ResourceGroupName
	$managedInstance = $managedInstance.ManagedInstanceName
	try
	{
		# Start log replay
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		
		$restoringDb = Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rgName -InstanceName $managedInstance `
			-Name $managedDatabaseName -Collation $collation `
			-StorageContainerUri $testStorageContainerUri `
			-StorageContainerSasToken $testStorageContainerSasToken `
			-AutoComplete -LastBackupName $lastBackupName

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
        }

		# Fetch status of the operation
		$status = "InProgress"
        $statusCompleted = "Completed"
		$statusResponse = ""

		while($true){
			$db = Get-AzSqlInstanceDatabase -ResourceGroupName $rgName -InstanceName $managedInstance -Name $managedDatabaseName

			$statusResponse = $db | Get-AzSqlInstanceDatabaseLogReplay

			# Wait until restore state is Completed - this means that all files have been restored from storage container.
            #
            $status = $statusResponse.Status
            if($status -eq $statusCompleted){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 15
            }
        }

		Assert-NotNull $statusResponse
		Assert-AreEqual $status $statusCompleted
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Database Log Replay cancel.
#>
function Test-PipingCompleteCancelManagedDatabaseLogReplay
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	$rgName = $rg.ResourceGroupName
	$managedInstance = $managedInstance.ManagedInstanceName
	try
	{
		# Start log replay
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		
		Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rgName -InstanceName $managedInstance `
			-Name $managedDatabaseName -Collation $collation `
			-StorageContainerUri $testStorageContainerUri `
			-StorageContainerSasToken $testStorageContainerSasToken

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
        }

		# Fetch status of the operation
		$status = "InProgress"
        $statusCompleted = "Completed"
		$statusResponse = ""

		$db = Get-AzSqlInstanceDatabase `
			-ResourceGroupName $rgName `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName
		
		while($true){
            $statusResponse = $db | Get-AzSqlInstanceDatabaseLogReplay

			# Wait until restore state is Restoring - this means restore has began
            #
            $status = $statusResponse.Status
            if($status -eq "Restoring"){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 15
            }
        }


		$db | Complete-AzSqlInstanceDatabaseLogReplay -LastBackupName $lastBackupName

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
		}
		
		$db | Stop-AzSqlInstanceDatabaseLogReplay -Force
		
		try {
			$dbRemoved = Get-AzSqlInstanceDatabase `
				-ResourceGroupName $rgName `
				-InstanceName $managedInstance `
				-Name $managedDatabaseName
        }
		catch {
			# This is what we want
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("not found")
		}

		Assert-Null $dbRemoved
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Database Log Replay cancel on a wrong database
#>
function Test-CancelManagedDatabaseLogReplayFailForWrongDatabase
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $managedInstance = Create-ManagedInstanceForTest $rg

    $rgName = $rg.ResourceGroupName
    $managedInstance = $managedInstance.ManagedInstanceName

    try
    {
        # Start log replay
        $managedDatabaseName = Get-ManagedDatabaseName
        $db = New-AzSqlInstanceDatabase -ResourceGroupName $rgName -InstanceName $managedInstance -Name $managedDatabaseName

        # Stop log replay on a DB that's not created with log replay should fail
        Assert-ThrowsContains { $db | Stop-AzSqlInstanceDatabaseLogReplay -Force } "error"
        $notDeletedDB = Get-AzSqlInstanceDatabase -ResourceGroupName $rgName -InstanceName $managedInstance -Name $managedDatabaseName
        Assert-NotNull $notDeletedDB
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

function Generate-SasToken ($rgname)
{
	$key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
	Assert-NotNull $key;

	$context = New-AzStorageContext -StorageAccountName $stoname -StorageAccountKey $key.Value[0];

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$sastoken = Get-AzStorageContainer -Name $container -Context $context | New-AzStorageContainerSASToken -Permission rl -Context $context -StartTime ([System.DateTime]::Now).AddHours(-20) -ExpiryTime ([System.DateTime]::Now).AddHours(48) -FullUri;
	}
	return $sastoken;
}7