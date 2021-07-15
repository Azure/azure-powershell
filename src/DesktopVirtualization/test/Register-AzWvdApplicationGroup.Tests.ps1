$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzWvdApplicationGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Register-AzWvdApplicationGroup' {
    It 'Register ApplicationGroup' {
        $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                        -ResourceGroupName $env.ResourceGroup `
                                        -Location $env.Location `
                                        -Name 'WorkspacePowershell1' `
                                        -FriendlyName 'fri' `
                                        -ApplicationGroupReference $null `
                                        -Description 'des'

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

        Register-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                        -ResourceGroupName $env.ResourceGroup `
                                        -WorkspaceName 'WorkspacePowershell1' `
                                        -ApplicationGroupPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourceGroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/applicationGroups/ApplicationGroupPowershell1'
        
        $workspace = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                        -ResourceGroupName $env.ResourceGroup `
                                        -Name 'WorkspacePowershell1'
            $workspace.ApplicationGroupReference[0] | Should -Be '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourceGroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/applicationGroups/ApplicationGroupPowershell1'
        
        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'

        $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'HostPoolPowershellContained1'
        
        $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Name 'WorkspacePowershell1'
    }
}
