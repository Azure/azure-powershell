if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDependencyMapDiscoverySource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDependencyMapDiscoverySource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDependencyMapDiscoverySource' {
    It 'UpdateExpanded' {
        {
            Update-AzDependencyMapDiscoverySource -ResourceGroupName $env.resourceGroup -MapName $env.mapName -SourceName $env.sourceName -Tag @{"key"="value"}
        } | Should -Not -Throw
    }

}
