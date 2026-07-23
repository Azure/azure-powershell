if(($null -eq $TestName) -or ($TestName -contains 'Set-AzIoTOperationsServiceBrokerListener'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzIoTOperationsServiceBrokerListener.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzIoTOperationsServiceBrokerListener' {
    It 'UpdateExpanded' {
        $listener = Set-AzIoTOperationsServiceBrokerListener -ServiceType "LoadBalancer" -BrokerName $env.BrokerName -InstanceName  $env.InstanceName -ListenerName $env.newBrokerListenerName -ResourceGroupName $env.ResourceGroup -ExtendedLocationName  $env.ExtendedLocation  -Port @(@{ port = 1883 })
        $listener | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
