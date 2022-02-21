$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDatabricksWorkspace.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDatabricksWorkspace' {
    It 'List1' {
        $workspaces = Get-AzDatabricksWorkspace
        $workspaces.Count | Should -BeGreaterOrEqual 3
    }

    It 'Get' {
        $workspace = Get-AzDatabricksWorkspace -Name $env.testWorkspace1 -ResourceGroupName $env.resourceGroup
        $workspace.Name | Should -Be $env.testWorkspace1
    }

    It 'List' {
        $workspaces = Get-AzDatabricksWorkspace -ResourceGroupName $env.resourceGroup
        $workspaces.Count | Should -Be 3
    }

    It 'GetViaIdentity' {
        $workspacePipein = (Get-AzDatabricksWorkspace -Name $env.testWorkspace2 -ResourceGroupName $env.resourceGroup)
        $workspace = Get-AzDatabricksWorkspace -InputObject $workspacePipein
        $workspace.Name | Should -Be $env.testWorkspace2
    }
}
