if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringMonitoringSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringMonitoringSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringMonitoringSetting' {
    It 'Get' {
        { 
            Get-AzSpringMonitoringSetting -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Update-AzSpringMonitoringSetting -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        } | Should -Not -Throw
    }
}
