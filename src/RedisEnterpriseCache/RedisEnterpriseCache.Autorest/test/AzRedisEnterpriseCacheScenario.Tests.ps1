$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzRedisEnterpriseCacheScenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzRedisEnterpriseCache' {
    It 'Create' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            SubscriptionId = $env.SubscriptionId
            Sku = "Balanced_B10"
            MinimumTlsVersion = "1.2"
            #Zone = @("1", "2", "3")
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "OSSCluster"
            EvictionPolicy = "VolatileLRU"
            PublicNetworkAccess = "Enabled"
            AccessKeysAuthentication = "Enabled"
        }
        $cache = New-AzRedisEnterpriseCache @splat -EnableSystemAssignedIdentity -Module "{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RedisBloom, args:`"ERROR_RATE 0.001 INITIAL_SIZE 400`"}"
        $cache.Name | Should -Be $splat.Name
        $cache.Location = $cache.Location.ToLower() -replace '\s', ''
        $cache.Location | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.ResourceState | Should -Be "Running"
        $cache.Zone | Should -Be $splat.Zone
        $cache.Database.Count | Should -Be 1
        $databaseName = "default"
        $cache.Database[$databaseName].Name | Should -Be $databaseName
        $cache.Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
        $cache.Database[$databaseName].ClientProtocol | Should -Be $splat.ClientProtocol
        $cache.Database[$databaseName].ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $cache.Database[$databaseName].EvictionPolicy | Should -Be $splat.EvictionPolicy
        $cache.Database[$databaseName].ProvisioningState | Should -Be "Succeeded"
        $cache.Database[$databaseName].ResourceState | Should -Be "Running"
        $cache.IdentityType | Should -Be "SystemAssigned"
    }

    It 'CreateNoDatabase' {
        $splat = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            SubscriptionId = $env.SubscriptionId
            Sku = "Balanced_B10"
            NoDatabase = $true
            PublicNetworkAccess = "Enabled"
        }
        $cache = New-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be $splat.Name
        $cache.Location = $cache.Location.ToLower() -replace '\s', ''
        $cache.Location | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.ResourceState | Should -Be "Running"
        $cache.Database.Count | Should -Be 0
    }

    It 'Create a cache without a database to create a georeplicated database later' {
        $splat = @{
            Name = $env.ClusterName3
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            SubscriptionId = $env.SubscriptionId
            Sku = "Balanced_B10"
            NoDatabase = $true
            PublicNetworkAccess = "Enabled"
        }
        # Write-Host $splat.Name
        $cache = New-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be $splat.Name
        $cache.Location = $cache.Location.ToLower() -replace '\s', ''
        $cache.Location | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.ResourceState | Should -Be "Running"
        $cache.Database.Count | Should -Be 0
    }

    It 'Create a cache with a georeplicated database' {
        $id = "{{id:`"/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default`"}}"
        $splat = @{
            Name = $env.ClusterName4
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            SubscriptionId = $env.SubscriptionId
            Sku = "Balanced_B10"
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "EnterpriseCluster"
            EvictionPolicy = "NoEviction"
            PublicNetworkAccess = "Enabled"
            AccessKeysAuthentication = "Enabled"
            GroupNickname = "GroupName" 
            LinkedDatabase = $id -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName4
        }
        # Write-Host $splat.Name
        $cache = New-AzRedisEnterpriseCache @splat -Module "{name:RediSearch}"
        $cache.Name | Should -Be $splat.Name
        $cache.Location = $cache.Location.ToLower() -replace '\s', ''
        $cache.Location | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.ResourceState | Should -Be "Running"
        $databaseName = "default"
        $cache.Database[$databaseName].GeoReplicationGroupNickname | Should -Be $splat.GroupNickname
        $id = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName4
        $cache.Database[$databaseName].GeoReplicationLinkedDatabase[0].Id | Should -Be $id
    }
}

