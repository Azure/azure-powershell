if(($null -eq $TestName) -or ($TestName -contains 'Test-AzStorageCacheAmlFileSystemSubnet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzStorageCacheAmlFileSystemSubnet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzStorageCacheAmlFileSystemSubnet' {
    It 'CheckExpanded' {
        {
            # Test subnet validation using expanded parameters
            $result = Test-AzStorageCacheAmlFileSystemSubnet -Location "canadacentral" -Name "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -PassThru
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }

    It 'CheckViaJsonString' {
        {
            # Test subnet validation using JSON string
            $jsonString = @"
{
    "location": "canadacentral",
    "filesystemSubnet": "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511",
    "sku": {
        "name": "AMLFS-Durable-Premium-250"
    },
    "storageCapacityTiB": 16
}
"@
            $result = Test-AzStorageCacheAmlFileSystemSubnet -JsonString $jsonString -PassThru
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }

    It 'CheckViaJsonFilePath' {
        {
            # Test subnet validation using JSON file path
            $jsonContent = @"
{
    "location": "canadacentral",
    "filesystemSubnet": "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511",
    "sku": {
        "name": "AMLFS-Durable-Premium-250"
    },
    "storageCapacityTiB": 16
}
"@
            $jsonFilePath = Join-Path $PSScriptRoot 'test-subnet-validation.json'
            $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
            $result = Test-AzStorageCacheAmlFileSystemSubnet -JsonFilePath $jsonFilePath -PassThru
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }
}
