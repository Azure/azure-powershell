if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDependencyMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDependencyMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDependencyMap' {
    It 'List1' {
        {
            $dm = Get-AzDependencyMap -ResourceGroupName $env.resourceGroup
            $dm.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $dm = Get-AzDependencyMap -ResourceGroupName $env.resourceGroup -MapName $env.mapName
            $dm.Name | Should -Be $env.mapName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $dm = Get-AzDependencyMap
            $dm.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

}
