if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDependencyMapDiscoverySource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDependencyMapDiscoverySource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDependencyMapDiscoverySource' {
    It 'List' {
        {
            $dmSource = Get-AzDependencyMapDiscoverySource -ResourceGroupName $env.resourceGroup -MapName $env.mapName
            $dmSource.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $dmSource = Get-AzDependencyMapDiscoverySource -ResourceGroupName $env.resourceGroup -MapName $env.mapName -SourceName $env.sourceName
            $dmSource.Name | Should -Be $env.sourceName
        } | Should -Not -Throw
    }
}
