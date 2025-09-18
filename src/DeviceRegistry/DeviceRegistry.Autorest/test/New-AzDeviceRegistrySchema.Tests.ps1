if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistrySchema'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistrySchema.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistrySchema' {
    It 'CreateExpanded' {
        $testConfig = $env.schemaTests.createTests.CreateExpanded
        $commonProperties = $env.schemaTests.commonProperties
        $RegistryName = $env.schemaTests.schemaRegistryName
        
        $result = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $RegistryName -Name $testConfig.name -DisplayName $commonProperties.displayName -Description $commonProperties.description -Format $commonProperties.format -Tag @{$commonProperties.tagsKey = $commonProperties.tagsValue}
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonProperties.tagsKey] | Should -Be $commonProperties.tagsValue
    }

    It 'CreateViaJsonFilePath' {
        $testConfig = $env.schemaTests.createTests.CreateViaJsonFilePath
        $commonProperties = $env.schemaTests.commonProperties
        $RegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        $result = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $RegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonProperties.tagsKey] | Should -Be $commonProperties.tagsValue
    }

    It 'CreateViaJsonString' {
        $testConfig = $env.schemaTests.createTests.CreateViaJsonString
        $commonProperties = $env.schemaTests.commonProperties
        $RegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonStringFilePath
        $jsonString = Get-Content -Path $jsonFilePath -Raw
        
        $result = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $RegistryName -Name $testConfig.name -JsonString $jsonString
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonProperties.tagsKey] | Should -Be $commonProperties.tagsValue
    }
}
