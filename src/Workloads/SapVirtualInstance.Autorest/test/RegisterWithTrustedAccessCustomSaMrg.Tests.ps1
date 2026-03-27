if(($null -eq $TestName) -or ($TestName -contains 'RegisterWithTrustedAccessCustomSaMrg'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'RegisterWithTrustedAccessCustomSaMrg.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'RegisterWithTrustedAccessCustomSaMrg' {

    It 'RegisterWithTrustedAccessCustomSaMrg' {
        $RegisterWithTrustedAccessCustomSaMrgResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.DiscoverSVI -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -CentralServerVmId $env.CentralServerVmId -ManagedResourceGroupName $env.MrgRGName -ManagedRgStorageAccountName $env.MrgSAName -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -UserAssignedIdentity @($env.IdentityName)
        $RegisterWithTrustedAccessCustomSaMrgResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $RegisterWithTrustedAccessCustomSaMrgResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($RegisterWithTrustedAccessCustomSaMrgResponse.Configuration | ConvertFrom-Json).managedRgStorageAccountName | Should -Be $env.MrgSAName
        $RegisterWithTrustedAccessCustomSaMrgResponse.managedResourceGroupConfigurationName | Should -Be $env.MrgRGName
    }

    It 'RegisterWithTrustedAccessCustomSaMrgAlias' -skip {
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -CentralServerVmId $env.CentralServerVmId -ManagedResourceGroupName $env.MrgRGName -ManagedRgStorageAccountName $env.MrgSAName -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -UserAssignedIdentity @($env.IdentityName)
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($RegisterWithTrustedAccessCustomSaMrgAliasResponse.Configuration | ConvertFrom-Json).managedRgStorageAccountName | Should -Be $env.MrgSAName
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse.managedResourceGroupConfigurationName | Should -Be $env.MrgRGName
    }
}