Describe 'Get-AzRedisEnterpriseCacheSku' {  
  It 'List' {
      $splat = @{
          ClusterName = $env.ClusterName
          ResourceGroupName = $env.ResourceGroupName
      }
      $skus = Get-AzRedisEnterpriseCacheSku @splat
      $skus | Should -Not -Be $null
      # Check that the SKUs contain the expected names
      $skuNames = $skus | Select-Object -ExpandProperty Name
      $sizes = $skus | Select-Object -ExpandProperty SizeInGb
      $skuNames | Should -Contain 'Balanced_B250'
      $skuNames | Should -Contain 'Balanced_B50'
      $sizes | Should -Contain 240.0
  }
}

Describe 'Update-AzRedisEnterpriseCache' {
    It 'UpdateExpanded' {
        {
            $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterName -ResourceGroupName $env.ResourceGroupName -EnableSystemAssignedIdentity $false
            $cache.IdentityType | Should -be "None"
        } | Should -Not -Throw
    }
}


Describe 'New-AzRedisEnterpriseCacheDatabase' {
    It 'Create' {
        $splat = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
            SubscriptionId = $env.SubscriptionId
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "EnterpriseCluster"
            EvictionPolicy = "AllKeysLFU"
            Port = 10000
            AccessKeysAuthentication = "Enabled"
        }
        $database = New-AzRedisEnterpriseCacheDatabase @splat
        $databaseName = "default"
        $database.Name | Should -Be $databaseName
        $database.Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
        $database.ClientProtocol | Should -Be $splat.ClientProtocol
        $database.ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $database.EvictionPolicy | Should -Be $splat.EvictionPolicy
        $database.Port | Should -Be $splat.Port
        $database.ProvisioningState | Should -Be "Succeeded"
        $database.ResourceState | Should -Be "Running"
    }

    It 'Create a georeplicated database' {
        $idCluster3 = "{{id:`"/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default`"}}" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName3
        $idCluster4 = "{{id:`"/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default`"}}" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName4
        $splat = @{
            Name = $env.ClusterName3
            ResourceGroupName = $env.ResourceGroupName
            SubscriptionId = $env.SubscriptionId
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "EnterpriseCluster"
            EvictionPolicy = "NoEviction"
            AccessKeysAuthentication = "Enabled"
            GroupNickname = "GroupName" 
            LinkedDatabase = $idCluster3,$idCluster4 -join ","
        }
        # Write-Host $splat.Name
        # Write-Host $splat.LinkedDatabase
        $database = New-AzRedisEnterpriseCacheDatabase @splat
        $databaseName = "default"
        # Write-Host ($database | Format-Table | Out-String)
        $database.Name | Should -Be $databaseName
        $database.Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
        $database.ClientProtocol | Should -Be $splat.ClientProtocol
        $database.ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $database.EvictionPolicy | Should -Be $splat.EvictionPolicy
        $database.ProvisioningState | Should -Be "Succeeded"
        $database.ResourceState | Should -Be "Running"
        $database.GeoReplicationGroupNickname | Should -Be $splat.GroupNickname
        $id = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName3
        $database.GeoReplicationLinkedDatabase[0].Id | Should -Be $id
    }

}

Describe 'Get-AzRedisEnterpriseCache' {
    It 'Get' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        $cache = Get-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be $splat.Name
        $cache.Location = $cache.Location.ToLower() -replace '\s', ''
        $cache.Location | Should -Be $env.Location
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $databaseName = "default"
        $cache.Database.Count | Should -Be 1
        $cache.Database[$databaseName].Name | Should -Be $databaseName
        $cache.Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }

    It 'ListByResourceGroup' {
        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
        }
        $caches = Get-AzRedisEnterpriseCache @splat
        $databaseName = "default"

        $caches[0].Location = $caches[0].Location.ToLower() -replace '\s', ''
        $caches[0].Location | Should -Be $env.Location
        $caches[0].Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $caches[0].Database.Count | Should -Be 1
        $caches[0].Database[$databaseName].Name | Should -Be $databaseName
        $caches[0].Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"

        $caches[1].Location = $caches[1].Location.ToLower() -replace '\s', ''
        $caches[1].Location | Should -Be $env.Location
        $caches[1].Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $caches[1].Database.Count | Should -Be 1
        $caches[1].Database[$databaseName].Name | Should -Be $databaseName
        $caches[1].Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }

    It 'ListBySubscriptionId' {
        $null = Get-AzRedisEnterpriseCache
    }
}

