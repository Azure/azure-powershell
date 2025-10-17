if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcClusterAdminKubeconfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcClusterAdminKubeconfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# This test is live only since it records sensitive information such as the kubeconfig.
Describe 'Get-AzAksArcClusterAdminKubeconfig' -Tag 'LiveOnly' {
    It 'List' {
        # WARNING: Please redact sensitive data in the recording file before committing. You can do this by replacing
        # the kubeconfig JSON response value with any value, converted to base64, required to make the test pass. The
        # current value is "dGVzdC1jbHVzdGVy" which is base64 for "test-cluster".
        # WARNING: Please do not record tests using production or long-running resources.
        $config = Get-AzAksArcClusterAdminKubeconfig `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $config | Should -Not -BeNullOrEmpty
        $config -like "*$($env.clusterName )*" | Should -BeTrue
    }
}
