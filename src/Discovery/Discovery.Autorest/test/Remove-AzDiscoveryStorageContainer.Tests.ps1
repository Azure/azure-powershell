if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryStorageContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryStorageContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryStorageContainer' {
    It 'Delete' {
        Remove-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForDel -SubscriptionId $env.SubscriptionId -Confirm:$false
        { Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForDel -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' {
        $identity = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForDelViaId -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $identity | Remove-AzDiscoveryStorageContainer -Confirm:$false
        { Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForDelViaId -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
