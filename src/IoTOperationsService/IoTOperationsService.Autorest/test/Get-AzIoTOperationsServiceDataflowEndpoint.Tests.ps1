if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceDataflowEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceDataflowEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceDataflowEndpoint' {
    It 'List' {
        $DataflowEndpoints = Get-AzIoTOperationsServiceDataflowEndpoint -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $DataflowEndpoints | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $DataflowEndpoint = Get-AzIoTOperationsServiceDataflowEndpoint -Name $env.DataflowEndpointName -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $DataflowEndpoint.Name | should -be $env.DataflowEndpointName
    }

    It 'GetViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
