if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceDataflowProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceDataflowProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceDataflowProfile' {
    It 'List' {
        $DataflowProfiles = Get-AzIoTOperationsServiceDataflowProfile -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $DataflowProfiles | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $DataflowProfile = Get-AzIoTOperationsServiceDataflowProfile -Name $env.DataflowProfileName -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $DataflowProfile.Name | should -be $env.DataflowProfileName
    }

    It 'GetViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
