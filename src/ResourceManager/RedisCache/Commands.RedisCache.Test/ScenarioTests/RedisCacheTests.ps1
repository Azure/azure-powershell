<#
.SYNOPSIS
Tests redis cache.
#>
function Test-RedisCache
{
    # Setup
    # resource group should exists
    $resourceGroupName = "MyResourceGroup"
    $cacheName = "powershelltest"
    $location = "North Central US"
	
    # Creating Cache
    $cacheCreated = New-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 250MB -Sku Basic
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "2.8" $cacheCreated.RedisVersion
    Assert-AreEqual "250MB" $cacheCreated.Size
    Assert-AreEqual "Basic" $cacheCreated.Sku
    
    Assert-NotNull $cacheCreated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheCreated.SecondaryKey "SecondaryKey do not exists"

    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		$cacheGet = Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            Assert-AreEqual $location $cacheGet[0].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cacheGet[0].Type
            Assert-AreEqual $resourceGroupName $cacheGet[0].ResourceGroupName
    
            Assert-AreEqual 6379 $cacheGet[0].Port
            Assert-AreEqual 6380 $cacheGet[0].SslPort
            Assert-AreEqual "succeeded" $cacheGet[0].ProvisioningState
            Assert-AreEqual "2.8" $cacheGet[0].RedisVersion
            Assert-AreEqual "250MB" $cacheGet[0].Size
            Assert-AreEqual "Basic" $cacheGet[0].Sku
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }

    # Updating Cache
    $cacheUpdated = Set-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -MaxMemoryPolicy AllKeysLRU -EnableNonSslPort $false
    
    Assert-AreEqual $cacheName $cacheUpdated.Name
    Assert-AreEqual $location $cacheUpdated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheUpdated.Type
    Assert-AreEqual $resourceGroupName $cacheUpdated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheUpdated.Port
    Assert-AreEqual 6380 $cacheUpdated.SslPort
    Assert-AreEqual "succeeded" $cacheUpdated.ProvisioningState
    Assert-AreEqual "2.8" $cacheUpdated.RedisVersion
    Assert-AreEqual "250MB" $cacheUpdated.Size
    Assert-AreEqual "Basic" $cacheUpdated.Sku
    Assert-AreEqual "AllKeysLRU" $cacheUpdated.MaxMemoryPolicy.Replace("-", "")
    Assert-False  { $cacheUpdated.EnableNonSslPort }
	
    Assert-NotNull $cacheUpdated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheUpdated.SecondaryKey "SecondaryKey do not exists"

    # List all cache in resource group
    $cachesInResourceGroup = Get-AzureRedisCache -ResourceGroupName $resourceGroupName
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
            Assert-AreEqual "2.8" $cachesInResourceGroup[$i].RedisVersion
            Assert-AreEqual "250MB" $cachesInResourceGroup[$i].Size
            Assert-AreEqual "Basic" $cachesInResourceGroup[$i].Sku
            break
        }
    }
    Assert-True {$found -eq 1} "Cache created earlier is not found."

    # List all cache in subscription
    $cachesInSubscription = Get-AzureRedisCache
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
            Assert-AreEqual "2.8" $cachesInSubscription[$i].RedisVersion
            Assert-AreEqual "250MB" $cachesInSubscription[$i].Size
            Assert-AreEqual "Basic" $cachesInSubscription[$i].Sku
            break
        }
    }
    Assert-True {$found -eq 1} "Cache created earlier is not found."

    # Get cache keys
    $cacheKeysBeforeUpdate = Get-AzureRedisCacheKey -ResourceGroupName $resourceGroupName -Name $cacheName 
    Assert-NotNull $cacheKeysBeforeUpdate.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheKeysBeforeUpdate.SecondaryKey "SecondaryKey do not exists"

    # Regenerate primary key
    $cacheKeysAfterUpdate = New-AzureRedisCacheKey -ResourceGroupName $resourceGroupName -Name $cacheName -KeyType Primary -Force
    Assert-AreEqual $cacheKeysBeforeUpdate.SecondaryKey $cacheKeysAfterUpdate.SecondaryKey
    Assert-AreNotEqual $cacheKeysBeforeUpdate.PrimaryKey $cacheKeysAfterUpdate.PrimaryKey

    # Delete cache
    Assert-True {Remove-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Force -PassThru} "Remove cache failed."
}


<#
.SYNOPSIS
Tests set redis cache that do not exists.
#>
function Test-SetNonExistingRedisCacheTest
{
    # Setup
    # resource group should exists
    $resourceGroupName = "MyResourceGroup"
    $cacheName = "NonExistingRedisCache"
    $location = "North Central US"
	
    # Creating Cache
    Assert-Throws {Set-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -MaxMemoryPolicy AllKeysLRU}
}

