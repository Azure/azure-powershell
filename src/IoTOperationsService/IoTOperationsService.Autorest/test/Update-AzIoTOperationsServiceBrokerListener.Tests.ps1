if(($null -eq $TestName) -or ($TestName -contains 'Update-AzIoTOperationsServiceBrokerListener'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzIoTOperationsServiceBrokerListener.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzIoTOperationsServiceBrokerListener' {
    It 'UpdateExpanded' {
        $listener = Update-AzIoTOperationsServiceBrokerListener -ServiceType "LoadBalancer" -BrokerName $env.BrokerName -InstanceName  $env.InstanceName -ListenerName $env.newBrokerListenerName -ResourceGroupName $env.ResourceGroup  -Port @(@{ port = 1883 })
        $listener | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaIdentityInstanceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityBrokerExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
