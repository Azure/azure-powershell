if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceBrokerAuthentication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceBrokerAuthentication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceBrokerAuthentication' {
    It 'List' {
        $BrokerAuthns = Get-AzIoTOperationsServiceBrokerAuthentication -BrokerName $env.BrokerName -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $BrokerAuthns | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityBroker' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $BrokerAuthn = Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName $env.BrokerAuthenticationName -InstanceName $env.InstanceName -BrokerName $env.BrokerName -ResourceGroupName $env.ResourceGroup
        $BrokerAuthn.Name | should -be $env.BrokerAuthenticationName
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
