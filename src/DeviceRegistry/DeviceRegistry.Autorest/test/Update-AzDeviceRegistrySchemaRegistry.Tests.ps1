if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistrySchemaRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistrySchemaRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistrySchemaRegistry' {
    It 'UpdateExpanded' {
        $testConfig = $env.schemaRegistryTests.updateTests.UpdateExpanded
        $commonProperties = $env.schemaRegistryTests.updateTests.commonProperties
        $commonPatchConfig = $env.schemaRegistryTests.updateTests.commonPatchConfig

        # Create schema registry to update
        $createdSchemaRegistry = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl
        
        # Update schema registry properties
        $result = Update-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -DisplayName $commonPatchConfig.displayName -Description $commonPatchConfig.description
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
        $result.Description | Should -Be $commonPatchConfig.description
        $result.Namespace | Should -Be $testConfig.namespace
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.schemaRegistryTests.updateTests.UpdateViaIdentityExpanded
        $commonProperties = $env.schemaRegistryTests.updateTests.commonProperties
        $commonPatchConfig = $env.schemaRegistryTests.updateTests.commonPatchConfig
        
        # Create schema registry to update
        $createdSchemaRegistry = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl
        
        # Update schema registry using schema registry object as identity
        $result = Update-AzDeviceRegistrySchemaRegistry -InputObject $createdSchemaRegistry -DisplayName $commonPatchConfig.displayName -Description $commonPatchConfig.description
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
        $result.Description | Should -Be $commonPatchConfig.description
        $result.Namespace | Should -Be $testConfig.namespace
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }
}
