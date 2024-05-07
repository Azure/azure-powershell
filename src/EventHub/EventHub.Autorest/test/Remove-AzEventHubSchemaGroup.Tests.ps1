if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubSchemaGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubSchemaGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubSchemaGroup' {
    It 'Delete'  {
        Remove-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup2
        { Get-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup2 -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $schemaGroup = Get-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup3
        Remove-AzEventHubSchemaGroup -InputObject $schemaGroup
        { Get-AzEventHubSchemaGroup -InputObject $schemaGroup -ErrorAction Stop } | Should -Throw
    }
}
