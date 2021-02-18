$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlConnectionString' {
    It 'Get' {
        $connectionString = Get-AzPostgreSqlConnectionString -Client ADO.NET -Name $env.serverName -ResourceGroupName $env.resourceGroup
        $connectionString | Should -Be "Server=$($env.serverName).postgres.database.azure.com;Database={your_database};Port=5432;User Id=postgresql_test@postgresql-test-100;Password={your_password};Ssl Mode=Require;"
    }

    It 'GetViaIdentity' {
        $server = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName

        $PHPConnectionString = Get-AzPostgreSqlConnectionString -Client PHP -InputObject $server
        $PHPExpect = "host=$($env.serverName).postgres.database.azure.com port=5432 dbname={your_database} user=postgresql_test@postgresql-test-100 password={your_password} sslmode=require"
        $PHPConnectionString | Should -Be $PHPExpect

        $JDBCConnectionString = Get-AzPostgreSqlConnectionString -Client JDBC -InputObject $server
        $JDBCExpect = "jdbc:postgresql://$($env.serverName).postgres.database.azure.com:5432/{your_database}?user=postgresql_test@postgresql-test-100&password={your_password}&sslmode=require"
        $JDBCConnectionString | Should -Be $JDBCExpect

        $NodeConnectionString = Get-AzPostgreSqlConnectionString -Client Node.js -InputObject $server
        $NodeExpect = "host=$($env.serverName).postgres.database.azure.com port=5432 dbname={your_database} user=postgresql_test@postgresql-test-100 password={your_password} sslmode=require"
        $NodeConnectionString | Should -Be $NodeExpect

        $PythonConnectionString = Get-AzPostgreSqlConnectionString -Client Python -InputObject $server
        $PythonExpect = "dbname='{your_database}' user='postgresql_test@postgresql-test-100' host='$($env.serverName).postgres.database.azure.com' password='{your_password}' port='5432' sslmode='true'"
        $PythonConnectionString | Should -Be $PythonExpect

        $RubyConnectionString = Get-AzPostgreSqlConnectionString -Client Ruby -InputObject $server
        $RubyExpect = "host=$($env.serverName).postgres.database.azure.com; dbname={your_database} user=postgresql_test@postgresql-test-100 password={your_password} port=5432 sslmode=require"
        $RubyConnectionString | Should -Be $RubyExpect

        $WebConnectionString = Get-AzPostgreSqlConnectionString -Client WebApp -InputObject $server
        $WebExpect = "Database={your_database}; Data Source=$($env.serverName).postgres.database.azure.com; User Id=postgresql_test@postgresql-test-100; Password={your_password}"
        $WebConnectionString | Should -Be $WebExpect

        $WebConnectionString = Get-AzPostgreSqlConnectionString -Client C++ -InputObject $server
        $WebExpect = "host=$($env.serverName).postgres.database.azure.com port=5432 dbname={your_database} user=postgresql_test@postgresql-test-100 password={your_password} sslmode=require"
        $WebConnectionString | Should -Be $WebExpect

        $WebConnectionString = Get-AzPostgreSqlConnectionString -Client psql -InputObject $server
        $WebExpect = "psql ""host=$($env.serverName).postgres.database.azure.com port=5432 dbname={your_database} user=postgresql_test@postgresql-test-100 password={your_password} sslmode=require"""
        $WebConnectionString | Should -Be $WebExpect
    }
}
