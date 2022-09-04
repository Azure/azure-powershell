if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubSchemaGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubSchemaGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubSchemaGroup' {
    It 'CreateExpanded' {
        $schemaGroup = New-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup2 -SchemaCompatibility Forward -SchemaType Avro -GroupProperty @{a='b'}
        $schemaGroup.Name | Should -Be $env.schemaGroup2
        $schemaGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $schemaGroup.SchemaCompatibility | Should -Be "Forward"
        $schemaGroup.SchemaType | Should -Be "Avro"
        $schemaGroup.GroupProperty | Should -Be @{a='b'}
    }
}
