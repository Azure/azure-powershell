$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdHostPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzWvdHostPool' {
    It 'FullSenerioCreate' {
        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1' `
                            -Location $env.Location `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -PreferredAppGroupType 'Desktop' `
                            -DesktopAppGroupName 'FullSenerioCreateAG' `
                            -WorkspaceName 'FullSenerioCreateWS'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'FullSenerioCreateAG'

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'

        $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'FullSenerioCreateWS'
    }

    It 'Create' {
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
                            -VMTemplate '{option1}' `
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

            $hostPool.Name | Should -Be 'HostPoolPowershellContained1'
            $hostPool.Location | Should -Be $env.Location
            $hostPool.HostPoolType | Should -Be 'Pooled'              
            $hostPool.LoadBalancerType | Should -Be 'DepthFirst'
            $hostPool.RegistrationInfoRegistrationTokenOperation | Should -Be 'Update'
            $hostPool.Description | Should -Be 'des'
            $hostPool.FriendlyName | Should -Be 'fri'
            $hostPool.MaxSessionLimit | Should -Be 5
            $hostPool.VMTemplate | Should -Be '{option1}'
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
            $hostPool.VMTemplate | Should -Be '{option1}'
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
}
