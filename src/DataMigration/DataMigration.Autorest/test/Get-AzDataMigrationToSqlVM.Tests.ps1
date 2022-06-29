$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataMigrationToSqlVM.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataMigrationToSqlVM' {
    It 'Get' -skip  {
        $instance = Get-AzDataMigrationToSqlVM -SqlVirtualMachineName $env.TestDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestDatabaseMigrationVm.TargetDbName
        $assert = ($instance.Name -eq $env.TestDatabaseMigrationVm.TargetDbName) -AND ($instance.Kind -eq 'SqlVm')
        $assert | Should be $true
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
