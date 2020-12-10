$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzMigrateProjectTool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Register-AzMigrateProjectTool' {
    It 'RegisterExpanded' {
        $toolName = "ServerMigration"
        $projName = "AzMigratePwshTestProj"
        Register-AzMigrateProjectTool -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId -MigrateProjectName $projName -Tool $toolName
        $project = Get-AzMigrateProject -Name $projName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $project.Property.RegisteredTool | Should -Contain $toolName
    }
}
