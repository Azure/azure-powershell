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
    It 'DeleteRegisterWithTrustedAccessCustomSaMrg' {
        $DeleteRegisterWithTrustedAccessCustomSaMrgResponse = Remove-AzWorkloadsSapVirtualInstance -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.DeletionRG
        $DeleteRegisterWithTrustedAccessCustomSaMrgResponse.Status | Should -Be $null
        Start-TestSleep 60
    }

    It 'RegisterWithTrustedAccessCustomSaMrg' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $RegisterWithTrustedAccessCustomSaMrgResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -CentralServerVmId $env.CentralServerVmId -ManagedResourceGroupName $env.MrgRGName -ManagedRgStorageAccountName $env.MrgSAName -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $RegisterWithTrustedAccessCustomSaMrgResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $RegisterWithTrustedAccessCustomSaMrgResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($RegisterWithTrustedAccessCustomSaMrgResponse.Configuration | ConvertFrom-Json).managedRgStorageAccountName | Should -Be $env.MrgSAName
        $RegisterWithTrustedAccessCustomSaMrgResponse.managedResourceGroupConfigurationName | Should -Be $env.MrgRGName
    }

    It 'DeleteRegisterWithTrustedAccessCustomSaMrgAlias' {
        $DeleteRegisterWithTrustedAccessCustomSaMrgAliasResponse = Remove-AzVIS -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.DeletionRG
        $DeleteRegisterWithTrustedAccessCustomSaMrgAliasResponse.Status | Should -Be $null
        Start-TestSleep 60
    }

    It 'RegisterWithTrustedAccessCustomSaMrgAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -CentralServerVmId $env.CentralServerVmId -ManagedResourceGroupName $env.MrgRGName -ManagedRgStorageAccountName $env.MrgSAName -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($RegisterWithTrustedAccessCustomSaMrgAliasResponse.Configuration | ConvertFrom-Json).managedRgStorageAccountName | Should -Be $env.MrgSAName
        $RegisterWithTrustedAccessCustomSaMrgAliasResponse.managedResourceGroupConfigurationName | Should -Be $env.MrgRGName
    }
}
