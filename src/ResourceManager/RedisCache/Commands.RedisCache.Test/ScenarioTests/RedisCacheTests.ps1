<#
.SYNOPSIS
Tests redis cache.
#>
function Test-RedisCache
{
    # Setup
    $resourceGroupName = "PowerShellTest-1"
    $cacheName = "redisteam001"
    $location = "West US"

    # Create resource group
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size P1 -Sku Premium
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "6GB" $cacheCreated.Size
    Assert-AreEqual "Premium" $cacheCreated.Sku
    
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
            Assert-AreEqual "succeeded" $cacheGet[0].ProvisioningState
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    # Updating Cache
    $cacheUpdated = Set-AzureRmRedisCache -Name $cacheName -RedisConfiguration @{"maxmemory-policy" = "allkeys-lru"} -EnableNonSslPort $true
    
    Assert-AreEqual $cacheName $cacheUpdated.Name
    Assert-AreEqual 6379 $cacheUpdated.Port
    Assert-AreEqual 6380 $cacheUpdated.SslPort
    Assert-AreEqual "succeeded" $cacheUpdated.ProvisioningState
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
            Assert-AreEqual $resourceGroupName $cachesInResourceGroup[$i].ResourceGroupName
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
            Assert-AreEqual $resourceGroupName $cachesInSubscription[$i].ResourceGroupName
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
    $cacheName = "redisteam002"
    $location = "West US"

    # Create resource group
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 1GB -Sku Standard -EnableNonSslPort $true
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "1GB" $cacheCreated.Size
    Assert-AreEqual "Standard" $cacheCreated.Sku
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
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    # Updating Cache using pipeline
    Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Set-AzureRmRedisCache -RedisConfiguration @{"maxmemory-policy" = "allkeys-random"} -EnableNonSslPort $false
    $cacheUpdatedPiped = Get-AzureRmRedisCache -Name $cacheName 
    
    Assert-AreEqual $cacheName $cacheUpdatedPiped.Name
    Assert-AreEqual $location $cacheUpdatedPiped.Location
    Assert-AreEqual $resourceGroupName $cacheUpdatedPiped.ResourceGroupName
    Assert-AreEqual 6379 $cacheUpdatedPiped.Port
    Assert-AreEqual 6380 $cacheUpdatedPiped.SslPort
    Assert-AreEqual "succeeded" $cacheUpdatedPiped.ProvisioningState
    Assert-AreEqual "1GB" $cacheUpdatedPiped.Size
    Assert-AreEqual "Standard" $cacheUpdatedPiped.Sku
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
    $cacheName = "redisteam003"
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
            Assert-AreEqual $resourceGroupName $cachesInResourceGroup[$i].ResourceGroupName
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
            Assert-AreEqual $resourceGroupName $cachesInSubscription[$i].ResourceGroupName
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
    $cacheName = "redisteam004"
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
        $storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageName -Location $location -Type "Standard_LRS" 
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
    $cacheName = "redisteam005"
    $location = "West US"
    $storageName = "redisteam005s"
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
    Export-AzureRmRedisCache -Name $cacheName -Prefix $prefix -Container $sasKeyForContainer

    # Get SAS token for blob
    $sasKeyForBlob = "" 
    Get-SasForBlob $resourceGroupName $storageName $storageContainerName $prefix ([ref]$sasKeyForBlob)

    # Tests ImportAzureRmRedisCache
    Import-AzureRmRedisCache -Name $cacheName -Files @($sasKeyForBlob) -Force
    
    ############################# Tests ResetRMAzureRedisCache ############################# 
    $rebootType = "PrimaryNode"
    Reset-AzureRmRedisCache -Name $cacheName -RebootType $rebootType -Force
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
    $cacheName = "redisteam006"
    $location = "West US"
    $storageName = "redisteam006s"
    
    ############################# Initial Creation ############################# 
    # Create resource group
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Create Storage Account
    New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageName -Location $location -Type "Standard_LRS" 
    $storageAccount = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageName

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
    Assert-NotNull $storageAccount.Id "Storage Id cannot be null"
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
Tests GetAzureRedisCacheLink
Tests NewAzureRedisCacheLink
Tests RemoveAzureRedisCacheLink
#>
function Test-GeoReplication
{
    # Setup
    $resourceGroupName = "PowerShellTest-7"
    $cacheName1 = "redisteam0071"
    $cacheName2 = "redisteam0072"
    $location1 = "West US"
    $location2 = "East US"
    
    ############################# Initial Creation ############################# 
    # Create resource group
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location1

    # Creating cache1 and cache2
    $cacheCreated1 = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName1 -Location $location1 -Sku Premium -Size P1
    $cacheCreated2 = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName2 -Location $location2 -Sku Premium -Size P1

    Assert-AreEqual "creating" $cacheCreated1.ProvisioningState
    Assert-AreEqual "creating" $cacheCreated2.ProvisioningState

    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $resourceGroupName
        if (([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0) -and ([string]::Compare("succeeded", $cacheGet[1].ProvisioningState, $True) -eq 0))
        {
            break
        }
        Assert-False {$i -eq 60} "Caches are not in succeeded state even after 30 min."
    }

    ############################# NewAzureRedisCacheLink ############################# 
    $linkCreated = New-AzureRmRedisCacheLink -PrimaryServerName $cacheName1 -SecondaryServerName $cacheName2
    Assert-AreEqual "creating" $linkCreated.ProvisioningState
    Assert-AreEqual $cacheName1 $linkCreated.PrimaryServerName
    Assert-AreEqual $cacheName2 $linkCreated.SecondaryServerName

    ############################# GetAzureRedisCacheLink ############################# 
    # Get single links and wait for creation to comeplte
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $linkGet = Get-AzureRmRedisCacheLink -PrimaryServerName $cacheName1 -SecondaryServerName $cacheName2
        if ([string]::Compare("succeeded", $linkGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName1 $linkGet[0].PrimaryServerName
            Assert-AreEqual $cacheName2 $linkGet[0].SecondaryServerName
            break
        }
        Assert-False {$i -eq 60} "Geo replication link is not in succeeded state even after 30 min."
    }

    # Get all links for cache name
    $linkGet = Get-AzureRmRedisCacheLink -Name $cacheName1
    Assert-AreEqual $cacheName1 $linkGet[0].PrimaryServerName
    Assert-AreEqual $cacheName2 $linkGet[0].SecondaryServerName
    $linkGet = Get-AzureRmRedisCacheLink -Name $cacheName2
    Assert-AreEqual $cacheName1 $linkGet[0].PrimaryServerName
    Assert-AreEqual $cacheName2 $linkGet[0].SecondaryServerName
    
    # Get links where server is primary
    $linkGet = Get-AzureRmRedisCacheLink -PrimaryServerName $cacheName1
    Assert-AreEqual $cacheName1 $linkGet[0].PrimaryServerName
    Assert-AreEqual $cacheName2 $linkGet[0].SecondaryServerName
    $linkGet = Get-AzureRmRedisCacheLink -PrimaryServerName $cacheName2
    Assert-True {$linkGet.Count -eq 0}

    # Get links where server is secondary
    $linkGet = Get-AzureRmRedisCacheLink -SecondaryServerName $cacheName2
    Assert-AreEqual $cacheName1 $linkGet[0].PrimaryServerName
    Assert-AreEqual $cacheName2 $linkGet[0].SecondaryServerName
    $linkGet = Get-AzureRmRedisCacheLink -SecondaryServerName $cacheName1
    Assert-True {$linkGet.Count -eq 0}

    ############################# RemoveAzureRedisCacheLink ############################# 
    Assert-True {Remove-AzureRmRedisCacheLink -PrimaryServerName $cacheName1 -SecondaryServerName $cacheName2 -PassThru} "Removing geo replication link failed."

    # links should disappear in 5 min
    for ($i = 0; $i -le 10; $i++)
    {
        Start-TestSleep 30000
        $linkGet1 = Get-AzureRmRedisCacheLink -PrimaryServerName $cacheName1
        $linkGet2 = Get-AzureRmRedisCacheLink -SecondaryServerName $cacheName2
        if (($linkGet1.Count -eq 0) -and ($linkGet2.Count -eq 0))
        {
            # removal completed successfully 
            break
        }
        Assert-False {$i -eq 10} "Geo replication link deletion is not in succeeded state even after 30 min."
    }

    ############################# CleanUp ############################# 
    # Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName1 -Force -PassThru} "Remove cache failed."
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName2 -Force -PassThru} "Remove cache failed."

    # Delete resource group
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests GetAzureRedisCacheFirewallRule
Tests NewAzureRedisCacheFirewallRule
Tests RemoveAzureRedisCacheFirewallRule
#>
function Test-FirewallRule
{
    # Setup
    $resourceGroupName = "PowerShellTest-8"
    $cacheName = "redisteam008"
    $location = "West US"
    $rule1 = "ruleone"
    $rule1StartIp = "10.0.0.0" 
    $rule1EndIp = "10.0.0.32" 
    $rule2 = "ruletwo"
    $rule2StartIp = "10.0.0.64" 
    $rule2EndIp = "10.0.0.128"
    $rule3 = "rulethree"
    $rule3StartIp = "10.0.0.33" 
    $rule3EndIp = "10.0.0.63" 

    ############################# Initial Creation ############################# 
    # Create resource group
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Sku Premium -Size P1
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    
    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        Start-TestSleep 30000
        $cacheGet = Get-AzureRmRedisCache -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    ############################# NewAzureRedisCacheFirewallRule ############################# 
    # Set firewall rule using parameter
    $rule1Created = New-AzureRmRedisCacheFirewallRule -Name $cacheName -RuleName $rule1 -StartIP $rule1StartIp -EndIP $rule1EndIp
    Assert-AreEqual $rule1StartIp $rule1Created.StartIP
    Assert-AreEqual $rule1EndIp $rule1Created.EndIP
    Assert-AreEqual $rule1 $rule1Created.RuleName

    # Set firewall rule using piping from Get
    $rule2Created = Get-AzureRmRedisCache -Name $cacheName | New-AzureRmRedisCacheFirewallRule -RuleName $rule2 -StartIP $rule2StartIp -EndIP $rule2EndIp
    Assert-AreEqual $rule2StartIp $rule2Created.StartIP
    Assert-AreEqual $rule2EndIp $rule2Created.EndIP
    Assert-AreEqual $rule2 $rule2Created.RuleName

    # Set firewall rule using piping from ResourceId
    $rule3Created = New-AzureRmRedisCacheFirewallRule -ResourceId $cacheCreated.Id -RuleName $rule3 -StartIP $rule3StartIp -EndIP $rule3EndIp
    Assert-AreEqual $rule3StartIp $rule3Created.StartIP
    Assert-AreEqual $rule3EndIp $rule3Created.EndIP
    Assert-AreEqual $rule3 $rule3Created.RuleName

    ############################# GetAzureRedisCacheFirewallRule ############################# 
    # Get single firewall rule
    $rule1Get = Get-AzureRmRedisCacheFirewallRule -Name $cacheName -RuleName $rule1
    Assert-AreEqual $rule1StartIp $rule1Get.StartIP
    Assert-AreEqual $rule1EndIp $rule1Get.EndIP
    Assert-AreEqual $rule1 $rule1Get.RuleName
    
    # Get all firewall rules
    $allRulesGet = Get-AzureRmRedisCacheFirewallRule -Name $cacheName
    for ($i = 0; $i -le 2; $i++)
    {
        if($allRulesGet[$i].RuleName -eq $rule1)
        {
            Assert-AreEqual $rule1StartIp $allRulesGet[$i].StartIP
            Assert-AreEqual $rule1EndIp $allRulesGet[$i].EndIP
        }
        elseif($allRulesGet[$i].RuleName -eq $rule2)
        {
            Assert-AreEqual $rule2StartIp $allRulesGet[$i].StartIP
            Assert-AreEqual $rule2EndIp $allRulesGet[$i].EndIP
        }
        elseif($allRulesGet[$i].RuleName -eq $rule3)
        {
            Assert-AreEqual $rule3StartIp $allRulesGet[$i].StartIP
            Assert-AreEqual $rule3EndIp $allRulesGet[$i].EndIP
        }
        else
        {
            Assert-False $True "unknown firewall rule"
        }
    }
    ############################# RemoveAzureRedisCacheFirewallRule ############################# 
    Assert-True {Remove-AzureRmRedisCacheFirewallRule -Name $cacheName -RuleName $rule1 -PassThru} "Removing firewall rule 'ruleone' failed."

    # Verify that rule is deleted
    $allRulesGet = Get-AzureRmRedisCacheFirewallRule -Name $cacheName
    Assert-AreEqual 2 $allRulesGet.Count
    
    # Remove firewall rules using piping
    Get-AzureRmRedisCacheFirewallRule -Name $cacheName | Remove-AzureRmRedisCacheFirewallRule -PassThru

    # Verify that all rules are deleted
    $allRulesGet = Get-AzureRmRedisCacheFirewallRule -Name $cacheName
    Assert-AreEqual 0 $allRulesGet.Count
    
    ############################# CleanUp ############################# 
    # Delete cache
    Assert-True {Remove-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."

    # Delete resource group
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests redis cache zones.
#>
function Test-Zones
{
    # Setup
    $resourceGroupName = "PowerShellTest-9"
    $cacheName = "redisteam009"
    $location = "East US 2"

    # Create resource group
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating Cache
    $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size P1 -Sku Premium -Zone @("1") -Tag @{"example-key" = "example-value"}
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "6GB" $cacheCreated.Size
    Assert-AreEqual "Premium" $cacheCreated.Sku
    Assert-AreEqual "1" $cacheCreated.Zone[0]
    Assert-AreEqual "example-value" $cacheCreated.Tag.Item("example-key")
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
            Assert-AreEqual "1" $cacheGet[0].Zone[0]
            Assert-AreEqual "example-value" $cacheGet[0].Tag.Item("example-key")
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

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