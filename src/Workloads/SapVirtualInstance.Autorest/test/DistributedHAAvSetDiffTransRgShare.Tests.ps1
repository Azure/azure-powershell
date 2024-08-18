if(($null -eq $TestName) -or ($TestName -contains 'DistributedHAAvSetDiffTransRgShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'DistributedHAAvSetDiffTransRgShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'DistributedHAAvSetDiffTransRgShare' {
    It 'CreateDistributedHAAvSetDiffTransRgShare' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateDistributedHAAvSetDiffTransRgShareConfig = Join-Path $PSScriptRoot $env.CreateDistributedHAAvSetDiffTransRgShareConfigPath
        $CreateDistributedHAAvSetDiffTransRgShareResponse = New-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvSetDiffTransRgShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateDistributedHAAvSetDiffTransRgShareConfig -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateDistributedHAAvSetDiffTransRgShareResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        ($CreateDistributedHAAvSetDiffTransRgShareResponse.Configuration | ConvertFrom-Json).infrastructureConfiguration.storageConfiguration.transportFileShareConfiguration.configurationType | Should -Be $env.MountTransShareConfigType
    }

    It 'InstallDistributedHAAvSetDiffTransRgShare' -skip {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
    }

    It 'CreateDistributedHAAvSetDiffTransRgShareAlias' {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
        $CreateDistributedHAAvSetDiffTransRgShareAliasConfig = Join-Path $PSScriptRoot $env.CreateDistributedHAAvSetDiffTransRgShareConfigPath
        $CreateDistributedHAAvSetDiffTransRgShareAliasResponse = New-AzVIS -SubscriptionId $env.WaaSSubscriptionId -Name $env.CreateDistributedHAAvSetDiffTransRgShareSID -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $CreateDistributedHAAvSetDiffTransRgShareAliasConfig -IdentityType $env.IdentityType -UserAssignedIdentity $MsiIdentityName
        $CreateDistributedHAAvSetDiffTransRgShareAliasResponse.provisioningState | Should -Be $env.ProvisioningStateSucceeded
        ($CreateDistributedHAAvSetDiffTransRgShareAliasResponse.Configuration | ConvertFrom-Json).infrastructureConfiguration.storageConfiguration.transportFileShareConfiguration.configurationType | Should -Be $env.MountTransShareConfigType
    }

    It 'InstallDistributedHAAvSetDiffTransRgShareAlias' -skip {
        $MsiIdentityName = @{ $env.IdentityName = @{}}
    }
}