<#
.SYNOPSIS
Tests creating redis cache that already exists.
#>
function Test-CreateExistingRedisCacheTest
{
    # Setup
    # resource group should exists
    $resourceGroupName = "MyResourceGroup"
    $cacheName = "myportalcache"
    $location = "North Central US"
	
    # Creating Cache
    Assert-ThrowsContains {New-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 250MB -Sku Standard} "already exists"
}

<#
.SYNOPSIS
Tests redis cache.
#>
function Test-RedisCachePipeline
{
    # Setup
    # resource group should exists
    $resourceGroupName = "MyResourceGroup"
    $cacheName = "powershelltestpipe"
    $location = "North Central US"
	
    # Creating Cache
    $cacheCreated = New-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName -Location $location -Size 250MB -Sku Basic -EnableNonSslPort $false
    
    Assert-AreEqual $cacheName $cacheCreated.Name
    Assert-AreEqual $location $cacheCreated.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheCreated.Type
    Assert-AreEqual $resourceGroupName $cacheCreated.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheCreated.Port
    Assert-AreEqual 6380 $cacheCreated.SslPort
    Assert-AreEqual "creating" $cacheCreated.ProvisioningState
    Assert-AreEqual "2.8" $cacheCreated.RedisVersion
    Assert-AreEqual "250MB" $cacheCreated.Size
    Assert-AreEqual "Basic" $cacheCreated.Sku
    Assert-False { $cacheCreated.EnableNonSslPort }
    
    Assert-NotNull $cacheCreated.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheCreated.SecondaryKey "SecondaryKey do not exists"

    # In loop to check if cache exists
    for ($i = 0; $i -le 60; $i++)
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		$cacheGet = Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName
        if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
        {
            Assert-AreEqual $cacheName $cacheGet[0].Name
            Assert-AreEqual $location $cacheGet[0].Location
            Assert-AreEqual "Microsoft.Cache/Redis" $cacheGet[0].Type
            Assert-AreEqual $resourceGroupName $cacheGet[0].ResourceGroupName
    
            Assert-AreEqual 6379 $cacheGet[0].Port
            Assert-AreEqual 6380 $cacheGet[0].SslPort
            Assert-AreEqual "succeeded" $cacheGet[0].ProvisioningState
            Assert-AreEqual "2.8" $cacheGet[0].RedisVersion
            Assert-AreEqual "250MB" $cacheGet[0].Size
            Assert-AreEqual "Basic" $cacheGet[0].Sku
            break
        }
        Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
    }
	
    # Updating Cache using pipeline
    Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Set-AzureRedisCache -MaxMemoryPolicy AllKeysRandom -EnableNonSslPort $true
    $cacheUpdatedPiped = Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName 
    
    Assert-AreEqual $cacheName $cacheUpdatedPiped.Name
    Assert-AreEqual $location $cacheUpdatedPiped.Location
    Assert-AreEqual "Microsoft.Cache/Redis" $cacheUpdatedPiped.Type
    Assert-AreEqual $resourceGroupName $cacheUpdatedPiped.ResourceGroupName
    
    Assert-AreEqual 6379 $cacheUpdatedPiped.Port
    Assert-AreEqual 6380 $cacheUpdatedPiped.SslPort
    Assert-AreEqual "succeeded" $cacheUpdatedPiped.ProvisioningState
    Assert-AreEqual "2.8" $cacheUpdatedPiped.RedisVersion
    Assert-AreEqual "250MB" $cacheUpdatedPiped.Size
    Assert-AreEqual "Basic" $cacheUpdatedPiped.Sku
    Assert-AreEqual "AllKeysRandom" $cacheUpdatedPiped.MaxMemoryPolicy.Replace("-", "")
    Assert-True  { $cacheUpdatedPiped.EnableNonSslPort } 
    
    # Get cache keys
    $cacheKeysBeforeUpdate = Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Get-AzureRedisCacheKey
    Assert-NotNull $cacheKeysBeforeUpdate.PrimaryKey "PrimaryKey do not exists"
    Assert-NotNull $cacheKeysBeforeUpdate.SecondaryKey "SecondaryKey do not exists"

    # Regenerate primary key
    $cacheKeysAfterUpdate = Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | New-AzureRedisCacheKey -KeyType Primary -Force
    Assert-AreEqual $cacheKeysBeforeUpdate.SecondaryKey $cacheKeysAfterUpdate.SecondaryKey
    Assert-AreNotEqual $cacheKeysBeforeUpdate.PrimaryKey $cacheKeysAfterUpdate.PrimaryKey

    # Delete cache
    Assert-True {Get-AzureRedisCache -ResourceGroupName $resourceGroupName -Name $cacheName | Remove-AzureRedisCache -Force -PassThru} "Remove cache failed."
}