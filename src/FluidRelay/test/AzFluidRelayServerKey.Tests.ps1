if(($null -eq $TestName) -or ($TestName -contains 'AzFluidRelayServerKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzFluidRelayServerKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzFluidRelayServerKey' {
    It 'RegenerateExpanded' {
        {
            $config = New-AzFluidRelayServer -Name $env.fluidRelayServer2 -ResourceGroup $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.fluidRelayServer2

            $config = New-AzFluidRelayServerKey -FluidRelayServerName $env.fluidRelayServer2 -ResourceGroup $env.resourceGroup -KeyName 'key1'
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzFluidRelayServerKey -FluidRelayServerName $env.fluidRelayServer2 -ResourceGroup $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
