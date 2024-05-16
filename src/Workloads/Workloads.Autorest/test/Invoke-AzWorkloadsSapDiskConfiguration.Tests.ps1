if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWorkloadsSapDiskConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWorkloadsSapDiskConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWorkloadsSapDiskConfiguration' {
    It 'SapExpanded' {
        $diskConfigDetail = Invoke-AzWorkloadsSapDiskConfiguration -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DbVMSku $env.DbVMSku -DeploymentType $env.DeploymentType -Environment $env.EnviornmentNonProd -SapProduct $env.SapProduct
        $diskConfigDetail.Count | Should -BeGreaterOrEqual 1
    }

    It 'SapViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
