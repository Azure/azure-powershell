if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceBrokerAuthorization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceBrokerAuthorization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceBrokerAuthorization' {
    It 'List' {
        $BrokerAuthzs = Get-AzIoTOperationsServiceBrokerAuthorization -BrokerName $env.BrokerName -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $BrokerAuthzs | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityBroker' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        $BrokerAuthz = Get-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName $env.BrokerAuthorizationName -InstanceName $env.InstanceName -BrokerName $env.BrokerName -ResourceGroupName $env.ResourceGroup
        $BrokerAuthz.Name | should -be $env.BrokerAuthorizationName
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
