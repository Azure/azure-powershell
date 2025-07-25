if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzIoTOperationsServiceBrokerAuthorization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzIoTOperationsServiceBrokerAuthorization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzIoTOperationsServiceBrokerAuthorization' {
    It 'Delete' {
        $BrokerAuthz = Remove-AzIoTOperationsServiceBrokerAuthorization `
            -AuthorizationName $env.newBrokerAuthName `
            -BrokerName $env.BrokerName `
            -InstanceName $env.InstanceName `
            -ResourceGroupName $env.ResourceGroup
        
        $BrokerAuthz | Should -BeNullOrEmpty
    }

    It 'DeleteViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityBroker' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
