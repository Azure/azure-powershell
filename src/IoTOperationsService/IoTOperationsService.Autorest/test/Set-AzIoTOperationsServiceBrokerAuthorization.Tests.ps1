if(($null -eq $TestName) -or ($TestName -contains 'Set-AzIoTOperationsServiceBrokerAuthorization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzIoTOperationsServiceBrokerAuthorization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzIoTOperationsServiceBrokerAuthorization' {
    It 'UpdateExpanded' {
        $BrokerAuthz = Set-AzIoTOperationsServiceBrokerAuthorization `
            -AuthorizationName $env.newBrokerAuthName `
            -BrokerName $env.BrokerName `
            -InstanceName $env.InstanceName `
            -ResourceGroupName $env.ResourceGroup `
            -ExtendedLocationName $env.ExtendedLocation `
            -AuthorizationPolicyCache "Enabled" `
            -AuthorizationPolicyRule @(
                @{
                principals = @{
                    clientIds  = @("my-client-id")
                    attributes = @(
                    @{
                        floor = "floor1"
                        site  = "site1"
                    }
                    )
                }
                brokerResources = @(
                    @{ method = "Connect" },
                    @{
                    method = "Subscribe"
                    topics = @("topic", "topic/with/wildcard/#")
                    }
                )
                stateStoreResources = @(
                    @{
                    method  = "ReadWrite"
                    keyType = "Pattern"
                    keys    = @("*")
                    }
                )
                }
            )
        $BrokerAuthz | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
