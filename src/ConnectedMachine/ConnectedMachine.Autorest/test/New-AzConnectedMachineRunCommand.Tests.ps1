if(($null -eq $TestName) -or ($TestName -contains 'New-AzConnectedMachineRunCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedMachineRunCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConnectedMachineRunCommand' {
    It 'Create' {
        $runCommand = New-AzConnectedMachineRunCommand -ResourceGroupName $env.ResourceGroupName -Location $env.Location -SourceScript $env.Script -RunCommandName $env.RunCommandName -MachineName $env.MachineName -Subscription $env.SubscriptionId
        $runCommand.Count | Should -Not -BeNullOrEmpty
    }
}
