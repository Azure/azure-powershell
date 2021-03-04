$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdHostPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdHostPool' {
    It 'Get' {
        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1' `
                            -Location $env.Location `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'des' `
                            -FriendlyName 'fri' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoContext $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -PreferredAppGroupType 'Desktop' `
                            -SsoClientId 'https://domain/name' `
                            -SsoClientSecretKeyVaultPath 'https://domain/certificates/cert' `
                            -SsoadfsAuthority 'https://msft.sts.microsoft.com/adfs' `
                            -SsoSecretType 'SharedKeyInKeyVault' `
                            -StartVMOnConnect:$false

        $hostPool = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'
            $hostPool.Name | Should -Be 'HostPoolPowershellContained1'
            $hostPool.Location | Should -Be $env.Location
            $hostPool.HostPoolType | Should -Be 'Pooled'              
            $hostPool.LoadBalancerType | Should -Be 'DepthFirst'
            $hostPool.RegistrationInfoRegistrationTokenOperation | Should -Be 'None'
            $hostPool.Description | Should -Be 'des'
            $hostPool.FriendlyName | Should -Be 'fri'
            $hostPool.MaxSessionLimit | Should -Be 5
            $hostPool.VMTemplate | Should -Be $null
            $hostPool.SsoContext | Should -Be $null
            # @todo not corrct since it should be null need to look into it
            # $hostPool.CustomRdpProperty | Should -Be ""
            $hostPool.Ring | Should -Be $null
            # @todo need to check this
            # $hostPool.ValidationEnvironment | Should -Be $false
            $hostPool.PreferredAppGroupType | Should -Be 'Desktop'
            $hostPool.SsoClientId | Should -Be 'https://domain/name'
            $hostPool.SsoClientSecretKeyVaultPath | Should -Be 'https://domain/certificates/cert'
            $hostPool.SsoadfsAuthority | Should -Be 'https://msft.sts.microsoft.com/adfs'
            $hostPool.SsoSecretType | Should -Be 'SharedKeyInKeyVault'
            $hostPool.StartVMOnConnect | Should -Be $false

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'
    }

    It 'List' {
        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1' `
                            -Location $env.Location `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'des' `
                            -FriendlyName 'fri' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoContext $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -PreferredAppGroupType 'Desktop' `
                            -SsoClientId 'https://domain/name' `
                            -SsoClientSecretKeyVaultPath 'https://domain/certificates/cert' `
                            -SsoadfsAuthority 'https://msft.sts.microsoft.com/adfs' `
                            -SsoSecretType 'SharedKeyInKeyVault' `
                            -StartVMOnConnect:$false

        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained2' `
                            -Location $env.Location `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'des' `
                            -FriendlyName 'fri' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoContext $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -PreferredAppGroupType 'Desktop' `
                            -SsoClientId 'https://domain/name' `
                            -SsoClientSecretKeyVaultPath 'https://domain/certificates/cert' `
                            -SsoadfsAuthority 'https://msft.sts.microsoft.com/adfs' `
                            -SsoSecretType 'SharedKeyInKeyVault' `
                            -StartVMOnConnect:$false

        $hostPools = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            | Where-Object -Property Name -Match 'HostPoolPowershellContained*' `
                            | Sort-Object -Property Name
            $hostPools[0].Name | Should -Be 'HostPoolPowershellContained1'
            $hostPools[0].Location | Should -Be $env.Location
            $hostPools[0].HostPoolType | Should -Be 'Pooled'              
            $hostPools[0].LoadBalancerType | Should -Be 'DepthFirst'
            $hostPools[0].RegistrationInfoRegistrationTokenOperation | Should -Be 'None'
            $hostPools[0].Description | Should -Be 'des'
            $hostPools[0].FriendlyName | Should -Be 'fri'
            $hostPools[0].MaxSessionLimit | Should -Be 5
            $hostPools[0].VMTemplate | Should -Be $null
            $hostPools[0].SsoContext | Should -Be $null
            # @todo not corrct since it should be null need to look into it
            # $hostPools[0].CustomRdpProperty | Should -Be ""
            $hostPools[0].Ring | Should -Be $null
            # @todo need to check this
            # $hostPools[0].ValidationEnvironment | Should -Be $false
            $hostPools[0].PreferredAppGroupType | Should -Be 'Desktop'
            $hostPools[0].SsoClientId | Should -Be 'https://domain/name'
            $hostPools[0].SsoClientSecretKeyVaultPath | Should -Be 'https://domain/certificates/cert'
            $hostPools[0].SsoadfsAuthority | Should -Be 'https://msft.sts.microsoft.com/adfs'
            $hostPools[0].SsoSecretType | Should -Be 'SharedKeyInKeyVault'
            $hostPools[0].StartVMOnConnect | Should -Be $false

            $hostPools[1].Name | Should -Be 'HostPoolPowershellContained2'
            $hostPools[1].Location | Should -Be $env.Location
            $hostPools[1].HostPoolType | Should -Be 'Pooled'              
            $hostPools[1].LoadBalancerType | Should -Be 'DepthFirst'
            $hostPools[1].RegistrationInfoRegistrationTokenOperation | Should -Be 'None'
            $hostPools[1].Description | Should -Be 'des'
            $hostPools[1].FriendlyName | Should -Be 'fri'
            $hostPools[1].MaxSessionLimit | Should -Be 5
            $hostPools[1].VMTemplate | Should -Be $null
            $hostPools[1].SsoContext | Should -Be $null
            # @todo not corrct since it should be null need to look into it
            # $hostPools[1].CustomRdpProperty | Should -Be ""
            $hostPools[1].Ring | Should -Be $null
            # @todo need to check this
            # $hostPools[1].ValidationEnvironment | Should -Be $false
            $hostPools[1].PreferredAppGroupType | Should -Be 'Desktop'
            $hostPools[1].SsoClientId | Should -Be 'https://domain/name'
            $hostPools[1].SsoClientSecretKeyVaultPath | Should -Be 'https://domain/certificates/cert'
            $hostPools[1].SsoadfsAuthority | Should -Be 'https://msft.sts.microsoft.com/adfs'
            $hostPools[1].SsoSecretType | Should -Be 'SharedKeyInKeyVault'
            $hostPools[1].StartVMOnConnect | Should -Be $false

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained2'
    }

    It 'List Subscription Level' {
        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1' `
                            -Location $env.Location `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'des' `
                            -FriendlyName 'fri' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoContext $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -PreferredAppGroupType 'Desktop' `
                            -SsoClientId 'https://domain/name' `
                            -SsoClientSecretKeyVaultPath 'https://domain/certificates/cert' `
                            -SsoadfsAuthority 'https://msft.sts.microsoft.com/adfs' `
                            -SsoSecretType 'SharedKeyInKeyVault' `
                            -StartVMOnConnect:$false

        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained2' `
                            -Location $env.Location `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'des' `
                            -FriendlyName 'fri' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoContext $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -PreferredAppGroupType 'Desktop' `
                            -SsoClientId 'https://domain/name' `
                            -SsoClientSecretKeyVaultPath 'https://domain/certificates/cert' `
                            -SsoadfsAuthority 'https://msft.sts.microsoft.com/adfs' `
                            -SsoSecretType 'SharedKeyInKeyVault' `
                            -StartVMOnConnect:$false

        $hostPools = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            | Where-Object -Property Name -Match 'HostPoolPowershellContained*' `
                            | Sort-Object -Property Name
            $hostPools[0].Name | Should -Be 'HostPoolPowershellContained1'
            $hostPools[0].Location | Should -Be $env.Location
            $hostPools[0].HostPoolType | Should -Be 'Pooled'              
            $hostPools[0].LoadBalancerType | Should -Be 'DepthFirst'
            $hostPools[0].RegistrationInfoRegistrationTokenOperation | Should -Be 'None'
            $hostPools[0].Description | Should -Be 'des'
            $hostPools[0].FriendlyName | Should -Be 'fri'
            $hostPools[0].MaxSessionLimit | Should -Be 5
            $hostPools[0].VMTemplate | Should -Be $null
            $hostPools[0].SsoContext | Should -Be $null
            # @todo not corrct since it should be null need to look into it
            # $hostPools[0].CustomRdpProperty | Should -Be ""
            $hostPools[0].Ring | Should -Be $null
            # @todo need to check this
            # $hostPools[0].ValidationEnvironment | Should -Be $false
            $hostPools[0].PreferredAppGroupType | Should -Be 'Desktop'
            $hostPools[0].SsoClientId | Should -Be 'https://domain/name'
            $hostPools[0].SsoClientSecretKeyVaultPath | Should -Be 'https://domain/certificates/cert'
            $hostPools[0].SsoadfsAuthority | Should -Be 'https://msft.sts.microsoft.com/adfs'
            $hostPools[0].SsoSecretType | Should -Be 'SharedKeyInKeyVault'
            $hostPools[0].StartVMOnConnect | Should -Be $false

            $hostPools[1].Name | Should -Be 'HostPoolPowershellContained2'
            $hostPools[1].Location | Should -Be $env.Location
            $hostPools[1].HostPoolType | Should -Be 'Pooled'              
            $hostPools[1].LoadBalancerType | Should -Be 'DepthFirst'
            $hostPools[1].RegistrationInfoRegistrationTokenOperation | Should -Be 'None'
            $hostPools[1].Description | Should -Be 'des'
            $hostPools[1].FriendlyName | Should -Be 'fri'
            $hostPools[1].MaxSessionLimit | Should -Be 5
            $hostPools[1].VMTemplate | Should -Be $null
            $hostPools[1].SsoContext | Should -Be $null
            # @todo not corrct since it should be null need to look into it
            # $hostPools[1].CustomRdpProperty | Should -Be ""
            $hostPools[1].Ring | Should -Be $null
            # @todo need to check this
            # $hostPools[1].ValidationEnvironment | Should -Be $false
            $hostPools[1].PreferredAppGroupType | Should -Be 'Desktop'
            $hostPools[1].SsoClientId | Should -Be 'https://domain/name'
            $hostPools[1].SsoClientSecretKeyVaultPath | Should -Be 'https://domain/certificates/cert'
            $hostPools[1].SsoadfsAuthority | Should -Be 'https://msft.sts.microsoft.com/adfs'
            $hostPools[1].SsoSecretType | Should -Be 'SharedKeyInKeyVault'
            $hostPools[1].StartVMOnConnect | Should -Be $false

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup `
                    -Name 'HostPoolPowershellContained2'
    }
}
