if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedMachine' {
    It 'List' {
        $machine = Get-AzConnectedMachine
        $machine | Should -Not -Be $null
    }

    It 'Get' {
        $machine = Get-AzConnectedMachine -Name $env.MachineName -ResourceGroupName $env.ResourceGroupName
        $machine | Should -Not -Be $null
    }
}
