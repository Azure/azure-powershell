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
    It 'CreateExpanded' {
        try {
            
            $vmTag = @{
                "cm-resource-parent" = "/subscriptions/dbedef25-184c-430f-b383-0eeb87c3205d/resourceGroups/alecbUserSessionTests/providers/Microsoft.DesktopVirtualization/HostPoolPowershellContained1"
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
                -ManagementType 'Automated'

            $configuration = New-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup `
                -HostPoolName $env.HostPool -ManagedDiskType "Standard_LRS" `
                -DomainInfoJoinType "AzureActiveDirectory" -ImageInfoImageType "Marketplace" `
                -NetworkInfoSubnetId "/subscriptions/dbedef25-184c-430f-b383-0eeb87c3205d/resourceGroups/alecbUserSessionTests/providers/Microsoft.Network/virtualNetworks/alecbUserSession-vnet/subnets/default" `
                -VMAdminCredentialsPasswordKeyvaultSecretUri "https://hpuposhkv.vault.azure.net/secrets/LocalAdminPW" `
                -VMAdminCredentialsUserNameKeyvaultSecretUri "https://hpuposhkv.vault.azure.net/secrets/LocalAdminUserName" `
                -VMNamePrefix "createTest" -VMSizeId "Standard_D2s_v3" -MarketplaceInfoExactVersion $env.MarketplaceImageVersion `
                -MarketplaceInfoOffer "office-365" -MarketplaceInfoPublisher "microsoftwindowsdesktop" `
                -MarketplaceInfoSku "win11-23h2-avd-m365" `
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
        finally {
            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool
        }

    }
}