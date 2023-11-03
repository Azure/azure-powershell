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
        try{
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool `
                                -Location $env.Location `
                                -HostPoolType 'Pooled' `
                                -LoadBalancerType 'DepthFirst' `
                                -PreferredAppGroupType 'Desktop' `
                                -DesktopAppGroupName 'FullSenerioCreateAG' `
                                -WorkspaceName 'FullSenerioCreateWS'
        }
        finally{
            $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name 'FullSenerioCreateAG'

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool

            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name 'FullSenerioCreateWS'
        }
    }

    It 'Create' {
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
                                -PreferredAppGroupType 'Desktop' `
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
                $hostPool.PreferredAppGroupType | Should -Be 'Desktop'
                $hostPool.StartVMOnConnect | Should -Be $false

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
                $hostPool.VMTemplate | Should -Be '{option1}'
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
