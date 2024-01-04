if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricNni'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricNni.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricNni' {
    It 'Create' {
        {
            $optionBLayer3Configuration = @{
                PrimaryIpv4Prefix = "172.31.0.0/31"
                SecondaryIpv4Prefix = "172.31.0.20/31"
                PeerAsn = 28
                VlanId = 501
            }
            $layer2Configuration = @{
                Interface = @("/subscriptions//resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric/networkToNetworkInterconnects/example-interface")
                Mtu = 1500
            }
            $importRoutePolicy = @{
                ImportIpv4RoutePolicyId = $global:config.nni.importIpv4RoutePolicyId
                ImportIpv6RoutePolicyId = $global:config.nni.importIpv6RoutePolicyId
            }
            $exportRoutePolicy = @{
                ExportIpv4RoutePolicyId = $global:config.nni.exportIpv4RoutePolicyId
                ExportIpv6RoutePolicyId = $global:config.nni.exportIpv6RoutePolicyId
            }

            New-AzNetworkFabricNni -SubscriptionId $global:config.common.subscriptionId -Name $global:config.nni.name -NetworkFabricName $global:config.nni.nfName -ResourceGroupName $global:config.common.resourceGroupName -UseOptionB $global:config.nni.useOptionB -ExportRoutePolicy $ExportRoutePolicy -ImportRoutePolicy $importRoutePolicy -IngressAclId $global:config.nni.ingressAclId -IsManagementType $global:config.nni.isManagementType -Layer2Configuration $layer2Configuration -NniType $global:config.nni.nniType -NpbStaticRouteConfiguration $npbStaticRouteConfiguration -OptionBLayer3Configuration $optionBLayer3Configuration

        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityNetworkFabricExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityNetworkFabric' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
