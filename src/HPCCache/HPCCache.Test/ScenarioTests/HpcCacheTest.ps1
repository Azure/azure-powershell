function Test-GetAzHPCCacheByNameAndResourceGroup
{
	Param($ResourceGroupName, $CacheName)
	$cacheObj = Get-AzHPCCache -ResourceGroupName $ResourceGroupName -CacheName $CacheName
	write-host $cacheObj
	Assert-AreEqual $CacheName $cacheObj.CacheName
}

function Test-FlushCache
{
	Param($ResourceGroupName, $CacheName)
	$bool = Update-AzHpcCache -ResourceGroupName $ResourceGroupName -Name $CacheName -Flush -PassThru -Force
	Assert-AreEqual $bool True
	$cacheObj = Get-AzHPCCache -ResourceGroupName $ResourceGroupName -CacheName $CacheName
	Assert-AreEqual $CacheName $cacheObj.CacheName
	Assert-AreEqual "Flushing" $cacheObj.Health.state

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# In loop to check if cache is healthy yet
		for ($i = 0; $i -le 5; $i++)
		{
			Start-TestSleep -Seconds 60
			$cacheGet = Get-AzHPCCache -ResourceGroupName $ResourceGroupName -CacheName $CacheName
			if ([string]::Compare("Healthy", $cacheGet.Health.state, $True) -eq 0)
			{
				Assert-AreEqual $CacheName $cacheGet.CacheName
				Assert-AreEqual "Healthy" $cacheGet.Health.state
				break
			}
			Assert-False {$i -eq 5} "Cache is not Healthy after 5 min."
		}
	}
}

function Test-Stop-Start-Cache
{
	Param($ResourceGroupName, $CacheName)
	$bool = Stop-AzHpcCache -ResourceGroupName $ResourceGroupName -Name $CacheName -PassThru -Force
	Assert-AreEqual $bool True

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# In loop to check if cache is stopped
		for ($i = 0; $i -le 15; $i++)
		{
			Start-TestSleep -Seconds 60
			$cacheGet = Get-AzHPCCache -ResourceGroupName $ResourceGroupName -CacheName $CacheName
			if ([string]::Compare("Stopped", $cacheGet.Health.state, $True) -eq 0)
			{
				Assert-AreEqual $CacheName $cacheGet.CacheName
				Assert-AreEqual "Stopped" $cacheGet.Health.state
				break
			}
			Assert-False {$i -eq 15} "Cache is not Stopped after 15 min."
		}
	}
	$boolStart = Start-AzHpcCache -ResourceGroupName $ResourceGroupName -Name $CacheName -PassThru -Force
	Assert-AreEqual $boolStart True

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# In loop to check if cache is healthy/started
		for ($i = 0; $i -le 20; $i++)
		{
			Start-TestSleep -Seconds 60
			$cacheGet = Get-AzHPCCache -ResourceGroupName $ResourceGroupName -CacheName $CacheName
			if ([string]::Compare("Healthy", $cacheGet.Health.state, $True) -eq 0)
			{
				Assert-AreEqual $CacheName $cacheGet.CacheName
				Assert-AreEqual "Healthy" $cacheGet.Health.state
				break
			}
			Assert-False {$i -eq 20} "Cache is not Healthy after 20 min."
		}
	}
}

function Test-NewCache-RemoveCache
{
	Param($ResourceGroupName, $SubID, $Location, $Vnet, $Subnet)
	$cache = "powershell2"
	$sku = "Standard_2G"
	$subnetUri = "/subscriptions/" + $SubID +"/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.Network/virtualNetworks/" + $Vnet + "/subnets/" + $Subnet
	$cacheCreate = New-AzHpcCache -ResourceGroupName $ResourceGroupName -Name $cache -Location $Location -CacheSize 3072 -Sku $sku -SubnetUri $subnetUri
	Start-TestSleep -Seconds 2
	$cacheCreated = Get-AzHpcCache -ResourceGroupName $resourceGroupName -CacheName $cache

	Assert-AreEqual $cache $cacheCreated.CacheName
	Assert-AreEqual $Location $cacheCreated.Location
	Assert-AreEqual $ResourceGroupName $cacheCreated.ResourceGroupName
	Assert-AreEqual 3072 $cacheCreated.CacheSize

	$bool = Remove-AzHpcCache -ResourceGroupName $ResourceGroupName -CacheName $cache -PassThru -Force
	Assert-AreEqual $bool True
	$getOnRemovedCache = Get-AzHpcCache -ResourceGroupName $ResourceGroupName -CacheName $cache
	Assert-AreEqual $cache $getOnRemovedCache.CacheName
	Assert-AreEqual "Stopping" $getOnRemovedCache.Health.state
}

function Test-SetCache
{
	Param($ResourceGroupName, $CacheName)
	$tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$updateCache = Set-AzHpcCache -ResourceGroupName $ResourceGroupName -Name $CacheName -Tag $tags
	Assert-Match $updateCache.Tags '"tag2": "value2" "tag1": "value1"'
	Start-TestSleep -Seconds 2
	$getCache = Get-AzHpcCache -ResourceGroupName $ResourceGroupName -CacheName $CacheName
	Assert-AreEqual $CacheName $getCache.CacheName
	Assert-Match getCache.Tags '"tag2": "value2" "tag1": "value1"'
}

function Test-GetUsageModel
{
	$usagemodel = Get-AzHpcCacheUsageModel
	Assert-AreEqual 3 $usagemodel.TargetType.Count
	Assert-AreEqual "READ_HEAVY_INFREQ"  $usagemodel.Name.GetValue(0)
	Assert-AreEqual "WRITE_WORKLOAD_15"  $usagemodel.Name.GetValue(1)
	Assert-AreEqual "WRITE_AROUND" $usagemodel.Name.GetValue(2)
}

function Test-GetSku
{
	$sku = Get-AzHpcCacheSku
	Assert-AreEqual "caches" $sku.Get(1).ResourceType
}