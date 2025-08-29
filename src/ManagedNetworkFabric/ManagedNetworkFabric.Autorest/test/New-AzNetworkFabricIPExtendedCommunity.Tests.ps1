if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricIPExtendedCommunity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricIPExtendedCommunity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricIPExtendedCommunity' {
    It 'Create' {
        {
            $ipExtendedCommunityRule = @(@{
                action = $global:config.IpExtendedCommunity.action
                sequenceNumber = $global:config.IpExtendedCommunity.sequenceNumber
                routeTarget = $global:config.IpExtendedCommunity.routeTargets
            })

            New-AzNetworkFabricIPExtendedCommunity -SubscriptionId $global:config.common.subscriptionId -Name $global:config.IpExtendedCommunity.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -IPExtendedCommunityRule $ipExtendedCommunityRule

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
