if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryStorageContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryStorageContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryStorageContainer' {
    It 'CreateExpanded' -Skip {
        # Skip: autorest codegen did not flatten StorageStoreStorageAccountId into CreateExpanded params.
        # StorageContainer creation requires storageAccountId which is only available via JsonString/JsonFilePath.
    }

    It 'CreateViaJsonFilePath' {
        $jsonPath = Join-Path $PSScriptRoot 'new-storagecontainer-test.json'
        try {
            $env.StorageContainerCreateJson | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
                -Name $env.StorageContainerNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.StorageContainerNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaJsonString' {
        $result = New-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForNew -SubscriptionId $env.SubscriptionId `
            -JsonString $env.StorageContainerCreateJson -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageContainerNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }
}
