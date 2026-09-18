if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcKubernetesVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcKubernetesVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksArcKubernetesVersion' {
    It 'List' {
        $k8sVersions = Get-AzAksArcKubernetesVersion -CustomLocationName $env.CustomLocationName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $k8sVersions | Should -Not -BeNullOrEmpty
        $k8sVersions.ProvisioningState | Should -be "Succeeded"
        $k8sVersions.Type | Should -be  "microsoft.hybridcontainerservice/kubernetesversions"
    }
}
