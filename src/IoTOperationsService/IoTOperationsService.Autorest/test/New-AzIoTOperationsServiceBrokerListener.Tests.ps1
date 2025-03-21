if(($null -eq $TestName) -or ($TestName -contains 'New-AzIoTOperationsServiceBrokerListener'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzIoTOperationsServiceBrokerListener.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzIoTOperationsServiceBrokerListener' {
    It 'CreateExpanded' {
        $listener = New-AzIoTOperationsServiceBrokerListener -ServiceType "LoadBalancer" -BrokerName $env.BrokerName-InstanceName  $env.InstanceName -ListenerName $env.newBrokerListenerName -ResourceGroupName $env.ResourceGroup -ExtendedLocationName  $env.ExtendedLocation  -Port @(@{ port = 1883 })
        $listener | Should -Not -BeNullOrEmpty
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
