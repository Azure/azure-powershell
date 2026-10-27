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
        $hostPoolName = $env.HostPool + '-desktop-get'
        $applicationGroupName = $env.DesktopApplicationGroup + '-desktop-get'
        $hostPool = $null
        $applicationGroup = $null
        try{
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $hostPoolName `
                -Location $env.Location `
                -HostPoolType 'Pooled' `
                -LoadBalancerType 'DepthFirst' `
                -PreferredAppGroupType 'Desktop' `
                -ManagementType 'Standard' -ErrorAction Stop

            $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $applicationGroupName `
                                -Location $env.Location `
                                -FriendlyName 'fri' `
                                -Description 'des' `
                                -HostPoolArmPath $hostPool.Id `
                                -ApplicationGroupType 'Desktop' -ErrorAction Stop

            $desktop = Get-AzWvdDesktop -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -ApplicationGroupName $applicationGroupName `
                                -Name 'SessionDesktop'
                $desktop.Name | Should -Be ($applicationGroupName + '/SessionDesktop')
                $desktop.FriendlyName | Should -Be 'SessionDesktop'
                $desktop.Description | Should -Be 'The default Session Desktop'
        }
        finally{
            if ($null -ne $applicationGroup) {
                $null = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup `
                    -Name $applicationGroupName -ErrorAction Stop
            }

            if ($null -ne $hostPool) {
                Wait-TestHostPoolApplicationGroupRemoval -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup -HostPoolName $hostPoolName

                $null = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup `
                    -Name $hostPoolName -ErrorAction Stop
            }
        }
    }

    It 'List' {
        $hostPoolName = $env.HostPool + '-desktop-list'
        $applicationGroupName = $env.DesktopApplicationGroup + '-desktop-list'
        $hostPool = $null
        $applicationGroup = $null
        try{
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $hostPoolName `
                -Location $env.Location `
                -HostPoolType 'Pooled' `
                -LoadBalancerType 'DepthFirst' `
                -PreferredAppGroupType 'Desktop' `
                -ManagementType 'Standard' -ErrorAction Stop

            $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $applicationGroupName `
                                -Location $env.Location `
                                -FriendlyName 'fri' `
                                -Description 'des' `
                                -HostPoolArmPath $hostPool.Id `
                                -ApplicationGroupType 'Desktop' -ErrorAction Stop

            $desktops = @(Get-AzWvdDesktop -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -ApplicationGroupName $applicationGroupName)
                $desktops.Count | Should -Be 1
                $desktops[0].Name | Should -Be ($applicationGroupName + '/SessionDesktop')
                $desktops[0].FriendlyName | Should -Be 'SessionDesktop'
                $desktops[0].Description | Should -Be 'The default Session Desktop'
        }
        finally{
            if ($null -ne $applicationGroup) {
                $null = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup `
                    -Name $applicationGroupName -ErrorAction Stop
            }

            if ($null -ne $hostPool) {
                Wait-TestHostPoolApplicationGroupRemoval -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup -HostPoolName $hostPoolName

                $null = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup `
                    -Name $hostPoolName -ErrorAction Stop
            }
        }
    }
}
