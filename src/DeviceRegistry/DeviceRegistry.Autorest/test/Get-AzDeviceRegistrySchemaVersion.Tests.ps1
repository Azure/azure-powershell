if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistrySchemaVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistrySchemaVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistrySchemaVersion' {
    It 'List' {
        $testConfig = $env.schemaVersionTests.getTests.List
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema versions for listing
        New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.names[0] -JsonFilePath $jsonFilePath
        New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.names[1] -JsonFilePath $jsonFilePath
        
        $results = Get-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName
        
        $results | Should -Not -BeNullOrEmpty
        $results.Count | Should -BeGreaterOrEqual 2
        $results | Where-Object { $_.Name -eq $testConfig.names[0] } | Should -Not -BeNullOrEmpty
        $results | Where-Object { $_.Name -eq $testConfig.names[1] } | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentitySchemaRegistry' {
        $testConfig = $env.schemaVersionTests.getTests.GetViaIdentitySchemaRegistry
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Get schema registry identity
        $schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -Name $schemaRegistryName
        
        $result = Get-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName $schemaName -Name $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'GetViaIdentitySchema' {
        $testConfig = $env.schemaVersionTests.getTests.GetViaIdentitySchema
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Get schema identity
        $schema = Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -Name $schemaName
        
        $result = Get-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'Get' {
        $testConfig = $env.schemaVersionTests.getTests.Get
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'GetViaIdentity' {
        $testConfig = $env.schemaVersionTests.getTests.GetViaIdentity
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create test schema version
        $created = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Use the created object as identity input
        $result = Get-AzDeviceRegistrySchemaVersion -InputObject $created
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }
}
