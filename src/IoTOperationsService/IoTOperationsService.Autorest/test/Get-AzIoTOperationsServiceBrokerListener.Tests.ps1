if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceBrokerListener'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceBrokerListener.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceBrokerListener' {
    It 'List' {
        $BrokerListeners = Get-AzIoTOperationsServiceBrokerListener -BrokerName $env.BrokerName -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $BrokerListeners | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $BrokerListener = Get-AzIoTOperationsServiceBrokerListener -ListenerName $env.BrokerListenerName -InstanceName $env.InstanceName -BrokerName $env.BrokerName -ResourceGroupName $env.ResourceGroup
        $BrokerListener.Name | should -be $env.BrokerListenerName
    }

    It 'GetViaIdentityBroker' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
