$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric' {
    It 'List' -skip {
        $instance = Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestSqlMigrationService.GroupName -SqlMigrationServiceName $env.TestSqlMigrationService.SqlMigrationServiceName
        $instance.Name | should be 'default-ir'
    }
}
