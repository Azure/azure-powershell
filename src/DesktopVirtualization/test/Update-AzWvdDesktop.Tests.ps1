$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdDesktop.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdDesktop' {

    It 'Update' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
                            -ApplicationGroupType 'Desktop'
        
        $desktop = Update-AzWvdDesktop -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -ApplicationGroupName 'ApplicationGroupPowershell1' `
                            -Name 'SessionDesktop' `
                            -FriendlyName 'Fri2' `
                            -Description 'Des2'
            $desktop.Name | Should -Be 'ApplicationGroupPowershell1/SessionDesktop'
            $desktop.FriendlyName | Should -Be 'Fri2'
            $desktop.Description | Should -Be 'Des2'

        $desktop = Get-AzWvdDesktop -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -ApplicationGroupName 'ApplicationGroupPowershell1' `
                            -Name 'SessionDesktop'
            $desktop.Name | Should -Be 'ApplicationGroupPowershell1/SessionDesktop'
            $desktop.FriendlyName | Should -Be 'Fri2'
            $desktop.Description | Should -Be 'Des2'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }
}
