$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDatabricksWorkspace.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDatabricksWorkspace' {
    It 'UpdateExpanded' {
        $res = Update-AzDatabricksWorkspace -Name $env.testWorkspace1 -ResourceGroupName $env.resourceGroup -Tag @{mark="home"}
        $res.Tag.Count | Should -Be 1
    }

    It 'UpdateViaIdentityExpanded' {
        $workspace = Get-AzDatabricksWorkspace -Name $env.testWorkspace2 -ResourceGroupName $env.resourceGroup
        $res = Update-AzDatabricksWorkspace -InputObject $workspace -Tag @{mark="home";owner="Charlie";purpose="job"}
        $res.Tag.Count | Should -Be 3
    }
}
