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

$vnetName = "logReplayPS"
$subnetName = "Cool"
$location = "westcentralus"
$lastBackupName = "full.bak";
$resourceGroupName = "mibrkiclogreplay"

$storageAccountName = "testlogreplayps"
$containerName = "logreplaypstest"
$testStorageContainerUri = "https://testlogreplayps.blob.core.windows.net/logreplaypstest";

function SetupEnvForTests
{
	try
	{
		# Create new resource group
		$global:rg = New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Create storage account
		$storageAccount = New-AzStorageAccount -ResourceGroupName $resourceGroupName `
			-Name $storageAccountName `
			-Type "Standard_LRS" `
			-Location $location

		Wait-Seconds 10

		# Get context of the storage account
		$key = Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName
		$ctx = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $key[0].Value

		# Create storage container
		New-AzStorageContainer -Name $containerName -Context $ctx

		# Add file to container to use for log replay
		Set-AzStorageBlobContent -File ".\Resources\full.bak" `
			-Container $containerName `
			-Blob "full.bak" `
			-Context $ctx

		# Get sas token as we will need to initiate log replay
		$global:testStorageContainerSasToken = New-AzStorageContainerSASToken -Context $ctx -Name "testSas" -StartTime ([System.DateTime]::Now).AddMinutes(-20) -ExpiryTime ([System.DateTime]::Now).AddHours(5) -Permission "rl" -FullUri

		# Setup VNET
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $location $resourceGroupName
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

		$managedInstance = Create-ManagedInstanceForTest $global:rg $subnetId
		$global:managedInstanceName = $managedInstance.ManagedInstanceName
	}
	catch
	{
	    #Remove-ResourceGroupForTest $global:rg
		throw
	}
}

<#
.SYNOPSIS
Tests Managed Database Log Replay.
#>
function Test-ManagedDatabaseLogReplay
{
	# Create new resource group
	$rg = New-AzResourceGroup -Name $resourceGroupName -Location $location

	# Create storage account
	$storageAccount = New-AzStorageAccount -ResourceGroupName $resourceGroupName `
		-Name $storageAccountName `
		-Type "Standard_LRS" `
		-Location $location

	Start-Sleep -s 10

	# Get context of the storage account
	$key = Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName
	$ctx = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $key[0].Value

	# Create storage container
	New-AzStorageContainer -Name $containerName -Context $ctx

	# Add file to container to use for log replay
	Set-AzStorageBlobContent -File ".\Resources\full.bak" `
		-Container $containerName `
		-Blob "full.bak" `
		-Context $ctx

	# Generates sas token as we will need to initiate log replay
	$testStorageContainerSasToken = New-AzStorageContainerSASToken `
		-Name $containerName -Permission "rl" `
		-StartTime ([System.DateTime]::Now).AddMinutes(-20) `
		-ExpiryTime ([System.DateTime]::Now).AddHours(5) `
		-Context $ctx -FullUri

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $location $resourceGroupName
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId
	$managedInstanceName = $managedInstance.ManagedInstanceName

	# Start log replay
	$managedDatabaseName = Get-ManagedDatabaseName
	$collation = "SQL_Latin1_General_CP1_CI_AS"
		
	Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $resourceGroupName -InstanceName $managedInstanceName `
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
		-ResourceGroupName $resourceGroupName `
		-InstanceName $managedInstanceName `
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

<#
.SYNOPSIS
Tests Managed Database Log Replay calling complete API.
#>
function Test-CompleteManagedDatabaseLogReplay
{
	# Setup
	$rg = Create-ResourceGroupForTest

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

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

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

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

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

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

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

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
