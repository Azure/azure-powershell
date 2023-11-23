$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlFlexibleServerConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlFlexibleServerConnectionString' {
    It 'Get' {
        $connectionString = Get-AzMySqlFlexibleServerConnectionString -Client ADO.NET -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $ADOExpect = 'Server=' + $env.flexibleServerName + '.mysql.database.azure.com; Port=3306; Database={your_database}; UserID=mysql_test; Password={your_password}; '
        $connectionString | Should -Be $ADOExpect
    
        $PHPConnectionString = Get-AzMySqlFlexibleServerConnectionString -Client PHP -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $PHPExpect = '$con=mysqli_init(); mysqli_real_connect($con, "' + $env.flexibleServerName + '.mysql.database.azure.com", "mysql_test", {your_password}, {your_database}, 3306);'
        $PHPConnectionString | Should -Be $PHPExpect

        $JDBCConnectionString = Get-AzMySqlFlexibleServerConnectionString -Client JDBC -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $JDBCExpect = 'String url ="jdbc:mysql://'+ $env.flexibleServerName + '.mysql.database.azure.com:3306/{your_database}"; myDbConn = DriverManager.getConnection(url, "mysql_test", {your_password});'
        $JDBCConnectionString | Should -Be $JDBCExpect

        $NodeConnectionString = Get-AzMySqlFlexibleServerConnectionString -Client Node.js -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $NodeExpect = 'var conn = mysql.createConnection({host: "' + $env.flexibleServerName + '.mysql.database.azure.com", user: "mysql_test", password: {your_password}, database: {your_database}, port: 3306});'
        $NodeConnectionString | Should -Be $NodeExpect

        $PythonConnectionString = Get-AzMySqlFlexibleServerConnectionString -Client Python -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $PythonExpect = 'cnx = mysql.connector.connect(user="mysql_test", password={your_password}, host="' + $env.flexibleServerName +'.mysql.database.azure.com", port=3306, database={your_database})'
        $PythonConnectionString | Should -Be $PythonExpect

        $RubyConnectionString = Get-AzMySqlFlexibleServerConnectionString -Client Ruby -Name $env.flexibleServerName -ResourceGroupName $env.resourceGroup
        $RubyExpect = 'client = Mysql2::Client.new(username: "mysql_test", password: {your_password}, database: {your_database}, host: "' + $env.flexibleServerName + '.mysql.database.azure.com", port: 3306)'
        $RubyConnectionString | Should -Be $RubyExpect
    }
}
