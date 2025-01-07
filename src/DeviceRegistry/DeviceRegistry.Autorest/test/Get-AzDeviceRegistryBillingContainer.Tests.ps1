if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryBillingContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryBillingContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryBillingContainer' {
    It 'List' {
        $billingContainer = Get-AzDeviceRegistryBillingContainer -SubscriptionId $env.SubscriptionId
        $billingContainer.Name | Should -Be $env.billingContainerName
    }

    It 'Get' {
        $billingContainer = Get-AzDeviceRegistryBillingContainer -SubscriptionId $env.SubscriptionId -Name $env.billingContainerName
        $billingContainer.Name | Should -Be $env.billingContainerName
    }

    It 'GetViaIdentity' {
        $billingContainerIdentity = @{
            BillingContainerName = $env.billingContainerName
            SubscriptionId = $env.SubscriptionId
        }
        $billing = Get-AzDeviceRegistryBillingContainer -InputObject $billingContainerIdentity
        $billing.Name | Should -Be $env.billingContainerName
    }
}
