if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzIoTOperationsServiceDataflowEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzIoTOperationsServiceDataflowEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzIoTOperationsServiceDataflowEndpoint' {
    It 'Delete' {
        $dataflowEndpoint = Remove-AzIoTOperationsServiceDataflowEndpoint `
            -Name $env.newDataflowEndpointName `
            -InstanceName $env.InstanceName `
            -ResourceGroupName $env.ResourceGroup

        $dataflowEndpoint | Should -BeNullOrEmpty

    }

    It 'DeleteViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
