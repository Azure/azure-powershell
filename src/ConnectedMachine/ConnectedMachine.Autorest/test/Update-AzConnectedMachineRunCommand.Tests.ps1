if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedMachineRunCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedMachineRunCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConnectedMachineRunCommand' {
    It 'Update' {
        $tags = @{Tag1="tag1"; Tag2="tag2"}
        $runCommand = Update-AzConnectedMachineRunCommand -ResourceGroupName $env.ResourceGroupName -RunCommandName $env.RunCommandName -MachineName $env.MachineName -Subscription $env.SubscriptionId -Tag $tags
        $runCommand.Count | Should -Not -BeNullOrEmpty
    }
}
