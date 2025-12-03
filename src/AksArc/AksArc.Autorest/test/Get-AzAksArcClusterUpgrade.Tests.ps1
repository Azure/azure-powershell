if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcClusterUpgrade'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcClusterUpgrade.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksArcClusterUpgrade' {
    It 'Get' {
        $upgradeProfiles = Get-AzAksArcClusterUpgrade `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $upgradeProfiles[0] | Should -Not -BeNullOrEmpty
        $upgradeProfiles[0].ProvisioningState | Should -be "Succeeded"
        $upgradeProfiles[0].Type | Should -Be "microsoft.hybridcontainerservice/provisionedclusterinstances/upgradeprofiles"
    }
}
