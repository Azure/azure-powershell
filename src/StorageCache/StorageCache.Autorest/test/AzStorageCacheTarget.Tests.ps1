if(($null -eq $TestName) -or ($TestName -contains 'AzStorageCacheTarget'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStorageCacheTarget.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStorageCacheTarget' {
    It 'CreateExpanded' {
        {
            $config = New-AzStorageCacheTarget -CacheName $env.storageCacheName -Name $env.storageCacheTargetName -ResourceGroupName $env.resourceGroup -Nfs3Target "110.0.44.44" -Nfs3UsageModel "READ_WRITE" -Nfs3VerificationTimer 30 -TargetType 'nfs3'
            $config.Name | Should -Be $env.storageCacheTargetName
        } | Should -Not -Throw
    }

    It 'Invalidate' {
        {
            $config = Invoke-AzStorageCacheInvalidateTarget -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup -StorageTargetName $env.storageCacheTargetName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Resume' {
        {
            $config = Resume-AzStorageCacheTarget -CacheName $env.storageCacheName -Name $env.storageCacheTargetName -ResourceGroupName $env.resourceGroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Suspend' {
        {
            $config = Suspend-AzStorageCacheTarget -CacheName $env.storageCacheName -Name $env.storageCacheTargetName -ResourceGroupName $env.resourceGroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Refresh' {
        {
            $config = Update-AzStorageCacheTargetDns -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup -StorageTargetName $env.storageCacheTargetName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'SpaceViaIdentity' {
        {
            $object = New-AzStorageCacheTargetSpaceAllocationObject -AllocationPercentage 100 -Name $env.storageCacheTargetName
            $config = Update-AzStorageCacheSpaceAllocation -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup -SpaceAllocation $object -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Upgrade' {
        {
            $config = Update-AzStorageCacheFirmware -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzStorageCacheTarget -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzStorageCacheTarget -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup -Name $env.storageCacheTargetName
            $config.Name | Should -Be $env.storageCacheTargetName
        } | Should -Not -Throw
    }

    It 'Flush' {
        {
            $config = Clear-AzStorageCacheTarget -CacheName $env.storageCacheName -Name $env.storageCacheTargetName -ResourceGroupName $env.resourceGroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Restore' {
        {
            $config = Restore-AzStorageCacheTargetSetting -CacheName $env.storageCacheName -ResourceGroupName $env.resourceGroup -StorageTargetName $env.storageCacheTargetName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }
}
