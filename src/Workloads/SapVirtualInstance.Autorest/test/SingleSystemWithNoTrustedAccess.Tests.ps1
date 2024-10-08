if(($null -eq $TestName) -or ($TestName -contains 'SingleSystemWithNoTrustedAccess'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'SingleSystemWithNoTrustedAccess.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'SingleSystemWithNoTrustedAccess' {
    It 'CreateSingleSystemWithNoTrustedAccess' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateSingleSystemWithNoTrustedAccessConfig = Join-Path $PSScriptRoot $env.CreateSingleSystemWithNoTrustedAccessConfigPath
        $CreateSingleSystemWithNoTrustedAccessResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateSingleSystemWithNoTrustedAccessSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateSingleSystemWithNoTrustedAccessConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPub -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateSingleSystemWithNoTrustedAccessResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateSingleSystemWithNoTrustedAccessResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPub
    }

    It 'InstallSingleSystemWithNoTrustedAccess' -skip {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
    }

    It 'CreateSingleSystemWithNoTrustedAccessAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateSingleSystemWithNoTrustedAccessAliasConfig = Join-Path $PSScriptRoot $env.CreateSingleSystemWithNoTrustedAccessConfigPath
        $CreateSingleSystemWithNoTrustedAccessAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateSingleSystemWithNoTrustedAccessSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateSingleSystemWithNoTrustedAccessAliasConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPub -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateSingleSystemWithNoTrustedAccessAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateSingleSystemWithNoTrustedAccessAliasResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPub
    }

    It 'InstallSingleSystemWithNoTrustedAccessAlias' -skip {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
    }
}
