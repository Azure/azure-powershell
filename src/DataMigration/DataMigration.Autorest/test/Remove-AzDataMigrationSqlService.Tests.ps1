$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataMigrationSqlService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDataMigrationSqlService' {
    It 'Delete' -skip {
        $count1 = (Get-AzDataMigrationSqlService  -ResourceGroupName $env.TestNewSqlMigrationService.GroupName).count
        Remove-AzDataMigrationSqlService -Name $env.TestNewSqlMigrationService.SqlMigrationServiceName -ResourceGroupName $env.TestNewSqlMigrationService.GroupName
        $count2 = (Get-AzDataMigrationSqlService  -ResourceGroupName $env.TestNewSqlMigrationService.GroupName).count
        $assert = ($count1-$count2 -eq 1)
        $assert | should be $true
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
