if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryStorageContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryStorageContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryStorageContainer' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -Tag @{ psTest = 'true' } | Out-Null
            $updated = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryStorageContainer -InputObject $resource -Tag @{ psTest = 'viaIdentity' } | Out-Null
            $updated = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-storagecontainer-test.json'
            '{"tags":{"psTest":"viaJsonFile"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-storagecontainer-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson"}}'
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -Tag $originalTags | Out-Null
        }
    }}
