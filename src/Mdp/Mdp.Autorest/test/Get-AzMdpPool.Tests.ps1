if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMdpPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMdpPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMdpPool' {
    It 'List' {
        $listOfPools = Get-AzMdpPool
        $listOfPools.Count | Should -BeGreaterOrEqual 0
    }

     It 'Get' {
        $pool = Get-AzMdpPool -ResourceGroupName $env.ResourceGroup -Name $env.MdpPoolNameGet
        $pool.Name | Should -Be $env.MdpPoolNameGet
        $pool.MaximumConcurrency | Should -Be 1
    }

    It 'List1' {
        $listOfPools = Get-AzMdpPool -ResourceGroupName $env.ResourceGroup
        $listOfPools.Count | Should -BeGreaterOrEqual 2
    }
}
