if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMissionVirtualEnclave'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMissionVirtualEnclave.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMissionVirtualEnclave' {
    # NOTE: Skipped until a Recording.json is captured against a live Microsoft.Mission preview subscription.
    It 'Get' -skip {
        {
            $enclave = Get-AzMissionVirtualEnclave -Name $env.enclaveName -ResourceGroupName $env.resourceGroup
            $enclave.Name | Should -Be $env.enclaveName
        } | Should -Not -Throw
    }

    It 'List1' -skip {
        {
            $enclaves = Get-AzMissionVirtualEnclave -ResourceGroupName $env.resourceGroup
            $enclaves | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $enclaves = Get-AzMissionVirtualEnclave
            $enclaves | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
