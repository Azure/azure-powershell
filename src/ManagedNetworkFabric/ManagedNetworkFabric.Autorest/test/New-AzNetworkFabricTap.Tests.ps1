if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricTap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricTap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricTap' {
    It 'Create' {
        {
            $destinations = @(@{
                DestinationId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/l3DomainName/internalNetworks/internalNetworkName"
                DestinationTapRuleId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkTapRules/NetworkTapRuleName1"
                DestinationType = "IsolationDomain"
                IsolationDomainPropertyEncapsulation = "GRE"
                IsolationDomainPropertyNeighborGroupId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/neighborGroups/NeighborGroupName"
                Name = "destinationName"
            })

            New-AzNetworkFabricTap -SubscriptionId $global:config.common.subscriptionId -Name $global:config.networkTap.name -ResourceGroupName $global:config.common.resourceGroupName -Destination $destinations -Location $global:config.common.location -NetworkPacketBrokerId $global:config.networkTap.npbId -PollingType $global:config.networkTap.pollingType
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
