if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistrySchemaVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistrySchemaVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistrySchemaVersion' {
    It 'CreateExpanded' {
        $testConfig = $env.schemaVersionTests.createTests.CreateExpanded
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        
        $result = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -Description $commonProperties.description -SchemaContent $commonProperties.schemaContent
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'CreateViaJsonFilePath' {
        $testConfig = $env.schemaVersionTests.createTests.CreateViaJsonFilePath
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        $result = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }

    It 'CreateViaJsonString' {
        $testConfig = $env.schemaVersionTests.createTests.CreateViaJsonString
        $commonProperties = $env.schemaVersionTests.commonProperties
        $schemaRegistryName = $env.schemaVersionTests.schemaRegistryName
        $schemaName = $env.schemaVersionTests.schemaName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonStringFilePath
        $jsonString = Get-Content -Path $jsonFilePath -Raw
        
        $result = New-AzDeviceRegistrySchemaVersion -ResourceGroupName $env.resourceGroup -SchemaRegistryName $schemaRegistryName -SchemaName $schemaName -Name $testConfig.name -JsonString $jsonString
        
        $result.Name | Should -Be $testConfig.name
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaContent | Should -Be $commonProperties.schemaContent
    }
}
