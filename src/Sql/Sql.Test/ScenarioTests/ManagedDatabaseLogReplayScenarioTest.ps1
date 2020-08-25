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
Tests Managed Database Log Replay.
#>
function Test-ManagedDatabaseLogReplay
{
	# Setup
	#$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"
	$testStorageContainerUri = "https://mijetest.blob.core.windows.net/pcc-remote-replicas-test";
    $testStorageContainerSasToken = "sv=2019-02-02&ss=b&srt=sco&sp=rl&se=2023-12-02T00:09:14Z&st=2019-11-25T16:09:14Z&spr=https&sig=92kAe4QYmXaht%2FgjocUpioABFvm5N0BwhKFrukGw41s%3D";
	$lastBackupName = "full.bak";

	# Setup VNET
	#$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	#$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	#$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

	$rg = "ps1325"
	$managedInstance = "ps8787"
	try
	{
		# Start log replay
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		
		Start-AzSqlInstanceDatabaseLogReplay -ResourceGroupName $rg -InstanceName $managedInstance `
			-Name $managedDatabaseName -Collation $collation `
			-StorageContainerUri $testStorageContainerUri `
			-StorageContainerSasToken $testStorageContainerSasToken `
			-AutoComplete -LastBackupName $lastBackupName

		if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
			Start-Sleep -s 10
        }

		# Fetch status of the operation
		$status = "InProgress"
		$statusInWaiting = "Waiting"
        $statusCompleted = "Completed"

		while($true){
            $statusResponse = Get-AzSqlInstanceDatabaseLogReplay `
			-ResourceGroupName $rg `
			-InstanceName $managedInstance `
			-Name $managedDatabaseName

			# Wait until restore state is Completed - this means that all files have been restored from storage container.
            #
            $status = $statusResponse.Status
            if($status -eq $statusCompleted){
				break;
            }
			
            if([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record"){
				Start-Sleep -s 30
            }
        }
	}
	finally
	{
		# Remove-ResourceGroupForTest $rg
	}
}

