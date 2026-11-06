if (($null -eq $TestName) -or ($TestName -contains 'ManagementApiUpgrade.ContextCache')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $script:TestRecordingFile = Join-Path $PSScriptRoot 'ManagementApiUpgrade.ContextCache.Recording.json'
    $currentPath = $PSScriptRoot
    $mockingPath = $null
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Filter 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
        if (-not $mockingPath -and -not $currentPath) {
            throw 'Cannot find the Storage recording support module.'
        }
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ManagementApiUpgrade.ContextCache' {
    foreach ($identityMode in @('SystemAssigned', 'UserAssigned', 'SystemAssigned,UserAssigned')) {
        It "Runs the context cache lifecycle with $identityMode identity" {
            $scope = @{
                ResourceGroupName = Get-StorageManagementFixture ResourceGroupName
                SubscriptionId = Get-StorageManagementFixture SubscriptionId
            }
            $namePrefix = Get-StorageManagementFixture ContextCacheNamePrefix
            $name = $namePrefix + '-' + $identityMode.Replace('SystemAssigned', 's').Replace('UserAssigned', 'u').Replace(',', '')
            $parameters = @{
                Name = $name
                Location = Get-StorageManagementFixture Location
                AccountKind = 'Regional'
                EnableSystemAssignedIdentity = $identityMode.Contains('SystemAssigned')
                Tag = @{ purpose = 'recording' }
            }
            if ($identityMode.Contains('UserAssigned')) {
                $parameters.UserAssignedIdentity = @(Get-StorageManagementFixture UserAssignedIdentityResourceId)
            }
            $created = $false
            try {
                (Test-AzStorageContextCacheNameAvailability -Name $name -SubscriptionId $scope.SubscriptionId).NameAvailable | Should -Be $true
                $cache = New-AzStorageContextCache @scope @parameters -ErrorAction Stop
                $created = $true
                $cache.IdentityType.Replace(' ', '') | Should -Be $identityMode
                $cache.Tag['purpose'] | Should -Be 'recording'
                if ($identityMode.Contains('UserAssigned')) {
                    $cache.IdentityUserAssignedIdentity.Keys | Should -Contain $parameters.UserAssignedIdentity[0]
                }
                (Test-AzStorageContextCacheNameAvailability -Name $name -SubscriptionId $scope.SubscriptionId).NameAvailable | Should -Be $false

                $cache = Update-AzStorageContextCache @scope -Name $name -Description updated -ErrorAction Stop
                $cache.Description | Should -Be 'updated'
                $cache.IdentityType.Replace(' ', '') | Should -Be $identityMode
                if ($identityMode.Contains('UserAssigned')) {
                    $cache.IdentityUserAssignedIdentity.Keys | Should -Contain $parameters.UserAssignedIdentity[0]
                }
                (Get-AzStorageContextCache @scope -Name $name).Name | Should -Be $name
                @(Get-AzStorageContextCache @scope | Where-Object Name -EQ $name).Count | Should -Be 1
                @(Get-AzStorageContextCache -SubscriptionId $scope.SubscriptionId | Where-Object Name -EQ $name).Count | Should -Be 1

                if ($identityMode -eq 'SystemAssigned') {
                    $null = Set-AzStorageContextCache @scope @parameters -Description replaced -ErrorAction Stop
                    $containerScope = @{
                        ResourceGroupName = $scope.ResourceGroupName
                        SubscriptionId = Get-StorageManagementFixture SubscriptionId
                        ContextCacheName = $name
                        Name = 'recording-container'
                    }
                    $modelName = Get-StorageManagementFixture ModelName
                    $container = New-AzStorageContextCacheContainer @containerScope -ModelName $modelName -ErrorAction Stop
                    $container.Provider | Should -Be 'OpenAI'
                    $container.ModelName | Should -Be $modelName
                    $container.TimeToLive | Should -Be 1
                    $container = Set-AzStorageContextCacheContainer @containerScope -ModelName $modelName -TimeToLive 30 -ErrorAction Stop
                    $container.TimeToLive | Should -Be 30
                    $container = Update-AzStorageContextCacheContainer @containerScope -TimeToLive 1 -ErrorAction Stop
                    $container.TimeToLive | Should -Be 1
                    $container.ModelName | Should -Be $modelName
                    (Get-AzStorageContextCacheContainer @containerScope).Provider | Should -Be 'OpenAI'
                    @(Get-AzStorageContextCacheContainer @scope -ContextCacheName $name).Count | Should -Be 1
                    foreach ($command in @('New-AzStorageContextCacheContainer', 'Set-AzStorageContextCacheContainer', 'Update-AzStorageContextCacheContainer')) {
                        foreach ($ttl in @(0, 31)) {
                            $invalid = $containerScope.Clone()
                            $invalid.TimeToLive = $ttl
                            if (-not $command.StartsWith('Update-')) {
                                $invalid.ModelName = $modelName
                            }
                            { & $command @invalid -ErrorAction Stop } | Should -Throw 'TimeToLive'
                        }
                    }
                    Remove-AzStorageContextCacheContainer @containerScope -Confirm:$false -ErrorAction Stop
                    @(Get-AzStorageContextCacheContainer @scope -ContextCacheName $name).Count | Should -Be 0
                }
            } finally {
                if ($created) {
                    Remove-AzStorageContextCache @scope -Name $name -Confirm:$false -ErrorAction Stop
                }
            }
            { Get-AzStorageContextCache @scope -Name $name -ErrorAction Stop } | Should -Throw 'ResourceNotFound'
        }
    }
}
