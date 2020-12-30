$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlFlexibleServerDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlFlexibleServerDatabase' {
    It 'List' {
        { 
            New-AzMySqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Charset latin1
            $database = Get-AzMySqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $database.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $database = Get-AzMySqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $database.Collation | Should -Be "latin1_swedish_ci"
            $database.Charset | Should -Be "latin1"
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)/databases/$($env.databaseName)"
            $database = Get-AzMySqlFlexibleServerDatabase -InputObject $ID
            $database.Collation | Should -Be "latin1_swedish_ci"
            $database.Charset | Should -Be "latin1"
            Remove-AzMySqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        } | Should -Not -Throw
    }
}
