if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabric' {
    It 'Create' {
        {
            $managementNetworkConfiguration = @{
                InfrastructureVpnConfigurationPeeringOption = "OptionB"
                WorkloadVpnConfigurationPeeringOption = "OptionB"
                InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget = @("65046:10039")
                InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget = @("65046:10039")
                InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget = @("65046:10039")
                InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget = @("65046:10039")
                WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget = @("65046:10039")
                WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget = @("65046:10039")
                WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget = @("65046:10039")
                WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget = @("65046:10039")
            }

            $terminalServerConfiguration = @{
                UserName = "username"
                Password = "password"
                SerialNumber = "2351"
                PrimaryIpv4Prefix = "172.31.0.0/30"
                SecondaryIpv4Prefix = "172.31.0.20/30"
            }

            New-AzNetworkFabric -SubscriptionId $global:config.common.subscriptionId -Name $global:config.fabric.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $global:config.fabric.nfcId -NetworkFabricSku $global:config.fabric.nfSku -ServerCountPerRack $global:config.fabric.serverCountPerRack -Ipv6Prefix $global:config.fabric.ipv6Prefix -RackCount $global:config.fabric.rackCount -FabricAsn $global:config.fabric.fabricASN -Ipv4Prefix $global:config.fabric.ipv4Prefix -TerminalServerConfiguration $terminalServerConfiguration

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
