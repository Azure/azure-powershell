if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistrySchemaRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistrySchemaRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistrySchemaRegistry' {
    It 'CreateExpanded' {
        $testConfig = $env.schemaRegistryTests.createTests.CreateExpanded
        $commonProperties = $env.schemaRegistryTests.createTests.commonProperties

        $result = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.Namespace | Should -Be $testConfig.namespace
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }

    It 'CreateViaJsonFilePath' {
        $testConfig = $env.schemaRegistryTests.createTests.CreateViaJsonFilePath
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $commonProperties = $env.schemaRegistryTests.createTests.commonProperties
        
        $result = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -JsonFilePath $jsonFilePath
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.Namespace | Should -Be $testConfig.namespace
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }

    It 'CreateViaJsonString' {
        $testConfig = $env.schemaRegistryTests.createTests.CreateViaJsonString
        $commonProperties = $env.schemaRegistryTests.createTests.commonProperties
        $jsonObject = @{
            location = $env.location
            properties = @{
                namespace = $testConfig.namespace
                displayName = $commonProperties.displayName
                description = $commonProperties.description
                storageAccountContainerUrl = $commonProperties.storageAccountContainerUrl
            }
        }
        $jsonString = $jsonObject | ConvertTo-Json -Depth 10
        
        $result = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -JsonString $jsonString
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.Namespace | Should -Be $testConfig.namespace
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }
}