Describe 'Get-AzRedisEnterpriseCacheKey' {
    It 'List' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        $databaseKeys = Get-AzRedisEnterpriseCacheKey @splat
        $databaseKeys.PrimaryKey | Should -Not -Be $null
        $databaseKeys.SecondaryKey | Should -Not -Be $null
    }
}

Describe 'Get-AzRedisEnterpriseCacheDatabase' {
    It 'List' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        $databases = Get-AzRedisEnterpriseCacheDatabase @splat
        $databases.Count | Should -Be 1
        $databases[0].Name | Should -Be "default"
        $databases[0].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"

        $splat2 = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
        }
        $databases2 = Get-AzRedisEnterpriseCacheDatabase @splat2
        $databases2.Count | Should -Be 1
        $databases2[0].Name | Should -Be "default"
        $databases2[0].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }
}

Describe 'New-AzRedisEnterpriseCacheAccessPolicyAssignment' {
    # UserobjectId from (Get-AzADUser -SignedIn).Id -> 5dce0ce9-f0a7-437f-aea2-760d05c62ca9
    It 'CreateExpanded' {
        {
            New-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName testPolicy -ClusterName $env.ClusterName -DatabaseName default -ResourceGroupName $env.ResourceGroupName -UserObjectId '5dce0ce9-f0a7-437f-aea2-760d05c62ca9' -AccessPolicyName default
        } | Should -Not -Throw
    }
}


Describe 'Remove-AzRedisEnterpriseCacheAccessPolicyAssignment' {
    It 'Delete' {
        {
            Remove-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName testPolicy -ClusterName $env.ClusterName -DatabaseName default -ResourceGroupName $env.ResourceGroupName
        } | Should -Not -Throw
    }
}

Describe 'New-AzRedisEnterpriseCacheKey' {
    It 'Regenerate' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
            KeyType = "Primary"
        }
        $databaseKeys = New-AzRedisEnterpriseCacheKey @splat
        $databaseKeys.PrimaryKey | Should -Not -Be $null
        $databaseKeys.SecondaryKey | Should -Not -Be $null

        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
            KeyType = "Secondary"
        }
        $databaseKeys = New-AzRedisEnterpriseCacheKey @splat
        $databaseKeys.PrimaryKey | Should -Not -Be $null
        $databaseKeys.SecondaryKey | Should -Not -Be $null
    }
}

Describe 'Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink' {
    $id = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName4
    It 'Force unlink database from group' {
        $splat = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.ResourceGroupName
            ClusterName = $env.ClusterName3
            Id = @($id)
        }
        $database = Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink @splat
    }
}


Describe 'Update-AzRedisEnterpriseCacheDatabaseDbRedisVersion' {
    It 'Upgrade' {
        {
            $cache = Get-AzRedisEnterpriseCacheDatabase -Name $env.ClusterName2 -ResourceGroup $env.ResourceGroupName
            $oldVersion = $cache.RedisVersion
            Update-AzRedisEnterpriseCacheDatabaseDbRedisVersion -ClusterName $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName -DatabaseName "default"
            $newCache = Get-AzRedisEnterpriseCacheDatabase -Name $env.ClusterName2 -ResourceGroup $env.ResourceGroupName
            $newCache.RedisVersion | Should -BeGreaterThan $oldVersion
        } | Should -Not -Throw
    }
}

Describe 'Remove-AzRedisEnterpriseCacheDatabase' {
    It 'Delete' {
        $splat = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
        }
        Remove-AzRedisEnterpriseCacheDatabase @splat
    }
}

Describe 'Remove-AzRedisEnterpriseCache' {
    It 'Delete' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        Remove-AzRedisEnterpriseCache @splat

        $splat2 = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
        }
        Remove-AzRedisEnterpriseCache @splat2
    }
}
