if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricInternetGatewayRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricInternetGatewayRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricInternetGatewayRule' {
    It 'Create' {
        {
            $ruleProperty = @{
                Action = "Allow"
                AddressList = @(
                    "10.10.10.10"
                )
            }

            New-AzNetworkFabricInternetGatewayRule -SubscriptionId $global:config.common.subscriptionId -Name $global:config.internetGatewayRule.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -RuleProperty $ruleProperty

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
