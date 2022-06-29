$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataMigrationSqlService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataMigrationSqlService' {
    It 'List1' -skip {
        $instance = Get-AzDataMigrationSqlService -SubscriptionId $env.SubscriptionId  
        $assert = $instance.Count -gt 0
        $assert | Should be $true
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' -skip {
        $instance = Get-AzDataMigrationSqlServic -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestSqlMigrationService.GroupName 
        $assert = $instance.Count -gt 0
        $assert | Should be $true
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
