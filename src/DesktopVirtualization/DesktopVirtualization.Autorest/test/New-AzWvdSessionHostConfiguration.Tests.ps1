if(($null -eq $TestName) -or ($TestName -contains 'New-AzWvdSessionHostConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdSessionHostConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWvdSessionHostConfiguration' {
    It 'CreateExpanded' {
        $vmTag = @{
            "cm-resource-parent" = "/subscriptions/dbedef25-184c-430f-b383-0eeb87c3205d/resourceGroups/alecbUserSessionTests/providers/Microsoft.DesktopVirtualization/alecbhpuHP"
        }
        $configuration = New-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent -DiskInfoType "Standard_LRS" `
            -DomainInfoJoinType "AzureActiveDirectory" -ImageInfoType "Marketplace" `
            -NetworkInfoSubnetId "/subscriptions/dbedef25-184c-430f-b383-0eeb87c3205d/resourceGroups/alecbUserSessionTests/providers/Microsoft.Network/virtualNetworks/alecbUserSession-vnet/subnets/default" `
            -VMAdminCredentialsPasswordKeyvaultSecretUri "https://hpuposhkv.vault.azure.net/secrets/LocalAdminPW" `
            -VMAdminCredentialsUserNameKeyvaultSecretUri "https://hpuposhkv.vault.azure.net/secrets/LocalAdminUserName" `
            -VMNamePrefix "createTest" -VMSizeId "Standard_D2s_v3" -MarketplaceInfoExactVersion "22631.2715.231114" `
            -MarketplaceInfoOffer "office-365" -MarketplaceInfoPublisher "microsoftwindowsdesktop" `
            -MarketplaceInfoSku "win11-23h2-avd-m365" `
            -SecurityInfoSecureBootEnabled `
            -SecurityInfoType "TrustedLaunch" `
            -SecurityInfoVTpmEnabled `
            -VmLocation $env.Location `
            -VmResourceGroup $env.ResourceGroupPersistent `
            -VmTag $vmTag

        $configuration = Get-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent    
            
        $configuration.VMNamePrefix | Should -Be "createTest"

    }
}
