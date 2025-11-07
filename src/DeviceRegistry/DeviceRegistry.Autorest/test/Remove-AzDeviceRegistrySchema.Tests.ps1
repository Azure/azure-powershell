if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistrySchema'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistrySchema.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistrySchema' {
    It 'Delete' {
        $testConfig = $env.schemaTests.deleteTests.Delete
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema to delete
        New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the schema
        Remove-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name
        
        # Verify the schema is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentitySchemaRegistry' {
        $testConfig = $env.schemaTests.deleteTests.DeleteViaIdentitySchemaRegistry
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema to delete
        New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Create schema registry identity object
        $registryIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            SchemaRegistryName = $schemaRegistryName
        }
        
        # Delete the schema using registry identity
        Remove-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name $testConfig.name
        
        # Verify the schema is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.schemaTests.deleteTests.DeleteViaIdentity
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema to delete
        $schema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the schema using the schema object as identity
        Remove-AzDeviceRegistrySchema -InputObject $schema
        
        # Verify the schema is deleted by trying to get it using the schema object (should throw)
        { Get-AzDeviceRegistrySchema -InputObject $schema -ErrorAction Stop } | Should -Throw
    }
}
