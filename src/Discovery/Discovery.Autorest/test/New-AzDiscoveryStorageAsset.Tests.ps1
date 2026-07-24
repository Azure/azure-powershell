if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryStorageAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryStorageAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryStorageAsset' {
    It 'CreateExpanded' {
        $result = New-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForNew -SubscriptionId $env.SubscriptionId `
            -Location $env.location -Path 'pstest-data' -Description 'PowerShell test storage asset' `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageAssetNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonString' {
        $json = '{"location":"' + $env.location + '","properties":{"path":"pstest-data-json","description":"PS test via JSON"}}'
        $result = New-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $env.StorageAssetNameForNewJson -SubscriptionId $env.SubscriptionId `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageAssetNameForNewJson
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' {
        $jsonPath = Join-Path $PSScriptRoot 'new-storageasset-test.json'
        try {
            $json = '{"location":"' + $env.location + '","properties":{"path":"pstest-data-jsonfile","description":"PS test via JSON file"}}'
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
                -StorageContainerName $env.StorageContainerNameForGet `
                -Name $env.StorageAssetNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.StorageAssetNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaIdentityStorageContainerExpanded' {
        $storageContainer = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.StorageContainerNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = New-AzDiscoveryStorageAsset -StorageContainerInputObject $storageContainer `
            -Name $env.StorageAssetNameForNewViaPar `
            -Location $env.location -Path 'pstest-data-viapar' -Description 'PS test via identity parent' `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageAssetNameForNewViaPar
    }
}
