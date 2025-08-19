if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDependencyMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDependencyMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDependencyMap' {
    It 'UpdateExpanded' {
        {
            Update-AzDependencyMap -ResourceGroupName $env.resourceGroup -Name $env.mapName -Tag @{"key"="value"}
        } | Should -Not -Throw
    }

}
