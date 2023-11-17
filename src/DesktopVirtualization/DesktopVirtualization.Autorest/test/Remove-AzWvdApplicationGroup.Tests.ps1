$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdApplicationGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWvdApplicationGroup' {
    It 'Delete' {
        $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.HostPool `
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
                            -Name $env.DesktopApplicationGroup `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath $env.HostPoolArmPath `
                            -ApplicationGroupType 'Desktop'

        $applicationGroup = Get-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.DesktopApplicationGroup
            $applicationGroup.Name | Should -Be $env.DesktopApplicationGroup
            $applicationGroup.Location | Should -Be $env.Location
            $applicationGroup.FriendlyName | Should -Be 'fri'
            $applicationGroup.Description | Should -Be 'des'
            $applicationGroup.HostPoolArmPath | Should -Be $env.HostPoolArmPath
            $applicationGroup.ApplicationGroupType | Should -Be 'Desktop'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.DesktopApplicationGroup

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.RemoteApplicationGroup
        
        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.RemoteApplicationGroup

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.HostPool

        try {
            $workspace = Get-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                        -ResourceGroupName $env.ResourceGroup `
                                        -Name $env.DesktopApplicationGroup
            throw "Get should have failed."
        } catch {

        }
    }
}
