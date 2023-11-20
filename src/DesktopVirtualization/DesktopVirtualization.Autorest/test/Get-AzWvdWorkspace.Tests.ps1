$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdWorkspace.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdWorkspace' {
    It 'Get' {
        try{
            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell1' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $workspace = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Name 'WorkspacePowershell1'
                $workspace.Name | Should -Be 'WorkspacePowershell1'
                $workspace.Location | Should -Be $env.Location
                $workspace.FriendlyName | Should -Be 'fri'
                $workspace.ApplicationGroupReference | Should -Be $null
                $workspace.Description | Should -Be 'des'
        }
        finally{
            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell1'
        }
    }

    It 'List' {
        try{
            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell1' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell2' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $workspaces = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            | Where-Object -Property Name -Match 'WorkspacePowershell*' `
                                            | Sort-Object -Property Name

                $workspaces[0].Name | Should -Be 'WorkspacePowershell1'
                $workspaces[0].Location | Should -Be $env.Location
                $workspaces[0].FriendlyName | Should -Be 'fri'
                $workspaces[0].ApplicationGroupReference | Should -Be $null
                $workspaces[0].Description | Should -Be 'des'

                $workspaces[1].Name | Should -Be 'WorkspacePowershell2'
                $workspaces[1].Location | Should -Be $env.Location
                $workspaces[1].FriendlyName | Should -Be 'fri'
                $workspaces[1].ApplicationGroupReference | Should -Be $null
                $workspaces[1].Description | Should -Be 'des'
        }
        finally{
            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell1'

            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell2'
        }
    }

    It 'List Subscription Level' {
        try{
            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell1' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell2' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $workspaces = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            | Where-Object -Property Name -Match 'WorkspacePowershell*' `
                                            | Sort-Object -Property Name

                $workspaces[0].Name | Should -Be 'WorkspacePowershell1'
                $workspaces[0].Location | Should -Be $env.Location
                $workspaces[0].FriendlyName | Should -Be 'fri'
                $workspaces[0].ApplicationGroupReference | Should -Be $null
                $workspaces[0].Description | Should -Be 'des'

                $workspaces[1].Name | Should -Be 'WorkspacePowershell2'
                $workspaces[1].Location | Should -Be $env.Location
                $workspaces[1].FriendlyName | Should -Be 'fri'
                $workspaces[1].ApplicationGroupReference | Should -Be $null
                $workspaces[1].Description | Should -Be 'des'
        }
        finally{
            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell1'

            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell2'
        }
    }
}
