$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdApplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzWvdApplication' {
    It 'Create' {
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
            $application.Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $application.FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.FriendlyName | Should -Be 'fri'
            $application.Description | Should -Be 'des'
            $application.IconIndex | Should -Be 0
            $application.IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.CommandLineSetting | Should -Be 'Allow'
            $application.ShowInPortal | Should -Be $true

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

    It 'AppAlias' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
                            -ApplicationGroupType 'RemoteApp'
        
        New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint1' `
                            -AppAlias 'paint' `
                            -CommandLineSetting 'Allow'

        $application = Get-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint1'
            $application.Name | Should -Be 'ApplicationGroupPowershell1/Paint1'
            $application.FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.IconIndex | Should -Be 0
            $application.IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.CommandLineSetting | Should -Be 'Allow'
            $application.ShowInPortal | Should -Be $false

        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint1'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }
}
