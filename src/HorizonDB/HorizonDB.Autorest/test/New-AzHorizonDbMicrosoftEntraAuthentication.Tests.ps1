if(($null -eq $TestName) -or ($TestName -contains 'New-AzHorizonDbMicrosoftEntraAuthentication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHorizonDbMicrosoftEntraAuthentication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHorizonDbMicrosoftEntraAuthentication' {
    It 'CreateExpanded' {
        $authentication = New-AzHorizonDbMicrosoftEntraAuthentication -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.newClusterName -SubscriptionId $env.SubscriptionId -State 'Enabled' -ErrorAction Stop

        $authentication.Name | Should -Be 'microsoftEntra'
        $authentication.ResourceGroupName | Should -Be $env.clusterResourceGroup
        $authentication.Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.clusterResourceGroup)/providers/Microsoft.HorizonDb/clusters/$($env.newClusterName)/authentications/microsoftEntra"
        $authentication.Type | Should -Be 'Microsoft.HorizonDb/clusters/authentications'
        $authentication.State | Should -Be 'Enabled'
        $authentication.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
