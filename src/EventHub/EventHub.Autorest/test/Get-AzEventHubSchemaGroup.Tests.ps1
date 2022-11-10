if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubSchemaGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubSchemaGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubSchemaGroup' {
    It 'List' {
        $listOfSchemaGroups = Get-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfSchemaGroups.Count | Should -Be 1
    }

    It 'Get' {
        $schemaGroup = Get-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup
        $schemaGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $schemaGroup.Name | Should -Be $env.schemaGroup
        $schemaGroup.SchemaCompatibility | Should -Be "None"
        $schemaGroup.SchemaType | Should -Be "Avro"
    }

    It 'GetViaIdentity' {
        $schemaGroup = Get-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup
        $schemaGroup = Get-AzEventHubSchemaGroup -InputObject $schemaGroup
        $schemaGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $schemaGroup.Name | Should -Be $env.schemaGroup
        $schemaGroup.SchemaCompatibility | Should -Be "None"
        $schemaGroup.SchemaType | Should -Be "Avro"
    }
}
