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
                                    -Name $env.RemoteApplicationGroup `
                                    -Location $env.Location `
                                    -FriendlyName 'fri' `
                                    -Description 'des' `
                                    -HostPoolArmPath  $env.HostPoolArmPath `
                                    -ApplicationGroupType 'RemoteApp'
        
        $startMenuItems = Get-AzWvdStartMenuItem -SubscriptionId $env.SubscriptionId `
                                    -ResourceGroupName $env.ResourceGroup `
                                    -ApplicationGroupName $env.RemoteApplicationGroup

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

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.RemoteApplicationGroup

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.HostPool
    }
}
