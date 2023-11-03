$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Unregister-AzWvdApplicationGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Unregister-AzWvdApplicationGroup' {
    It 'Unregister ApplicationGroup' {
        try{
            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell1' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

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

            Register-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -WorkspaceName 'WorkspacePowershell1' `
                                            -ApplicationGroupPath $env.DesktopApplicationGroupPath

            $workspace = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Name 'WorkspacePowershell1'
            $workspace.ApplicationGroupReference[0] | Should -Be $env.DesktopApplicationGroupPath

            Unregister-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -WorkspaceName 'WorkspacePowershell1' `
                                            -ApplicationGroupPath $env.DesktopApplicationGroupPath
    
            $workspace = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Name 'WorkspacePowershell1'
            $workspace.ApplicationGroupReference.length | Should -Be 0
        }
        finally{
            $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.DesktopApplicationGroup

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.HostPool

            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell1'
        }
    }
}
