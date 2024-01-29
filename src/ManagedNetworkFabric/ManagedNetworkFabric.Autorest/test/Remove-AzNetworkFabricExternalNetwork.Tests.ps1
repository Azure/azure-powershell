if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkFabricExternalNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkFabricExternalNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkFabricExternalNetwork' {
    It 'Delete' {
        {
            Remove-AzNetworkFabricExternalNetwork -SubscriptionId $global:config.common.subscriptionId -L3IsolationDomainName $global:config.l3domain.name -Name $global:config.externalNetwork.name -ResourceGroupName $global:config.common.resourceGroupName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityL3IsolationDomain' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
