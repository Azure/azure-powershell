if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWorkloadsSapSupportedSku'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWorkloadsSapSupportedSku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWorkloadsSapSupportedSku' {
    It 'SapExpanded' {
        $sapSupportedSku = Invoke-AzWorkloadsSapSupportedSku -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DeploymentType $env.DeploymentTypeThreeTier -Environment $env.EnviornmentProd -SapProduct $env.SapProduct
        $sapSupportedSku.Count | Should -BeGreaterOrEqual 1
    }

    It 'SapViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
