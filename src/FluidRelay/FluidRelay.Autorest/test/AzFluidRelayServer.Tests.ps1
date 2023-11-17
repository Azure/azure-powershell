if(($null -eq $TestName) -or ($TestName -contains 'AzFluidRelayServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzFluidRelayServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzFluidRelayServer' {
    It 'CreateExpanded' {
        {
            $config = New-AzFluidRelayServer -Name $env.fluidRelayServer1 -ResourceGroup $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.fluidRelayServer1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzFluidRelayServer
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzFluidRelayServer -ResourceGroup $env.resourceGroup -Name $env.fluidRelayServer1
            $config.Name | Should -Be $env.fluidRelayServer1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzFluidRelayServer -ResourceGroup $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $config = Update-AzFluidRelayServer -ResourceGroup $env.resourceGroup -Name $env.fluidRelayServer1 -Tag @{"Category"="sales"}
            $config.Name | Should -Be $env.fluidRelayServer1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzFluidRelayServer -ResourceGroup $env.resourceGroup -Name $env.fluidRelayServer1
        } | Should -Not -Throw
    }
}
