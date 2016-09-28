<#
.SYNOPSIS
Tests redis cache.
#>
function Test-RedisCache
{
    # Setup
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "powershelltest"
    $location = "North Central US"

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
}


<#
.SYNOPSIS
Tests set redis cache that do not exists.
#>
function Test-SetNonExistingRedisCacheTest
{
    # Setup
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "NonExistingRedisCache"
    $location = "North Central US"

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
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "powershelltestpipe"
    $location = "North Central US"

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
}

<#
.SYNOPSIS
Tests bug fix in set redis cache.
#>
function Test-SetRedisCacheBugFixTest
{
    # Setup
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "siddharthchatrola"
    $location = "North Central US"

    # Updating Cache
    $cacheUpdated = Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -EnableNonSslPort $true
    Assert-True  { $cacheUpdated.EnableNonSslPort }

    $cacheUpdated2 = Set-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RedisConfiguration @{"maxmemory-policy" = "allkeys-lru"} 
    Assert-AreEqual "allkeys-lru" $cacheUpdated2.RedisConfiguration.Item("maxmemory-policy")
    Assert-True  { $cacheUpdated2.EnableNonSslPort }
}

<#
.SYNOPSIS
Tests MaxMemoryPolicy error check
#>
function Test-MaxMemoryPolicyErrorCheck
{
    # Setup
    # resource group should exists
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
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "powershellcluster"
    $location = "East US"

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
}

<#
.SYNOPSIS
Tests SetAzureRedisCacheDiagnostics
#>
function Test-SetAzureRedisCacheDiagnostics
{
    # Setup
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "sunnycache"
    
    # Set Diagnostics
    Set-AzureRmRedisCacheDiagnostics -ResourceGroupName $resourceGroupName -Name $cacheName -StorageAccountId "/subscriptions/f8f8f139-2fd5-4d86-afca-21f21f35806e/resourceGroups/SunnyAAPT6/providers/Microsoft.ClassicStorage/storageAccounts/sunnystoragenew"
}

<#
.SYNOPSIS
Tests RemoveAzureRedisCacheDiagnostics
#>
function Test-RemoveAzureRedisCacheDiagnostics
{
    # Setup
    # resource group should exists
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "sunnycache"
    
    # Set Diagnostics
    Remove-AzureRmRedisCacheDiagnostics -ResourceGroupName $resourceGroupName -Name $cacheName
}

<#
.SYNOPSIS
Tests ResetRMAzureRedisCache
#>
function Test-ResetAzureRmRedisCache
{
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "sunny-reboot"
    $rebootType = "PrimaryNode"
    
    Reset-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -RebootType $rebootType -Force
}

<#
.SYNOPSIS
Tests ExportRMAzureRedisCache
#>
function Test-ExportAzureRmRedisCache
{
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "sunny-importexport"
    $prefix = "sunny"
    $container = "<container sas key>"
    Export-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Prefix $prefix -Container $container
}

<#
.SYNOPSIS
Tests ImportAzureRmRedisCache
#>
function Test-ImportAzureRmRedisCache
{
    $resourceGroupName = "SunnyAAPT6"
    $cacheName = "sunny-importexport"
    $files = @("<blob sas key>")
    Import-AzureRmRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Files $files -Force
}

<#
.SYNOPSIS
Tests schedule patching
#>
function Test-RedisCachePatchSchedules
{
    $resourceGroupName = "SiddharthsSub"
    $cacheName = "sunny-premium"
    
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

    Assert-ThrowsContains {Get-AzureRmRedisCachePatchSchedule -ResourceGroupName $resourceGroupName -Name $cacheName} "There are no patch schedules found for redis cache 'sunny-premium'"
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