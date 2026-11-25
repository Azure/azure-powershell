if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWvdSessionHostConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHostConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWvdSessionHostConfiguration' {
    BeforeAll {
        $script:shcUpdateFixture = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.ResourceGroup
            HostPoolName = 'shc-update-' + ($env.HostPool -replace '^HostPool', '')
            Owned = $false
        }

        $existingHostPool = Get-AzWvdHostPool -SubscriptionId $script:shcUpdateFixture.SubscriptionId `
                -ResourceGroupName $script:shcUpdateFixture.ResourceGroupName `
                -ErrorAction Stop | Where-Object { $_.Name -eq $script:shcUpdateFixture.HostPoolName }
        if ($existingHostPool) {
            throw "Host pool '$($script:shcUpdateFixture.HostPoolName)' already exists."
        }

        $hostPool = New-AzWvdHostPool -SubscriptionId $script:shcUpdateFixture.SubscriptionId `
                -ResourceGroupName $script:shcUpdateFixture.ResourceGroupName `
                -Name $script:shcUpdateFixture.HostPoolName `
                -Location $env.Location `
                -HostPoolType 'Pooled' `
                -LoadBalancerType 'DepthFirst' `
                -Description 'des' `
                -FriendlyName 'fri' `
                -MaxSessionLimit 5 `
                -VMTemplate '{option1}' `
                -CustomRdpProperty $null `
                -Ring $null `
                -ValidationEnvironment:$false `
                -PreferredAppGroupType 'Desktop' `
                -StartVMOnConnect:$false `
                -ManagementType 'Automated' `
                -IdentityType 'SystemAssigned' `
                -ErrorAction Stop
        $script:shcUpdateFixture.Owned = $true

        if (-not $env:AzPSAutorestTestPlaybackMode) {
            $assignment = New-AzRoleAssignment -ObjectId $hostPool.IdentityPrincipalId `
                -RoleDefinitionName "Desktop Virtualization Virtual Machine Contributor" `
                -Scope $env.ResourceGroupArmPath `
                -ErrorAction Stop

            $assignment = New-AzRoleAssignment -ObjectId $hostPool.IdentityPrincipalId `
                -RoleDefinitionName "Key Vault Secrets User" `
                -Scope $env.KeyVaultPersistentArmPath `
                -ErrorAction Stop

            Start-Sleep -Seconds 60
        }

        $seedPrefix = "shcseed"
        if ($seedPrefix -eq $env.SHMSessionHostNamePrefix) {
            $seedPrefix = "shcseedalt"
        }
        $script:shcUpdateFixture.ConfigurationParameters = @{
            SubscriptionId = $script:shcUpdateFixture.SubscriptionId
            ResourceGroupName = $script:shcUpdateFixture.ResourceGroupName
            HostPoolName = $script:shcUpdateFixture.HostPoolName
            DomainInfoJoinType = "AzureActiveDirectory"
            ImageInfoImageType = "Marketplace"
            NetworkInfoSubnetId = $env.VnetSubnetId
            VMAdminCredentialsPasswordKeyvaultSecretUri = $env.VMAdminCredentialsPasswordKeyvaultSecretUri
            VMAdminCredentialsUserNameKeyvaultSecretUri = $env.VMAdminCredentialsUserNameKeyvaultSecretUri
            VMNamePrefix = $seedPrefix
            VMSizeId = "Standard_D2s_v3"
            MarketplaceInfoExactVersion = $env.MarketplaceImageVersion
            MarketplaceInfoOffer = $env.MarketplaceInfoOffer
            MarketplaceInfoPublisher = $env.MarketplaceInfoPublisher
            MarketplaceInfoSku = $env.MarketplaceInfoSku
            SecurityInfoSecureBootEnabled = $true
            SecurityInfoType = "TrustedLaunch"
            SecurityInfoVTpmEnabled = $true
            VmLocation = $env.Location
            VmResourceGroup = $env.ResourceGroup
            VmTag = @{ "cm-resource-parent" = $hostPool.Id }
        }
    }

    It 'UpdateExpanded' {    
        $configurationParameters = $script:shcUpdateFixture.ConfigurationParameters
        $configuration = New-AzWvdSessionHostConfiguration @configurationParameters `
                -ManagedDiskType "Standard_LRS" `
                -ErrorAction Stop

        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $script:shcUpdateFixture.ResourceGroupName `
        -HostPoolName $script:shcUpdateFixture.HostPoolName `
        -VMNamePrefix $env.SHMSessionHostNamePrefix `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion `
        -ErrorAction Stop

        $configuration.VMNamePrefix | Should -Be $env.SHMSessionHostNamePrefix
    }

    It 'UpdateExpanded_EphemeralOSDisk' {
        $configurationParameters = $script:shcUpdateFixture.ConfigurationParameters
        $configuration = New-AzWvdSessionHostConfiguration @configurationParameters `
                -DiffDiskSettingOption "Local" `
                -DiffDiskSettingPlacement "TempDisk" `
                -ErrorAction Stop

        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $script:shcUpdateFixture.ResourceGroupName `
        -HostPoolName $script:shcUpdateFixture.HostPoolName `
        -VMNamePrefix $env.SHMSessionHostNamePrefix `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion `
        -DiffDiskSettingOption "Local" `
        -DiffDiskSettingPlacement "TempDisk" `
        -ErrorAction Stop

        $configuration.DiffDiskSettingOption | Should -Be "Local"
        $configuration.DiffDiskSettingPlacement | Should -Be "TempDisk"
    }

    AfterAll {
        if ($script:shcUpdateFixture -and $script:shcUpdateFixture.Owned) {
            $null = Remove-AzWvdHostPool -SubscriptionId $script:shcUpdateFixture.SubscriptionId `
                    -ResourceGroupName $script:shcUpdateFixture.ResourceGroupName `
                    -Name $script:shcUpdateFixture.HostPoolName `
                    -ErrorAction Stop
            $script:shcUpdateFixture.Owned = $false
        }
    }
}
