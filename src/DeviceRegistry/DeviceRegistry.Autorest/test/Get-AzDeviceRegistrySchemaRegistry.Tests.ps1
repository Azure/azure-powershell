if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistrySchemaRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistrySchemaRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistrySchemaRegistry' {
    It 'List' {
        $testConfig = $env.schemaRegistryTests.getTests.List
        $commonProperties = $env.schemaRegistryTests.getTests.commonProperties

        for ($i = 0; $i -lt $testConfig.namespaces.Count; $i++) {
            New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.names[$i] -Location $env.location -Namespace $testConfig.namespaces[$i] -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl
        }

        $result = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup

        $result.Count -ge 2 | Should -Be $true
    }

    It 'Get' {
        $testConfig = $env.schemaRegistryTests.getTests.Get
        $commonProperties = $env.schemaRegistryTests.getTests.commonProperties
        New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl

        $result = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.ResourceGroupName | Should -Be $env.resourceGroup
        $result.Location | Should -Be $env.location
        $result.Namespace | Should -Be $testConfig.namespace
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }

    It 'GetViaIdentity' {
        $testConfig = $env.schemaRegistryTests.getTests.GetViaIdentity
        $commonProperties = $env.schemaRegistryTests.getTests.commonProperties
        $sr = New-AzDeviceRegistrySchemaRegistry -ResourceGroupName $env.resourceGroup -SchemaRegistryName $testConfig.name -Location $env.location -Namespace $testConfig.namespace -DisplayName $commonProperties.displayName -Description $commonProperties.description -StorageAccountContainerUrl $commonProperties.storageAccountContainerUrl

        $result = Get-AzDeviceRegistrySchemaRegistry -InputObject $sr

        $result.Name | Should -Be $testConfig.name
        $result.ResourceGroupName | Should -Be $env.resourceGroup
        $result.Location | Should -Be $env.location
        $result.Namespace | Should -Be $testConfig.namespace
        $result.DisplayName | Should -Be $commonProperties.displayName
        $result.Description | Should -Be $commonProperties.description
        $result.StorageAccountContainerUrl | Should -Be $commonProperties.storageAccountContainerUrl
    }
}
