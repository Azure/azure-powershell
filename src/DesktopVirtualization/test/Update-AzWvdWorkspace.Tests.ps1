$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdWorkspace.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdWorkspace' {
    It 'Update' {
        try{
            $workspace = New-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name 'WorkspacePowershell1' `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'
                $workspace.Name | Should -Be 'WorkspacePowershell1'
                $workspace.Location | Should -Be $env.Location
                $workspace.FriendlyName | Should -Be 'fri'
                $workspace.ApplicationGroupReference | Should -Be $null
                $workspace.Description | Should -Be 'des'

            $workspace = Update-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Name 'WorkspacePowershell1' `
                                            -FriendlyName 'fri2' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des2'
                $workspace.Name | Should -Be 'WorkspacePowershell1'
                $workspace.Location | Should -Be $env.Location
                $workspace.FriendlyName | Should -Be 'fri2'
                $workspace.ApplicationGroupReference | Should -Be $null
                $workspace.Description | Should -Be 'des2'

            $workspace = Get-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                            -ResourceGroupName $env.ResourceGroup `
                                            -Name 'WorkspacePowershell1'
                $workspace.Name | Should -Be 'WorkspacePowershell1'
                $workspace.Location | Should -Be $env.Location
                $workspace.FriendlyName | Should -Be 'fri2'
                $workspace.ApplicationGroupReference | Should -Be $null
                $workspace.Description | Should -Be 'des2'
        }
        finally{
            $workspace = Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                                -ResourceGroupName $env.ResourceGroup `
                                                -Name 'WorkspacePowershell1'
        }
    }
}
