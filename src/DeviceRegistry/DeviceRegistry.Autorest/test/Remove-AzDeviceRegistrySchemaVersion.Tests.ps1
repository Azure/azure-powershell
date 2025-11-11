if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistrySchemaVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistrySchemaVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistrySchemaVersion' {
    It 'Delete' {
        $testConfig = $env.schemaVersionTests.deleteTests.Delete
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the schema version
        Remove-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name
        
        # Verify deletion by trying to get the resource
        { Get-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentitySchemaRegistry' {
        $testConfig = $env.schemaVersionTests.deleteTests.DeleteViaIdentitySchemaRegistry
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Get schema registry identity
        $schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -Name $schemaRegistryName
        
        # Delete the schema version using schema registry identity
        Remove-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName $schemaName -Name $testConfig.name
        
        # Verify deletion by trying to get the resource
        { Get-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentitySchema' {
        $testConfig = $env.schemaVersionTests.deleteTests.DeleteViaIdentitySchema
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Get schema identity
        $schema = Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -Name $schemaName
        
        # Delete the schema version using schema identity
        Remove-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name $testConfig.name
        
        # Verify deletion by trying to get the resource
        { Get-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.schemaVersionTests.deleteTests.DeleteViaIdentity
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the schema version using its identity
        Remove-AzDeviceRegistrySchemaVersion -InputObject $created
        
        # Verify deletion by trying to get the resource
        { Get-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -ErrorAction Stop } | Should -Throw
    }
}
