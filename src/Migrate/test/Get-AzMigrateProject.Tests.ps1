$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateProject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateProject' {
    It 'Get' {
        $project = Get-AzMigrateProject -Name $env.migProjectName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $project.Name | Should -Be $env.migProjectName
    }

    It 'GetViaIdentity' -skip {
        $project1 = Get-AzMigrateProject -Name $env.migProjectName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $project2 = Get-AzMigrateProject -InputObject $project1
        $project2.Name | Should -Be $env.migProjectName
    }
}
