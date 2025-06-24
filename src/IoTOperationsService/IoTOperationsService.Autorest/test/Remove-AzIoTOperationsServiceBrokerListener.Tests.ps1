if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzIoTOperationsServiceBrokerListener'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzIoTOperationsServiceBrokerListener.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzIoTOperationsServiceBrokerListener' {
    It 'Delete' {
        $listener = Remove-AzIoTOperationsServiceBrokerListener -BrokerName $env.BrokerName -InstanceName  $env.InstanceName -ListenerName $env.newBrokerListenerName -ResourceGroupName $env.ResourceGroup
        $listener | Should -BeNullOrEmpty
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
