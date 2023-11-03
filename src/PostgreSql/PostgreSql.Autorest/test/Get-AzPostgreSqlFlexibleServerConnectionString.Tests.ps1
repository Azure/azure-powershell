$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlFlexibleServerConnectionString' {
    It 'Get' {
        $connectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client ADO.NET -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $connectionString | Should -Be "Server=$($env.flexibleServerName).postgres.database.azure.com;Database={your_database};Port=5432;User Id=adminuser;Password={your_password};"
    
        $PHPConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client PHP -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $PHPExpect = "host=$($env.flexibleServerName).postgres.database.azure.com port=5432 dbname={your_database} user=adminuser password={your_password}"
        $PHPConnectionString | Should -Be $PHPExpect

        $JDBCConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client JDBC -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $JDBCExpect = "jdbc:postgresql://$($env.flexibleServerName).postgres.database.azure.com:5432/{your_database}?user=adminuser&password={your_password}&"
        $JDBCConnectionString | Should -Be $JDBCExpect

        $NodeConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client Node.js -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $NodeExpect = "host=$($env.flexibleServerName).postgres.database.azure.com port=5432 dbname={your_database} user=adminuser password={your_password}"
        $NodeConnectionString | Should -Be $NodeExpect

        $PythonConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client Python -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $PythonExpect = "dbname='{your_database}' user='adminuser' host='$($env.flexibleServerName).postgres.database.azure.com' password='{your_password}' port='5432'"
        $PythonConnectionString | Should -Be $PythonExpect

        $RubyConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client Ruby -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $RubyExpect = "host=$($env.flexibleServerName).postgres.database.azure.com; dbname={your_database} user=adminuser password={your_password} port=5432"
        $RubyConnectionString | Should -Be $RubyExpect

        $WebConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client C++ -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $WebExpect = "host=$($env.flexibleServerName).postgres.database.azure.com port=5432 dbname={your_database} user=adminuser password={your_password}"
        $WebConnectionString | Should -Be $WebExpect

        $WebConnectionString = Get-AzPostgreSqlFlexibleServerConnectionString -Client psql -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $WebExpect = "psql ""host=$($env.flexibleServerName).postgres.database.azure.com port=5432 dbname={your_database} user=adminuser password={your_password}"""
        $WebConnectionString | Should -Be $WebExpect
    }
}
