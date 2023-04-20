if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryAgentPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryAgentPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryAgentPool' {
    It 'List' {
        $List = Get-AzContainerRegistryAgentPool -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup
        $List.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $Obj = Get-AzContainerRegistryAgentPool -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -Name $env.rstr1
        $Obj.Name | Should -Be $env.rstr1
    }

    It 'GetViaIdentity' {
        $Obj = Get-AzContainerRegistryAgentPool -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -Name $env.rstr1
        $Res = Get-AzContainerRegistryAgentPool -InputObject $Obj
        $Res.Name | Should -Be $env.rstr1
    }
}
