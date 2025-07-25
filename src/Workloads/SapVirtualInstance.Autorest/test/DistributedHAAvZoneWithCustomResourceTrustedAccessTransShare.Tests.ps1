if(($null -eq $TestName) -or ($TestName -contains 'DistributedHAAvZoneWithCustomResourceTrustedAccessTransShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'DistributedHAAvZoneWithCustomResourceTrustedAccessTransShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'DistributedHAAvZoneWithCustomResourceTrustedAccessTransShare' {
    It 'CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShare' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfig = Join-Path $PSScriptRoot $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfigPath
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareResponse.Configuration | ConvertFrom-Json).infrastructureConfiguration.storageConfiguration.transportFileShareConfiguration.configurationType | Should -Be $env.MountTransShareConfigType
    }

    It 'InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShare' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfig = Join-Path $PSScriptRoot $env.InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfigPath
        $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
    }

    It 'CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasConfig = Join-Path $PSScriptRoot $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfigPath
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasResponse.Configuration | ConvertFrom-Json).infrastructureConfiguration.storageConfiguration.transportFileShareConfiguration.configurationType | Should -Be $env.MountTransShareConfigType
    }

    It 'InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasConfig = Join-Path $PSScriptRoot $env.InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfigPath
        $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
    }
}
