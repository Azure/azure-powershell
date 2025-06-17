if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricIPPrefix'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricIPPrefix.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricIPPrefix' {
    It 'Create' {
        {
            $ipPrefixRules = @(@{
                action = $global:config.IpPrefix.action
                sequenceNumber = $global:config.IpPrefix.sequenceNumber
                networkPrefix = $global:config.IpPrefix.networkPrefix
                condition = $global:config.IpPrefix.condition
                subnetMaskLength = $global:config.IpPrefix.subnetMaskLength
            })

            New-AzNetworkFabricIPPrefix -SubscriptionId $global:config.common.subscriptionId -Name $global:config.IpPrefix.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -IPPrefixRule $ipPrefixRules

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
