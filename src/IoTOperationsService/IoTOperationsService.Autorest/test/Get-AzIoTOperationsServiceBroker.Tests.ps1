if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceBroker'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceBroker.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceBroker' {
    It 'List' {
        $Brokers = Get-AzIoTOperationsServiceBroker -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $Brokers | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $Broker = Get-AzIoTOperationsServiceBroker -Name $env.BrokerName -InstanceName $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $Broker.Name | should -be $env.BrokerName
    }

    It 'GetViaIdentityInstance' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
