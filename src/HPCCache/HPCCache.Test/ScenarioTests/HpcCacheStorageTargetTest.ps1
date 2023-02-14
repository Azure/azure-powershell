function Test-GetAzHPCCacheStorageTargetByNameAndResourceGroup
{
	Param($ResourceGroupName, $CacheName, $StorageTargetName)
	$storageTargetObj = Get-AzHPCCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $StorageTargetName
	Assert-AreEqual $StorageTargetName $storageTargetObj.Name
}

function Test-New-Get-Remove-StorageTarget
{
	Param($ResourceGroupName, $CacheName, $SubscriptionID)
	$StorageAccountName = "cmdletsa"
	$stName = "powershellstoragetarget"
	$junctions = @(@{"namespacePath"="/msazure";"targetPath"="/";"nfsExport"="/"})
	$containerId = "/subscriptions/" + $SubscriptionID +"/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.Storage/storageAccounts/" + $storageAccountName + "/blobServices/default/containers/cmdletcontnr4"
	New-AzHpcCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName  -CLFS -StorageContainerID $containerID -Junction $junctions -Force
	Start-TestSleep -Seconds 5
	$storageTarget = Get-AzHPCCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName
	Assert-AreEqual $stName $storageTarget.Name
	Assert-AreEqual  "CLFS" $storageTarget.TargetType

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# In loop to check if StorageTarget is Succeeded
		for ($i = 0; $i -le 20; $i++)
		{
			Start-TestSleep -Seconds 30
			$storageTargetGet = Get-AzHPCCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName
			if ([string]::Compare("Succeeded", $storageTargetGet.ProvisioningState, $True) -eq 0)
			{
				Assert-AreEqual $stName $storageTargetGet.Name
				Assert-AreEqual "Succeeded" $storageTargetGet.ProvisioningState
				break
			}
			Assert-False {$i -eq 20} "StorageTarget is not done completeling after 10 minutes."
		}
	}

	$storageTargetRemove = Remove-AzHPCCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName -PassThru -Force
	Assert-AreEqual $storageTargetRemove True
	Start-TestSleep -Seconds 120
}


function Test-SetStorageTarget
{
	Param($ResourceGroupName, $CacheName, $stName)
	$junctions = @(@{"namespacePath"="/abcdefgh";"targetPath"="/";"nfsExport"="/"})
	Set-AzHpcCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName -CLFS -Junction $junctions -Force
	Start-TestSleep -Seconds 5
	$storageTarget = Get-AzHPCCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName
	Assert-AreEqual $stName $storageTarget.Name
	Assert-AreEqual  "CLFS" $storageTarget.TargetType

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# In loop to check if StorageTarget is Succeeded
		for ($i = 0; $i -le 20; $i++)
		{
			Start-TestSleep -Seconds 30
			$storageTargetGet = Get-AzHPCCacheStorageTarget -ResourceGroupName $ResourceGroupName -CacheName $CacheName -StorageTargetName $stName
			if ([string]::Compare("Succeeded", $storageTargetGet.ProvisioningState, $True) -eq 0)
			{
				Assert-AreEqual $stName $storageTargetGet.Name
				Assert-AreEqual "Succeeded" $storageTargetGet.ProvisioningState
                Assert-AreEqual "/abcdefgh" $storageTargetGet.Junctions.nameSpacePath
				break
			}
			Assert-False {$i -eq 20} "StorageTarget is not done completeling after 10 minutes."
		}
	}
}