if(($null -eq $TestName) -or ($TestName -contains 'New-AzDependencyMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDependencyMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDependencyMap' {
    It 'CreateExpanded' {
        {
            $dm = New-AzDependencyMap -Name $env.mapNameForCreation -ResourceGroupName $env.resourceGroup -Location $env.location
            $dm.Name | Should -Be $env.mapNameForCreation
        } | Should -Not -Throw
    }

}
