if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricExternalNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricExternalNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricExternalNetwork' {
    It 'Create' {
        {
            $exportRoutePolicy = @{
                ExportIpv4RoutePolicyId = $global:config.externalnetwork.exportIpv4RoutePolicyId
                ExportIpv6RoutePolicyId = $global:config.externalnetwork.exportIpv6RoutePolicyId
            }
            $importRoutePolicy = @{
                ImportIpv4RoutePolicyId = $global:config.externalnetwork.importIpv4RoutePolicyId
                ImportIpv6RoutePolicyId = $global:config.externalnetwork.importIpv6RoutePolicyId
            }
            $routeTarget = @{
                ExportIpv4RouteTarget = @("65046:10039")
                ExportIpv6RouteTarget = @("65046:10039")
                ImportIpv4RouteTarget = @("65046:10039")
                ImportIpv6RouteTarget = @("65046:10039")
            }
            $optionBProperty = @{
                RouteTarget = $routeTarget
            }

            $optionAPropertyBfdConfiguration = @{
                IntervalInMilliSecond = 300
                Multiplier = 3
            }

            New-AzNetworkFabricExternalNetwork -SubscriptionId $global:config.common.subscriptionId -L3IsolationDomainName $global:config.externalnetwork.l3domainName -Name $global:config.externalnetwork.name -ResourceGroupName $global:config.common.resourceGroupName -PeeringOption $global:config.externalnetwork.peeringOption -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionBProperty $optionBProperty

            New-AzNetworkFabricExternalNetwork -SubscriptionId $global:config.common.subscriptionId -L3IsolationDomainName $global:config.externalnetwork.l3domainName -Name $global:config.externalnetwork.name1 -ResourceGroupName $global:config.common.resourceGroupName -PeeringOption $global:config.externalnetwork.peeringOption1 -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionAPropertyBfdConfiguration $optionAPropertyBfdConfiguration -OptionAPropertyEgressAclId $global:config.externalnetwork.egressAclId -OptionAPropertyIngressAclId $global:config.externalnetwork.ingressAclId -OptionAPropertyMtu $global:config.externalnetwork.mtu -OptionAPropertyPeerAsn $global:config.externalnetwork.peerAsn -OptionAPropertyPrimaryIpv4Prefix $global:config.externalnetwork.primaryIpv4Prefix -OptionAPropertySecondaryIpv4Prefix $global:config.externalnetwork.secondaryIpv4Prefix -OptionAPropertyVlanId $global:config.externalnetwork.vlanId

        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityL3IsolationDomainExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityL3IsolationDomain' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
