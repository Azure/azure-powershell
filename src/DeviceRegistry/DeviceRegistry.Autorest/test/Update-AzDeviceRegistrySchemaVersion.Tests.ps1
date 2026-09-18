if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistrySchemaVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistrySchemaVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistrySchemaVersion' {
    It 'UpdateExpanded' {
        $testConfig = $env.schemaVersionTests.updateTests.UpdateExpanded
        $commonProperties = $env.schemaVersionTests.commonProperties
        $commonPatchConfig = $env.schemaVersionTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        $result = Update-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -Description $commonPatchConfig.description
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'UpdateViaIdentitySchemaRegistryExpanded' {
        $testConfig = $env.schemaVersionTests.updateTests.UpdateViaIdentitySchemaRegistryExpanded
        $commonProperties = $env.schemaVersionTests.commonProperties
        $commonPatchConfig = $env.schemaVersionTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Get schema registry identity
        $schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -Name $schemaRegistryName
        
        $result = Update-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName $schemaName -Name $testConfig.name -Description $commonPatchConfig.description
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'UpdateViaIdentitySchemaExpanded' {
        $testConfig = $env.schemaVersionTests.updateTests.UpdateViaIdentitySchemaExpanded
        $commonProperties = $env.schemaVersionTests.commonProperties
        $commonPatchConfig = $env.schemaVersionTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Get schema identity
        $schema = Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -Name $schemaName
        
        $result = Update-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name $testConfig.name -Description $commonPatchConfig.description
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.schemaVersionTests.updateTests.UpdateViaIdentityExpanded
        $commonProperties = $env.schemaVersionTests.commonProperties
        $commonPatchConfig = $env.schemaVersionTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        $result = Update-AzDeviceRegistrySchemaVersion -InputObject $created -Description $commonPatchConfig.description
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }
}
