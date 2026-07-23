if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryStorageAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryStorageAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryStorageAsset' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -Tag @{ psTest = 'true' } | Out-Null
            $updated = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson"}}'
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-storageasset-test.json'
            '{"tags":{"psTest":"viaJsonFile"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-storageasset-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaIdentityStorageContainerExpanded' {
        $storageContainer = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageAssetContainerName -ErrorAction Stop
        $original = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryStorageAsset -StorageContainerInputObject $storageContainer `
                -Name $env.StorageAssetNameForGet -Tag @{ psTest = 'viaIdentityParent' } | Out-Null
            $updated = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
                -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentityParent'
        }
        finally {
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
                -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet `
                -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryStorageAsset -InputObject $resource -Tag @{ psTest = 'viaIdentity' } | Out-Null
            $updated = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -Tag $originalTags | Out-Null
        }
    }}
