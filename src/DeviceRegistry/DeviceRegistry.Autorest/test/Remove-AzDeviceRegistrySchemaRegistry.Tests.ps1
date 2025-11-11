if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistrySchemaRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistrySchemaRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistrySchemaRegistry' {
    It 'Delete' {
        $testConfig = $env.schemaRegistryTests.deleteTests.Delete
        $commonProperties = $env.schemaRegistryTests.deleteTests.commonProperties
        
        # Create test schema registry to delete
        New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl
        
        # Delete the schema registry
        Remove-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name
        
        # Verify the schema registry is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.schemaRegistryTests.deleteTests.DeleteViaIdentity
        $commonProperties = $env.schemaRegistryTests.deleteTests.commonProperties
        
        # Create test schema registry to delete
        $schemaRegistry = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl
        
        # Delete the schema registry using the schema registry object as identity
        Remove-AzDeviceRegistrySchemaRegistry -InputObject $schemaRegistry
        
        # Verify the schema registry is deleted by trying to get it using the schema registry object (should throw)
        { Get-AzDeviceRegistrySchemaRegistry -InputObject $schemaRegistry -ErrorAction Stop } | Should -Throw
    }
}
