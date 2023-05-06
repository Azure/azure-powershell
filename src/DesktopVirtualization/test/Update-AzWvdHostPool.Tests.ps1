$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdHostPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdHostPool' {
    It 'Update' {
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
                                -VMTemplate '{option1}' `
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'RailApplications' `
                                -StartVMOnConnect:$false
                $hostPool.Name | Should -Be $env.HostPool
                $hostPool.Location | Should -Be $env.Location
                $hostPool.HostPoolType | Should -Be 'Pooled'              
                $hostPool.LoadBalancerType | Should -Be 'DepthFirst'
                $hostPool.RegistrationInfoRegistrationTokenOperation | Should -Be 'Update'
                $hostPool.Description | Should -Be 'des'
                $hostPool.FriendlyName | Should -Be 'fri'
                $hostPool.MaxSessionLimit | Should -Be 5
                $hostPool.VMTemplate | Should -Be '{option1}'
                # @todo not corrct since it should be null need to look into it
                # $hostPool.CustomRdpProperty | Should -Be ""
                $hostPool.Ring | Should -Be $null
                # @todo need to check this
                # $hostPool.ValidationEnvironment | Should -Be $false
                $hostPool.PreferredAppGroupType | Should -Be 'RailApplications'
                $hostPool.StartVMOnConnect | Should -Be $false

            $hostPool = Update-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool `
                                -LoadBalancerType 'BreadthFirst' `
                                -Description 'des2' `
                                -FriendlyName 'fri2' `
                                -MaxSessionLimit 6 `
                                -VMTemplate '{option2}' `
                                -CustomRdpProperty $null `
                                -Ring $null `
                                -ValidationEnvironment:$false `
                                -PreferredAppGroupType 'Desktop' `
                                -StartVMOnConnect:$false
                $hostPool.Name | Should -Be $env.HostPool
                $hostPool.Location | Should -Be $env.Location
                $hostPool.HostPoolType | Should -Be 'Pooled'              
                $hostPool.LoadBalancerType | Should -Be 'BreadthFirst'
                $hostPool.Description | Should -Be 'des2'
                $hostPool.FriendlyName | Should -Be 'fri2'
                $hostPool.MaxSessionLimit | Should -Be 6
                $hostPool.VMTemplate | Should -Be '{option2}'
                # @todo not corrct since it should be null need to look into it
                # $hostPool.CustomRdpProperty | Should -Be ""
                $hostPool.Ring | Should -Be $null
                # @todo need to check this
                # $hostPool.ValidationEnvironment | Should -Be $false3
                $hostPool.PreferredAppGroupType | Should -Be 'Desktop'
                $hostPool.StartVMOnConnect | Should -Be $false

            $hostPool = Get-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool
                $hostPool.Name | Should -Be $env.HostPool
                $hostPool.Location | Should -Be $env.Location
                $hostPool.HostPoolType | Should -Be 'Pooled'              
                $hostPool.LoadBalancerType | Should -Be 'BreadthFirst'
                $hostPool.Description | Should -Be 'des2'
                $hostPool.FriendlyName | Should -Be 'fri2'
                $hostPool.MaxSessionLimit | Should -Be 6
                $hostPool.VMTemplate | Should -Be '{option2}'
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
}
