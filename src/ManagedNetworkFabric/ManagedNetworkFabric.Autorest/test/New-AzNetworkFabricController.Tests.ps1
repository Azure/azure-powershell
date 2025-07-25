if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricController'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricController.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricController' {
    It 'Create' {
        {
            $infra = @(@{
                ExpressRouteCircuitId = "/subscriptions/b256be71-d296-4e0e-99a1-408d9edc8718/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/example-expressRouteCircuit"
                ExpressRouteAuthorizationKey = "b256be71-d296-4e0e-99a1-408d9edc8718"
            })
            $workLoad = @(@{
                ExpressRouteCircuitId = "/subscriptions/b256be71-d296-4e0e-99a1-408d9edc8718/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/example-expressRouteCircuit"
                ExpressRouteAuthorizationKey = "b256be71-d296-4e0e-99a1-408d9edc8718"
            })

            New-AzNetworkFabricController -SubscriptionId $global:config.controller.subscriptionId -Name $global:config.controller.newNFCName -ResourceGroupName $global:config.controller.resourceGroupName -Location $global:config.controller.location -Ipv4AddressSpace $global:config.controller.ipv4Address -IsWorkloadManagementNetworkEnabled $global:config.controller.isWorkloadManagementNetworkEnabled  -NfcSku $global:config.controller.nfcSku -WorkloadExpressRouteConnection $workLoad -InfrastructureExpressRouteConnection $infra

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
