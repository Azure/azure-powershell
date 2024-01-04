if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricTapRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricTapRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricTapRule' {
    It 'Create' {
        {
            $matchConfiguration = @(@{
                Action = @(@{
                    DestinationId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/neighborGroups/NeighborGroupName"
                    IsTimestampEnabled = "True"
                    MatchConfigurationName = "match1"
                    Truncate = "100"
                    Type = "Drop"
                })
                IPAddressType = "IPv4"
                MatchCondition = @(@{
                    EncapsulationType = "None"
                    PortConditionLayer4Protocol = "TCP"
                    PortConditionPort = @("100")
                    PortConditionPortGroupName = @("portGroupName1")
                    PortConditionPortType = "SourcePort"
                    VlanMatchConditionInnerVlan = @("30")
                    VlanMatchConditionVlan = @("20-30")
                    VlanMatchConditionVlanGroupName = @("name")
                    IPConditionIpgroupName = @("name")
                    IPConditionIpprefixValue = @("10.20.20.20/12")
                    IPConditionPrefixType = "Prefix"
                    IPConditionType = "SourceIP"
                })
                MatchConfigurationName = "config1"
                SequenceNumber = 12
            })

            New-AzNetworkFabricTapRule -SubscriptionId $global:config.common.subscriptionId -Name $global:config.networkTapRule.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -ConfigurationType $global:config.networkTapRule.configurationType -DynamicMatchConfiguration $dynamicConfiguration -MatchConfiguration $matchConfiguration

            New-AzNetworkFabricTapRule -SubscriptionId $global:config.common.subscriptionId -Name $global:config.networkTapRule.name1 -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -ConfigurationType $global:config.networkTapRule.configurationType1 -PollingIntervalInSecond 30 -TapRulesUrl "https://fileurl.com" -DynamicMatchConfiguration $dynamicConfiguration -MatchConfiguration $matchConfiguration

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
