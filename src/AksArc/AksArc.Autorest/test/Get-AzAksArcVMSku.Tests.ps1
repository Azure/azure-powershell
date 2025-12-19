if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcVMSku'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcVMSku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksArcVMSku' {
    It 'Get' {
        $vmSkus = Get-AzAksArcVMSku -CustomLocationName $env.customLocationName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $vmSkus | Should -Not -BeNullOrEmpty
        $vmSkus.ProvisioningState | Should -be "Succeeded"
        $vmSkus.Type | Should -be  "microsoft.hybridcontainerservice/skus"
    }
}
