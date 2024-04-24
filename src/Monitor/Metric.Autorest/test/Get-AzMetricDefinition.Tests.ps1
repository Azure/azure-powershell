if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMetricDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMetricDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMetricDefinition' {
    It 'List'  {
        {
            $definitionResultRegion = Get-AzMetricDefinition -Region eastus2euap -MetricNamespace "Microsoft.Storage/storageAccounts"
            $definitionResultRegion.Count | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $definitionResultResource = Get-AzMetricDefinition -ResourceUri $env.resourceId
            $definitionResultResource.Count | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }
}
