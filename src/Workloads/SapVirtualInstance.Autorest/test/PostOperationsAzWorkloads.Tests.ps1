if(($null -eq $TestName) -or ($TestName -contains 'PostOperationsAzWorkloads'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'PostOperationsAzWorkloads.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'PostOperationsAzWorkloads' {
    It 'PostOperationsSapDiskConfiguration' {
        $PostOperationsSapDiskConfigurationResponse = Invoke-AzWorkloadsSapDiskConfiguration -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DbVMSku $env.DbVMSku -DeploymentType $env.DeploymentType -Environment $env.EnviornmentNonProd -SapProduct $env.SapProduct
        $PostOperationsSapDiskConfigurationResponse.Count | Should -BeGreaterOrEqual 1
    }
    
    It 'PostOperationsSapSizingRecommendation' {
        $PostOperationsSapSizingRecommendationResponse = Invoke-AzWorkloadsSapSizingRecommendation -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DbMemory $env.DbMemory -DeploymentType $env.DeploymentType -Environment $env.EnviornmentNonProd -SapProduct $env.SapProduct -Sap $env.Saps -DbScaleMethod $env.DbScaleMethod
        $PostOperationsSapSizingRecommendationResponse.Count | Should -BeGreaterOrEqual 1
    }

    It 'PostOperationsSapSupportedSku' {
        $PostOperationsSapSupportedSkuResponse = Invoke-AzWorkloadsSapSupportedSku -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DeploymentType $env.DeploymentTypeThreeTier -Environment $env.EnviornmentProd -SapProduct $env.SapProduct
        $PostOperationsSapSupportedSkuResponse.Count | Should -BeGreaterOrEqual 1
    }

    It 'PostOperationsSapDiskConfigurationAlias' {
        $PostOperationsSapDiskConfigurationAliasResponse = Invoke-AzVISDiskConfiguration -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DbVMSku $env.DbVMSku -DeploymentType $env.DeploymentType -Environment $env.EnviornmentNonProd -SapProduct $env.SapProduct
        $PostOperationsSapDiskConfigurationAliasResponse.Count | Should -BeGreaterOrEqual 1
    }
    
    It 'PostOperationsSapSizingRecommendationAlias' {
        $PostOperationsSapSizingRecommendationAliasResponse = Invoke-AzVISSizingRecommendation -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DbMemory $env.DbMemory -DeploymentType $env.DeploymentType -Environment $env.EnviornmentNonProd -SapProduct $env.SapProduct -Sap $env.Saps -DbScaleMethod $env.DbScaleMethod
        $PostOperationsSapSizingRecommendationAliasResponse.Count | Should -BeGreaterOrEqual 1
    }

    It 'PostOperationsSapSupportedSkuAlias' {
        $PostOperationsSapSupportedSkuAliasResponse = Invoke-AzVISSupportedSKU -SubscriptionId $env.WaaSSubscriptionId -Location $env.Location -AppLocation $env.Location -DatabaseType $env.DatabaseType -DeploymentType $env.DeploymentTypeThreeTier -Environment $env.EnviornmentProd -SapProduct $env.SapProduct
        $PostOperationsSapSupportedSkuAliasResponse.Count | Should -BeGreaterOrEqual 1
    }
}
