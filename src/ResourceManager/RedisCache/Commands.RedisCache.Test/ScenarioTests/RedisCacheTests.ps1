<#
.SYNOPSIS
Tests redis cache.
#>
function Test-RedisCache
{
    # Setup
    $resourceGroupName = "PowerShellTest-1"
    $cacheName = "powershelltest"
    $location = "West US"

	# Create resource group
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 1GB -Sku Standard
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "3.0" $cacheCreated.RedisVersion
    Assert-AreEqual "1GB" $cacheCreated.Size
    Assert-AreEqual "Standard" $cacheCreated.Sku
    
    Assert-NotNull $cacheCreated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheCreated.SecondaryKey "SecondaryKey do not exists"

    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            Assert-AreEqual $location $cacheGet[0].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cacheGet[0].Type
            Assert-AreEqual $resourceGroupName $cacheGet[0].ResourceGroupName
    
            Assert-AreEqual 6379 $cacheGet[0].Port
            Assert-AreEqual 6380 $cacheGet[0].SslPort
            Assert-AreEqual "succeeded" $cacheGet[0].ProvisioningState
            Assert-AreEqual "3.0" $cacheGet[0].RedisVersion
            Assert-AreEqual "1GB" $cacheGet[0].Size
            Assert-AreEqual "Standard" $cacheGet[0].Sku
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    # Updating Cache
    $cacheUpdated = Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RedisConfiguration @{"maxmemory-policy" = "allkeys-lru"} -EnableNonSslPort $true
    
    Assert-AreEqual $cacheName $cacheUpdated.Name
    Assert-AreEqual $location $cacheUpdated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheUpdated.Type
    Assert-AreEqual $resourceGroupName $cacheUpdated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheUpdated.Port
    Assert-AreEqual 6380 $cacheUpdated.SslPort
    Assert-AreEqual "succeeded" $cacheUpdated.ProvisioningState
    Assert-AreEqual "3.0" $cacheUpdated.RedisVersion
    Assert-AreEqual "1GB" $cacheUpdated.Size
    Assert-AreEqual "Standard" $cacheUpdated.Sku
    Assert-AreEqual "allkeys-lru" $cacheUpdated.RedisConfiguration.Item("maxmemory-policy")
    Assert-True  { $cacheUpdated.EnableNonSslPort }

    Assert-NotNull $cacheUpdated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheUpdated.SecondaryKey "SecondaryKey do not exists"

    # List all cache in resource group
    $cachesInResourceGroup = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName
    Assert-True {$cachesInResourceGroup.Count -ge 1}
    
    $found = 0
    for ($i = 0; $i -lt $cachesInResourceGroup.Count; $i++)
    {
        if ($cachesInResourceGroup[$i].Name -eq $cacheName)
        {
            $found = 1
            Assert-AreEqual $location $cachesInResourceGroup[$i].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cachesInResourceGroup[$i].Type
            Assert-AreEqual $resourceGroupName $cachesInResourceGroup[$i].ResourceGroupName
    
            Assert-AreEqual 6379 $cachesInResourceGroup[$i].Port
            Assert-AreEqual 6380 $cachesInResourceGroup[$i].SslPort
            Assert-AreEqual "succeeded" $cachesInResourceGroup[$i].ProvisioningState
            Assert-AreEqual "3.0" $cachesInResourceGroup[$i].RedisVersion
            Assert-AreEqual "1GB" $cachesInResourceGroup[$i].Size
            Assert-AreEqual "Standard" $cachesInResourceGroup[$i].Sku
            break
        }
    }
    Assert-True {$found -eq 1} "Cache created earlier is not found."

    # List all cache in subscription
    $cachesInSubscription = Get-AzureRmRedisCache
    Assert-True {$cachesInSubscription.Count -ge 1}
    Assert-True {$cachesInSubscription.Count -ge $cachesInResourceGroup.Count}
    
    $found = 0
    for ($i = 0; $i -lt $cachesInSubscription.Count; $i++)
    {
        if ($cachesInSubscription[$i].Name -eq $cacheName)
        {
            $found = 1
            Assert-AreEqual $location $cachesInSubscription[$i].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cachesInSubscription[$i].Type
            Assert-AreEqual $resourceGroupName $cachesInSubscription[$i].ResourceGroupName
    
            Assert-AreEqual 6379 $cachesInSubscription[$i].Port
            Assert-AreEqual 6380 $cachesInSubscription[$i].SslPort
            Assert-AreEqual "succeeded" $cachesInSubscription[$i].ProvisioningState
            Assert-AreEqual "3.0" $cachesInSubscription[$i].RedisVersion
            Assert-AreEqual "1GB" $cachesInSubscription[$i].Size
            Assert-AreEqual "Standard" $cachesInSubscription[$i].Sku
            break
        }
    }
    Assert-True {$found -eq 1} "Cache created earlier is not found."

    # Get cache keys
    $cacheKeysBeforeUpdate = Get-AzureRmRedisCacheKey -ResourceGroupName $resourceGroupName -Name $cacheName 
    Assert-NotNull $cacheKeysBeforeUpdate.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheKeysBeforeUpdate.SecondaryKey "SecondaryKey do not exists"

    # Regenerate primary key
    $cacheKeysAfterUpdate = New-AzureRmRedisCacheKey -ResourceGroupName $resourceGroupName -Name $cacheName -KeyType Primary -Force
    Assert-AreEqual $cacheKeysBeforeUpdate.SecondaryKey $cacheKeysAfterUpdate.SecondaryKey
    Assert-AreNotEqual $cacheKeysBeforeUpdate.PrimaryKey $cacheKeysAfterUpdate.PrimaryKey

    # Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."

	# Delete resource group
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests set redis cache that do not exists.
#>
function Test-SetNonExistingRedisCacheTest
{
    # Setup
    $resourceGroupName = "PowerShellTestNonExisting"
    $cacheName = "nonexistingrediscache"
    $location = "West US"

    # Creating Cache
    Assert-Throws {Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RedisConfiguration @{"maxmemory-policy" = "allkeys-random"} }
}

<#
.SYNOPSIS
Tests redis cache.
#>
function Test-RedisCachePipeline
{
    # Setup
    $resourceGroupName = "PowerShellTest-2"
    $cacheName = "powershelltestpipe"
    $location = "West US"

	# Create resource group
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 1GB -Sku Basic -EnableNonSslPort $true
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "3.0" $cacheCreated.RedisVersion
    Assert-AreEqual "1GB" $cacheCreated.Size
    Assert-AreEqual "Basic" $cacheCreated.Sku
    Assert-True { $cacheCreated.EnableNonSslPort }
    
    Assert-NotNull $cacheCreated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheCreated.SecondaryKey "SecondaryKey do not exists"

    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            Assert-AreEqual $location $cacheGet[0].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cacheGet[0].Type
            Assert-AreEqual $resourceGroupName $cacheGet[0].ResourceGroupName
    
            Assert-AreEqual 6379 $cacheGet[0].Port
            Assert-AreEqual 6380 $cacheGet[0].SslPort
            Assert-AreEqual "succeeded" $cacheGet[0].ProvisioningState
            Assert-AreEqual "3.0" $cacheGet[0].RedisVersion
            Assert-AreEqual "1GB" $cacheGet[0].Size
            Assert-AreEqual "Basic" $cacheGet[0].Sku
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    # Updating Cache using pipeline
    Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Set-AzureRmRedisCache -RedisConfiguration @{"maxmemory-policy" = "allkeys-random"} -EnableNonSslPort $false
    $cacheUpdatedPiped = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName 
    
    Assert-AreEqual $cacheName $cacheUpdatedPiped.Name
    Assert-AreEqual $location $cacheUpdatedPiped.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheUpdatedPiped.Type
    Assert-AreEqual $resourceGroupName $cacheUpdatedPiped.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheUpdatedPiped.Port
    Assert-AreEqual 6380 $cacheUpdatedPiped.SslPort
    Assert-AreEqual "succeeded" $cacheUpdatedPiped.ProvisioningState
    Assert-AreEqual "3.0" $cacheUpdatedPiped.RedisVersion
    Assert-AreEqual "1GB" $cacheUpdatedPiped.Size
    Assert-AreEqual "Basic" $cacheUpdatedPiped.Sku
    Assert-AreEqual "allkeys-random"  $cacheUpdatedPiped.RedisConfiguration.Item("maxmemory-policy")
    Assert-False  { $cacheUpdatedPiped.EnableNonSslPort } 
    
    # Get cache keys
    $cacheKeysBeforeUpdate = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Get-AzureRmRedisCacheKey
    Assert-NotNull $cacheKeysBeforeUpdate.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheKeysBeforeUpdate.SecondaryKey "SecondaryKey do not exists"

    # Regenerate primary key
    $cacheKeysAfterUpdate = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | New-AzureRmRedisCacheKey -KeyType Primary -Force
    Assert-AreEqual $cacheKeysBeforeUpdate.SecondaryKey $cacheKeysAfterUpdate.SecondaryKey
    Assert-AreNotEqual $cacheKeysBeforeUpdate.PrimaryKey $cacheKeysAfterUpdate.PrimaryKey

    # Delete cache
    Assert-True {Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Remove-AzureRmRedisCache -Force -PassThru} "Remove cache failed."

	# Delete resource group
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests MaxMemoryPolicy error check
#>
function Test-MaxMemoryPolicyErrorCheck
{
    # Setup
    $resourceGroupName = "DummyResourceGroup"
    $cacheName = "dummycache"
    $location = "North Central US"

    # Updating Cache
    Assert-ThrowsContains {New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -MaxMemoryPolicy AllKeysRandom} "The 'MaxMemoryPolicy' setting has been deprecated"
}

<#
.SYNOPSIS
Tests redis cache clustering.
#>
function Test-RedisCacheClustering
{
    # Setup
    $resourceGroupName = "PowerShellTest-3"
    $cacheName = "powershellcluster"
    $location = "West US"

	# Create resource group
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 6GB -Sku Premium -ShardCount 3
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "6GB" $cacheCreated.Size
    Assert-AreEqual "Premium" $cacheCreated.Sku
    Assert-AreEqual 3 $cacheCreated.ShardCount
    
    Assert-NotNull $cacheCreated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheCreated.SecondaryKey "SecondaryKey do not exists"

    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    # Updating Cache
    $cacheUpdated = Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RedisConfiguration @{"maxmemory-policy" = "allkeys-lru"} -TenantSettings @{"some-key" = "some-value"}
    
    Assert-AreEqual $cacheName $cacheUpdated.Name
    Assert-AreEqual "succeeded" $cacheUpdated.ProvisioningState
    Assert-AreEqual "6GB" $cacheCreated.Size
    Assert-AreEqual "Premium" $cacheCreated.Sku
    Assert-AreEqual 3 $cacheCreated.ShardCount
    Assert-AreEqual "allkeys-lru" $cacheUpdated.RedisConfiguration.Item("maxmemory-policy")
    Assert-AreEqual "some-value" $cacheUpdated.TenantSettings.Item("some-key")

    Assert-NotNull $cacheUpdated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheUpdated.SecondaryKey "SecondaryKey do not exists"

    # List all cache in resource group
    $cachesInResourceGroup = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName
    Assert-True {$cachesInResourceGroup.Count -ge 1}
    
    $found = 0
    for ($i = 0; $i -lt $cachesInResourceGroup.Count; $i++)
    {
        if ($cachesInResourceGroup[$i].Name -eq $cacheName)
        {
            $found = 1
            Assert-AreEqual $location $cachesInResourceGroup[$i].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cachesInResourceGroup[$i].Type
            Assert-AreEqual $resourceGroupName $cachesInResourceGroup[$i].ResourceGroupName
    
            Assert-AreEqual 6379 $cachesInResourceGroup[$i].Port
            Assert-AreEqual 6380 $cachesInResourceGroup[$i].SslPort
            Assert-AreEqual "succeeded" $cachesInResourceGroup[$i].ProvisioningState
            Assert-AreEqual "6GB" $cacheCreated.Size
            Assert-AreEqual "Premium" $cacheCreated.Sku
            Assert-AreEqual 3 $cacheCreated.ShardCount
            break
        }
    }
    Assert-True {$found -eq 1} "Cache created earlier is not found."

    # List all cache in subscription
    $cachesInSubscription = Get-AzureRmRedisCache
    Assert-True {$cachesInSubscription.Count -ge 1}
    Assert-True {$cachesInSubscription.Count -ge $cachesInResourceGroup.Count}
    
    $found = 0
    for ($i = 0; $i -lt $cachesInSubscription.Count; $i++)
    {
        if ($cachesInSubscription[$i].Name -eq $cacheName)
        {
            $found = 1
            Assert-AreEqual $location $cachesInSubscription[$i].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cachesInSubscription[$i].Type
            Assert-AreEqual $resourceGroupName $cachesInSubscription[$i].ResourceGroupName
    
            Assert-AreEqual 6379 $cachesInSubscription[$i].Port
            Assert-AreEqual 6380 $cachesInSubscription[$i].SslPort
            Assert-AreEqual "succeeded" $cachesInSubscription[$i].ProvisioningState
            Assert-AreEqual "6GB" $cacheCreated.Size
            Assert-AreEqual "Premium" $cacheCreated.Sku
            Assert-AreEqual 3 $cacheCreated.ShardCount
            break
        }
    }
    Assert-True {$found -eq 1} "Cache created earlier is not found."

    # Get cache keys
    $cacheKeysBeforeUpdate = Get-AzureRmRedisCacheKey -ResourceGroupName $resourceGroupName -Name $cacheName 
    Assert-NotNull $cacheKeysBeforeUpdate.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheKeysBeforeUpdate.SecondaryKey "SecondaryKey do not exists"

    # Regenerate primary key
    $cacheKeysAfterUpdate = New-AzureRmRedisCacheKey -ResourceGroupName $resourceGroupName -Name $cacheName -KeyType Primary -Force
    Assert-AreEqual $cacheKeysBeforeUpdate.SecondaryKey $cacheKeysAfterUpdate.SecondaryKey
    Assert-AreNotEqual $cacheKeysBeforeUpdate.PrimaryKey $cacheKeysAfterUpdate.PrimaryKey

    # Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."
	
	# Delete resource group
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests RedisCachePatchSchedules and a bug fix
#>
function Test-RedisCachePatchSchedules
{
    # Setup
    $resourceGroupName = "PowerShellTest-4"
    $cacheName = "powershelltests4"
    $location = "West US"
	
	############################# Initial Creation ############################# 
	# Create resource group
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

	# Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Sku Premium -Size P1
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

	############################# Tests schedule patching ##########################################
	$weekend = New-AzureRmRedisCacheScheduleEntry -DayOfWeek "Weekend" -StartHourUtc 2 -MaintenanceWindow "06:00:00"
    $thursday = New-AzureRmRedisCacheScheduleEntry -DayOfWeek "Thursday" -StartHourUtc 10 -MaintenanceWindow "09:00:00"

    $createResult = New-AzureRmRedisCachePatchSchedule -ResourceGroupName $resourceGroupName -Name $cacheName -Entries @($weekend, $thursday)
    Assert-True {$createResult.Count -eq 3}
    foreach ($scheduleEntry in $createResult)
    {
        if($scheduleEntry.DayOfWeek -eq "Thursday")
        {
            Assert-AreEqual 10 $scheduleEntry.StartHourUtc
            Assert-AreEqual "09:00:00" $scheduleEntry.MaintenanceWindow
        } 
        elseif($scheduleEntry.DayOfWeek -eq "Saturday" -or $scheduleEntry.DayOfWeek -eq "Sunday")
        {
            Assert-AreEqual 2 $scheduleEntry.StartHourUtc
            Assert-AreEqual "06:00:00" $scheduleEntry.MaintenanceWindow
        }
        else
        {
            Assert-True $false "Unknown DayOfWeek."
        }
    }

    $getResult = Get-AzureRmRedisCachePatchSchedule -ResourceGroupName $resourceGroupName -Name $cacheName
    Assert-True {$getResult.Count -eq 3}
    foreach ($scheduleEntry in $getResult)
    {
        if($scheduleEntry.DayOfWeek -eq "Thursday")
        {
            Assert-AreEqual 10 $scheduleEntry.StartHourUtc
            Assert-AreEqual "09:00:00" $scheduleEntry.MaintenanceWindow
        } 
        elseif($scheduleEntry.DayOfWeek -eq "Saturday" -or $scheduleEntry.DayOfWeek -eq "Sunday")
        {
            Assert-AreEqual 2 $scheduleEntry.StartHourUtc
            Assert-AreEqual "06:00:00" $scheduleEntry.MaintenanceWindow
        }
        else
        {
            Assert-True $false "Unknown DayOfWeek."
        }
    }

    Remove-AzureRmRedisCachePatchSchedule -ResourceGroupName $resourceGroupName -Name $cacheName

    Assert-ThrowsContains {Get-AzureRmRedisCachePatchSchedule -ResourceGroupName $resourceGroupName -Name $cacheName} "There are no patch schedules found for redis cache"
	
	############################# Bug fix in set redis cache related to EnableNonSslPort ##########################################
    $cacheUpdated = Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -EnableNonSslPort $true
    Assert-True  { $cacheUpdated.EnableNonSslPort }

    $cacheUpdated2 = Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RedisConfiguration @{"maxmemory-policy" = "allkeys-lru"} 
    Assert-AreEqual "allkeys-lru" $cacheUpdated2.RedisConfiguration.Item("maxmemory-policy")
    Assert-True  { $cacheUpdated2.EnableNonSslPort }
	
	############################# CleanUp ############################# 
	# Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."

	# Delete resource group
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

function Create-StorageAccount($resourceGroupName,$storageName,$location)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageName -SkuName "Standard_LRS" -Location $location 
    }
}

function Get-SasForContainer
{
	param
	(
	$resourceGroupName,
	$storageName,
	$storageContainerName,
	[ref] $sasKeyForContainer
	)
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# Get storage account context
		$storageAccountContext = New-AzureStorageContext -StorageAccountName $storageName -StorageAccountKey (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageName).Value[0]

		# Create Container in Storage Account
		New-AzureStorageContainer -Name $storageContainerName -Context $storageAccountContext

		# Get SAS token for container
		$sasKeyForContainer.Value = New-AzureStorageContainerSASToken -Name $storageContainerName -Permission "rwdl" -StartTime ([System.DateTime]::Now).AddMinutes(-20) -ExpiryTime ([System.DateTime]::Now).AddHours(2) -Context $storageAccountContext -FullUri
	}
	else
	{
		$sasKeyForContainer.Value = "dummysasforcontainer"
	}
}

function Get-SasForBlob
{
	param
	(
	$resourceGroupName,
	$storageName,
	$storageContainerName,
	$prefix,
	[ref] $sasKeyForBlob
	)
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# Get storage account context
		$storageAccountContext = New-AzureStorageContext -StorageAccountName $storageName -StorageAccountKey (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageName).Value[0]

		# Get SAS token for blob
		$sasKeyForBlob.Value = New-AzureStorageBlobSASToken -Container $storageContainerName -Blob $prefix -Permission "rwdl" -StartTime ([System.DateTime]::Now).AddMinutes(-20) -ExpiryTime ([System.DateTime]::Now).AddHours(2) -Context $storageAccountContext -FullUri
	}
	else
	{
		$sasKeyForBlob.Value = "dummysasforblob"
	}
}

