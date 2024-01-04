if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricRoutePolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricRoutePolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricRoutePolicy' {
    It 'Create' {
        {
            $statements = @(@{
                ActionType = "Permit"
                SequenceNumber = 12345
                ActionLocalPreference = 123
                ConditionIPCommunityId = @($global:config.routePolicy.ipCommunityId)
                ConditionIPExtendedCommunityId = @($global:config.routePolicy.ipExtendedCommunityId)
                ConditionIPPrefixId = $global:config.routePolicy.ipPrefixId
                ConditionType = "Or"
                IPCommunityPropertyAddIpcommunityId = @($global:config.routePolicy.ipCommunityId)
                IPExtendedCommunityPropertyAddIpextendedCommunityId = @($global:config.routePolicy.ipExtendedCommunityId)
            })

            New-AzNetworkFabricRoutePolicy -SubscriptionId $global:config.common.subscriptionId -Name $global:config.routePolicy.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -NetworkFabricId $global:config.routePolicy.nfId -AddressFamilyType $global:config.routePolicy.addressFamilyType -DefaultAction $global:config.routePolicy.defaultAction -Statement $statements

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
