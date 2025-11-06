if (($null -eq $TestName) -or ($TestName -contains 'New-AzWvdSessionHostConfiguration')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdSessionHostConfiguration.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWvdSessionHostConfiguration' {
    BeforeAll{
        $vmTag = @{
            "cm-resource-parent" = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/" + $env.HostPool
        }

        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool `
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
                -IdentityType 'SystemAssigned'

        # Run this only in the -record mode, as the -playback will not import Az.Resources. 
        if (-not $env:AzPSAutorestTestPlaybackMode) {

            # Assign 'Desktop Virtualization Virtual Machine Contributor' role for this hostpool on the Resource Group level
            $assignment = New-AzRoleAssignment -ObjectId $hostPool.IdentityPrincipalId `
                -RoleDefinitionName "Desktop Virtualization Virtual Machine Contributor" `
                -Scope $env.ResourceGroupArmPath

            # Assign 'Key Vault Secrets User' role for this hostpool on the Resource Group level
            $assignment = New-AzRoleAssignment -ObjectId $hostPool.IdentityPrincipalId `
                -RoleDefinitionName "Key Vault Secrets User" `
                -Scope $env.KeyVaultPersistentArmPath
            
            # Wait for 1 minute to execute the SHC command
            Start-Sleep -Seconds 60
        }
    }


    It 'CreateExpanded' {
        $configuration = New-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup `
                -HostPoolName $env.HostPool -ManagedDiskType "Standard_LRS" `
                -DomainInfoJoinType "AzureActiveDirectory" -ImageInfoImageType "Marketplace" `
                -NetworkInfoSubnetId $env.VnetSubnetId `
                -VMAdminCredentialsPasswordKeyvaultSecretUri $env.VMAdminCredentialsPasswordKeyvaultSecretUri `
                -VMAdminCredentialsUserNameKeyvaultSecretUri $env.VMAdminCredentialsUserNameKeyvaultSecretUri `
                -VMNamePrefix "createTest" -VMSizeId "Standard_D2s_v3" -MarketplaceInfoExactVersion $env.MarketplaceImageVersion `
                -MarketplaceInfoOffer $env.MarketplaceInfoOffer -MarketplaceInfoPublisher $env.MarketplaceInfoPublisher `
                -MarketplaceInfoSku $env.MarketplaceInfoSku `
                -SecurityInfoSecureBootEnabled `
                -SecurityInfoType "TrustedLaunch" `
                -SecurityInfoVTpmEnabled `
                -VmLocation $env.Location `
                -VmResourceGroup $env.ResourceGroup `
                -VmTag $vmTag

        $configuration = Get-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -HostPoolName $env.HostPool
        $configuration.VMNamePrefix | Should -Be "createTest"
    }

    AfterAll{
        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool
    }
}