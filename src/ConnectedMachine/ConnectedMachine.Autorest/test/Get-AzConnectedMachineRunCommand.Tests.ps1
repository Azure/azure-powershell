if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedMachineRunCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachineRunCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedMachineRunCommand' {
    It 'List' {
        $runCommand = Get-AzConnectedMachineRunCommand -ResourceGroupName $env.ResourceGroupName -MachineName $env.MachineName
        $runCommand.Count | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $runCommand = Get-AzConnectedMachineRunCommand -ResourceGroupName $env.ResourceGroupName -RunCommandName $env.RunCommandName -MachineName $env.MachineName
        $runCommand.Count | Should -Not -BeNullOrEmpty
    }
}
