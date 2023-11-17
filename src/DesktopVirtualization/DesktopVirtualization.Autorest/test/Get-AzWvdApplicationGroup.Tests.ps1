$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdApplicationGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdApplicationGroup' {
    It 'Get' {
        try {
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
                               -Name "HostPool"
        }
    }

    It 'List' {
        try {
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

            $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.RemoteApplicationGroup  `
                                -Location $env.Location `
                                -FriendlyName 'fri' `
                                -Description 'des' `
                                -HostPoolArmPath $env.HostPoolArmPath `
                                -ApplicationGroupType 'RemoteApp'

            $applicationGroups = Get-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                | Where-Object -Property Name -Match 'ApplicationGroupPowershell*' `
                                | Sort-Object -Property Name

                $applicationGroups[0].Name | Should -Be $env.DesktopApplicationGroup
                $applicationGroups[0].Location | Should -Be $env.Location
                $applicationGroups[0].FriendlyName | Should -Be 'fri'
                $applicationGroups[0].Description | Should -Be 'des'
                $applicationGroups[0].HostPoolArmPath | Should -Be $env.HostPoolArmPath
                $applicationGroups[0].ApplicationGroupType | Should -Be 'Desktop'

                $applicationGroups[1].Name | Should -Be $env.RemoteApplicationGroup 
                $applicationGroups[1].Location | Should -Be $env.Location
                $applicationGroups[1].FriendlyName | Should -Be 'fri'
                $applicationGroups[1].Description | Should -Be 'des'
                $applicationGroups[1].HostPoolArmPath | Should -Be $env.HostPoolArmPath
                $applicationGroups[1].ApplicationGroupType | Should -Be 'RemoteApp'
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

    It 'List Subscription Level' {
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
                                -HostPoolArmPath $env.HostPoolArmPath `
                                -ApplicationGroupType 'Desktop'

            $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -Name $env.RemoteApplicationGroup  `
                                -Location $env.Location `
                                -FriendlyName 'fri' `
                                -Description 'des' `
                                -HostPoolArmPath $env.HostPoolArmPath `
                                -ApplicationGroupType 'RemoteApp'

            $applicationGroups = Get-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                                | Where-Object -Property Name -Match 'ApplicationGroupPowershell*' `
                                | Sort-Object -Property Name

                $applicationGroups[0].Name | Should -Be $env.DesktopApplicationGroup
                $applicationGroups[0].Location | Should -Be $env.Location
                $applicationGroups[0].FriendlyName | Should -Be 'fri'
                $applicationGroups[0].Description | Should -Be 'des'
                $applicationGroups[0].HostPoolArmPath | Should -Be $env.HostPoolArmPath
                $applicationGroups[0].ApplicationGroupType | Should -Be 'Desktop'

                $applicationGroups[1].Name | Should -Be $env.RemoteApplicationGroup 
                $applicationGroups[1].Location | Should -Be $env.Location
                $applicationGroups[1].FriendlyName | Should -Be 'fri'
                $applicationGroups[1].Description | Should -Be 'des'
                $applicationGroups[1].HostPoolArmPath | Should -Be $env.HostPoolArmPath
                $applicationGroups[1].ApplicationGroupType | Should -Be 'RemoteApp'
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
