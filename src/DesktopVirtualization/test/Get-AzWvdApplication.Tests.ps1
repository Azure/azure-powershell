$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdApplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdApplication' {
    It 'Get' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
                            -ApplicationGroupType 'RemoteApp'
        
        $application = New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint' `
                            -FilePath 'C:\windows\system32\mspaint.exe' `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -IconIndex 0 `
                            -IconPath 'C:\windows\system32\mspaint.exe' `
                            -CommandLineSetting 'Allow' `
                            -ShowInPortal:$true

        $application = Get-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint'
            $application.Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $application.FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.FriendlyName | Should -Be 'fri'
            $application.Description | Should -Be 'des'
            $application.IconIndex | Should -Be 0
            $application.IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.CommandLineSetting | Should -Be 'Allow'
            $application.ShowInPortal | Should -Be $true

        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }

    It 'List' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
                            -ApplicationGroupType 'RemoteApp'
        
        $application = New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint' `
                            -FilePath 'C:\windows\system32\mspaint.exe' `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -IconIndex 0 `
                            -IconPath 'C:\windows\system32\mspaint.exe' `
                            -CommandLineSetting 'Allow' `
                            -ShowInPortal:$true

        $application = New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint2' `
                            -FilePath 'C:\windows\system32\mspaint.exe' `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -IconIndex 0 `
                            -IconPath 'C:\windows\system32\mspaint.exe' `
                            -CommandLineSetting 'Allow' `
                            -ShowInPortal:$true

        $applications = Get-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1'
            $applications[0].Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $applications[0].FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[0].FriendlyName | Should -Be 'fri'
            $applications[0].Description | Should -Be 'des'
            $applications[0].IconIndex | Should -Be 0
            $applications[0].IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[0].CommandLineSetting | Should -Be 'Allow'
            $applications[0].ShowInPortal | Should -Be $true

            $applications[1].Name | Should -Be 'ApplicationGroupPowershell1/Paint2'
            $applications[1].FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[1].FriendlyName | Should -Be 'fri'
            $applications[1].Description | Should -Be 'des'
            $applications[1].IconIndex | Should -Be 0
            $applications[1].IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[1].CommandLineSetting | Should -Be 'Allow'
            $applications[1].ShowInPortal | Should -Be $true

        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint'
        
        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint2'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }
}
