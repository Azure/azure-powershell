if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistrySchema'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistrySchema.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistrySchema' {
    It 'UpdateExpanded' {
        $testConfig = $env.schemaTests.updateTests.UpdateExpanded
        $commonProperties = $env.schemaTests.commonProperties
        $commonPatchConfig = $env.schemaTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath

        # Create schema to update
        $createdSchema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Update schema properties
        $result = Update-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -DisplayName $commonPatchConfig.displayName -Description $commonPatchConfig.description -Tag @{$commonPatchConfig.tagsKey = $commonPatchConfig.tagsValue}
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonPatchConfig.tagsKey] | Should -Be $commonPatchConfig.tagsValue
    }

    It 'UpdateViaIdentitySchemaRegistryExpanded' {
        $testConfig = $env.schemaTests.updateTests.UpdateViaIdentitySchemaRegistryExpanded
        $commonProperties = $env.schemaTests.commonProperties
        $commonPatchConfig = $env.schemaTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create schema to update
        $createdSchema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Create schema registry identity object
        $registryIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            SchemaRegistryName = $schemaRegistryName
        }
        
        # Update schema using registry identity
        $result = Update-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name $testConfig.name -DisplayName $commonPatchConfig.displayName -Description $commonPatchConfig.description -Tag @{$commonPatchConfig.tagsKey = $commonPatchConfig.tagsValue}
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonPatchConfig.tagsKey] | Should -Be $commonPatchConfig.tagsValue
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.schemaTests.updateTests.UpdateViaIdentityExpanded
        $commonProperties = $env.schemaTests.commonProperties
        $commonPatchConfig = $env.schemaTests.updateTests.commonPatchConfig
        $schemaRegistryName = $env.schemaTests.schemaRegistryName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        # Create schema to update
        $createdSchema = New-AzDeviceRegistrySchema -ResourceGroupName $env.resourceGroup -RegistryName $schemaRegistryName -Name $testConfig.name -JsonFilePath $jsonFilePath
        
        # Update schema using schema object as identity
        $result = Update-AzDeviceRegistrySchema -InputObject $createdSchema -DisplayName $commonPatchConfig.displayName -Description $commonPatchConfig.description -Tag @{$commonPatchConfig.tagsKey = $commonPatchConfig.tagsValue}
        
        $result.Name | Should -Be $testConfig.name
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
        $result.Description | Should -Be $commonPatchConfig.description
        $result.SchemaType | Should -Be $commonProperties.schemaType
        $result.Format | Should -Be $commonProperties.format
        $result.Tag[$commonPatchConfig.tagsKey] | Should -Be $commonPatchConfig.tagsValue
    }
}
