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
        try{
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool `
                                -Location $env.Location `
                                -HostPoolType 'Pooled' `
                                -LoadBalancerType 'DepthFirst' `
                                -RegistrationTokenOperation 'Update' `
                                -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                                -Description 'des' `
                                -FriendlyName 'fri' `
                                -MaxSessionLimit 5 `
                                -VMTemplate $null `
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'Desktop' ` `
                                -StartVMOnConnect:$false

            $hostPool = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool
                $hostPool.Name | Should -Be $env.HostPool
                $hostPool.Location | Should -Be $env.Location
                $hostPool.HostPoolType | Should -Be 'Pooled'              
                $hostPool.LoadBalancerType | Should -Be 'DepthFirst'
                $hostPool.RegistrationInfoRegistrationTokenOperation | Should -BeNullOrEmpty
                $hostPool.Description | Should -Be 'des'
                $hostPool.FriendlyName | Should -Be 'fri'
                $hostPool.MaxSessionLimit | Should -Be 5
                $hostPool.VMTemplate | Should -Be $null
                # @todo not corrct since it should be null need to look into it
                # $hostPool.CustomRdpProperty | Should -Be ""
                $hostPool.Ring | Should -Be $null
                # @todo need to check this
                # $hostPool.ValidationEnvironment | Should -Be $false
                $hostPool.PreferredAppGroupType | Should -Be 'Desktop'
                $hostPool.StartVMOnConnect | Should -Be $false
        }
        finally{
            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool
        }
    }

    It 'List' {
        try{
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool `
                                -Location $env.Location `
                                -HostPoolType 'Pooled' `
                                -LoadBalancerType 'DepthFirst' `
                                -RegistrationTokenOperation 'Update' `
                                -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                                -Description 'des' `
                                -FriendlyName 'fri' `
                                -MaxSessionLimit 5 `
                                -VMTemplate $null `
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'Desktop' `
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
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'Desktop' `
                                -StartVMOnConnect:$false

            $hostPools = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                | Where-Object -Property Name -Match 'HostPoolPowershellContained*' `
                                | Sort-Object -Property Name
                $hostPools[0].Name | Should -Be $env.HostPool
                $hostPools[0].Location | Should -Be $env.Location
                $hostPools[0].HostPoolType | Should -Be 'Pooled'              
                $hostPools[0].LoadBalancerType | Should -Be 'DepthFirst'
                $hostPools[0].RegistrationInfoRegistrationTokenOperation | Should -BeNullOrEmpty
                $hostPools[0].Description | Should -Be 'des'
                $hostPools[0].FriendlyName | Should -Be 'fri'
                $hostPools[0].MaxSessionLimit | Should -Be 5
                $hostPools[0].VMTemplate | Should -Be $null
                # @todo not corrct since it should be null need to look into it
                # $hostPools[0].CustomRdpProperty | Should -Be ""
                $hostPools[0].Ring | Should -Be $null
                # @todo need to check this
                # $hostPools[0].ValidationEnvironment | Should -Be $false
                $hostPools[0].PreferredAppGroupType | Should -Be 'Desktop'
                $hostPools[0].StartVMOnConnect | Should -Be $false

                $hostPools[1].Name | Should -Be 'HostPoolPowershellContained2'
                $hostPools[1].Location | Should -Be $env.Location
                $hostPools[1].HostPoolType | Should -Be 'Pooled'              
                $hostPools[1].LoadBalancerType | Should -Be 'DepthFirst'
                $hostPools[1].RegistrationInfoRegistrationTokenOperation | Should -BeNullOrEmpty
                $hostPools[1].Description | Should -Be 'des'
                $hostPools[1].FriendlyName | Should -Be 'fri'
                $hostPools[1].MaxSessionLimit | Should -Be 5
                $hostPools[1].VMTemplate | Should -Be $null
                # @todo not corrct since it should be null need to look into it
                # $hostPools[1].CustomRdpProperty | Should -Be ""
                $hostPools[1].Ring | Should -Be $null
                # @todo need to check this
                # $hostPools[1].ValidationEnvironment | Should -Be $false
                $hostPools[1].PreferredAppGroupType | Should -Be 'Desktop'
                $hostPools[1].StartVMOnConnect | Should -Be $false
        }
        finally{
            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name 'HostPoolPowershellContained2'
        }
    }

    It 'List Subscription Level' {
        try{
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool `
                                -Location $env.Location `
                                -HostPoolType 'Pooled' `
                                -LoadBalancerType 'DepthFirst' `
                                -RegistrationTokenOperation 'Update' `
                                -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                                -Description 'des' `
                                -FriendlyName 'fri' `
                                -MaxSessionLimit 5 `
                                -VMTemplate $null `
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'Desktop' `
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
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'Desktop' `
                                -StartVMOnConnect:$false

            $hostPools = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                | Where-Object -Property Name -Match 'HostPoolPowershellContained*' `
                                | Sort-Object -Property Name
                $hostPools[0].Name | Should -Be $env.HostPool
                $hostPools[0].Location | Should -Be $env.Location
                $hostPools[0].HostPoolType | Should -Be 'Pooled'              
                $hostPools[0].LoadBalancerType | Should -Be 'DepthFirst'
                $hostPools[0].RegistrationInfoRegistrationTokenOperation | Should -BeNullOrEmpty
                $hostPools[0].Description | Should -Be 'des'
                $hostPools[0].FriendlyName | Should -Be 'fri'
                $hostPools[0].MaxSessionLimit | Should -Be 5
                $hostPools[0].VMTemplate | Should -Be $null
                # @todo not corrct since it should be null need to look into it
                # $hostPools[0].CustomRdpProperty | Should -Be ""
                $hostPools[0].Ring | Should -Be $null
                # @todo need to check this
                # $hostPools[0].ValidationEnvironment | Should -Be $false
                $hostPools[0].PreferredAppGroupType | Should -Be 'Desktop'
                $hostPools[0].StartVMOnConnect | Should -Be $false

                $hostPools[1].Name | Should -Be 'HostPoolPowershellContained2'
                $hostPools[1].Location | Should -Be $env.Location
                $hostPools[1].HostPoolType | Should -Be 'Pooled'              
                $hostPools[1].LoadBalancerType | Should -Be 'DepthFirst'
                $hostPools[1].RegistrationInfoRegistrationTokenOperation | Should -BeNullOrEmpty
                $hostPools[1].Description | Should -Be 'des'
                $hostPools[1].FriendlyName | Should -Be 'fri'
                $hostPools[1].MaxSessionLimit | Should -Be 5
                $hostPools[1].VMTemplate | Should -Be $null
                # @todo not corrct since it should be null need to look into it
                # $hostPools[1].CustomRdpProperty | Should -Be ""
                $hostPools[1].Ring | Should -Be $null
                # @todo need to check this
                # $hostPools[1].ValidationEnvironment | Should -Be $false
                $hostPools[1].PreferredAppGroupType | Should -Be 'Desktop'
                $hostPools[1].StartVMOnConnect | Should -Be $false
        }
        finally{
            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                        -ResourceGroupName $env.ResourceGroup `
                        -Name 'HostPoolPowershellContained2'
        }
    }
}
