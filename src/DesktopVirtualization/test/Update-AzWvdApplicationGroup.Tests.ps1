$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdApplicationGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdApplicationGroup' {
    It 'Update' {
        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1' `
                            -Location $env.Location `
                            -HostPoolType 'Shared' `
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
                            -PreferredAppGroupType 'Desktop'
        
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershellContained1' `
                            -ApplicationGroupType 'RemoteApp'
            $applicationGroup.Name | Should -Be 'ApplicationGroupPowershell1'
            $applicationGroup.Location | Should -Be $env.Location
            $applicationGroup.FriendlyName | Should -Be 'fri'
            $applicationGroup.Description | Should -Be 'des'
            $applicationGroup.HostPoolArmPath | Should -Be '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershellContained1'
            $applicationGroup.ApplicationGroupType | Should -Be 'RemoteApp'

        $applicationGroup = Update-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -FriendlyName 'fri' `
                            -Description 'des'
            $applicationGroup.Name | Should -Be 'ApplicationGroupPowershell1'
            $applicationGroup.Location | Should -Be $env.Location
            $applicationGroup.FriendlyName | Should -Be 'fri'
            $applicationGroup.Description | Should -Be 'des'
            $applicationGroup.HostPoolArmPath | Should -Be '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershellContained1'
            $applicationGroup.ApplicationGroupType | Should -Be 'RemoteApp'

        $applicationGroup = Get-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
            $applicationGroup.Name | Should -Be 'ApplicationGroupPowershell1'
            $applicationGroup.Location | Should -Be $env.Location
            $applicationGroup.FriendlyName | Should -Be 'fri'
            $applicationGroup.Description | Should -Be 'des'
            $applicationGroup.HostPoolArmPath | Should -Be '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershellContained1'
            $applicationGroup.ApplicationGroupType | Should -Be 'RemoteApp'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'

        $hostPool = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'
    }
}
