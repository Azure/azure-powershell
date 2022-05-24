$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataMigrationSqlService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataMigrationSqlService' {
    It 'CreateExpanded' -skip {
        $instance = New-AzDataMigrationSqlService -Name $env.TestNewSqlMigrationService.SqlMigrationServiceName -ResourceGroupName $env.TestNewSqlMigrationService.GroupName -Location $env.TestNewSqlMigrationService.Location
        $assert = ($instance.Type -eq "Microsoft.DataMigration/sqlMigrationServices")
        $assert | should be $true
    }
}
