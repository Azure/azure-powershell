if(($null -eq $TestName) -or ($TestName -contains 'SingleSystemWithCustomResourceTrustedAccess'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'SingleSystemWithCustomResourceTrustedAccess.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'SingleSystemWithCustomResourceTrustedAccess' {
    It 'CreateSingleSystemWithCustomResourceTrustedAccess' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $UpdateTags = @{ $env.TestType = $env.TestTypeValue}
        $CreateSingleSystemWithCustomResourceTrustedAccessConfig = Join-Path $PSScriptRoot $env.CreateSingleSystemWithCustomResourceTrustedAccessConfigPath
        $CreateSingleSystemWithCustomResourceTrustedAccessResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateSingleSystemWithCustomResourceTrustedAccessSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateSingleSystemWithCustomResourceTrustedAccessConfig -Tag $UpdateTags -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateSingleSystemWithCustomResourceTrustedAccessResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateSingleSystemWithCustomResourceTrustedAccessResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        $CreateSingleSystemWithCustomResourceTrustedAccessResponse.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'InstallSingleSystemWithCustomResourceTrustedAccess' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $InstallSingleSystemWithCustomResourceTrustedAccessConfig = Join-Path $PSScriptRoot $env.InstallSingleSystemWithCustomResourceTrustedAccessConfigPath
        $InstallSingleSystemWithCustomResourceTrustedAccessResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateSingleSystemWithCustomResourceTrustedAccessSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $InstallSingleSystemWithCustomResourceTrustedAccessConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $InstallSingleSystemWithCustomResourceTrustedAccessResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
    }

    It 'CreateSingleSystemWithCustomResourceTrustedAccessAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $UpdateTags = @{ $env.TestType = $env.TestTypeValue}
        $CreateSingleSystemWithCustomResourceTrustedAccessAliasConfig = Join-Path $PSScriptRoot $env.CreateSingleSystemWithCustomResourceTrustedAccessConfigPath
        $CreateSingleSystemWithCustomResourceTrustedAccessAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateSingleSystemWithCustomResourceTrustedAccessSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateSingleSystemWithCustomResourceTrustedAccessAliasConfig -Tag $UpdateTags -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateSingleSystemWithCustomResourceTrustedAccessAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        $CreateSingleSystemWithCustomResourceTrustedAccessAliasResponse.managedResourcesNetworkAccessType | Should -Be $env.MrgNetAccTypPrvt
        $CreateSingleSystemWithCustomResourceTrustedAccessAliasResponse.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'InstallSingleSystemWithCustomResourceTrustedAccessAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $InstallSingleSystemWithCustomResourceTrustedAccessAliasConfig = Join-Path $PSScriptRoot $env.InstallSingleSystemWithCustomResourceTrustedAccessConfigPath
        $InstallSingleSystemWithCustomResourceTrustedAccessAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateSingleSystemWithCustomResourceTrustedAccessSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $InstallSingleSystemWithCustomResourceTrustedAccessAliasConfig -ManagedResourcesNetworkAccessType $env.MrgNetAccTypPrvt -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $InstallSingleSystemWithCustomResourceTrustedAccessAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
    }
}
