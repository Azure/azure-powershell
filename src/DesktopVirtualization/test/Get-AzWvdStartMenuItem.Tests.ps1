$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdStartMenuItem.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdStartMenuItem' {
    It 'List' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                    -ResourceGroupName $env.ResourceGroup `
                                    -Name 'ApplicationGroupPowershell1' `
                                    -Location $env.Location `
                                    -FriendlyName 'fri' `
                                    -Description 'des' `
                                    -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
                                    -ApplicationGroupType 'RemoteApp'
        
        $startMenuItems = Get-AzWvdStartMenuItem -SubscriptionId $env.SubscriptionId `
                                    -ResourceGroupName $env.ResourceGroup `
                                    -ApplicationGroupName 'ApplicationGroupPowershell1'

        $paint = $startMenuItems | Where-Object -Property Name -Match 'Paint'
            $paint[0].Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $paint[0].FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $paint[0].IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $paint[0].IconIndex | Should -Be 0
        
        $paint = $startMenuItems | Where-Object -Property Name -Match 'Snip'
            $paint[0].Name | Should -Be 'ApplicationGroupPowershell1/Snipping Tool'
            $paint[0].FilePath | Should -Be 'C:\windows\system32\SnippingTool.exe'
            $paint[0].IconPath | Should -Be 'C:\windows\system32\SnippingTool.exe'
            $paint[0].IconIndex | Should -Be 0
    }
}
