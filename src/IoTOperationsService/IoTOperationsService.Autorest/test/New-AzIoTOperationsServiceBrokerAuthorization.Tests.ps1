if(($null -eq $TestName) -or ($TestName -contains 'New-AzIoTOperationsServiceBrokerAuthorization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzIoTOperationsServiceBrokerAuthorization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzIoTOperationsServiceBrokerAuthorization' {
    It 'CreateExpanded' {
        $BrokerAuthz = New-AzIoTOperationsServiceBrokerAuthorization `
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

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
