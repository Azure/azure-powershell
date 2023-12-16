$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzMySqlFlexibleServerDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzMySqlFlexibleServerDatabase' {
    It 'List' {
        { 
            $database = Get-AzMySqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $database.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ViaName' {
        {
            $database = New-AzMySqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Charset latin1
            $database.Name | Should -Be $env.databaseName
            $database.Collation | Should -Be "latin1_swedish_ci"
            $database.Charset | Should -Be "latin1"

            $database = Get-AzMySqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $database.Collation | Should -Be "latin1_swedish_ci"
            $database.Charset | Should -Be "latin1"
            
            Remove-AzMySqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)/databases/$($env.databaseName)"
            $database = New-AzMySqlFlexibleServerDatabase -InputObject $ID -Charset latin1
            $database.Name | Should -Be $env.databaseName
            $database.Collation | Should -Be "latin1_swedish_ci"
            $database.Charset | Should -Be "latin1"

            $database = Get-AzMySqlFlexibleServerDatabase -InputObject $database
            $database.Collation | Should -Be "latin1_swedish_ci"
            $database.Charset | Should -Be "latin1"
            
            Remove-AzMySqlFlexibleServerDatabase -InputObject $database

        } | Should -Not -Throw
    }
}