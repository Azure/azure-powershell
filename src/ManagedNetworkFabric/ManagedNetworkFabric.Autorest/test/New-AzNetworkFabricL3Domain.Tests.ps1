if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricL3Domain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricL3Domain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricL3Domain' {
    It 'Create' {
        {
            $connectedSubnetRoutePolicy = @{
                ExportRoutePolicy = @{
                    ExportIpv4RoutePolicyId = $global:config.l3domain.exportIpv4RoutePolicyId
                    ExportIpv6RoutePolicyId = $global:config.l3domain.exportIpv6RoutePolicyId
                }
            }
            $aggregateRouteConfiguration = @{
                Ipv4Route = @(@{
                    Prefix = "10.0.0.1/28"
                })
                Ipv6Route = @(@{
                    Prefix = "2fff::/64"
                })
            }

            New-AzNetworkFabricL3Domain -SubscriptionId $global:config.common.subscriptionId -Name $global:config.l3domain.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -NetworkFabricId $global:config.l3domain.nfId -AggregateRouteConfiguration $aggregateRouteConfiguration -ConnectedSubnetRoutePolicy $connectedSubnetRoutePolicy -RedistributeConnectedSubnet $global:config.l3domain.redistributeConnectedSubnets -RedistributeStaticRoute $global:config.l3domain.redistributeStaticRoutes

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
