if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryStorageAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryStorageAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryStorageAsset' {
    It 'Delete' {
        Remove-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForDel -SubscriptionId $env.SubscriptionId -Confirm:$false
        { Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForDel -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentityStorageContainer' {
        $storageContainer = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        Remove-AzDiscoveryStorageAsset -StorageContainerInputObject $storageContainer `
            -Name $env.StorageAssetNameForDelViaPar -Confirm:$false
        { Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForDelViaPar -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' {
        $identity = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForDelViaId -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $identity | Remove-AzDiscoveryStorageAsset -Confirm:$false
        { Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForDelViaId -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