<#
.SYNOPSIS
Tests ExportRMAzureRedisCache
Tests ImportAzureRmRedisCache
Tests ResetRMAzureRedisCache
#>
function Test-ImportExportReboot
{
    # Setup
    $resourceGroupName = "PowerShellTest-5"
    $cacheName = "importexporttest"
    $location = "West US"
	$storageName = "powershelltest1"
	$storageContainerName = "exportimport" 
	$prefix = "sunny"

	############################# Initial Creation ############################# 
	# Create resource group
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

	# Create Storage Account
	Create-StorageAccount $resourceGroupName $storageName $location

	# Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Sku Premium -Size P1
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

	############################# ExportRMAzureRedisCache & ImportAzureRmRedisCache ############################# 
	# Get SAS token for container
	$sasKeyForContainer = ""
	Get-SasForContainer $resourceGroupName $storageName $storageContainerName ([ref]$sasKeyForContainer)
	
	# Tests ExportRMAzureRedisCache
	Export-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Prefix $prefix -Container $sasKeyForContainer

	# Get SAS token for blob
	$sasKeyForBlob = "" 
	Get-SasForBlob $resourceGroupName $storageName $storageContainerName $prefix ([ref]$sasKeyForBlob)

	# Tests ImportAzureRmRedisCache
	Import-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Files @($sasKeyForBlob) -Force
	
	############################# Tests ResetRMAzureRedisCache ############################# 
	$rebootType = "PrimaryNode"
    Reset-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RebootType $rebootType -Force
	Start-TestSleep 120000
	
	############################# CleanUp ############################# 
	# Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."

	# Delete resource group
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests SetAzureRedisCacheDiagnostics
Tests RemoveAzureRedisCacheDiagnostics
#>
function Test-DiagnosticOperations
{
    # Setup
    $resourceGroupName = "PowerShellTest-6"
    $cacheName = "powershelltests6"
    $location = "West US"
	$storageName = "powershelltest2"
	
	############################# Initial Creation ############################# 
	# Create resource group
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

	# Create Storage Account
	$storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageName -SkuName "Standard_LRS" -Location $location 

	# Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Sku Premium -Size P1
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

	############################# SetAzureRedisCacheDiagnostics & RemoveAzureRedisCacheDiagnostics tests #############################
	# Tests SetAzureRedisCacheDiagnostics
	Set-AzureRmRedisCacheDiagnostics -ResourceGroupName $resourceGroupName -Name $cacheName -StorageAccountId $storageAccount.Id
	
	# Tests RemoveAzureRedisCacheDiagnostics
	Remove-AzureRmRedisCacheDiagnostics -ResourceGroupName $resourceGroupName -Name $cacheName
	
	############################# CleanUp ############################# 
	# Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."

	# Delete resource group
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}


<#
.SYNOPSIS
Sleeps but only during recording.
#>
function Start-TestSleep($milliseconds)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        Start-Sleep -Milliseconds $milliseconds
    }
}