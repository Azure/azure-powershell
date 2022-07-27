$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataMigrationSqlServiceAuthKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataMigrationSqlServiceAuthKey' {
    It 'RegenerateExpanded'  -skip {
        $oldAuthKeys = Get-AzDataMigrationSqlServiceAuthKey -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestAuthKey.GroupName -SqlMigrationServiceName $env.TestAuthKey.SqlMigrationServiceName
        New-AzDataMigrationSqlServiceAuthKey -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestAuthKey.GroupName -SqlMigrationServiceName $env.TestAuthKey.SqlMigrationServiceName -KeyName AuthKey1
        New-AzDataMigrationSqlServiceAuthKey -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestAuthKey.GroupName -SqlMigrationServiceName $env.TestAuthKey.SqlMigrationServiceName -KeyName AuthKey2
        $newAuthKeys = Get-AzDataMigrationSqlServiceAuthKey -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestAuthKey.GroupName -SqlMigrationServiceName $env.TestAuthKey.SqlMigrationServiceName
        $value = ($newAuthKeys.AuthKey1 -ne $oldAuthKeys.AuthKey1) -AND ($newAuthKeys.AuthKey2 -ne $oldAuthKeys.AuthKey2)
        $value | should be $true
    }
}
