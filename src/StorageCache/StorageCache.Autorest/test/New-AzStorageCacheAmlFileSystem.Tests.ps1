if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageCacheAmlFileSystem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageCacheAmlFileSystem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageCacheAmlFileSystem' {
    It 'CreateExpanded' {
        {
            # Create AML filesystem using expanded parameters
            $result = New-AzStorageCacheAmlFileSystem -Name "acctest43511-1" -ResourceGroupName "acctest43511" -Location "canadacentral" -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1
            $result | Should -Not -Be $null
            $result.Name | Should -Be "acctest43511-1"
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            # Create AML filesystem using JSON string
            $jsonString = @"
{
    "location": "canadacentral",
    "properties": {
        "maintenanceWindow": {
            "dayOfWeek": "Saturday",
            "timeOfDayUTC": "03:00"
        },
        "filesystemSubnet": "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511",
        "storageCapacityTiB": 16
    },
    "sku": {
        "name": "AMLFS-Durable-Premium-250"
    },
    "zones": ["1"]
}
"@
            $result = New-AzStorageCacheAmlFileSystem -Name "acctest43511-2" -ResourceGroupName "acctest43511" -JsonString $jsonString
            $result | Should -Not -Be $null
            $result.Name | Should -Be "acctest43511-2"
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            # Create AML filesystem using JSON file path
            $jsonContent = @"
{
    "location": "canadacentral",
    "properties": {
        "maintenanceWindow": {
            "dayOfWeek": "Saturday",
            "timeOfDayUTC": "03:00"
        },
        "filesystemSubnet": "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511",
        "storageCapacityTiB": 16
    },
    "sku": {
        "name": "AMLFS-Durable-Premium-250"
    },
    "zones": ["1"]
}
"@
            $jsonFilePath = Join-Path $PSScriptRoot 'test-create-amlfs.json'
            $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
            $result = New-AzStorageCacheAmlFileSystem -Name "acctest43511-3" -ResourceGroupName "acctest43511" -JsonFilePath $jsonFilePath
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
            $result | Should -Not -Be $null
            $result.Name | Should -Be "acctest43511-3"
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        {
            # Create AML filesystem using identity object
            $identity = @{
                SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
                ResourceGroupName = "acctest43511"
                AmlFilesystemName = "acctest43511-4"
            }
            $result = New-AzStorageCacheAmlFileSystem -InputObject $identity -Location "canadacentral" -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/0a715a3b-8a16-43ba-a6bb-1e38ad050791/resourceGroups/acctest43511/providers/Microsoft.Network/virtualNetworks/acctest43511/subnets/acctest43511" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1
            $result | Should -Not -Be $null
            $result.Name | Should -Be "acctest43511-4"
        } | Should -Not -Throw
    }
}
