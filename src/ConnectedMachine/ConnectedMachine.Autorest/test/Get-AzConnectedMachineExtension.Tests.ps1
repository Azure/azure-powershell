if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedMachineExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachineExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedMachineExtension' {
    It 'Get' {
        $all = @(Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $env.MachineName -Name $env.ExtensionName)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'List' {
        $all = @(Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $env.MachineName)
        $all | Should -Not -BeNullOrEmpty
    }
}
