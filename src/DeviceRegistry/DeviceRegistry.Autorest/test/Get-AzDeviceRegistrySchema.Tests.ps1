if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistrySchema'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistrySchema.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistrySchema' {
    It 'List' {
        $testConfig = $env.schemaTests.getTests.List
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.names[0] -JsonFilePath $jsonFilePath
        New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.names[1] -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName
        
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
        $schemaNames = $result | ForEach-Object { $_.Name }
        $schemaNames | Should -Contain $testConfig.names[0]
        $schemaNames | Should -Contain $testConfig.names[1]
    }

    It 'GetViaIdentitySchemaRegistry' {
        $testConfig = $env.schemaTests.getTests.GetViaIdentitySchemaRegistry
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $createdSchema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        $registryIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            SchemaRegistryName = $schemaRegistryName
        }
        
        $result = Get-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonProperties.tagsKey] | Should -Be $commonProperties.tagsValue
    }

    It 'Get' {
        $testConfig = $env.schemaTests.getTests.Get
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $createdSchema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonProperties.tagsKey] | Should -Be $commonProperties.tagsValue
    }

    It 'GetViaIdentity' {
        $testConfig = $env.schemaTests.getTests.GetViaIdentity
        $commonProperties = $env.schemaTests.commonProperties
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $createdSchema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        $identity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            SchemaRegistryName = $schemaRegistryName
            SchemaName = $testConfig.name
        }
        
        $result = Get-AzDeviceRegistrySchema -InputObject $identity
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonProperties.tagsKey] | Should -Be $commonProperties.tagsValue
    }
}
