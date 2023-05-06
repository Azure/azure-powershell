$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdDesktop.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdDesktop' {
    It 'Get' {
        try{
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
                                -HostPoolArmPath  $env.HostPoolArmPath `
                                -ApplicationGroupType 'Desktop'

            $desktop = Get-AzWvdDesktop -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -ApplicationGroupName $env.DesktopApplicationGroup `
                                -Name 'SessionDesktop'
                $desktop.Name | Should -Be 'ApplicationGroupPowershell1/SessionDesktop'
                $desktop.FriendlyName | Should -Be 'SessionDesktop'
                $desktop.Description | Should -Be 'The default Session Desktop'
        }
        finally{
            $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.DesktopApplicationGroup

            $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.RemoteApplicationGroup
        }
    }

    It 'List' {
        try{
            $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.DesktopApplicationGroup `
                                -Location $env.Location `
                                -FriendlyName 'fri' `
                                -Description 'des' `
                                -HostPoolArmPath  $env.HostPoolArmPath `
                                -ApplicationGroupType 'Desktop'

            $desktops = Get-AzWvdDesktop -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -ApplicationGroupName $env.DesktopApplicationGroup
                $desktops[0].Name | Should -Be 'ApplicationGroupPowershell1/SessionDesktop'
                $desktops[0].FriendlyName | Should -Be 'SessionDesktop'
                $desktops[0].Description | Should -Be 'The default Session Desktop'
        }
        finally{
            $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.DesktopApplicationGroup

            $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.RemoteApplicationGroup

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool
        }
    }
}
