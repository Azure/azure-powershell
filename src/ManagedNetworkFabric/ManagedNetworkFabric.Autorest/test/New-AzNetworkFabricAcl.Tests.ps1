if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricAcl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricAcl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricAcl' {
    It 'Create' {
        {
            $dynamicMatchConfiguration = @(@{
                IPGroup = @(@{
                    IPAddressType = "IPv4"
                    IPPrefix = @("10.20.3.1/20")
                    Name = "ipGroupName"
                })
                PortGroup = @(@{
                    Name = "portGroupName"
                    Port = @("100-200")
                })
                VlanGroup = @(@{
                    Name = "valnGroupName"
                    Vlan = @("20-30")
                })
            })

            $matchConfiguration = @(@{
                Action = @(@{
                    Type = "Count"
                    CounterName = "counterName"
                })
                IPAddressType = "IPv4"
                MatchCondition = @(@{
                    DscpMarking = @("32")
                    EtherType = @("0x1")
                    Fragment = @("0xff00-0xffff")
                    IPLength = @("4094-9214")
                    TtlValue =  @("23")
                    PortConditionFlag = @("established")
                    PortConditionLayer4Protocol = "TCP"
                    PortConditionPortGroupName = @("portGroupName")
                    PortConditionPortType = "SourcePort"
                    VlanMatchConditionInnerVlan = @("30")
                    VlanMatchConditionVlan = @("20-30")
                    VlanMatchConditionVlanGroupName = @("name")
                    IPConditionIpgroupName = @("name")
                    IPConditionIpprefixValue = @("10.20.20.20/12")
                    IPConditionPrefixType = "Prefix"
                    IPConditionType = "SourceIP"

                })
                MatchConfigurationName = "matchConfName"
                SequenceNumber = 13
            })

            New-AzNetworkFabricAcl -SubscriptionId $global:config.common.subscriptionId -Name $global:config.ACL.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -ConfigurationType $global:config.ACL.configurationType -DefaultAction $global:config.ACL.defaultAction -DynamicMatchConfiguration $dynamicMatchConfiguration -MatchConfiguration $matchConfiguration

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
