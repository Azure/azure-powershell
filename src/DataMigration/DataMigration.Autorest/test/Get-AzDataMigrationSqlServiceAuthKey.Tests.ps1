$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataMigrationSqlServiceAuthKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataMigrationSqlServiceAuthKey' {
    It 'List' -skip  {
        $instance = Get-AzDataMigrationSqlServiceAuthKey -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestSqlMigrationService.GroupName -SqlMigrationServiceName $env.TestSqlMigrationService.SqlMigrationServiceName
        $assert = ($instance.psobject.properties.name[0] -eq 'AuthKey1') -AND ($instance.psobject.properties.name[1] -eq 'AuthKey2')
        $assert | Should be $true
    }
}
