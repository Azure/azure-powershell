if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricIPCommunity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricIPCommunity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricIPCommunity' {
    It 'Create' {
        {
            $ipCommunityRule = @(@{
                action = $global:config.IpCommunity.action
                sequenceNumber = $global:config.IpCommunity.sequenceNumber
                communityMember = $global:config.IpCommunity.communityMembers
                wellKnownCommunity = $global:config.IpCommunity.wellKnownCommunities
            })

            New-AzNetworkFabricIPCommunity -SubscriptionId $global:config.common.subscriptionId -Name $global:config.IpCommunity.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -IPCommunityRule $ipCommunityRule

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
