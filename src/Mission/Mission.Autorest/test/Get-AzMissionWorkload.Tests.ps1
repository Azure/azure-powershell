if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMissionWorkload'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMissionWorkload.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMissionWorkload' {
    # NOTE: Skipped until a Recording.json is captured against a live Microsoft.Mission preview subscription.
    It 'Get' -skip {
        {
            $workload = Get-AzMissionWorkload -Name $env.workloadName -ResourceGroupName $env.resourceGroup -VirtualEnclaveName $env.enclaveName
            $workload.Name | Should -Be $env.workloadName
        } | Should -Not -Throw
    }

    It 'List1' -skip {
        {
            $workloads = Get-AzMissionWorkload -ResourceGroupName $env.resourceGroup -VirtualEnclaveName $env.enclaveName
            $workloads | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $workloads = Get-AzMissionWorkload -VirtualEnclaveName $env.enclaveName
            $workloads | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
