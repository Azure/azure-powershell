if(($null -eq $TestName) -or ($TestName -contains 'DistributedSystemWithTrustedAccessNoTransShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'DistributedSystemWithTrustedAccessNoTransShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'DistributedSystemWithTrustedAccessNoTransShare' {
    It 'CreateDistributedSystemWithTrustedAccessNoTransShare' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateDistributedSystemWithTrustedAccessNoTransShareConfig = Join-Path $PSScriptRoot $env.CreateDistributedSystemWithTrustedAccessNoTransShareConfigPath
        $CreateDistributedSystemWithTrustedAccessNoTransShareResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedSystemWithTrustedAccessNoTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateDistributedSystemWithTrustedAccessNoTransShareConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateDistributedSystemWithTrustedAccessNoTransShareResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateDistributedSystemWithTrustedAccessNoTransShareResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($CreateDistributedSystemWithTrustedAccessNoTransShareResponse.Configuration | ConvertFrom-Json).configuration.infrastructureConfiguration.storageConfiguration.transportFileShareConfiguration.configurationType | Should -Be $null
    }

    It 'InstallDistributedSystemWithTrustedAccessNoTransShare' -skip {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
    }

    It 'CreateDistributedSystemWithTrustedAccessNoTransShareAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateDistributedSystemWithTrustedAccessNoTransShareAliasConfig = Join-Path $PSScriptRoot $env.CreateDistributedSystemWithTrustedAccessNoTransShareConfigPath
        $CreateDistributedSystemWithTrustedAccessNoTransShareAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedSystemWithTrustedAccessNoTransShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateDistributedSystemWithTrustedAccessNoTransShareAliasConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateDistributedSystemWithTrustedAccessNoTransShareAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateDistributedSystemWithTrustedAccessNoTransShareAliasResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        ($CreateDistributedSystemWithTrustedAccessNoTransShareAliasResponse.Configuration | ConvertFrom-Json).configuration.infrastructureConfiguration.storageConfiguration.transportFileShareConfiguration.configurationType | Should -Be $null
    }

    It 'InstallDistributedSystemWithTrustedAccessNoTransShareAlias' -skip {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
    }
}
